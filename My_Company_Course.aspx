<%@ Page Language="C#" AutoEventWireup="true" CodeFile="My_Company_Course.aspx.cs" MasterPageFile="~/master/UIO.master" Inherits="My_Company_Course" %>
<asp:Content ID="compCourses" runat="server" ContentPlaceHolderID="cphBody">
<asp:Panel ID="panelCourses" runat="server" 
        HorizontalAlign="Center" Height="629px">
        <div align="center" style="position:absolute; left:230px; background-color:#EEF1F8;">
            <table id="tblImgCouses" cellpadding="0" cellspacing="0" bgcolor="#EEF1F8"  
                        style="width: 480px; height: 54px;">
                        <tr>
                            <td style="width: 10px;" align="right">
                                &nbsp;</td>
                            <td align="left">
                                <asp:Image ID="imgMyCompCourses" runat="server" ImageUrl="~/images/Headers/header_company_courses.png"
                                    AlternateText="My Company Courses Header" Height="55px" /></td>
                        </tr>
                    </table>
            <table cellpadding="0" cellspacing="0" bgcolor="#EEF1F8"
                style="width: 480px; height: 48px;">
                        <tr>
                            <td align="left" class="info_text" style="width: 15px; height: 19px;">
                                </td>
                            <td align="left" class="info_text" style="width: 60px; height: 19px;">
                                TYPE</td>
                            <td align="left" class="info_text" style="width: 195px; height: 19px;">
                                TITLE</td>
                            <td align="center" class="info_text" style="width: 100px; height: 19px;">
                                COURSE CODE</td>
                            <td align="left" class="info_text" style="width: 10px; height: 19px;">
                                </td>
                        </tr>
                    </table>
            <asp:GridView ID="gwMyCompCourses" runat="server" AutoGenerateColumns="False" GridLines="None"
                        ShowHeader="False" BackColor="#EEF1F8" onrowcommand="gwMyCompCourses_RowCommand" >
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <table width="100%">
                                        <tr style="background-color:#BBCEE5; height:20%">
                                            <td style="background-color:#BBCEE5; height: 20px;" align="center">
                                                <asp:Image ID="imgCourseSmallIcon" ImageUrl=''
                                                    runat="server" /></a</td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="50px" 
                                    CssClass="text_mycourses" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <table width="100%">
                                        <tr style="background-color:#BBCEE5">
                                            <td style="background-color:#BBCEE5; height: 20px;">
                                                <asp:LinkButton ID="lblCourseTitle" Text='<%# Eval("courses_coursetitle") %>' Font-Underline="false"
                                                    ForeColor="#0e447a" Font-Bold="true" Font-Names="Arial, Helvetica, sans-serif"
                                                    Font-Size="12px" runat="server" CommandName="Select" CommandArgument='<%# Eval("courses_pk") %>'></asp:LinkButton></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblCourseDescription" Text='<%# Eval("courses_shortdescription") %>'
                                                    CssClass="info_text" runat="server"></asp:Label></td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <ItemStyle Width="240px" HorizontalAlign="Left" CssClass="text_mycourses" 
                                    VerticalAlign="Top" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <table width="100%">
                                        <tr style="background-color:#BBCEE5">
                                            <td style="background-color:#BBCEE5; height:20px">
                                                <asp:Label ID="lblCourseCode" Text='<%# Eval("courses_acronym") %>' CssClass="shop_heading_trading"
                                                    runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="55px" 
                                    CssClass="text_mycourses" />
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <table width="100%">
                                    <tr style="background-color:#BBCEE5">
                                            <td align="right" style="height:20px" >
                                                
                                                <br />
                                            </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 5px;">
                                                    
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 26px;" valign="top">
                                                    <asp:ImageButton ID="imgbtnRedeemVoucher" ImageUrl="~\images\btn_voucher.gif" CommandName="Redeem"
                                                        CommandArgument='<%# Eval("courses_pk") %>' runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td></td></tr>
                                    </table>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="100px" 
                                    CssClass="text_mycourses" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
        </div>
    </asp:Panel>
</asp:Content>
