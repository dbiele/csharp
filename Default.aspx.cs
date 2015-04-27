using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.Configuration;
using System.Web.UI.WebControls;

using System.Xml;
using inVisionLearning;
using System.IO;
using System.Text;
public partial class _Default : System.Web.UI.Page
{
    UserInfo ivlUser = null;
    Categories alCategories = null;
    Courses alCourses = null;
    double _shoppingcartTotal;
    string CouID = string.Empty;

    protected void imgbtnGoToMyCourses_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            Response.Redirect("~/my_courses.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

   

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                if ((Request.QueryString["alert_code"] != null))
                {
                    switch (Convert.ToInt32(Request.QueryString["alert_code"]))
                    {
                        case 1:
                            Response.Write("<script>alert('Your account has been successfully created.');</script>");
                            break;
                        case 2:
                            Response.Write("<script>alert('Your account has been successfully updated.');</script>");
                            break;
                    }
                }
                //if ((Request.QueryString["acronym"] != null))
                if ((Request.QueryString["acronym"] != null) && (Request.QueryString["categoryid"] != null))
                {
                    if (bizShopping.checkCourseAcronym(Request.QueryString["acronym"]) != "" && bizShopping.checkCategory(Convert.ToInt32(Request.QueryString["categoryid"])) != null)
                    {
                        CouID = bizShopping.getCourseID(Request.QueryString["acronym"]);
                        //course_info(bizShopping.getCourseCode(Request.QueryString["acronym"]));
                        if (!string.IsNullOrEmpty(CouID))
                        {
                            course_info(CouID);
                        }
                    }
                }
                else if ((Request.QueryString["cat"] != null))
                {
                    this.panelWelcome.Visible = false;
                    this.panelCourses.Visible = true;
                    this.panelCourseDetails.Visible = false;
                    LoadCourseByCat(Request.QueryString["cat"]);
                }
                bindShoppingCart();
                detectFlash();
            }
            BuildPage();
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }


    #region Portal1 code
    private void bindShoppingCart()
    {
        try
        {
            this.gwShoppingCart.DataSourceID = null;
            if (Session["ShoppingCart"] == null)
            {
                this.gwShoppingCart.DataSource = null;
            }
            else
            {
                if (((DataTable)Session["ShoppingCart"]).Rows.Count > 0)
                {
                    this.gwShoppingCart.DataSource = (DataTable)Session["ShoppingCart"];
                }
                else
                {
                    this.gwShoppingCart.DataSource = null;
                }
            }
            this.gwShoppingCart.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void detectFlash()
    {
        try
        {
            this.ltrlFlashDetect.Text = "<script language=\"JavaScript\" type=\"text/javascript\">\n ";
            this.ltrlFlashDetect.Text += "<!-- \n";
            this.ltrlFlashDetect.Text += "var hasReqestedVersion = DetectFlashVer(requiredMajorVersion, requiredMinorVersion, requiredRevision);\n ";
            this.ltrlFlashDetect.Text += "if (hasReqestedVersion) { \n";
            this.ltrlFlashDetect.Text += "    document.write('<img src=\"images/icon_flash_ok.gif\" />'); \n";
            this.ltrlFlashDetect.Text += "} else { \n";
            this.ltrlFlashDetect.Text += "    document.write('<img src=\"images/icon_flash_no.gif\" />'); \n";
            this.ltrlFlashDetect.Text += "} \n";
            this.ltrlFlashDetect.Text += "// -->\n ";
            this.ltrlFlashDetect.Text += "</script> \n";
            this.ltrlFlashDetect.Text += "<noscript> \n";
            this.ltrlFlashDetect.Text += "<img src=\"images/icon_flash_no.gif\" /> \n";
            this.ltrlFlashDetect.Text += "</noscript> \n";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void bindCourses(int industry, int course_type)
    {
        try
        {
            if (course_type == 1)
            {
                this.gwShopping.DataSourceID = null;
                this.gwShopping.DataSource = bizShopping.getCourses(industry, course_type);
                this.gwShopping.DataBind();
            }
            else if (course_type == 2)
            {
                this.gwPrepShopping.DataSourceID = null;
                this.gwPrepShopping.DataSource = bizShopping.getCourses(industry, course_type);
                this.gwPrepShopping.DataBind();
                if (this.gwPrepShopping.Rows.Count < 1)
                {
                    this.gwPrepShopping.Visible = false;
                    //this.imgIndustryPrepHeader.Visible = false;
                }
                else
                {
                    this.gwPrepShopping.Visible = true;
                    //this.imgIndustryPrepHeader.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    private void bindCatCourses(int CatID, int course_type)
    {
        try
        {
            if (course_type == 1)
            {
                this.gwShopping.DataSourceID = null;
                this.gwShopping.DataSource = Courses.getCatalogCourses(CatID);//, course_type);
                this.gwShopping.DataBind();
                this.lblType.Text = Courses.getCatalogCourses(CatID).Rows[0]["course_type_description"].ToString();
                this.imgbtnArrowpPrep.Visible = false;
            }
            else if (course_type == 2)
            {
                this.gwPrepShopping.DataSourceID = null;
                this.gwPrepShopping.DataSource = Courses.getCatalogCourses(CatID, course_type);
                this.gwPrepShopping.DataBind();
                if (this.gwPrepShopping.Rows.Count < 1)
                {
                    this.gwPrepShopping.Visible = false;
                    //this.imgIndustryPrepHeader.Visible = false;
                    this.lblTypePrep.Visible = false;
                    this.imgbtnArrowpPrep.Visible = false;
                }
                else
                {
                    this.gwPrepShopping.Visible = true;
                    //this.imgIndustryPrepHeader.Visible = true;
                    this.lblTypePrep.Visible = true;
                    this.lblTypePrep.Text = Courses.getCatalogCourses(CatID, course_type).Rows[0]["course_type_description"].ToString();
                    this.imgbtnArrowpPrep.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void course_info(string course_code)
    {
        try
        {
            this.panelWelcome.Visible = false;
            this.panelCourses.Visible = false;
            this.panelCourseDetails.Visible = true;
            populateCourseDetails(course_code);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //private void addToCart(string course_code)
    //{
    //    try
    //    {
    //        if ((Session["ShoppingCart"] != null))
    //        {
    //            DataView dv = new DataView((DataTable)Session["ShoppingCart"]);
    //            dv.RowFilter = "[courses_coursecode] = " + course_code;
    //            if (dv.Count > 0)
    //            {
    //                Response.Write("<script>alert('This course is already in your cart.');</script>");
    //                this.gwShoppingCart.DataSource = (DataTable)Session["ShoppingCart"];
    //                this.gwShoppingCart.DataBind();
    //            }
    //            else
    //            {
    //                Session["ShoppingCart"] = bizShopping.addtoCart((DataTable)Session["ShoppingCart"], course_code);
    //                bindShoppingCart();
    //            }
    //        }
    //        else
    //        {
    //            Session["ShoppingCart"] = bizShopping.addtoCart((DataTable)Session["ShoppingCart"], course_code);
    //            bindShoppingCart();
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}


    private void addToCart(int courseID)
    {
        try
        {
            if ((Session["ShoppingCart"] != null))
            {
                DataView dv = new DataView((DataTable)Session["ShoppingCart"]);
                //dv.RowFilter = "[courses_coursecode] = " + course_code;
                dv.RowFilter = "[courses_pk] = " + courseID;
                if (dv.Count > 0)
                {
                    Response.Write("<script>alert('This course is already in your cart.');</script>");
                    this.gwShoppingCart.DataSource = (DataTable)Session["ShoppingCart"];
                    this.gwShoppingCart.DataBind();
                }
                else
                {
                    //Session["ShoppingCart"] = bizShopping.addtoCart((DataTable)Session["ShoppingCart"], course_code);
                    Session["ShoppingCart"] = bizShopping.addtoCart((DataTable)Session["ShoppingCart"], courseID);
                    bindShoppingCart();
                }
            }
            else
            {
                //Session["ShoppingCart"] = bizShopping.addtoCart((DataTable)Session["ShoppingCart"], course_code);
                Session["ShoppingCart"] = bizShopping.addtoCart((DataTable)Session["ShoppingCart"], courseID);
                bindShoppingCart();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void populateCourseDetails(string courseCode)
    {
        Course selCourse = null;
        DataTable dtCategory = null;
       
       
        string strCourseName = string.Empty;
        try
        {
            selCourse = new Course(Convert.ToInt32(courseCode));

            //dsRecord = bizShopping.getCourseDetails(User.Identity.Name);
            //lblCourseCode1.Text=selCourse.c();

            if (!string.IsNullOrEmpty(selCourse.name))
            {
                 strCourseName = selCourse.name;
            }
            else
            {
                strCourseName = "";
            }
            lblCourseCode2.Text = selCourse.courseCode;
            lblIndustry.Text = "";

            if (!string.IsNullOrEmpty(selCourse.prereqTitle))
            {
                lblPrerequisites.Text = selCourse.prereqTitle;
            }
            else
            {
                lblPrerequisites.Text = "";
            }

            if (!string.IsNullOrEmpty(selCourse.cpe_credits))
            {
                lblCPECredits.Text = selCourse.cpe_credits;
            }
            else
            {
                lblCPECredits.Text = "";
            }

            if (!string.IsNullOrEmpty(selCourse.cost))
            {
                lblCost.Text = selCourse.cost;
            }
            else
            {
                lblCost.Text = "";
            }

            if (!string.IsNullOrEmpty(selCourse.name))
            {
                lblCourseTitle.Text = selCourse.name;
            }
            else
            {
                lblCourseTitle.Text = "";
            }

            if (!string.IsNullOrEmpty(selCourse.shortdesc))
            {
                lblShortDescription.Text = selCourse.shortdesc;
            }
            else
            {
                lblShortDescription.Text = "";
            }

            if (!string.IsNullOrEmpty(selCourse.longdesc))
            {
                lblLongDescription.Text = selCourse.longdesc;
            }
            else
            {
                lblLongDescription.Text = "";
            }

            if (!string.IsNullOrEmpty(selCourse.length))
            {
                lblLength.Text = selCourse.length;
            }
            else
            {
                lblLength.Text = "";
            }
            
            if (Convert.ToInt32(selCourse.type) == 2)
            {
                this.imgbtnAddtoCart_Details.Visible = false;
                this.lblCost.Visible = false;
            }

            if (!string.IsNullOrEmpty(selCourse.AlsoLocatedIn))
            {
                lblAlsoLocatedin.Text = selCourse.AlsoLocatedIn;
            }
            else
            {
                lblAlsoLocatedin.Text = "";
            }
            
            //this.imgIndustryHeader_Details.ImageUrl = "";
            setupPreviewButton(courseCode);
            if (Request.QueryString["categoryid"] != null)
            {
                dtCategory = new DataTable();
                dtCategory = Courses.getCatalogCourses(Convert.ToInt32(Request.QueryString["categoryid"]));
                if (dtCategory.Rows.Count > 0)
                {
                    this.imgIndustryHeader_Details.ImageUrl = dtCategory.Rows[0]["category_LargeIcon"].ToString();
                    this.lblIndustry.Text = dtCategory.Rows[0]["category_name"].ToString();
                    
                }
                //Session["CategoryID"] = Request.QueryString["categoryid"];

            }


            if (ViewState["SelectedCategoryID"] != null)
            {
                dtCategory = new DataTable();
                dtCategory = Courses.getCatalogCourses(Convert.ToInt32(ViewState["SelectedCategoryID"]));
                if (dtCategory.Rows.Count > 0)
                {
                    this.imgIndustryHeader_Details.ImageUrl = dtCategory.Rows[0]["category_LargeIcon"].ToString();
                    this.lblIndustry.Text = dtCategory.Rows[0]["category_name"].ToString();
                }
                //Session["CategoryID"] = ViewState["SelectedCategoryID"];

            }

            
            #region commented
            //if (Convert.ToInt32(selCourse.type) == 2)
            //{
            //    this.imgbtnAddtoCart_Details.Visible = false;
            //    this.lblCost.Visible = false;
            //}

            //foreach (DataRow datarow in dsRecord.Rows)
            //{
            //    if (datarow["courses_coursetitle"].ToString() != null)
            //    {
            //        strCourseName = datarow["courses_coursetitle"].ToString();
            //    }
            //    else
            //    {
            //        strCourseName = "";
            //    }

            //    if (datarow["industry_name"].ToString() != null)
            //    {
            //        lblIndustry.Text = datarow["industry_name"].ToString();
            //    }
            //    else
            //    {
            //        lblIndustry.Text = "";
            //    }
            //    if (datarow["courses_prerequisites"].ToString() != null)
            //    {
            //        lblPrerequisites.Text = datarow["courses_prerequisites"].ToString();
            //    }
            //    else
            //    {
            //        lblPrerequisites.Text = "";
            //    }
            //    //-----
            //    if (datarow["courses_cpe_credits"].ToString() != null)
            //    {
            //        lblCPECredits.Text = datarow["courses_cpe_credits"].ToString();
            //    }
            //    else
            //    {
            //        lblCPECredits.Text = "";
            //    }

            //    if (datarow["courses_cost"].ToString() != null)
            //    {
            //        lblCost.Text = datarow["courses_cost"].ToString();
            //    }
            //    else
            //    {
            //        lblCost.Text = "";
            //    }


            //    if (datarow["courses_coursetitle"].ToString() != null)
            //    {
            //        lblCourseTitle.Text = datarow["courses_coursetitle"].ToString();
            //    }
            //    else
            //    {
            //        lblCourseTitle.Text = "";
            //    }

            //    if (datarow["courses_shortdescription"].ToString() != null)
            //    {
            //        lblShortDescription.Text = datarow["courses_shortdescription"].ToString();
            //    }
            //    else
            //    {
            //        lblShortDescription.Text = "";
            //    }
            //    //--
            //    if (datarow["courses_longdescription"].ToString() != null)
            //    {
            //        lblLongDescription.Text = datarow["courses_longdescription"].ToString();
            //    }
            //    else
            //    {
            //        lblLongDescription.Text = "";
            //    }

            //    if (datarow["courses_timeexpected"].ToString() != null)
            //    {
            //        lblLength.Text = datarow["courses_timeexpected"].ToString();
            //    }
            //    else
            //    {
            //        lblLength.Text = "";
            //    }

            //    if (Convert.ToInt32(datarow["courses_course_type_fk"].ToString()) == 2)
            //    {
            //        this.imgbtnAddtoCart_Details.Visible = false;
            //        this.lblCost.Visible = false;
            //    }
            //}
            // this.imgbtnAddtoCart_Details.Visible = true;
            //this.lblCost.Visible = true;
            //switch (courseCode.Trim())
            //{
            //    case "15":
            //        this.imgIndustryHeader_Details.ImageUrl = "images\\header_shop_trading.jpg";
            //        break;
            //    case "16":
            //        this.imgIndustryHeader_Details.ImageUrl = "images\\header_shop_oil.jpg";
            //        break;
            //    case "17":
            //        this.imgIndustryHeader_Details.ImageUrl = "images\\header_shop_gas.jpg";
            //        break;
            //    case "18":
            //        this.imgIndustryHeader_Details.ImageUrl = "images\\header_shop_power.jpg";
            //        break;
            //    case "19":
            //        this.imgIndustryHeader_Details.ImageUrl = "images\\header_shop_energy.jpg";
            //        break;
            //}
            //setupPreviewButton(courseCode); 
            #endregion
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

   
    private void setupPreviewButton(string coursecode)
    {

        string previewURL = null;
        string windowoptions = null;
        try
        {
            //previewURL = bizMyCourses.getCoursePreviewURL(coursecode);
            //windowoptions = bizMyCourses.getWindowOptions(coursecode);
            switch (coursecode)
            {
                case "1500":
                    this.imgbtnPreview.OnClientClick = "createPopup('courses_preview/bttf/Preview/mainframeset.htm','Pop',popupWinNum++,789,542);";
                    break;
                case "1501":
                    this.imgbtnPreview.OnClientClick = "createPopup('courses_preview/cctcr/Preview/mainframeset.htm','Pop',popupWinNum++,789,542);";
                    break;
                case "1502":
                    this.imgbtnPreview.OnClientClick = "window.open('" + previewURL + "', 'Pop', '" + windowoptions + "');";
                    break;
                case "1503":
                    this.imgbtnPreview.OnClientClick = "createPopup('courses_preview/aahe/Preview/mainframeset.htm','Pop',popupWinNum++,789,542);";
                    break;
                case "1504":
                    this.imgbtnPreview.OnClientClick = "createPopup('courses_preview/fsfd/Preview/mainframeset.htm','Pop',popupWinNum++,789,542);";
                    break;
                case "1505":
                    this.imgbtnPreview.OnClientClick = "createPopup('courses_preview/fx/Preview/mainframeset.htm','Pop',popupWinNum++,789,542);";
                    break;
                case "1506":
                    this.imgbtnPreview.OnClientClick = "createPopup('courses_preview/hfo/Preview/mainframeset.htm','Pop',popupWinNum++,789,542);";
                    break;
                case "1507":
                    this.imgbtnPreview.OnClientClick = "createPopup('courses_preview/icrm/Preview/default.htm','Pop',popupWinNum++,780,570);";
                    break;
                case "1508":
                    this.imgbtnPreview.OnClientClick = "createPopup('courses_preview/oad/Preview/mainframeset.htm','Pop',popupWinNum++,789,542);";
                    break;
                case "1509":
                    this.imgbtnPreview.OnClientClick = "createPopup('courses_preview/tcr/Preview/mainframeset.htm','Pop',popupWinNum++,789,542);";
                    break;
                case "1510":
                    this.imgbtnPreview.OnClientClick = "createPopup('courses_preview/var/Preview/mainframeset.htm','Pop',popupWinNum++,789,542);";
                    break;
                case "1511":
                    this.imgbtnPreview.OnClientClick = "createPopup('courses_preview/wd/Preview/mainframeset.htm','Pop',popupWinNum++,789,542);";
                    break;
                case "1600":
                    this.imgbtnPreview.OnClientClick = "createPopup('courses_preview/bp/Preview/mainframeset.htm','Pop',popupWinNum++,788,542);";
                    break;
                case "1601":
                    this.imgbtnPreview.OnClientClick = "createPopup('courses_preview/wpc/Preview/mainframeset.htm','Pop',popupWinNum++,788,542);";
                    break;
                case "1602":
                    this.imgbtnPreview.OnClientClick = "createPopup('courses_preview/pr/Preview/mainframeset.htm','Pop',popupWinNum++,788,542);";
                    break;
                case "1603":
                    this.imgbtnPreview.OnClientClick = "window.open('" + previewURL + "', 'Pop', '" + windowoptions + "');";
                    break;
                case "1604":
                    this.imgbtnPreview.OnClientClick = "createPopup('courses_preview/cr/Preview/mainframeset.htm','Pop',popupWinNum++,788,542);";
                    break;
                case "1700":
                    this.imgbtnPreview.OnClientClick = "createPopup('courses_preview/gmd/Preview/mainframeset.htm','Pop',popupWinNum++,788,542);";
                    break;
                case "1701":
                    this.imgbtnPreview.OnClientClick = "createPopup('courses_preview/ong/Preview/mainframeset.htm','Pop',popupWinNum++,788,542);";
                    break;
                case "1800":
                    this.imgbtnPreview.OnClientClick = "createPopup('courses_preview/pte/Preview/default.htm','Pop',popupWinNum++,780,570);";
                    break;
                case "1801":
                    this.imgbtnPreview.OnClientClick = "createPopup('courses_preview/ipi/Preview/mainframeset.htm','Pop',popupWinNum++,788,542);";
                    break;
                case "1802":
                    this.imgbtnPreview.OnClientClick = "createPopup('courses_preview/epmi/Preview/default.htm','Pop',popupWinNum++,780,570);";
                    break;
                case "1900":
                    this.imgbtnPreview.OnClientClick = "createPopup('courses_preview/sci/Preview/mainframeset.htm','Pop',popupWinNum++,788,542);";
                    break;
                default:
                    // Me.imgbtnPreview.OnClientClick = "createPopup('" & bizAdmin.getPreviewPath(coursecode) & "','Pop',popupWinNum++,788,542);"
                    this.imgbtnPreview.OnClientClick = "window.open('" + previewURL + "', 'Pop', '" + windowoptions + "');";
                    break;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void imgbtnRedeemVoucher_Details_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        try
        {
            //string sku = bizShopping.getCourseCode(this.lblCourseCode1.Text);
            Response.Redirect("secured\\redeem_voucher.aspx?courseID=" + ViewState["CourseCode"].ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void LoadCourseByCat(string categoryID)
    {
        string imageCat = string.Empty;
        string imageCatPrepHeader = string.Empty;
        try
        {
            DataTable dtCourse = null;
            dtCourse = new DataTable();
            if (!string.IsNullOrEmpty(categoryID))
            {
                dtCourse = Courses.getCatalogCourses(Convert.ToInt32(categoryID));
                if (dtCourse.Rows.Count > 0)
                {

                    //imageCat = dtCourse.Rows[0]["category_smallIcon"].ToString();
                    this.imgIndustryHeader.ImageUrl = dtCourse.Rows[0]["category_LargeIcon"].ToString();
                    this.lblHeaderCourse.Text = dtCourse.Rows[0]["category_name"].ToString()+" "+ " Courses";
                    //this.imgIndustryHeader_Details.ImageUrl = "images\\header_shop_trading.jpg";
                    //this.imgIndustryPrepHeader.ImageUrl = "images\\header_prep_trading.jpg";
                    bindCatCourses(Convert.ToInt32(categoryID), 1);
                    bindCatCourses(Convert.ToInt32(categoryID), 2);
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void imgbtnCheckout_Click(object sender, ImageClickEventArgs e)
    {
        try
        {

            Response.Redirect("~/secured/checkout.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void imgbtnAddtoCart_Details_Click(object sender, ImageClickEventArgs e)
    {
        if (ViewState["CourseCode"] != null)
        {
            addToCart(Convert.ToInt32(ViewState["CourseCode"]));
        }
        //addToCart(bizShopping.getCourseCode(this.lblCourseCode1.Text));
        //addToCart(bizShopping.getCourseCode(Convert.ToInt32(ViewState["CourseCode"])));
    }

    protected void lnkbtnFlashMoreInfo_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/system_requirements.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    protected void gwShopping_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ViewState["CourseCode"] = "";
        try
        {
            ViewState["CourseCode"] = e.CommandArgument.ToString();
            if (e.CommandName == "AddtoCart")
            {
                //addToCart(e.CommandArgument.ToString());
                addToCart(Convert.ToInt32(e.CommandArgument));
            }
            if (e.CommandName == "Redeem")
            {
                if (Session["UserInfo"] != null)
                {
                    //Response.Redirect("secured\\redeem_voucher.aspx?coursecode=" + e.CommandArgument.ToString());
                    Response.Redirect("secured\\redeem_voucher.aspx?courseID=" + e.CommandArgument.ToString());
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
            if (e.CommandName == "Select")
            {
                course_info(e.CommandArgument.ToString());
                //ViewState["CourseCode"] = e.CommandArgument.ToString();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void gwPrepShopping_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ViewState["CourseCode"] = "";
        try
        {
            ViewState["CourseCode"] = e.CommandArgument.ToString();
            if (e.CommandName == "AddtoCart")
            {
                //addToCart(e.CommandArgument.ToString());
                addToCart(Convert.ToInt32(e.CommandArgument));
            }
            if (e.CommandName == "Redeem")
            {
                if (Session["UserInfo"] != null)
                {
                    Response.Redirect("secured\\redeem_voucher.aspx?courseID=" + e.CommandArgument.ToString());
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
            if (e.CommandName == "Select")
            {
                course_info(e.CommandArgument.ToString());
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void gwShoppingCart_DataBound(object sender, EventArgs e)
    {
        try
        {
            if (gwShoppingCart.Rows.Count > 0)
            {
                this.panelFooter.Visible = true;
            }
            else
            {
                this.panelFooter.Visible = false;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void gwShoppingCart_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "ShoppingCartCourse_Clicked")
            {
                this.panelWelcome.Visible = false;
                this.panelCourses.Visible = false;
                this.panelCourseDetails.Visible = true;
                populateCourseDetails(e.CommandArgument.ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void gwShoppingCart_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        double total;
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Summation of Shopping Cart Items
                total = double.Parse((DataBinder.Eval(e.Row.DataItem, "courses_cost").ToString()).Replace("$", ""));
                _shoppingcartTotal += total;
            }
            else
            {
                this.lblSubTotal.Text = "$" + _shoppingcartTotal.ToString("0.00");
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    protected void gwShoppingCart_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            DataTable dt = (DataTable)Session["ShoppingCart"];
            dt.Rows.RemoveAt(e.RowIndex);
            Session["ShoppingCart"] = dt;
            bindShoppingCart();
        }
        catch (Exception ex)
        {
            throw ex;
        }


    }

    protected void industry_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            this.panelWelcome.Visible = false;
            this.panelCourses.Visible = true;
            this.panelCourseDetails.Visible = false;

            switch (((ImageButton)sender).ID)
            {
                case "imgbtnTrading":
                    LoadCourseByCat("TRADING");
                    break;
                case "imgbtnOil":
                    LoadCourseByCat("OIL");
                    break;
                case "imgbtnGas":
                    LoadCourseByCat("GAS");
                    break;
                case "imgbtnPower":
                    LoadCourseByCat("POWER");
                    break;
                case "imgbtnEnergy":
                    LoadCourseByCat("ENERGY");
                    break;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion

    #region portal2

    protected void BuildPage()
    {
        if (Session["UserInfo"] != null)
        {
            ivlUser = (UserInfo)Session["UserInfo"];
        }
        else
        {
            //Response.Redirect("~\\Login.aspx");
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
            lbTemp.ID = strCatID;
            lbTemp.Text = RenderCatImageStr(Cat)+" "+Cat.name;
            lbTemp.Command += new CommandEventHandler(OnCatClick);
            lbTemp.CommandName = "EnableCoursePanel";
            lbTemp.CommandArgument = strCatID;
            pnlCategory.Controls.Add(lbTemp);
            //pnlCategory.CssClass = "";
        }
    }
    void OnCatClick(object sender, CommandEventArgs e)
    {
        try
        {
            ViewState["SelectedCategoryID"] = e.CommandArgument.ToString();
            Session["CategoryID"] = e.CommandArgument.ToString();
            DataTable dtCourse = null;
            dtCourse = new DataTable();
            if (ViewState["SelectedCategoryID"] != null)
            {
                LoadCourseByCat(ViewState["SelectedCategoryID"].ToString());
            }
            this.panelWelcome.Visible = false;
            this.panelCourses.Visible = true;
            this.panelCourseDetails.Visible = false;
            
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  
    #endregion

    protected void imgbtnArrow_Click(object sender, ImageClickEventArgs e)
    {
        if (gwShopping.Rows.Count > 0)
        {
            if ((string)ViewState["Arrow"]!= "close")
            {
                this.imgbtnArrow.ImageUrl = "~/images/icon_category_closed.png";
                gwShopping.Visible = false;
                ViewState["Arrow"] = "close";
            }
            else
            {
                this.imgbtnArrow.ImageUrl = "~/images/icon_category_open.png";
                gwShopping.Visible = true;
                ViewState["Arrow"] = "open";
            }
        }

    }


    protected void imgbtnArrowpPrep_Click(object sender, ImageClickEventArgs e)
    {
        if (gwPrepShopping.Rows.Count > 0)
        {
            if ((string)ViewState["ArrowPrep"] != "close")
            {
                this.imgbtnArrowpPrep.ImageUrl = "~/images/icon_category_closed.png";
                gwPrepShopping.Visible = false;
                ViewState["ArrowPrep"] = "close";
            }
            else
            {
                this.imgbtnArrowpPrep.ImageUrl = "~/images/icon_category_open.png";
                gwPrepShopping.Visible = true;
                ViewState["ArrowPrep"] = "open";
            }
        }

    }
    protected void imgbtnReturnToCourse_Click(object sender, ImageClickEventArgs e)
    {
        this.panelCourseDetails.Visible = false;
        this.panelCourses.Visible = true;
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
    protected void lnkbtnFlashMoreInfo_Click1(object sender, EventArgs e)
    {
        Response.Redirect("~/FlashTest.aspx");
    }
    protected void imgbtnForums_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Forums/forums.aspx");
    }
}




