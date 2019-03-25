<%@ Page language="c#" Codebehind="SendRefresh.aspx.cs" AutoEventWireup="false" Inherits="CENTASMS.SendRefresh" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SendRefresh</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table class="font" style="FILTER: Alpha(opacity=80)" borderColor="#cccccc" cellSpacing="1"
				cellPadding="5" width="100%" border="0">
				<TR>
					<TD style="WIDTH: 71px" height="1%">
						<P><asp:image id="imgLoad" runat="server" ImageUrl="resource/indicator.gif"  ></asp:image></P>
					</TD>
					<td height="1%">
						<P><asp:label id="lab_state" runat="server" ForeColor="Red" Width="192px"></asp:label></P>
					</td>
				</TR>
			</table>
		</form>
	</body>
</HTML>
