<%@ Page Language="C#" MasterPageFile="~/master/TriPanel.master" AutoEventWireup="true" CodeFile="catalog.aspx.cs" Inherits="catalog" Title="Course Catalog" %>

<asp:Content ID="cntHeader" ContentPlaceHolderID="cphHeader" runat="server">
    <img src="/images/header_catalog.png" width="245" height="58" style="float:left; margin:0 0 0 40px;" alt="Catalog" title="Catalog" />
    <img src="/images/header_course_details.png" width="245" height="58" style="float:left; margin:0 0 0 60px;" alt="Welcome to InVision Learning Portal Catalog" title="Welcome to InVision Learning Portal Catalog" />
    <img src="/images/header_contact.png" width="245" height="58" style="float:left; margin:0 0 0 124px;" alt="Contact Us" title="Contact Us" />
    <br style="clear:both;"/>
</asp:Content>       
<asp:Content ID="Categories" ContentPlaceHolderID="cphLeft" Runat="Server">
    <div id="catalogColumn2">
        <asp:Panel ID="pnlCategory" runat="server">
        </asp:Panel>
    </div>    
</asp:Content>
<asp:Content ID="Courses" ContentPlaceHolderID="cphCenter" Runat="Server">
    <div id="coursesColumn">
       <asp:Panel ID="pnlStart" runat="server" Visible="true">
           Select a Catagory on the Left to view courses
        </asp:Panel>
        <asp:Panel ID="pnlCourse" runat="server" Visible="false">
            <h4>Type</h4><h4> Title</h4><h5>Length</h5><h4 style='padding:0 0 0 20px;'>Prerequisites</h4><br style='clear:both;'/>
        </asp:Panel>
        <asp:Panel ID="pnlDetails" runat="server" Visible="false">
            <asp:Label ID="lblName" runat="server"></asp:Label><br />
            <asp:ImageButton ID="ibReturn" runat="server" ImageUrl="~/images/btn_return_courselist.png" OnCommand="ReturnToList" Height="40" Width="220" AlternateText="Return to course list" ToolTip="Return to course list" /> 
            <asp:Panel ID="pnlPreReq" runat="server" Visible="false"></asp:Panel><br />
            <asp:ImageButton ID="ibPreview" runat="server" ImageUrl="~/images/btn_preview_course.png" OnCommand="PreviewCourse" Height="40" Width="220" AlternateText="Preview Course" ToolTip="Preview Course" /> 
<!--alignment fix for hourGlass icon-->
           		<div class="hourGlass">
					<div class="length">
						<p><strong>Length:</strong></p>
					</div>
					<div class="img">
                		<img src="images/hourglass.png" width="20" height="30"  alt="Course Length" title="Course Length" />
					</div>
					<div class="int">
                		<asp:Label ID="lblLength" runat="server"/>
					</div>
				</div>
            <p><strong>Description:</strong></p>
            <asp:Label ID="lblShort" runat="server"/>
            <asp:Label ID="lblLong" runat="server"/>
        </asp:Panel>        
     </div>
</asp:Content>
<asp:Content ID="Details" ContentPlaceHolderID="cphRight" Runat="Server">
   <div id="contactColumn">
        <p>If you are interested in learning more about any of our products and solutions, please contact Lori Biele at
                        <strong>508.624.9100 x 223</strong> or <a href="mailto:lbiele@invisionlearning.com">
                        <strong>lbiele@invisionlearning.com</strong></a>.</p>
        <p><a href="http://www.invisionlearning.com">view our website</a></p>
        <p>&nbsp;</p>
        <p><strong>Adobe Flash Player</strong><br />
            <img src="/images/btn_flash_detected.png" width="10" height="10" align="left" alt="Edit Account Information" title="Edit Account Information" />&nbsp;Detected&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="/FlashTest.aspx"><img src="/images/more_info.png" width="72" height="17" align="top" alt="Flash player information"  title="Flash player information" /></a></p>
        </p>
    </div>
</asp:Content>

