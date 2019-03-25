<%@ Register TagPrefix="uc1" TagName="SendTabs" Src="UserControl/SendTabs.ascx" %>
<%@ Register TagPrefix="uc1" TagName="MenuTabs" Src="UserControl/MenuTabs.ascx" %>
<%@ Register TagPrefix="anthem" Namespace="Anthem" Assembly="Anthem" %>
<%@ Register TagPrefix="uc1" TagName="UserTabs" Src="UserControl/UserTabs.ascx" %>
<%@ Page language="c#" Codebehind="UserMaintenance.aspx.cs" AutoEventWireup="false" Inherits="CENTASMS.UserMaintenance" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Telecom Digital SMS Services</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<SCRIPT language="javascript" event="onkeypress" for="document"> if ( event.keyCode==34) event.returnValue = false;</SCRIPT>
		<LINK href="CentaSmsStyle.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="CalendarUtrl/Popup.js" type="text/javascript"></script>
		<script type="text/javascript">   
        function change() {    
            var imgNode = document.getElementById("vimg");    
            imgNode.src = "CheckCode.asPx?t=" + (new Date()).valueOf();  // 234, 261??是 "WaterMark.ashx?t=" + (new Date()).valueOf(); ?句?可以改????，?里加???的??是?了防止??器?存的??    
        }  
        
        	function ConfirmSendontime() 
			{
				if (confirm("Are you sure?")) 
				{
					return true;
				} 
            } 
            
            function Clear() 
			{
				 document.getElementById("txtSmsContent").innerHTML ="";
				  document.getElementById("tbNum").innerHTML ="";
           
            } 
            
            function ShowInputMiddle(pagePath, winAttrs) {
				window.showModalDialog(pagePath, '', winAttrs);
	        } 
	        
	          function   Focuss(  id,clear)    
		   {     
		   if(clear=='All')
		   {
		   if(id=='txtUserID1')
		   { 
		      document.getElementById("txtUserID1").value =""; 
		      document.getElementById("txtUserName1").value =""; 
		      document.getElementById("txtPwd1").value =""; 
		      document.getElementById("txtEmail1").value ="";  
		      document.getElementById("txtDepart1").value =""; 
		   } 
		   } 
		   document.getElementById(id).focus();
         }   

	        function  focusload()
  { 
 if (document.getElementById('txtUserID1')!=null)
 { 
   document.getElementById("txtUserID1").focus();
 }
 }
		</script>
	</HEAD>
	<body OnLoad="focusload()">
		<form id="fmSms" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="top_bar01_bg"><img src="resource/mango_logo_title.gif" width="359" height="49">
					</td>
				</tr>
				<tr>
					<td class="top_bar02_bg" vAlign="top" height="15">
						<P align="left"><FONT color="black" ><IMG height="15" src="resource/spacer.gif" width="15">
							<asp:Literal runat="server" Text="<%$ Resources:UMSearchUserName %>"/>&nbsp;<asp:label id="lbUser" runat="server"></asp:label></FONT></P>
					</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr width="100%">
					<td vAlign="top">
						<table class="admin-tan-border" id="table1" height="500" cellSpacing="0" cellPadding="0"
							width="100%" border="0">
							<tr>
								<td class="admin-table" style="HEIGHT: 10px" vAlign="top" height="5"><IMG height="15" src="resource/spacer.gif" width="15">
								</td>
								<td vAlign="top"><uc1:usertabs id="UserTabs1" runat="server"></uc1:usertabs></td>
							</tr>
							<TR vAlign="top">
								<TD style="WIDTH: 169px; HEIGHT: 100%" vAlign="top" class="left_bar_bg"><uc1:menutabs id="MenuTabs1" runat="server"></uc1:menutabs></TD>
								<TD vAlign="top"><anthem:panel id="panel1" runat="server" Visible="false">
										<TABLE class="tan-border02" style="WIDTH: 100%; BORDER-COLLAPSE: collapse; HEIGHT: 380px"
											cellSpacing="10" cellPadding="0" rules="none" align="left" border="0">
											<TR style="height:6px">
												<TD align="left" height="1"></TD>
												<TD align="left" height="1"></TD>
												<TD align="left" height="1"> </TD>
												<TD align="left" height="1"> </TD>
												<TD align="left" width="20%" height="1"></TD>
											</TR >
											<TR vAlign="middle" style="height:28px">
												<TD   align="left" height="1"><STRONG> <asp:Literal runat="server" Text="<%$ Resources:UMSearchUser %>"/></STRONG>
												</TD>
												<TD align="left" height="1"><asp:Literal runat="server" Text="<%$ Resources:UMSearchUserName %>"/> 
													<anthem:DropDownList id="dplUsers" runat="server" Width="120px" AutoCallBack="True">
														<asp:ListItem Value="All" Selected="True" meta:resourcekey="ListItemResource1" > </asp:ListItem>
													</anthem:DropDownList></TD>
												<TD align="left" height="1"><asp:Literal runat="server" Text="<%$ Resources:UMSelectDateFrom %>"/>
													<asp:TextBox id="txtStartDate" onclick="fPopUpDlg('CalendarUtrl/calendar.htm', document.fmSms.txtStartDate, 'winpop', 234, 261);return false"
														runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
													<asp:RequiredFieldValidator id="rfv" runat="server" ControlToValidate="dplUsers" ErrorMessage="*"></asp:RequiredFieldValidator></TD>
												<TD align="left" height="1"><asp:Literal runat="server" Text="<%$ Resources:UMSelectDateTo %>"/>
													<asp:TextBox id="txtEndDate" onclick="fPopUpDlg('CalendarUtrl/calendar.htm', document.fmSms.txtEndDate, 'winpop', 234, 261);return false"
														runat="server" Width="80px" ReadOnly="True"></asp:TextBox></TD>
												<TD align="left" width="20%" height="1">
														<anthem:Button id="btnSearch" runat="server"   meta:resourcekey="btnSearchResource1"></anthem:Button></TD>
											<TR>
												<TD vAlign="baseline" align="left" height="1"></TD>
												<TD align="left" height="1"></TD>
												<TD align="left" height="1"></TD>
												<TD align="left" height="1"></TD>
												<TD align="left" width="20%" height="1"></TD>
											</TR>
											<TR width="100%">
												<TD vAlign="top" align="left" width="50%" colSpan="5" height="256">
													<anthem:DataGrid id="dgData" runat="server" Width="98%"  AutoGenerateColumns="False" AllowPaging="True">
														<PagerStyle Mode="NumericPages"></PagerStyle>
														<HeaderStyle Font-Bold="True"></HeaderStyle>
														<Columns>
															<asp:TemplateColumn  >
																<HeaderStyle  Width="30px" HorizontalAlign="Left" Wrap="false" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle Width="30px" CssClass="grid-item"></ItemStyle>
																<ItemTemplate>
																	<%#this.dgData.CurrentPageIndex * this.dgData.PageSize + Container.ItemIndex + 1%>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="<%$ Resources:UMUserID %>" >
																<HeaderStyle Width="200px" Wrap="True" HorizontalAlign="Left" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle CssClass="grid-item" Width="200px" ></ItemStyle>
																<ItemTemplate>
																	<%# DataBinder.Eval(Container, "DataItem.USER_ID")%>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="<%$ Resources:UMUserName %>">
																<HeaderStyle Width="200px" Wrap="True" HorizontalAlign="Left" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle CssClass="grid-item" Width="200px"></ItemStyle>
																<ItemTemplate>
																	<%# DataBinder.Eval(Container, "DataItem.USER_NAME")%>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="<%$ Resources:UMUserRight %>">
																<HeaderStyle Width="200px" Wrap="True" HorizontalAlign="Left" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle CssClass="grid-item" Width="200px"></ItemStyle>
																<ItemTemplate>
																	<%# DataBinder.Eval(Container, "DataItem.SHAREDGP_RIGHT")%>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="<%$ Resources:UMUserEmail %>">
																<HeaderStyle Width="200px" Wrap="True" HorizontalAlign="Left" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle CssClass="grid-item" Width="200px"></ItemStyle>
																<ItemTemplate>
																	<%# DataBinder.Eval(Container, "DataItem.USER_EMAIL")%>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="<%$ Resources:UMUserDep %>">
																<HeaderStyle Width="200px" Wrap="True" HorizontalAlign="Left" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle CssClass="grid-item" Width="200px"></ItemStyle>
																<ItemTemplate>
																	<%# DataBinder.Eval(Container, "DataItem.DEPARTMENT")%>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="<%$ Resources:UMCreateDate %>">
																<HeaderStyle HorizontalAlign="Left" Width="200px" CssClass="grid-header" Wrap="True" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle CssClass="grid-item" Width="200px"></ItemStyle>
																<ItemTemplate>
																	<%# DataBinder.Eval(Container, "DataItem.CREATE_DATE")%>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
													</anthem:DataGrid></TD>
											</TR>
											<TR width="100%">
												<TD colSpan="5"> </TD>
											</TR>
										</TABLE>
									</anthem:panel>
                                    <anthem:panel id="panel2" runat="server" Visible="false">
									<TABLE class="tan-border02" style="WIDTH:100%; BORDER-COLLAPSE: collapse; HEIGHT: 380px"
											cellSpacing="10" cellPadding="0" rules="none" align="left" border="0"> 
											<TR vAlign="middle" style="height:6px">
												<TD   colSpan="6" ></TD>
											</TR>
											<TR vAlign="middle"   align="left" style="height:28px">
												<TD    colSpan="6" > <STRONG>&nbsp; 
															<asp:Literal runat="server" Text="<%$ Resources:UMNewUser %>"/></STRONG> 
												</TD>
											 </tr>
											<TR vAlign="middle" align="left" style="height:28px">
												<TD  style="WIDTH:60px"  ></TD>
                                                <TD style="WIDTH: 180px"    >
													 <asp:Label id="lbUserID1" runat="server" meta:resourcekey="lbUserID1Resource1"> </asp:Label>
														 </TD>
												<TD style="WIDTH:120px"    >
														<anthem:TextBox id="txtUserID1" runat="server" Width="120px"></anthem:TextBox>
                                                    
												</TD>
                                                <TD  style="WIDTH:100px"> <asp:RequiredFieldValidator id="Requiredfieldvalidator21" runat="server" Width="10px" ControlToValidate="txtUserID1"
															ErrorMessage="*"></asp:RequiredFieldValidator>
                                                                                                            </TD>  
												<TD style="WIDTH:180px"   >
													<asp:Label id="lbUserName1" runat="server" meta:resourcekey="lbUserName1Resource1"> </asp:Label>
													 </TD>
												 <TD  style="WIDTH:120px"  >
													<anthem:TextBox id="txtUserName1" runat="server" Width="120px"></anthem:TextBox>
                                                    <asp:RequiredFieldValidator id="Requiredfieldvalidator51" runat="server" Width="10px" ControlToValidate="txtUserName1"
														ErrorMessage="*"></asp:RequiredFieldValidator>
												</TD>
											</TR>
											<TR vAlign="middle"   align="left"  style="height:28px">
												<TD></TD>
                                                <TD   > 
													 <asp:Label id="lbPwd1"  width="120px"  runat="server" meta:resourcekey="lbPwd1Resource1"> </asp:Label>
													 </TD>
												<TD   >
													<anthem:TextBox id="txtPwd1" runat="server" Width="120px" TextMode="Password"> </anthem:TextBox>
                                                    	 
												</TD> 
                                                <TD ><asp:RequiredFieldValidator id="Requiredfieldvalidator41" runat="server" Width="10px" ControlToValidate="txtPwd1"
															ErrorMessage="*"></asp:RequiredFieldValidator>
                                                  </TD> 
												<TD>
                                                <asp:Label id="Label21" runat="server"   meta:resourcekey="Label21Resource1" > </asp:Label>
												</TD>
												<TD     >
													<anthem:DropDownList id="dplRight1" runat="server" Width="120px">
														<asp:ListItem Value="Y" Selected="True" meta:resourcekey="ListItemResource2"> </asp:ListItem>
														<asp:ListItem Value="N" meta:resourcekey="ListItemResource3" > </asp:ListItem>
													</anthem:DropDownList></TD>
											</TR>  
											<TR vAlign="middle"  align="left" style="height:28px">
												<TD  ></TD> 
                                                <TD    >
													 <asp:Label id="lbEmail" runat="server"  meta:resourcekey="lbEmailResource1" > </asp:Label>
														 </TD>
												<TD       >
														<anthem:TextBox id="txtEmail1" runat="server" Width="120px"></anthem:TextBox>
                                                  
												</TD> 
                                                <TD >   <asp:RegularExpressionValidator id="rvEmail" runat="server" Width="10px" ControlToValidate="txtEmail1" ErrorMessage="*"
															ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

                                                </TD> 
												<TD   >
													<asp:Label id="Label3" runat="server" Width="120px" meta:resourcekey="Label3Resource1" ></asp:Label>
													 
												</TD>
												<TD   >
													<anthem:TextBox id="txtDepart1" runat="server" Width="120px"></anthem:TextBox><asp:RequiredFieldValidator id="Requiredfieldvalidator7" runat="server" Width="10px" ControlToValidate="txtDepart1"
														ErrorMessage="*"></asp:RequiredFieldValidator></TD>
											</TR>
											<TR vAlign="middle" align="left" style="height:28px">
											 	<TD></TD>
												<TD></TD>
												<TD></TD>
												<TD></TD>
                                                <TD></TD>
												<TD  >
														<anthem:BUTTON id="btnNewUser" runat="server"  meta:resourcekey="btnNewUserResource1"></anthem:BUTTON>&nbsp;
														<anthem:Label id="lbMsg" runat="server" ForeColor="Red"></anthem:Label></TD>
											</TR>
											<TR vAlign="middle"  align="left" style="height:100px">
											 	<TD></TD>
												<TD></TD>
												<TD></TD>
												<TD></TD>
                                                <TD></TD>
                                                <TD></TD> 
											</TR>
										</TABLE>
									</anthem:panel>
                                    <anthem:panel id="panel3" runat="server" Visible="false">
									<TABLE class="tan-border02" style="WIDTH:100%; BORDER-COLLAPSE: collapse; HEIGHT: 380px"
											cellSpacing="10" cellPadding="0" rules="none" align="left" border="0"> 
											<TR vAlign="middle" style="height:6px">
												<TD   colSpan="6" ></TD>
											</TR>
											<TR vAlign="middle"   align="left" style="height:28px">
												<TD    colSpan="6" > <STRONG>&nbsp; 
															<asp:Literal runat="server" Text="<%$ Resources:UpdateNewUser %>"/>：&nbsp;</STRONG>
															<anthem:DropDownList id="dplUsersU" runat="server" Width="120px" AutoCallBack="True">
																<asp:ListItem Value="All" Selected="True">All</asp:ListItem>
															</anthem:DropDownList>
															<anthem:Button id="btnSearchU" runat="server" Visible="False"  meta:resourcekey="btnSearchUResource1"></anthem:Button> 
                                           	</TD>
											 </tr>
											<TR vAlign="middle" align="left" style="height:28px">
												<TD  style="WIDTH:60px"  ></TD>
                                                    <TD style="WIDTH: 180px"    >
														<asp:Label id="lbUserIDU" runat="server"  meta:resourcekey="lbUserID1Resource1"></asp:Label>
													 </TD>
											    	<TD style="WIDTH:120px">
														<anthem:TextBox id="txtUserIDU" runat="server" Width="120px" ReadOnly="True"></anthem:TextBox>
												</TD>
											    	<TD  style="WIDTH: 100px">	<asp:RequiredFieldValidator id="Requiredfieldvalidator12" runat="server" Width="10px" ControlToValidate="txtUserIDU"
															ErrorMessage="*"></asp:RequiredFieldValidator>
                                               												</TD>
                                                    <TD style="WIDTH:180px">
													<asp:Label id="lbUserNameU" runat="server" meta:resourcekey="lbUserNameUResource1"></asp:Label>
												 </TD>
												    <TD  style="WIDTH:120px"  >
													<anthem:TextBox id="txtUserNameU" runat="server" Width="120px"></anthem:TextBox>
                                                        	<asp:RequiredFieldValidator id="Requiredfieldvalidator8" runat="server" Width="10px" ControlToValidate="txtUserNameU"
														ErrorMessage="*"></asp:RequiredFieldValidator>
                                                        												    </TD>
											</TR>
											<TR vAlign="middle" align="left" style="height:28px">
												<TD></TD>
                                                <TD >
													<asp:Label id="lbPwdU" runat="server" Width="160px" Visible="true" meta:resourcekey="lbPwdUResource1"></asp:Label>
													 </TD>
												<TD  >
													<anthem:TextBox id="txtPwdU" runat="server" Width="120px"></anthem:TextBox>

												</TD>
												<TD> <asp:RequiredFieldValidator id="rfvPwdU" runat="server" Width="10px" ControlToValidate="txtPwdU" ErrorMessage="*"> </asp:RequiredFieldValidator>
												
                                                </TD>
                                                <TD >
													<asp:Label id="lbRightU" runat="server" Width="180px" meta:resourcekey="lbRightUResource1"></asp:Label>

                                                </TD>
												<TD  >
													<anthem:DropDownList id="dplRightU" runat="server" Width="120px">
														<asp:ListItem Value="Y" Selected="True" meta:resourcekey="ListItemResource5"> </asp:ListItem>
														<asp:ListItem Value="N" meta:resourcekey="ListItemResource6" > </asp:ListItem>
													</anthem:DropDownList></TD>
											</TR>
											<TR vAlign="middle" align="left" style="height:28px">
											<td></td>	
                                                <TD  >
														<asp:Label id="lbEmailU" runat="server"  meta:resourcekey="lbEmailUResource1"></asp:Label>
														 </TD>
												<TD  >
														<anthem:TextBox id="txtEmailU" runat="server" Width="120px"></anthem:TextBox>

												</TD>
										     	<td><asp:RegularExpressionValidator id="rvEmailU" runat="server" Width="10px" ControlToValidate="txtEmailU" ErrorMessage="*"
															ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

											</td>
                                               	<TD  >
													<asp:Label id="Label1" runat="server" Width="160px"  meta:resourcekey="Label1Resource1"></asp:Label>
													 </TD>
												<TD  >
													<anthem:TextBox id="txtDepartU" runat="server" Width="120px"></anthem:TextBox><asp:RequiredFieldValidator id="Requiredfieldvalidator11" runat="server" Width="10px" ControlToValidate="txtDepartU"
														ErrorMessage="*"></asp:RequiredFieldValidator></TD>
											</TR>
											<TR vAlign="middle" align="left" style="height:28px">
											 	<TD></TD>
                                                <TD></TD> 
                                                <TD></TD> 
												<TD></TD>
												<TD></TD>
												<TD>
												<anthem:BUTTON id="btnNewUserU" runat="server"  meta:resourcekey="btnNewUserUResource1"></anthem:BUTTON>&nbsp;
														<anthem:Label id="lbMsgU" runat="server" ForeColor="Red"></anthem:Label> 
												</TD>
											</TR>
											<TR vAlign="middle"  align="left" style="height:100px">
											 	<TD></TD>
												<TD></TD>
												<TD></TD>
												<TD></TD>
                                                <TD></TD>
                                                <TD></TD> 
											</TR>
										</TABLE>
									</anthem:panel>
                                    <anthem:panel id="panel4" runat="server" Visible="false">
										<TABLE class="tan-border02" style="WIDTH: 100%; BORDER-COLLAPSE: collapse; HEIGHT: 380px"
											cellSpacing="10" cellPadding="0" rules="none" align="left" border="0">
											<TR vAlign="middle" style="height:6px">
												<TD height="1" colSpan="4"></TD>
											</TR>
											<TR vAlign="middle" style="height:28px">
												<TD  align="left" colSpan="4" height="1"> <STRONG>&nbsp; <asp:Literal runat="server" Text="<%$ Resources:UMDeleteUser %>"/>：
														</STRONG> 
													<anthem:DropDownList id="dplUsersD" runat="server" Width="120px">
														<asp:ListItem Value="All" Selected="True">All</asp:ListItem>
													</anthem:DropDownList>
													<anthem:Button id="btnDelete" runat="server"  meta:resourcekey="btnDeleteResource1" ></anthem:Button>
													<anthem:Label id="lbMsgD" runat="server" ForeColor="Red"></anthem:Label></TD>
											<TR>
												<TD style="WIDTH: 98px; HEIGHT: 21px" vAlign="top" align="left" width="98" colSpan="4"
													height="21"></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 98px" vAlign="baseline" align="left" width="98" height="100"></TD>
												<TD style="WIDTH: 162px" vAlign="top" align="left" width="162" height="100"></TD>
												<TD style="WIDTH: 126px" align="left" height="100"></TD>
												<TD align="left" height="100"></TD>
											</TR>
										</TABLE>
									</anthem:panel></TD>
							</TR>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
