<%@ Import namespace="CENTASMS"%>
<%@ Page language="c#" Codebehind="InputSendByTime.aspx.cs" AutoEventWireup="false" Inherits="CENTASMS.InputSendByTime" %>
<%@ Register TagPrefix="anthem" Namespace="Anthem" Assembly="Anthem" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Middle Dialog</title>
		<script language="JavaScript" src="CalendarUtrl/Popup.js" type="text/javascript"></script>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="CentaSmsStyle.css" type="text/css" rel="stylesheet">
		<base target="_self">
		<meta http-equiv="PRAGMA" content="NO-CACHE">
		<meta http-equiv="CACHE-CONTROL" content="NO-CACHE">
		<meta http-equiv="EXPIRES" content="0">
		<script>
			function ShowExportPreview(pagePath, winAttrs) {
				window.showModalDialog(pagePath, '', winAttrs);
	        }
	        
	           function BtnEnable() 
			{
				  document.getElementById("btnSaveData").disabled =true;
			} 
			
			
 function CheckTime(obj) 
{   
var strvalue=(obj.value).replace(/(^\s*)|(\s*$)/g, ""); 
//var reg=/[9,5,6]{1}[0-9]{7}/; 
var reg=/^([0-1]\d|2[0-3]):[0-5]\d$/

if(reg.exec(strvalue))
{  
}else
{alert("請輸入正確時間！");
obj.focus();
return (false);
} 
 
}
	
	function CheckDate(obj) 
{   
    var strvalue = (obj.value).replace(/(^\s*)|(\s*$)/g, "");

    var reg = /^((((19|20)\d{2})-(0?(1|[3-9])|1[012])-(0?[1-9]|[12]\d|30))|(((19|20)\d{2})-(0?[13578]|1[02])-31)|(((19|20)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|((((19|20)([13579][26]|[2468][048]|0[48]))|(2000))-0?2-29))$/
    if (reg.exec(strvalue)) {
    } else {
        alert("請輸入正確日期！");
        obj.focus();
        return (false);
    } 
}
	
		</script>
	</HEAD>
	<body style="WIDTH: 500px; HEIGHT: 258px" bgColor="#edecd1" MS_POSITIONING="GridLayout">
		<form id="fmInput" method="post" runat="server">
			<hr align="center" width="400">
			<table id="tablea" style="WIDTH: 384px; HEIGHT: 125px" cellSpacing="0" cellPadding="0"
				align="center" border="0">
				<tr>
					<td style="HEIGHT: 125px">
						<table style="WIDTH: 327px; HEIGHT: 79px" cellSpacing="0" cellPadding="0" align="center"
							border="0">
							<tr>
							</tr>
							<tr>
							</tr>
							<tr>
								<td style="WIDTH: 72px" align="right"><STRONG>日期:</STRONG></td>
								<td style="WIDTH: 104px"><asp:textbox id="tbScheduleDate"  runat="server" onChange="return CheckDate(this)"  Width="120px"></asp:textbox><STRONG></STRONG></td>
								<td style="WIDTH: 69px" align="right"><FONT face="新細明體"><STRONG>時間:</STRONG></FONT></td>
								<td><asp:textbox id="tbTime" runat="server" Width="120px" onChange="return CheckTime(this)"></asp:textbox></td>
							</tr>
							<TR>
							</TR>
							<tr>
								<td style="WIDTH: 72px"><FONT face="新細明體">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</FONT></td>
								<td style="WIDTH: 104px" align="right"><FONT face="新細明體"></FONT></td>
								<td style="WIDTH: 69px" align="right"><FONT face="新細明體"><anthem:button id="btnSaveData" runat="server" Width="50px" Text="Save"></anthem:button></FONT></td>
								<TD align="center" valign="bottom">
									<IFRAME id="sendonframe" src="SendFrame.aspx" frameborder="no" scrolling="no" width="200"
										height="60"></IFRAME>
								</TD>
							</tr>
							<TR>
								<TD style="WIDTH: 68px"></TD>
								<TD style="WIDTH: 104px"><FONT face="新細明體">&nbsp;</FONT></TD>
								<TD style="WIDTH: 69px" align="right"><FONT face="新細明體"></FONT></TD>
								<TD align="left"></TD>
							</TR>
							<TR>
								<TD align="right" colSpan="4"></TD>
							</TR>
						</table>
					</td>
				</tr>
			</table>
			<HR align="center" width="400">
			</TR></TABLE></TR></TABLE></form>
	</body>
</HTML>
