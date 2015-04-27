<%@Page Language="C#" MasterPageFile="master/mpMainSiteNavigation.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="The Oxford Princeton Programme - Web Based Training" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="panelWelcome" runat="server" HorizontalAlign="Center" Height="629px">
        <table width="500" align="center" style="background-color:#EEF1F8">
                        <tr>
                            <td style="background-image: url('images/Headers/header_catalog_details.png'); background-repeat: no-repeat; background-position: center 0px; height: 44px; background-attachment: inherit;">
                             <p class="HeaderMainMenuFont" align="left">
                                    Welcome to Web-based Training!</p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div id="flashContent">
			                        <object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" width="460" height="220" id="tutorial" align="middle">
				                        <param name="movie" value="tutorials/tutorial.swf" />
				                        <param name="quality" value="high" />
				                        <param name="bgcolor" value="#EEF1F8" />
				                        <param name="play" value="true" />
				                        <param name="loop" value="false" />
				                        <param name="wmode" value="window" />
				                        <param name="scale" value="showall" />
				                        <param name="menu" value="false" />
				                        <param name="devicefont" value="false" />
				                        <param name="salign" value="" />
                                        <param name="FlashVars" value="url=/tutorial_verify.aspx&id=102" />
				                        <param name="allowScriptAccess" value="sameDomain" />
				                    <!--[if !IE]>-->
				                    <object type="application/x-shockwave-flash" data="tutorial.swf" width="460" height="220">
					                    <param name="movie" value="tutorials/tutorial.swf" />
					                    <param name="quality" value="high" />
					                    <param name="bgcolor" value="#EEF1F8" />
					                    <param name="play" value="true" />
					                    <param name="loop" value="false" />
					                    <param name="wmode" value="window" />
					                    <param name="scale" value="showall" />
					                    <param name="menu" value="false" />
					                    <param name="devicefont" value="false" />
					                    <param name="salign" value="" />
                                        <param name="FlashVars" value="url=/tutorial_verify.aspx&id=102" />
					                    <param name="allowScriptAccess" value="sameDomain" />
				                    <!--<![endif]-->
					                    <a href="http://www.adobe.com/go/getflash">
						                    <img src="http://www.adobe.com/images/shared/download_buttons/get_flash_player.gif" alt="Get Adobe Flash player" />
					                    </a>
				                    <!--[if !IE]>-->
				                    </object>
				                    <!--<![endif]-->
			                        </object>
		                        </div>
                            </td>
                        </tr>

                        <tr>
                            <td align="left">
                                <p class="text">
                                    These self-study courses are designed for professionals, regardless of expertise 
                                    or experience, seeking the flexibility of time (24/7) and location (worldwide 
                                    Internet access) as they build knowledge and create an energy edge in the 
                                    marketplace.<br />
                                    <br />
                                    Simply select your desired subject stream on the left and choose from a wide 
                                    array of topics. You can choose as many courses as you would like. Once 
                                    purchased, courses can easily be accessed via the open book icon at the top of 
                                    this page.<br />
                                    <br />
                                    The Oxford Princeton Programme has created &quot;road maps&quot; for those who seek expert 
                                    status in a specified field. These competency paths offer a series of courses 
                                    that can be taken over a flexible time horizon. They apply to all professionals 
                                    (entry-level, middle manager, senior management) as one can enter anywhere on 
                                    the path as is suitable with his or her individual level of skill and 
                                    experience. To view our web-based competency paths, please
                                    <a href="http://www.oxfordprinceton.com/competency/default.asp" target="_blank">
                                    click here</a>.<br /><br /></p>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <div align="center">
                                    <asp:ImageButton ID="imgbtnGoToMyCourses" runat="server" AlternateText="Go To My Courses"
                                        ImageUrl="~/images/btn_gocourse.jpg" onclick="imgbtnGoToMyCourses_Click" /></div>
                            </td>
                        </tr>
                    </table>
    </asp:Panel>
    <asp:Panel ID="panelCourses" runat="server" Visible="False" 
        HorizontalAlign="Center" Height="629px">
        <div align="center" style="position:absolute; left:230px; background-color:#EEF1F8;">
            <table id="tblImgCouses" cellpadding="0" cellspacing="0" bgcolor="#EEF1F8"  
                        style="width: 480px; height: 54px;">
                        <tr>
                            <td style="width: 10px;" align="right">
                                &nbsp;</td>
                            <td align="left" valign="top"
                                style="background-image: url('images/Headers/header_catalog_details.png'); background-repeat: no-repeat; background-position: left top;">
                                <asp:Image ID="imgIndustryHeader" runat="server" 
                                    AlternateText="Industry Header" Height="55px" Width="55px" 
                                    ImageAlign="Middle" />
                                    &nbsp;
                                    <asp:Label ID="lblHeaderCourse" runat="server" Text="Industry" 
                                    CssClass="HeaderFont"></asp:Label></td>
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
                            <td align="right" class="info_text" style="width: 100px; height: 19px;">
                                PRICE</td>
                            <td align="left" class="info_text" style="width: 10px; height: 19px;">
                                </td>
                        </tr>
                        <tr valign="top">
                            <td align="left" class="info_text" style="width: 15px; height: 19px;">
                            </td>
                            <td colspan="4" style="width:455; height: 25px;" align="left" colspan="2">
                                <asp:Label ID="lblType" runat="server" CssClass="bold_text"></asp:Label>
                                <asp:ImageButton ID="imgbtnArrow" runat="server" 
                                    ImageUrl="~/images/icon_category_open.png" onclick="imgbtnArrow_Click" />
                            </td>
                            <td style="width: 10px; height: 25px;">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="info_text" style="width: 15px; height: 19px;">
                                </td>
                            <td colspan="5" align="left" valign="top" style="height: 20px;"><img src="images/category_break.gif" alt="break" width="455" height="2" /></td>
                        </tr>
                    </table>
            <asp:GridView ID="gwShopping" runat="server" AutoGenerateColumns="False" GridLines="None"
                        ShowHeader="False" onrowcommand="gwShopping_RowCommand" BackColor="#EEF1F8" >
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <table width="100%">
                                        <tr style="background-color:#BBCEE5; height:20%">
                                            <td style="background-color:#BBCEE5; height: 20px;" align="center">
                                                <asp:Image ID="imgCourseSmallIcon" ImageUrl='<%# Eval("category_smallIcon")%>'
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
                                        <tr style="background-color:#BBCEE5; height:20px">
                                            <td align="right" style="background-color:#BBCEE5; height:20px">
                                               <asp:Label ID="lblCost" Text='<%# Eval("courses_cost") %>' CssClass="shop_cost"
                                                    runat="server"></asp:Label><br />
                                            </td>
                                            <tr>
                                                <td style="height: 26px;">
                                                    <asp:ImageButton ID="imgbtnAddtoCart" ImageUrl="~\images\btn_add_to_cart.gif" CommandName="AddtoCart"
                                                        CommandArgument='<%# Eval("courses_pk") %>' runat="server" /><br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 26px;">
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
                   
            <%--<asp:Image ID="imgIndustryPrepHeader" runat="server" AlternateText="Industry Prep Course Divider" Width="16px" />
