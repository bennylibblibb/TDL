<%@ Page language="c#" Codebehind="SendFrame.aspx.cs" AutoEventWireup="false" Inherits="CENTASMS.SendFrame" %>
<%@ Register TagPrefix="anthem" Namespace="Anthem" Assembly="Anthem" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Middle Dialog</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="CentaSmsStyle.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="SendFrame" method="post" runat="server">
			<table class="font" style="FILTER: Alpha(opacity=80)" borderColor="#cccccc" cellSpacing="1"
				cellPadding="5" width="100%" border="0">
				<TR>
					<TD><asp:image id="imgLoad" runat="server" ImageUrl="resource/indicator.gif"></asp:image></TD>
					<TD>
						<br>
						<anthem:label id="lbMsg" runat="server" ForeColor="Red" Width="144px"></anthem:label></TD>
				</TR>
			</table>
		</form>
	</body>
</HTML>
