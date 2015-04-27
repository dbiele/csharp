using System;
using System.Collections;
// using System.Data;
// using System.Data.SqlClient;
using System.Web.UI;
// using System.Web.Configuration;
using System.Web.UI.WebControls;

using System.IO;
using System.Text;
using inVisionLearning;

public partial class catalog : System.Web.UI.Page
{
    UserInfo ivlUser = null;
    Categories alCategories = null;
    Courses alCourses = null;

    protected override void OnInit(EventArgs e)
    {
        BuildPage();
        base.OnInit(e);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void BuildPage()
    {
        if (Session["UserInfo"] != null)
        {
            ivlUser = (UserInfo)Session["UserInfo"];
        }
        else
        {
            Response.Redirect("~\\Login.aspx");
        }

        if (Session["Categories"] == null || Session["Courses"] == null)
        {
            alCategories = new Categories();
            alCourses = new Courses();
            Session["Categories"] = alCategories;
            Session["Courses"] = alCourses;

        }
        else
        {
            alCategories = (Categories)Session["Categories"];
            alCourses = (Courses)Session["Courses"];
        }
        AddTopLevelCat();
    }

    protected void AddTopLevelCat()
    {
        foreach (Category Cat in alCategories.GetChildCat(0))
        {
            string strCatID = Cat.ID.ToString();
            LinkButton lbTemp = new LinkButton();
            lbTemp.ID = "lbnCat" + strCatID;
            lbTemp.Text = Cat.name;
            lbTemp.Command += new CommandEventHandler(OnCatClick);
            lbTemp.CommandName = "EnableCoursePanel";
            lbTemp.CommandArgument = "pnlCat" + strCatID;
            pnlCategory.Controls.Add(lbTemp);

            Panel pnlTemp = new Panel();
            pnlTemp.ID = "pnlCat" + strCatID;
            pnlTemp.Visible = false;

            getCourses(Cat.ID, strCatID, pnlTemp);
            GetSubCat(Cat.ID, strCatID, pnlTemp);
            pnlCourse.Controls.Add(pnlTemp);
        }
    }

    protected void GetSubCat(int ParentCatId, string strCatId, Panel p)
    {
        foreach (Category category in alCategories.GetChildCat(ParentCatId))
        {
            if (alCourses.GetCoursesByCat(category.ID).Count > 0)
            {
                string strCategoryId = category.ID.ToString();
                Image imgTwiddler = new Image();
                imgTwiddler.ID = "Twid" + strCategoryId;
                imgTwiddler.Height = 10;
                imgTwiddler.Width = 11;
                imgTwiddler.ImageAlign = ImageAlign.Right;
                imgTwiddler.ImageUrl = "~/images/icon_category_open.png";
                imgTwiddler.ToolTip = "Expand Category";
                imgTwiddler.AlternateText = "Expand Category";
                
                LinkButton lbnCategory = new LinkButton();
                lbnCategory.ID = "lbnCat" + strCategoryId;
                lbnCategory.Command += new CommandEventHandler(ExpCourses);

                lbnCategory.CommandName = "CloseSesame";
                lbnCategory.CommandArgument = strCategoryId;

                StringBuilder sbTemp = new StringBuilder();
                StringWriter swTemp = new StringWriter(sbTemp);
                HtmlTextWriter htwControl = new HtmlTextWriter(swTemp);
                imgTwiddler.RenderControl(htwControl);
                lbnCategory.Text = "<h6>" + sbTemp.ToString() + category.name + "</h6>";
                
                if (p.FindControl(lbnCategory.ID) == null)
                {
                    p.Controls.Add(lbnCategory);
                    // find courses
                    getCourses(category.ID, strCategoryId, p);
                    // find sub categories
                    GetSubCat(category.ID, strCategoryId, p);

                }

            }
        }
    }

    protected void getCourses(int ParentCatId, string CatID, Panel p)
    {
        Panel pnlCourses = new Panel();
        pnlCourses.ID = "pnl" + CatID;

        foreach (Course Cou in alCourses.GetCoursesByCat(ParentCatId))
        {
            bool bAddCourse = true;
            if (Cou.type == 2 && !ivlUser.Ext_UserType.Equals("INTERNAL"))
            {
                bAddCourse = false;
            }
            if (bAddCourse)
            {
                string strCourseId = Cou.ID.ToString();
                string strCouCatID = Cou.category.ToString();
                LinkButton lbCourse = new LinkButton();
                lbCourse.ID = "lbnCou" + strCouCatID + strCourseId;
                lbCourse.Text = Cou.name;
                lbCourse.Command += new CommandEventHandler(OnCouClick);
                lbCourse.CommandName = "EnableDetailPanel";
                lbCourse.CommandArgument = strCourseId;
                Label lblLength = new Label();
                lblLength.ID = "lblLen" + strCouCatID + strCourseId;
                lblLength.CssClass = "length";
                lblLength.Text = Cou.length;
                Label lblPreReq = new Label();
                lblPreReq.ID = "lblPR" + strCouCatID + strCourseId;
                lblPreReq.CssClass = "prereq";
                lblPreReq.Text = Cou.prereqTitle;
                ImageButton imgAddtoCart = new ImageButton();
                imgAddtoCart.ID = "imgAddtoCart" + strCouCatID + strCourseId;
                imgAddtoCart.CssClass = "";


                // build Catalog line...
                pnlCourses.Controls.Add(new LiteralControl("<p class='course'>"));
                pnlCourses.Controls.Add(lbCourse);
                pnlCourses.Controls.Add(new LiteralControl("</p>"));
                pnlCourses.Controls.Add(lblLength);
                pnlCourses.Controls.Add(lblPreReq);
                pnlCourse.Controls.Add(imgAddtoCart);
                pnlCourses.Controls.Add(new LiteralControl("<br style='clear:both;'/>"));
            }
        }
        p.Controls.Add(pnlCourses);
    }
    protected void getDetails(Course course, Panel pnlItem)
    {
        lblName.Text = "<h3>" + course.name + "</h3>";
        lblShort.Text = "<p>" + course.shortdesc + "</p>";
        lblLength.Text = course.length;
        lblLong.Text = course.longdesc;

        if (course.prereqID > 0)
        {
            pnlPreReq.Visible = true;
            // add courses to prereq panel
            pnlPreReq.Controls.Add(new LiteralControl("<div id='prerequisites'><h3>"));
            Image imgPreReq = new Image();
            imgPreReq.ID = "imgPreReq";
            imgPreReq.ImageUrl = "~\\images\\icon_prerequisite.gif";
            imgPreReq.Height = 20;
            imgPreReq.Width = 20;
            imgPreReq.ToolTip = "Prerequisites Required";
            imgPreReq.AlternateText = "Prerequisites Required";
            pnlPreReq.Controls.Add(imgPreReq);
            pnlPreReq.Controls.Add(new LiteralControl("Prerequisites Required</h3><p>"));

            Stack stkPreReq = alCourses.GetPreReqDepends(course.ID);
            int i = 0;
            foreach (string strDepends in stkPreReq)
            {
                i += 1;
                Label lblTemp = new Label();
                lblTemp.ID = "lblDep" + i.ToString();
                lblTemp.Text = strDepends;
                pnlPreReq.Controls.Add(lblTemp);
            }
            pnlPreReq.Controls.Add(new LiteralControl("</p><h5>&nbsp;</h5></div>"));
        }
        else
        {
            if (course.preview.ToUpper().Contains("MISSING"))
            {
                pnlPreReq.Visible = true;
                ibPreview.Visible = false;

                // add courses to prereq panel
                pnlPreReq.Controls.Add(new LiteralControl("<div id='prerequisites'><h3>"));
                Image imgPreReq = new Image();
                imgPreReq.ID = "imgPreReq";
                imgPreReq.ImageUrl = "~\\images\\icon_urgent.png";
                imgPreReq.Height = 20;
                imgPreReq.Width = 20;
                imgPreReq.ToolTip = "Missing Preview Launch File";
                imgPreReq.AlternateText = "Missing Preview Launch File";
                pnlPreReq.Controls.Add(imgPreReq);
                pnlPreReq.Controls.Add(new LiteralControl("Missing Preview Launch File</h3><p>"));
                
                Label lblTemp = new Label();
                lblTemp.ID = "lblDep" + course.ID.ToString();
                lblTemp.Text = "The Preview Launch file data is missing from the course data.<br/>Please contact Support, Thank you.";
                pnlPreReq.Controls.Add(lblTemp);
                pnlPreReq.Controls.Add(new LiteralControl("</p> <h5>&nbsp;</h5></div>"));
                
            }
        }
    }

    void OnCatClick(object sender, CommandEventArgs e)
    {
        foreach (Control Ctrl in pnlCategory.Controls)
        {
            if (Ctrl is LinkButton)
            {
                ((LinkButton)Ctrl).CssClass = "";
            }
        }
        LinkButton lbSelected = (LinkButton)sender;
        lbSelected.CssClass = "active";
        if (ViewState["ActCouPnl"] != null)
        {
            string strActivePnl = ViewState["ActCouPnl"].ToString();
            Panel pnlOld = (Panel)pnlCourse.FindControl(strActivePnl);
            pnlOld.Visible = false;
        }
        Panel pnlChild = (Panel)pnlCourse.FindControl(e.CommandArgument.ToString());
        pnlChild.Visible = true;

        ViewState["ActCouPnl"] = e.CommandArgument.ToString();

        pnlStart.Visible = false;
        pnlCourse.Visible = true;
        pnlDetails.Visible = false;

    }
    void OnCouClick(object sender, CommandEventArgs e)
    {
        pnlStart.Visible = false;
        pnlCourse.Visible = false;
        pnlDetails.Visible = true;

        getDetails(alCourses.GetCourseById(Convert.ToInt32(e.CommandArgument)), pnlDetails);
    }
    void ExpCourses(object sender, CommandEventArgs e)
    {
        LinkButton lbTemp = (LinkButton)sender;
        Panel pnlTemp = (Panel)lbTemp.Parent.FindControl("pnl" + e.CommandArgument.ToString());
        switch(e.CommandName.ToString())
        {
            case "OpenSesame":
                lbTemp.Text = lbTemp.Text.Replace("icon_category_closed.png","icon_category_open.png");
                lbTemp.Text = lbTemp.Text.Replace("Expand Category","Collapse Category");
                lbTemp.CommandName = "CloseSesame";
                pnlTemp.Visible=true;
                break;
            case "CloseSesame":
                lbTemp.Text = lbTemp.Text.Replace("icon_category_open.png","icon_category_closed.png");
                lbTemp.Text = lbTemp.Text.Replace("Collapse Category","Expand Category");
                lbTemp.CommandName = "OpenSesame";
                pnlTemp.Visible=false;
                break;
        }
        
    }

    protected void ReturnToList(object sender, CommandEventArgs e)
    {
        pnlDetails.Visible = false;
        pnlCourse.Visible = true;

    }
    protected void PreviewCourse(object sender, CommandEventArgs e)
    {

    }
}
