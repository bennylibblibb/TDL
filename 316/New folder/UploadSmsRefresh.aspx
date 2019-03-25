<%@ Page language="c#" Codebehind="UploadSmsRefresh.cs" AutoEventWireup="false" Inherits="CENTASMS.UploadSmsRefresh" %>
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
	<body MS_POSITIONING="GridLayout">
		<form id="UploadFrom" method="post" runat="server">
			<table align="left">
				<tr>
					<td height="30" align="left">
						<DIV id="divView" runat="server" align="left"><FONT face="新細明體"> &nbsp;點擊</FONT>
							<asp:LinkButton id="lbtnView" runat="server">記錄</asp:LinkButton><FONT face="新細明體">以查看已往記錄</FONT></DIV>
						<DIV id="divStatus" runat="server"><FONT face="新細明體"> &nbsp;點擊</FONT>
							<asp:LinkButton id="LbtnRefresh" runat="server">刷新</asp:LinkButton><FONT face="新細明體">以查看上傳狀態</FONT></DIV>
					</td>
				</tr>
				<tr align="center">
					<td align="left"><asp:DataGrid id="dgActions" runat="server" AutoGenerateColumns="False" AllowPaging="True" Width="100%">
							<HeaderStyle Font-Bold="True" Wrap="False"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="ID">
									<HeaderStyle HorizontalAlign="Left" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="40px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<%# DataBinder.Eval(Container, "DataItem.ISMS_IREC_NO") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn>
									<HeaderStyle HorizontalAlign="Left" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="160px" CssClass="grid-item"></ItemStyle>
									<HeaderTemplate>
										<FONT face="新細明體">文件名稱</FONT>
									</HeaderTemplate>
									<ItemTemplate>
										<asp:Label id=lbGroupNameP runat="server" Width="160px" Text='<%# DataBinder.Eval(Container, "DataItem.CSMS_ACTION_CONTENT") %>'>
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="狀態">
									<HeaderStyle HorizontalAlign="Left" Width="60px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="60px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<FONT face="新細明體" color="red">
											<%# DataBinder.Eval(Container, "DataItem.CSMS_ACTION_STATUS")%>
										</FONT>
									</ItemTemplate>
									<EditItemTemplate>
										<FONT face="新細明體"></FONT>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="操作員">
									<HeaderStyle HorizontalAlign="Left" Width="60px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="60px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<%# DataBinder.Eval(Container, "DataItem.CACTION_HANDLER")%>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="上傳日期">
									<HeaderStyle HorizontalAlign="Left" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="150px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<%# DataBinder.Eval(Container, "DataItem.ACTION_STARTTIME")%>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="完成日期">
									<HeaderStyle HorizontalAlign="Left" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="150px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<%# DataBinder.Eval(Container, "DataItem.ACTION_ENDTIME")%>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:ButtonColumn Visible="False" Text="刪除" CommandName="Delete">
									<HeaderStyle HorizontalAlign="Left" Width="20px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Font-Bold="True" Width="20px" CssClass="grid-item"></ItemStyle>
								</asp:ButtonColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:DataGrid>
					</td>
				</tr>
				<TR>
					<TD align="left"><FONT face="新細明體">&nbsp;</FONT></TD>
				</TR>
				<TR>
					<TD align="left">
						<asp:label id="lbResult" runat="server" ForeColor="Red"></asp:label></TD>
				</TR>
			</table>
		</form>
	</body>
</HTML>