--%>          
            <table cellpadding="0" cellspacing="0" style="width: 480px; height: 36px;" bgcolor="#EEF1F8">
                        <tr>
                            <td style="width: 15px; height: 26px;" align="right">
                                </td>
                            <td align="left" valign="top" style="height: 26px;">
                                <asp:Label ID="lblTypePrep" runat="server" CssClass="bold_text"></asp:Label>
                                <asp:ImageButton ID="imgbtnArrowpPrep" runat="server" 
                                    ImageUrl="~/images/icon_category_open.png" onclick="imgbtnArrowpPrep_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="info_text" style="width: 15px; height: 19px;">
                                </td>
                            <td align="left" valign="top" style="height: 20px;"><img src="images/category_break.gif" alt="break" width="455" height="2" /></td>
                        </tr>
                    </table>
            <asp:GridView ID="gwPrepShopping" runat="server" AutoGenerateColumns="False" 
                        GridLines="None" onrowcommand="gwPrepShopping_RowCommand" ShowHeader="False" BackColor="#EEF1F8">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <table width="100%">
                                        <tr style="background-color:#BBCEE5">
                                            <td style="background-color:#BBCEE5; height:20px" align="center">
                                                <asp:Image ID="imgPrepCourseSmallIcon" runat="server" 
                                                    ImageUrl='<%# Eval("category_smallIcon")%>' />
                                            </td>
                                        </tr>
                                        <tr><td></td></tr>
                                    </table>
                                </ItemTemplate>
                                <ItemStyle CssClass="text_mycourses" HorizontalAlign="Right" 
                                    VerticalAlign="Top" Width="50px" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <table width="100%">
                                        <tr style="background-color:#BBCEE5">
                                            <td style="background-color:#BBCEE5; height:20px">
                                                <asp:LinkButton ID="lblPrepCourseTitle" runat="server" 
                                                    CommandArgument='<%# Eval("courses_pk") %>' CommandName="Select" 
                                                    Font-Bold="true" Font-Names="Arial, Helvetica, sans-serif" Font-Size="12px" 
                                                    Font-Underline="false" ForeColor="#0e447a" 
                                                    Text='<%# Eval("courses_coursetitle") %>'>
                                                </asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblPrepCourseDescription" runat="server" CssClass="info_text" 
                                                    Text='<%# Eval("courses_shortdescription") %>'></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                </ItemTemplate>
                                <ItemStyle CssClass="text_mycourses" HorizontalAlign="Left" VerticalAlign="Top" 
                                    Width="240px" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <table width="100%">
                                        <tr style="background-color:#BBCEE5">
                                            <td style="background-color:#BBCEE5; height:20px">
                                                <asp:Label ID="lblPrepCourseCode" runat="server" 
                                                    CssClass="shop_heading_trading" Text='<%# Eval("courses_acronym") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr><td></td></tr>
                                    </table>
                                </ItemTemplate>
                                <ItemStyle CssClass="text_mycourses" HorizontalAlign="Left" VerticalAlign="Top" 
                                    Width="55px" />
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <table width="100%">
                                        <tr style="background-color:#BBCEE5">
                                            <td align="right" >
                                                <asp:Label ID="lblPrepCostPrep" runat="server" CssClass="shop_cost" 
                                                    Text='<%# Eval("courses_cost") %>'></asp:Label>
                                                <br />
                                            </td>
                                            <tr>
                                                <td style="height: 26px;">
                                                    <asp:ImageButton ID="imgbtnAddtoCarPrept" runat="server" 
                                                        CommandArgument='<%# Eval("courses_pk") %>' CommandName="AddtoCart" 
                                                        ImageUrl="~\images\btn_add_to_cart.gif" />
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 26px;">
                                                    <asp:ImageButton ID="imgbtnRedeemVoucherPrep" runat="server" 
                                                        CommandArgument='<%# Eval("courses_pk") %>' CommandName="Redeem" 
                                                        ImageUrl="~\images\btn_voucher.gif" />
                                                </td>
                                            </tr>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <ItemStyle CssClass="text_mycourses" HorizontalAlign="Left" VerticalAlign="Top" 
                                    Width="100px" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
        </div>
    </asp:Panel>
    <asp:Panel ID="panelCourseDetails" runat="server" Visible="false" 
        HorizontalAlign="Center" Height="629px">
            <table bgcolor="#EEF1F8" align="center" cellpadding="0" 
            cellspacing="0" style="height: 50px; width: 497px;">
            <tr valign="top">               
                <td height="50">
                    <table ID="tblImgCousesPrep" cellpadding="0" cellspacing="0" 
                        style="width: 490px; height: 50px;">
                        <tr>
                            <td align="right" style="width: 10px">
                                &nbsp;</td>
                            <td align="left" 
                                style="background-image: url('images/Headers/header_catalog_details.png'); background-repeat: no-repeat; background-position: left top">
                                <asp:Image ID="imgIndustryHeader_Details" runat="server" 
                                    AlternateText="Industry Header" Height="55px" Width="55px" ImageAlign="Middle" />
                                &nbsp;<asp:Label ID="lblHeaderCourseDetails" runat="server" CssClass="HeaderFont" 
                                    Text="Course Details"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            </table>
            <table align="center" bgcolor="#EEF1F8" cellpadding="0" cellspacing="0" 
                    style="background-position: left top; width: 500px">
                    <tr>
                        <td style="width: 15px">
                            &nbsp;</td>
                        <td align="left" style="width: 300px">
                            <p class="shop_heading_trading">
                                    <asp:Label ID="lblCourseTitle" runat="server" CssClass="bold_text" Text=""></asp:Label>
                                </p></td>
                        <td align="right">
                        <p class="shop_heading_trading" align="center">
                                    <asp:Label ID="lblCost" runat="server" Text="" CssClass="shop_cost"></asp:Label>
                                </p>
                            <%--<div align="right" class="shop_heading_trading" style="width:100px">
                                    <asp:Label ID="" runat="server" Text=""></asp:Label></div>--%></td>
                        <td style="width: 15px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 15px">
                            &nbsp;</td>
                        <td style="width: 300px" align="left">
                            <p class="info_text">
                                <span class="info_bold">Length:&nbsp;<img alt="time" src="images/icon_time.png" />&nbsp;</span><asp:Label ID="lblLength" runat="server" 
                                    Text=""></asp:Label>
                            </p>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td style="width: 15px">
                            &nbsp;</td>
                    </tr>
                    <tr style="height: 35px" valign="top">
                        <td style="width: 15px">
                            &nbsp;</td>
                        <td style="width: 300px" align="left">
                            <p class="info_text">
                                <span class="info_bold">Prerequisites:</span>&nbsp;<img alt="prerequisites" src="images/icon_prereq.png" />&nbsp;<asp:Label ID="lblPrerequisites" 
                                    runat="server" Text=""></asp:Label>
                            </p>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td style="width: 15px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 15px">
                            &nbsp;</td>
                        <td style="width: 300px" align="left" valign="top" >
                            <asp:ImageButton ID="imgbtnPreview" runat="server" 
                                CommandArgument='<%# Eval("courses_coursecode") %>' CommandName="Preview" 
                                ImageUrl="~\images\buttons\btn_preview_sm.png" />
                        </td>
                        <td align="left" >
                            <asp:ImageButton ID="imgbtnAddtoCart_Details" runat="server" 
                                CommandArgument='<%# Eval("courses_pk") %>' CommandName="AddtoCart" 
                                ImageUrl="~\images\btn_add_to_cart.gif" 
                                onclick="imgbtnAddtoCart_Details_Click" style="padding-bottom:5px" />
                            <br />
                            <asp:ImageButton ID="imgbtnRedeemVoucher_Details" runat="server" 
                                CommandArgument='<%# Eval("courses_coursecode") %>' CommandName="Redeem" 
                                ImageUrl="~\images\btn_voucher.gif" 
                                onclick="imgbtnRedeemVoucher_Details_Click" style="padding-bottom:5px" />
                        </td>
                        <td style="width: 15px">
                            &nbsp;</td>
                    </tr>
                </table>
            <table align="center" bgcolor="#EEF1F8" cellpadding="0" cellspacing="0" style="width: 500px">
                    <tr>
                        <td style="width: 15px">
                            &nbsp;</td>
                        <td align="left" style="width: 470px">
                            <p class="info_text">
                                <span class="info_bold">Description</span></p>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 15px">
                            &nbsp;</td>
                        <td align="left" style="width: 470px; height:auto ">
                            <p class="info_text">
                                <asp:Label ID="lblShortDescription" runat="server" Text=""></asp:Label>
                            </p>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr style="height: 30px">
                        <td style="width: 15px">
                            &nbsp;</td>
                        <td align="left" style="width: 470px">
                            <p class="info_text">
                                <span class="info_bold">Programme Level:&nbsp;</span><asp:Label ID="lblPgmLevel" 
                                    runat="server"></asp:Label>
                            </p>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr style="height: 30px">
                        <td style="width: 15px">
                            &nbsp;</td>
                        <td align="left" style="width: 470px">
                            <p class="info_text">
                                <span class="info_bold">Course Code:</span>&nbsp;<asp:Label ID="lblCourseCode2" 
                                    runat="server" Text=""></asp:Label>
                            </p>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 15px">
                            &nbsp;</td>
                        <td align="left" style="width: 470px">
                            <p class="info_text">
                                <span class="info_bold">Industry:</span>&nbsp;<asp:Label ID="lblIndustry" 
                                    runat="server" Text=""></asp:Label>
                            </p>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 15px">
                            &nbsp;</td>
                        <td align="left" style="width: 470px">
                            <p class="info_text">
                                <span class="info_bold">Also Located in:&nbsp;</span><asp:Label 
                                    ID="lblAlsoLocatedin" runat="server"></asp:Label>
                            </p>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr style="height: 30px">
                        <td style="width: 15px">
                            &nbsp;</td>
                        <td align="left" style="width: 470px">
                            <p class="info_text">
                                <span class="info_bold">CPE Credits:</span>&nbsp;<asp:Label ID="lblCPECredits" 
                                    runat="server" Text=""></asp:Label>
                            </p>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 15px">&nbsp;</td>
                        <td align="left" style="width: 470px">
                            <p class="info_text">
                                <span class="info_bold">You will learn to:</span>
                            </p>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 15px">
                            &nbsp;</td>
                        <td align="left" style="width: 470px">
                            <p>
                                <asp:Label ID="lblLongDescription" runat="server" CssClass="info_text" Text=""></asp:Label>
                            </p>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 15px">
                            &nbsp;</td>
                        <td align="left" style="width: 470px" class="shop_heading_trading">
                                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                            </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 15px">
                            &nbsp;</td>
                        <td align="left" class="shop_heading_trading" style="width: 470px">
                            <asp:ImageButton ID="imgbtnReturnToCourse" runat="server" 
                                ImageUrl="~/images/buttons/btn_return_courselist.png" 
                                onclick="imgbtnReturnToCourse_Click" /></td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
    </asp:Panel>  
