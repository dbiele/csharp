<%@ Page Language="C#" MasterPageFile="~/master/TriUIO_Master.master" AutoEventWireup="true" CodeFile="my_courses.aspx.cs" Inherits="my_courses" Title="The Oxford Princeton Programme - Web Based Training" %>

<asp:Content ID="Categories" ContentPlaceHolderID="cphLeft" Runat="Server">
    <div id="catalogColumn" style="width: 208px; background-color:#EEF1F8;" align="left">
        <asp:Panel ID="pnlCategory" runat="server" Height="19px"></asp:Panel>
    </div>    
</asp:Content>

<asp:Content ID="Courses" ContentPlaceHolderID="cphCenter" Runat="Server">
    <div id="mycoursesColumn" style="width: 280px; height: 489px; background-color:#EEF1F8" align="left">
        <asp:Label ID="lblTop" runat="server" CssClass="mycourse_welcome_text"></asp:Label>
        <asp:Panel ID="pnlCourse" runat="server" Width="260px"></asp:Panel>
    </div>
</asp:Content>

<asp:Content ID="Details" ContentPlaceHolderID="cphRight" runat="server">
    <div id="coursedetailColumn" align="left" style="width:190px; background-color:#EEF1F8">
        <asp:Panel ID="pnlDetails" runat="server" Visible="false" Height="193px" Width="200px">
            <asp:Label ID="lblCourseName" runat="server" CssClass="user_info_name" ></asp:Label>
            <p><br /></p>
            <asp:Table ID="tblCourseLaunch" runat="server" CellPadding="0" CellSpacing="0" Width="200" Visible="true">
                <asp:TableRow ID="trStatus" runat="server" Height="25">
                    <asp:TableCell ID="tcStLabel" runat="server" Width="60" CssClass="course_details">Status:</asp:TableCell>
                    <asp:TableCell ID="tcStImg" runat="server" Width="20">
                        <asp:Image ID="imgStatus" runat="server" ImageAlign="Left" Height="15" Width="15" />
                    </asp:TableCell>
                    <asp:TableCell ID="tcStDetails" runat="server" Width="80" CssClass="course_details">
                         <asp:Label ID="lblStatus" runat="server"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ID="tcStStats" runat="server" Width="40" CssClass="course_details">
                        <asp:Label ID="lblStatusStats" runat="server"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="trScore" runat="server" Height="25">
                    <asp:TableCell ID="tcScLabel" runat="server" CssClass="course_details">Score:</asp:TableCell>
                    <asp:TableCell ID="tcScimg" runat="server">
                        <asp:Image ID="imgScore" runat="server" ImageAlign="Left" Height="15" Width="15" />
                    </asp:TableCell>
                    <asp:TableCell ID="tcScDetails" runat="server" CssClass="course_details">
                            <asp:Label ID="lblScore" runat="server"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ID="tcScStats" runat="server" CssClass="course_details">
                        <asp:Label ID="lblScoreStats" runat="server"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="trUpdate" runat="server" Height="25" Visible="false">
                    <asp:TableCell ID="tcUpLabel" runat="server" CssClass="course_details">Updated:</asp:TableCell>
                    <asp:TableCell ID="tcUpImg" runat="server" ColumnSpan="2">
                        <asp:Image ID="imgUpdate" runat="server" ImageAlign="Left" ImageUrl="~/images/icon_urgent.png" AlternateText="Course Updated" ToolTip="Course Updated" Height="15" Width="15" />
                    </asp:TableCell>
                    <asp:TableCell ID="tcUpStats" runat="server">
                        &nbsp;
                    </asp:TableCell>
                 </asp:TableRow>
                 <asp:TableRow ID="trLaunch" runat="server">    
                    <asp:TableCell ID="tcLaunch" runat="server" ColumnSpan="4"><br />
                        <asp:ImageButton ID="ibLaunchCourse" runat="server" AlternateText="Launch Course"  ImageUrl="~/images/btn_launch_course.png" ToolTip="Launch Course" OnCommand="Launch_Course" CommandName="Launch"/>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <asp:Panel ID="pnlPreReq" runat="server" Visible="false">
            </asp:Panel>
            <p><br /></p>
            <p class="course_details">Description:</p>
            <asp:Label ID="lblShortDesc" runat="server" CssClass="info_text"></asp:Label>
            <asp:Label ID="lblLongDesc" runat="server" CssClass="info_text"></asp:Label>
            
       </asp:Panel>
    </div>
</asp:Content>

