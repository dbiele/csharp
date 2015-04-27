using System;
using System.Collections;
// using System.Data;
// using System.Data.SqlClient;
using System.Web.UI;
// using System.Web.Configuration;
using System.Web.UI.WebControls;

using System.Text;
using System.IO;
using inVisionLearning;

public partial class my_courses : System.Web.UI.Page
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
        Label lblTemp = (Label)pnlCourse.FindControl("lblTop");
        //Label lblMid = (Label)pnlCourse.FindControl("lblMid");

        if (IsPostBack)
        {
            lblTemp.Text="<h4>Type</h4><h4>Title</h4><h4>Status</h4><br />";
            //lblTemp.ForeColor = System.Drawing.Color.Empty;
            //lblMid.Text = "";
            //lblMid.ForeColor = System.Drawing.Color.Empty;
        }
        else
        {
            lblTemp.Text = "<p>Welcome to your personalized My Courses page!</p><br><span class='info_text'>Please select a product from the left to view your courses.</span>";
            //lblMid.Text= "Please select a product from the left to view your courses.";
            //lblTemp.ForeColor = System.Drawing.Color.Green;
        }

    }
    protected void BuildPage()
    {
        //UserInfo ivlUser = null;
        if (Session["UserInfo"] != null)
        {
            ivlUser = (UserInfo)Session["UserInfo"];
        }
        else
        {
            Response.Redirect("~\\Login.aspx");
        }

        if (Session["MyCategories"] == null || Session["MyCourses"] == null)
        {
            alCategories = new Categories();
            alCourses = new Courses(ivlUser.UID, ivlUser.DefaultGroups);
            alCategories.Filter(alCourses);
            Session["MyCategories"] = alCategories;
            Session["MyCourses"] = alCourses;

        }
        else
        {
            alCategories = (Categories)Session["MyCategories"];
            alCourses = (Courses)Session["MyCourses"];
            
            if (Session["CRS_REFRESH"] != null)
            {
                int iCid = Convert.ToInt32(Session["CRS_REFRESH"]);
                string strOldStatus = alCourses.GetCourseById(iCid).UsrStat;
                alCourses.RefreshCourseData(ivlUser.UID, iCid, ivlUser.DefaultGroups);
                string strNewStatus = alCourses.GetCourseById(iCid).UsrStat;
                if (!strOldStatus.Equals(strNewStatus))
                {
                    Session["MyCourses"] = alCourses;
                    if (!strOldStatus.Equals("Not Started"))
                    {
                        Session.Remove("CRS_REFRESH");
                    }
                }
            } 
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
            lbTemp.Text = RenderCatImageStr(Cat)+" "+Cat.name;
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

    protected void GetSubCat(int ParentID, string strCatId, Panel p)
    {
        string strWorkingPnl = "pnlCat" + strCatId;
        string strCreateLbl = string.Empty;
        foreach (Category category in alCategories.GetChildCat(ParentID))
        {
            if (alCourses.GetCoursesByCat(category.ID).Count > 0)
            {
                strCreateLbl = "lblCat" + category.ID.ToString();

                Label lblTemp = new Label();
                lblTemp.ID = strCreateLbl;
                lblTemp.Text = category.name;
                lblTemp.CssClass = "info_bold";
                p.Controls.Add(lblTemp);
                if (p.FindControl(strCreateLbl) == null)
                {
                    // find courses
                    getCourses(category.ID, strCatId, p);
                    // find sub categories
                    GetSubCat(category.ID, strCatId, p);

                }
            }
        }
    }

    protected void getCourses(int iParentCatId, string CatID, Panel p)
    {
        string strWorkingPnl = "pnlCat" + CatID;
        string strCreatePnl = string.Empty;

        foreach (Course Cou in alCourses.GetCoursesByCat(iParentCatId))
        {
           bool bAddCourse = true;
            if (Cou.type == 2 && !ivlUser.Ext_UserType.Equals("INTERNAL"))
            {
                bAddCourse = false;
            }
            if (bAddCourse)
            {
                string strCourseId = Cou.ID.ToString();
                string strCatID = Cou.category.ToString();
                strCreatePnl = "pnlCou" + strCourseId;
                LinkButton lbCourse = new LinkButton();
                lbCourse.ID = "lbnCou" + strCatID + strCourseId;
                lbCourse.CssClass = "";
                lbCourse.Text = RenderImageStr(Cou) + Cou.name;
                lbCourse.Command += new CommandEventHandler(OnCouClick);
                lbCourse.CommandName = "EnableDetailPanel";
                lbCourse.CommandArgument = strCourseId;
                p.Controls.Add(lbCourse);
            }
        }
    }

    protected void getDetails(Course course, Panel pnlItem)
    {   
        lblCourseName.Text = "<h3>" + course.name + "</h3>";
        lblShortDesc.Text = "<p>" + course.shortdesc + "</p>";
        
        if (course.bCOFL)
        {
            string strURL = course.launch.Replace('\\','/');
            ibLaunchCourse.OnClientClick = "window.open('" + strURL + "', '', '" + course.WinOpt + "').focus();";
        }
        else
        {
            ibLaunchCourse.OnClientClick = "window.open('/scorm/frameset.aspx?CID=" + course.ID + "', '', '" + course.WinOpt + "').focus();";
        }
        ibLaunchCourse.CommandArgument = course.ID.ToString();

        if (course.CheckPreReq(ivlUser.UID))
        {
            //not available yet
            tblCourseLaunch.Visible = false;
            pnlPreReq.Visible = true;
            // add courses to prereq panel
            pnlPreReq.Controls.Add(new LiteralControl("<div id='prerequisites'><h6>"));
            Image imgPreReq = new Image();
            imgPreReq.ID = "imgPreReq";
            imgPreReq.ImageUrl = course.UsrStatImg;
            imgPreReq.Height = 15;
            imgPreReq.Width = 15;
            imgPreReq.ToolTip = course.UsrStat;
            imgPreReq.AlternateText = course.UsrStat;
            pnlPreReq.Controls.Add(imgPreReq);
            pnlPreReq.Controls.Add(new LiteralControl(course.UsrStat + "</h6><p>"));

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
            pnlPreReq.Controls.Add(new LiteralControl("</p> <h5>&nbsp;</h5></div>"));
        }
        else
        {
            if (course.launch.ToUpper().Contains("MISSING"))
            {
                tblCourseLaunch.Visible = false;
                pnlPreReq.Visible = true;
                pnlPreReq.Controls.Add(new LiteralControl("<div id='prerequisites'><h3>"));
                Image imgPreReq = new Image();
                imgPreReq.ID = "imgPreReq";
                imgPreReq.ImageUrl = "~\\images\\icon_urgent.gif";
                imgPreReq.Height = 15;
                imgPreReq.Width = 15;
                imgPreReq.ToolTip = "Launch File Missing";
                imgPreReq.AlternateText = "Launch File Missing";
                pnlPreReq.Controls.Add(imgPreReq);
                pnlPreReq.Controls.Add(new LiteralControl("Launch File Missing </h3><p>"));
                
                Label lblTemp = new Label();
                lblTemp.ID = "lblDep" + course.ID.ToString();
                lblTemp.Text = "The Course Launch file data is missing from the course data.<br/>Please contact Support, Thank you.";
                pnlPreReq.Controls.Add(lblTemp);
                pnlPreReq.Controls.Add(new LiteralControl("</p> <h5>&nbsp;</h5></div>"));
            }
            else
            {
                tblCourseLaunch.Visible = true;
                pnlPreReq.Visible = false;
                imgStatus.ImageUrl = course.UsrStatImg;
                imgStatus.AlternateText = "Status: Course " + course.UsrStat;
                imgStatus.ToolTip = "Status: Course " + course.UsrStat;
                lblStatus.Text = course.UsrStat;
                if (course.completed.ToString("MM/dd/yyyy").Equals("01/01/1900"))
                {
                    lblStatusStats.Text = String.Empty;
                }
                else
                {
                    lblStatusStats.Text = course.completed.ToString("M/d/yy");
                }
                imgScore.ImageUrl = course.UsrStatImg;
                imgScore.AlternateText = "Score: " + course.UsrStat;
                imgScore.ToolTip = "Score: " + course.UsrStat;

                switch (course.UsrStat)
                {
                    case "Completed": //Completed
                        lblScore.ForeColor = System.Drawing.Color.Green;
                        lblScoreStats.ForeColor = System.Drawing.Color.Green;
                        break;
                    case "Failed":  //failed
                        lblScore.ForeColor = System.Drawing.Color.Red;
                        lblScoreStats.ForeColor = System.Drawing.Color.Red;
                        break;
                    default:
                        lblScore.ForeColor = System.Drawing.Color.Empty;
                        lblScoreStats.ForeColor = System.Drawing.Color.Empty;
                        break;
                }
                lblScore.Text = course.UsrStat;
                lblScoreStats.Text = course.score;

                if (course.UserVer.CompareTo(course.LatestVer) == 0)
                {
                    trUpdate.Visible = false;
                }
                else
                {
                    trUpdate.Visible = true;
                }

                ibLaunchCourse.CommandArgument = course.ID.ToString();
            }
        }

        lblLongDesc.Text = "<p>" + course.longdesc + "</p>";

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
        foreach (Control Ctrl in pnlChild.Controls)
        {
            if (Ctrl is LinkButton)
            {
                ((LinkButton)Ctrl).CssClass = "";
            }

        }
        pnlDetails.Visible = false;
        ViewState["ActCouPnl"] = e.CommandArgument.ToString();
 
    }

    void OnCouClick(object sender, CommandEventArgs e)
    {
        LinkButton lbSelected = (LinkButton)sender;
        Course couTemp = alCourses.GetCourseById(Convert.ToInt32(e.CommandArgument));
        if (!couTemp.UsrStat.Equals(lblStatus.Text))
        {
            lbSelected.Text = RenderImageStr(couTemp)+couTemp.name;
        }
        
        foreach (Control Ctrl in lbSelected.Parent.Controls)
        {
            if (Ctrl is LinkButton)
            {
                ((LinkButton)Ctrl).CssClass = "";
            }
        }
        
        lbSelected.CssClass="active";
        getDetails(couTemp, pnlDetails);
        pnlDetails.Visible = true;
    }

    protected void Launch_Course(object sender, CommandEventArgs e)
    {
        int iCID = Convert.ToInt32(e.CommandArgument);

        //cofl complete course data on first launch
        Course crsLaunched = alCourses.GetCourseById(iCID);
        if (crsLaunched.bCOFL && !crsLaunched.UsrStat.Equals("Completed"))
        {
            crsLaunched.CompleteOnLaunch(ivlUser.UID);
        }

        Session["CRS_REFRESH"] = iCID.ToString();
        Response.Redirect("~/scorm/buffer.aspx");
        
        
    }

    protected string RenderImageStr(Course couImage)
    {
        Image imgCourseStatus = new Image();
        imgCourseStatus.ID = imgCourseStatus + couImage.ID.ToString();
        imgCourseStatus.Height = 15;
        imgCourseStatus.Width = 15;
        imgCourseStatus.ImageUrl = couImage.UsrStatImg;
        imgCourseStatus.ToolTip = "Status: Course " + couImage.UsrStat;

        StringBuilder sbTemp = new StringBuilder();
        StringWriter swTemp = new StringWriter(sbTemp);
        HtmlTextWriter htwControl = new HtmlTextWriter(swTemp);
        imgCourseStatus.RenderControl(htwControl);
        
        return sbTemp.ToString();
    }

    protected string RenderCatImageStr(Category catImage)
    {
        Image imgCourseStatus = new Image();
        imgCourseStatus.ID = imgCourseStatus + catImage.ID.ToString();
        imgCourseStatus.Height = 26;
        imgCourseStatus.Width = 26;
        imgCourseStatus.ImageUrl = catImage.MediumIcon;
        imgCourseStatus.ImageAlign = ImageAlign.Middle;
        imgCourseStatus.Style["background-color"] = "none";
        //imgCourseStatus.ToolTip = "Status: Course " + couImage.UsrStat;
        StringBuilder sbTemp = new StringBuilder();
        StringWriter swTemp = new StringWriter(sbTemp);
        HtmlTextWriter htwControl = new HtmlTextWriter(swTemp);
        imgCourseStatus.RenderControl(htwControl);

        return sbTemp.ToString();
    }
}
