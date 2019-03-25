<%@ Page language="c#" Codebehind="MemberofSent.aspx.cs" AutoEventWireup="false" Inherits="CENTASMS.MemberofSent" %>
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
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<table align="center">
				<TR align="center">
					<TD align="center">
						&nbsp;
					</TD>
				</TR>
				<tr align="center">
					<td align="center">
						<asp:DataGrid id="dgMembers" runat="server" AutoGenerateColumns="False" AllowPaging="True" Width="450px"
							Height="90%">
							<HeaderStyle Font-Bold="True" Wrap="False" BackColor="#EDECD1"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="ID">
									<HeaderStyle HorizontalAlign="Left" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="40px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<%#this.dgMembers.CurrentPageIndex * this.dgMembers.PageSize + Container.ItemIndex + 1%>
										<FONT face="新細明體"></FONT>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="CBATCHID">
									<HeaderStyle HorizontalAlign="Left" Width="80px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="80px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<%# DataBinder.Eval(Container, "DataItem.CBATCHID")%>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="IREC_NO" Visible ="false" >
						<HeaderStyle HorizontalAlign="Left" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
						<ItemStyle Width="40px" CssClass="grid-item"></ItemStyle>
						<ItemTemplate>
						<%# DataBinder.Eval(Container, "DataItem.IREC_NO") %>
							 
						</ItemTemplate>
					</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="組別名稱">
									<HeaderStyle HorizontalAlign="Left" Width="80px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="120px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<%# DataBinder.Eval(Container, "DataItem.CGROUP_NAME")%>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="成員號碼">
									<HeaderStyle HorizontalAlign="Left" Width="80px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="80px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<%# DataBinder.Eval(Container, "DataItem.CMOBILENO")%>
									</ItemTemplate>
								</asp:TemplateColumn>
								
								 <asp:TemplateColumn HeaderText="發送狀態" Visible="false" >
																<HeaderStyle Wrap="false" HorizontalAlign="Left" Width="60px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle CssClass="grid-item" Width="60px"></ItemStyle>
																<ItemTemplate>
																	<%# StringStatus(DataBinder.Eval(Container, "DataItem.IPRIORITY"))%>
																 </ItemTemplate>
															</asp:TemplateColumn>
															
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:DataGrid>
						<P><FONT face="新細明體"></FONT>&nbsp;</P>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
