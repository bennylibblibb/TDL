<%@ Page language="c#" Codebehind="MmsTool.cs" AutoEventWireup="false" Inherits="CENTASMS.MmsTool" %>
<%@ Register TagPrefix="uc1" TagName="UserTabs" Src="UserControl/UserTabs.ascx" %>
<%@ Register TagPrefix="anthem" Namespace="Anthem" Assembly="Anthem" %>
<%@ Register TagPrefix="uc1" TagName="MenuTabs" Src="UserControl/MenuTabs.ascx" %>
<%@ Register TagPrefix="uc1" TagName="SendTabs" Src="UserControl/SendTabs.ascx" %>
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
		</script>
	</HEAD>
	<body>
		<form id="fmSms" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="top_bar01_bg"><img src="resource/mango_logo_title.gif" width="359" height="49">
					</td>
				</tr>
				<tr>
					<td class="top_bar02_bg" vAlign="top" height="15">
						<P align="left"><FONT color="#ffffff"><IMG height="15" src="resource/spacer.gif" width="15"></FONT>
							用戶:&nbsp;<asp:label id="lbUser" runat="server"></asp:label></P>
					</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="100%" border="1" height="500" class="tan-border01">
				<tr width="100%">
					<td vAlign="top">
						<table class="tan-border01" id="table1" height="100%" cellSpacing="0" cellPadding="0" width="100%"
							border="0" style="BORDER-COLLAPSE: collapse">
							<tr>
								<td class="admin-table" style="HEIGHT: 10px" vAlign="top" height="2"><IMG height="15" src="resource/spacer.gif" width="15">
								</td>
								<td style="HEIGHT: 36px" vAlign="top">
                                <anthem:LABEL id="lbMsg" runat="server" Width="200px" ForeColor="Red" Visible=false></anthem:LABEL> 
                                 </td>
							</tr>
							<TR vAlign="top">
								<TD style="WIDTH: 169px; HEIGHT: 100%" vAlign="top" class="left_bar_bg"><uc1:menutabs id="MenuTabs1" runat="server"></uc1:menutabs></TD>
								<TD vAlign="top" align="center">
									<TABLE class="tan-border01" cellSpacing="10" cellPadding="0" rules="none" align="left"
										border="0">
									
										<TR width="100%">
											<TD vAlign="top" align="center" width="50%" colSpan="5" height="256"><FONT face="新細明體">
													<anthem:panel id="plSendMsg" runat="server">
														 	<anthem:DataGrid id="dgSchedule" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False">
														<PagerStyle Mode="NumericPages"></PagerStyle>
														<HeaderStyle Font-Bold="True"></HeaderStyle>
														<EditItemStyle Height="36px"></EditItemStyle>
														<ItemStyle Height="36px" CssClass="grid-item"></ItemStyle>
														<Columns>
															<asp:TemplateColumn HeaderText="ID" Visible=false>
																<HeaderStyle HorizontalAlign="Left" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle Width="40px" CssClass="grid-item"></ItemStyle>
																<ItemTemplate> 
																 <%#this.dgSchedule.CurrentPageIndex * this.dgSchedule.PageSize + Container.ItemIndex + 1%>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="CBATCHID">
																<HeaderStyle HorizontalAlign="Left" Width="80px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle CssClass="grid-item" Width="80px"></ItemStyle>
																<ItemTemplate>
																	<anthem:Label id="lbBatchidD" runat="server" Visible =false Width="160px" Text='<%# DataBinder.Eval(Container, "DataItem.CBATCHID") %>'>
																	</anthem:Label>
																		<a href=# onclick=window.open('MemberofSent.aspx?Type=S&ID=<%# DataBinder.Eval(Container, "DataItem.CBATCHID") %>','','scrollbars=yes,width=500,height=360,top=300,left=300')>																	
																		<%# DataBinder.Eval(Container, "DataItem.CBATCHID")%>
																		</a>  
																</ItemTemplate>
															</asp:TemplateColumn> 
                                                            <asp:TemplateColumn HeaderText="Subject">
																<HeaderStyle HorizontalAlign="Left" Wrap="false" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle CssClass="grid-item"></ItemStyle>
																<ItemTemplate>
																<%# GetText((DataBinder.Eval(Container, "DataItem.CMMSSUBJECT")).ToString())%>
													            </ItemTemplate>
															</asp:TemplateColumn> 
															<asp:TemplateColumn HeaderText="內容">
																<HeaderStyle HorizontalAlign="Left" Wrap="false" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle CssClass="grid-item"></ItemStyle>
																<ItemTemplate> 
																<a  class="blacklineheight" href='SendByGroup.aspx?csindex=0&sIndex=0&CBATCHID=<%# DataBinder.Eval(Container, "DataItem.CBATCHID") %>'>
														        <%#  GetText((DataBinder.Eval(Container, "DataItem.CSMSMSG")).ToString())%>
													            </a>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="建立日期">
																<HeaderStyle HorizontalAlign="Left" Width="160px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle CssClass="grid-item" Width="160px"></ItemStyle>
																<ItemTemplate>
																	<%# DataBinder.Eval(Container, "DataItem.CREATE_DATE")%>
																</ItemTemplate>
															</asp:TemplateColumn>
															 
															<asp:ButtonColumn Text="刪除" CommandName="Delete" ItemStyle-Font-Bold="True">
															<HeaderStyle HorizontalAlign="Left" Width="60px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle Width="60px" CssClass="grid-item"></ItemStyle>
															</asp:ButtonColumn>
														</Columns>
													</anthem:DataGrid>
													</anthem:panel></FONT></TD>
										</TR>
										<TR height="100%" width="100%">
											<TD colSpan="5"><FONT face="新細明體"></FONT></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
