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
						<DIV id="divView" runat="server" align="left"><FONT face="�s�ө���"> &nbsp;�I��</FONT>
							<asp:LinkButton id="lbtnView" runat="server">�O��</asp:LinkButton><FONT face="�s�ө���">�H�d�ݤw���O��</FONT></DIV>
						<DIV id="divStatus" runat="server"><FONT face="�s�ө���"> &nbsp;�I��</FONT>
							<asp:LinkButton id="LbtnRefresh" runat="server">��s</asp:LinkButton><FONT face="�s�ө���">�H�d�ݤW�Ǫ��A</FONT></DIV>
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
										<FONT face="�s�ө���">���W��</FONT>
									</HeaderTemplate>
									<ItemTemplate>
										<asp:Label id=lbGroupNameP runat="server" Width="160px" Text='<%# DataBinder.Eval(Container, "DataItem.CSMS_ACTION_CONTENT") %>'>
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="���A">
									<HeaderStyle HorizontalAlign="Left" Width="60px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="60px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<FONT face="�s�ө���" color="red">
											<%# DataBinder.Eval(Container, "DataItem.CSMS_ACTION_STATUS")%>
										</FONT>
									</ItemTemplate>
									<EditItemTemplate>
										<FONT face="�s�ө���"></FONT>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="�ާ@��">
									<HeaderStyle HorizontalAlign="Left" Width="60px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="60px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<%# DataBinder.Eval(Container, "DataItem.CACTION_HANDLER")%>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="�W�Ǥ��">
									<HeaderStyle HorizontalAlign="Left" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="150px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<%# DataBinder.Eval(Container, "DataItem.ACTION_STARTTIME")%>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="�������">
									<HeaderStyle HorizontalAlign="Left" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="150px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<%# DataBinder.Eval(Container, "DataItem.ACTION_ENDTIME")%>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:ButtonColumn Visible="False" Text="�R��" CommandName="Delete">
									<HeaderStyle HorizontalAlign="Left" Width="20px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Font-Bold="True" Width="20px" CssClass="grid-item"></ItemStyle>
								</asp:ButtonColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:DataGrid>
					</td>
				</tr>
				<TR>
					<TD align="left"><FONT face="�s�ө���">&nbsp;</FONT></TD>
				</TR>
				<TR>
					<TD align="left">
						<asp:label id="lbResult" runat="server" ForeColor="Red"></asp:label></TD>
				</TR>
			</table>
		</form>
	</body>
</HTML>
