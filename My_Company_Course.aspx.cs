using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using inVisionLearning;

public partial class My_Company_Course : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindMyCompCourses();
        }
    }

    private void BindMyCompCourses()
    {
        if (Session["UserInfo"] != null)
        {
            int UID = ((inVisionLearning.UserInfo)((Session["UserInfo"]))).UID;
            this.gwMyCompCourses.DataSourceID = null;
            this.gwMyCompCourses.DataSource = bizMyCourses.getMyCompanyCourses(UID);
            this.gwMyCompCourses.DataBind();
        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }
    }
    protected void gwMyCompCourses_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try 
        {
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
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
}