</asp:Content>
<%--Shopping cart header--%>
<asp:Content ID="Content4" ContentPlaceHolderID="cpShoppingCartHeader" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" align="left" 
        style="width: 202px; height: 55px;">
        <tr>
            <td>
                <asp:Image ID="imgInYourCart" runat="server" AlternateText="In Your Cart" ImageUrl="~/images/headers/header_cart.png" /></td>
        </tr>
    </table>
</asp:Content>
<%--Shopping cart--%>
<asp:Content ID="Content2" ContentPlaceHolderID="cpShoppingCart" Runat="Server">
    
    <asp:GridView ID="gwShoppingCart" runat="server" AutoGenerateColumns="False" 
        ShowHeader="False" BorderStyle="None" GridLines="None" 
        HorizontalAlign="Center" ondatabound="gwShoppingCart_DataBound" 
        onrowcommand="gwShoppingCart_RowCommand" 
        onrowdatabound="gwShoppingCart_RowDataBound" onrowdeleting="gwShoppingCart_RowDeleting" 
         
        
        >
        <Columns>
            <asp:TemplateField>                
                <ItemStyle CssClass="cart_course" Width="130px" />
                <ItemTemplate>
                    <asp:LinkButton ID="lnkbtnCourseTitle_ShoppingCart" runat="server" Text='<%# Bind("shortcoursetitle") %>' CommandName="ShoppingCartCourse_Clicked" CommandArgument='<%# Eval("courses_pk") %>' Font-Underline="false" ></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="courses_cost" >
                <ItemStyle CssClass="info_bold" Width="44px" />
            </asp:BoundField>
            <asp:TemplateField ShowHeader="False">
                <ItemStyle Width="11px" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgbtnDelete" runat="server" CausesValidation="False" CommandName="Delete"
                        ImageUrl="~/images/btn_cart_delete.gif" OnClientClick="return confirm('Are you sure you want to remove this course from your shopping cart?');" Text="Delete" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>        
        <EmptyDataTemplate>
            <br /><p class="info_text">Your cart is empty.</p>
        </EmptyDataTemplate>
    </asp:GridView>
    
