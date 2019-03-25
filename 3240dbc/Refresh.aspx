<%@ Page language="c#" Codebehind="Refresh.aspx.cs" AutoEventWireup="false" Inherits="CENTASMS.Refresh" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Refresh</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<div id="Rdiv_load" runat="server">
				<table class="font" style="FILTER: Alpha(opacity=80)" borderColor="#cccccc" cellSpacing="1"
					cellPadding="5" width="100%" border="0">
					<TR>
						<TD style="WIDTH: 71px" height="1%">
							<P><asp:image id="imgLoad" runat="server" ImageUrl="resource/indicator.gif"></asp:image></P>
						</TD>
						<td height="1%">
							<P><asp:label id="lab_state" runat="server" ForeColor="Red" Width="192px"></asp:label></P>
						</td>
					</TR>
					<tr>
						<td colSpan="2" height="99%"><asp:label id="lbResult" runat="server" ForeColor="Red"></asp:label><FONT face="·s²Ó©úÅé">&nbsp;</FONT></td>
					</tr>
				</table>
			</div>
		</form>
	</body>
</HTML>
