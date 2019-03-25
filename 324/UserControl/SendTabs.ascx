<%@ Control Language="c#" AutoEventWireup="false" Codebehind="SendTabs.ascx.cs" Inherits="CENTASMS.UserControl.SendTabs" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Import namespace="CENTASMS"%>
<%@ Import namespace="CENTASMS.UserControl"%>
<%@ Register TagPrefix="anthem" Namespace="Anthem" Assembly="Anthem" %>
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
		<td vAlign="bottom"><anthem:DataList id="tabs" SelectedItemStyle-CssClass="admin-tab-active" ItemStyle-CssClass="admin-tab-inactive"
				runat="server" EnableViewState="False" RepeatDirection="Horizontal">
				<SelectedItemStyle CssClass="admin-tab-active"></SelectedItemStyle>
				<SelectedItemTemplate>
					<%# ((TabItem) Container.DataItem).Name %>
				</SelectedItemTemplate>
				<ItemStyle Height="36px" CssClass="admin-tab-inactive"></ItemStyle>
				<ItemTemplate>
					<a href='<%= Global.GetApplicationPath(Request) %>/<%# ((TabItem) Container.DataItem).Path %>'>
						<%# ((TabItem) Container.DataItem).Name %>
					</a>
				</ItemTemplate>
			</anthem:DataList></td>
	</tr>
</table>
