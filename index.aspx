<%@ Page language="c#" Codebehind="index.aspx.cs" AutoEventWireup="false" Inherits="CENTASMS.index" %>
<%@ Register TagPrefix="uc1" TagName="MenuTabs" Src="UserControl/MenuTabs.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Telecom Digital SMS Services</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<SCRIPT LANGUAGE="javascript" FOR="document" EVENT="onkeypress"> if ( event.keyCode==34) event.returnValue = false;</SCRIPT>
		<LINK href="CentaSmsStyle.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="script.js"></script>
		<script type="text/javascript">   
        function change() {    
            var imgNode = document.getElementById("vimg");    
            imgNode.src = "CheckCode.asPx?t=" + (new Date()).valueOf();  // ??是 "WaterMark.ashx?t=" + (new Date()).valueOf(); ?句?可以改????，?里加???的??是?了防止??器?存的??    
        }    
		</script>
	</HEAD>
	<body>
		<form id="Reports" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td vAlign="top" background="resource/bars.gif" height="46"><UL>
							<LI>
								<DIV style="MARGIN-RIGHT: 0px" align="left"><FONT face="Arial" size="5" color="#ffffff"><STRONG>Telecom Digital SMS Services</STRONG></FONT></DIV>
							</LI>
						</UL>
					</td>
				</tr>
				<tr>
					<td class="tab-active" vAlign="top" height="15">
						<P align="left">
							<FONT color="#ffffff"><IMG height="15" src="resource/spacer.gif" width="15"></FONT>
							<asp:Label id="lbUser" runat="server"></asp:Label></P>
					</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr width="100%">
					<td width="8"><IMG height="8" src="resource/spacer.gif" width="8"></td>
					<td vAlign="top">
						<table class="admin-tan-border" height="100%" cellSpacing="0" cellPadding="0" width="100%"
							border="0">
							<tr>
								<td vAlign="top" style="WIDTH: 169px; HEIGHT: 20px">
									<img src="resource/CentaSmsLogo.JPG">
								</td>
								<td valign="top"><FONT face="新細明體">22222</FONT>
								</td>
							</tr>
							<tr valign="top">
								<td vAlign="top" style="WIDTH: 169px; HEIGHT: 400px">
									<uc1:MenuTabs id="MenuTabs1" runat="server"></uc1:MenuTabs></td>
								<td vAlign="top"><FONT face="新細明體"></FONT>
								</td>
							</tr>
							<TR>
								<TD vAlign="top" style="WIDTH: 169px; HEIGHT: 50px"><FONT face="新細明體">3333</FONT></TD>
								<TD vAlign="top"><FONT face="新細明體">4444444</FONT></TD>
							</TR>
						</table>
					</td>
					<td width="11"><IMG height="11" src="resource/spacer.gif" width="11"></td>
				</tr>
				<tr>
					<td vAlign="top" colSpan="5" height="15"><IMG height="15" src="resource/spacer.gif" width="15"></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
