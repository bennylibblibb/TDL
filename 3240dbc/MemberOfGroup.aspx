<%@ Page language="c#" Codebehind="MemberOfGroup.aspx.cs" AutoEventWireup="false" Inherits="CENTASMS.MemberOfGroup" %>
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
		<form id="Form1" method="post" runat="server"> 
			<asp:DataGrid id="dgMembers" style="Z-INDEX: 101; LEFT: 16px; POSITION: absolute; TOP: 24px" runat="server"
				AutoGenerateColumns="False" AllowPaging="True" Width="100%">
				<PagerStyle Mode="NumericPages"></PagerStyle>
				<EditItemStyle Height="36px"></EditItemStyle>
				<ItemStyle Height="36px"></ItemStyle>
				<HeaderStyle Font-Bold="True" Wrap="False"></HeaderStyle>
				<Columns>
					<asp:TemplateColumn HeaderText="ID">
						<HeaderStyle HorizontalAlign="Left" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
						<ItemStyle Width="40px" CssClass="grid-item"></ItemStyle>
						<ItemTemplate>
							<%#this.dgMembers.CurrentPageIndex * this.dgMembers.PageSize + Container.ItemIndex + 1%>
							<FONT face="新細明體"></FONT>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="ITEM_NO">
						<HeaderStyle HorizontalAlign="Left" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
						<ItemStyle Width="40px" CssClass="grid-item"></ItemStyle>
						<ItemTemplate>
						<%# DataBinder.Eval(Container, "DataItem.IITEM_NO") %>
							 
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<HeaderStyle HorizontalAlign="Left" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
						<ItemStyle Width="120px" CssClass="grid-item"></ItemStyle>
						<HeaderTemplate>
							<FONT face="新細明體">組別名稱</FONT>
						</HeaderTemplate>
						<ItemTemplate>
							<asp:Label id=lbGroupNameP runat="server" Width="120px" Text='<%# DataBinder.Eval(Container, "DataItem.cgroup_name") %>'>
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="成員名稱">
						<HeaderStyle HorizontalAlign="Left" Width="80px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
						<ItemStyle Width="40px" CssClass="grid-item"></ItemStyle>
						<ItemTemplate>
							<%# DataBinder.Eval(Container, "DataItem.CMEMBER_NAME")%>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="成員號碼">
						<HeaderStyle HorizontalAlign="Left" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
						<ItemStyle Width="40px" CssClass="grid-item"></ItemStyle>
						<ItemTemplate>
							<%# DataBinder.Eval(Container, "DataItem.CMOBILENO")%>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="添加日期">
						<HeaderStyle HorizontalAlign="Left" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
						<ItemStyle Width="160px" CssClass="grid-item"></ItemStyle>
						<ItemTemplate>
							<%# DataBinder.Eval(Container, "DataItem.create_date")%>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:EditCommandColumn Visible="False" ItemStyle-Font-Bold="True" ButtonType="LinkButton" UpdateText="更新"
						CancelText="取消" EditText="編輯">
						<HeaderStyle HorizontalAlign="Left" Width="60px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
						<ItemStyle Width="60px" CssClass="grid-item"></ItemStyle>
					</asp:EditCommandColumn>
					<asp:ButtonColumn Text="刪除" Visible="False" ItemStyle-Font-Bold="True" CommandName="Delete">
						<HeaderStyle HorizontalAlign="Left" Width="60px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
						<ItemStyle Width="60px" CssClass="grid-item"></ItemStyle>
					</asp:ButtonColumn>
				</Columns>
			</asp:DataGrid>
		</form>
	</body>
</HTML>