</asp:Content>
<%--Shopping footer--%>
<asp:Content ID="Content5" ContentPlaceHolderID="cpShoppingCartFooter" Runat="Server">
    <asp:Panel ID="panelFooter" runat="server" Visible="False" Height="76px">
        <table align="center" width="100%">
            <tr>
                <td valign="bottom" class="info_bold" colspan="2">
                    <hr noshade="noshade" />
                </td>
            </tr>
            <tr>
                <td valign="top" class="info_bold">
                    Subtotal:</td>
                <td valign="top">
                    <div align="right" class="info_bold">
                        <asp:Label ID="lblSubTotal" runat="server"></asp:Label></div>
                </td>                
            </tr>
            <tr valign="middle">
                <td height="37" colspan="2" align="center">
                    <asp:ImageButton ID="imgbtnCheckout" runat="server" AlternateText="Proceed to checkout"
                        ImageUrl="~/images/btn_checkout.gif" onclick="imgbtnCheckout_Click"  /></td>
            </tr>
        </table>
    </asp:Panel>    
</asp:Content>
<%--Flash part--%>
<asp:Content ID="Content6" ContentPlaceHolderID="flash" runat="Server">
    <table width="175" cellpadding="5">
        <tr>
            <td colspan="2">
                <span class="info_text">All web-based training courses require </span><span class="info_bold">
                    Adobe Flash Player.</span></td>
        </tr>
    </table>
    <table cellpadding="5" style="width: 203px; height: 70px">
        <tr>
            <td width="90">
                <div align="left">
                    <asp:Literal ID="ltrlFlashDetect" runat="server"></asp:Literal>
                </div>
            </td>
            <td width="57">
                <div align="right">
                    <span class="info_text">
                        <asp:LinkButton ID="lnkbtnFlashMoreInfo" runat="server">more info</asp:LinkButton></span></div>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="forumsID" runat="server" ContentPlaceHolderID="cphForums">
<div>  <asp:ImageButton ID="imgbtnForums" runat="server" AlternateText="In Your Cart" 
                    ImageUrl="~/images/headers/header_forums.png" onclick="imgbtnForums_Click" /> </div>

</asp:Content>
<%--Left side category/Catalog--%>
<asp:Content ID="Categories" ContentPlaceHolderID="cpCategory" Runat="Server">
    <asp:Image ID="imgCatalog" runat="server" AlternateText="Catalog"
                            ImageUrl="~/images/Headers/header_catalog.png" Height="57px" 
                            Width="205px"  />
    <div id="catalogColumn" align="left" style="width:205px;>
                        <asp:Panel ID="pnlCategory"  runat="server" Height="171px" Width="200px" 
                            align="left">
                        </asp:Panel> </div> 
</asp:Content>

