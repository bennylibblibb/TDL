<%@ Register TagPrefix="anthem" Namespace="Anthem" Assembly="Anthem" %>
<%@ Page language="c#" Codebehind="AlertSmsData.aspx.cs" AutoEventWireup="false" Inherits="CENTASMS.AlertSmsData"  ValidateRequest="false" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>Telecom Digital SMS Services</TITLE>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<SCRIPT language="javascript" event="onkeypress" for="document"> if ( event.keyCode==34) event.returnValue = false;</SCRIPT>
		<LINK href="CentaSmsStyle.css" type="text/css" rel="stylesheet">
		<script type="text/javascript">   
		  
		function CountSmsContent()
		{
		 var txt =document.getElementById("txtSmsContent").value; 
		var nByte =CheckLength(txt); 
		var nChar=txt.length;
 
 if (nChar != nByte ){    
   document.getElementById("lbLen").innerHTML= nChar;
    document.getElementById("lbNum").innerHTML = CountSmsBig5(nChar);
 }  
 else {   
    document.getElementById("lbLen").innerHTML = nChar;  
    document.getElementById("lbNum").innerHTML = CountSmsNoBig5(nByte);
 }  
 
 }
 
function CheckLength(countMe) {   
document.getElementById("lbMsg").innerHTML ="";     
        var escapedStr = encodeURI(countMe)
        if (escapedStr.indexOf("%") != -1) {
            var count = escapedStr.split("%").length - 1
            if (count == 0) count++  //perverse case; can't happen with real UTF-8
            var tmp = escapedStr.length - (count * 3)
            count = count + tmp
        } else {
            count = escapedStr.length
        }
        //alert(escapedStr + ": size is " + count)
        return count;
}

function CountSmsBig5(nLen){

    if (nLen == 0)
      return 0;      
    else if (nLen <= 70)
      return 1;
    else if (nLen <= 134)
      return 2;
    else if (nLen <= 201)
      return 3;
    else if (nLen <= 268)      
      return 4;
    else if (nLen <= 335)
      return 5;
    else if (nLen <= 402)
      return 6;
    else if (nLen <= 469)
      return 7;
    else if (nLen <= 536)      
      return 8;
    else if (nLen <= 603)
      return 9;
    else if (nLen <= 670)      
      return 10;
      else{document.getElementById("lbMsg").innerHTML ='禬筁程才计670'}                                              
 
    return 0;                                                      
}


function CountSmsNoBig5(nLen) {
    if (nLen == 0)
      return 0;      
    else if (nLen <= 160) 
      return 1;
    else if (nLen <= 306)
      return 2;
    else if (nLen <= 459)
      return 3;
    else if (nLen <= 612)      
      return 4;
    else if (nLen <= 765)
      return 5;
    else if (nLen <= 918)
      return 6;
    else if (nLen <= 1071)
      return 7;
    else if (nLen <= 1224)      
      return 8;
    else if (nLen <= 1377)
      return 9;
    else if (nLen <= 1530)      
      return 10;                                              
   else{document.getElementById("lbMsg").innerHTML ='禬筁程才计1530'}          
    return 0;                                                    
}
		</script>
	</HEAD>
	<body onunload="opener.location.reload();">
		<FORM id="Form1" method="post" runat="server">
			<TABLE align="center">
				<TR align="center">
					<TD style="HEIGHT: 14px" align="center">&nbsp;&nbsp;
					</TD>
				</TR>
				<TR align="center">
					<TD align="center"><anthem:textbox onkeypress="CountSmsContent()" id="txtSmsContent" onkeydown="CountSmsContent()"
							onblur="CountSmsContent()" onkeyup="CountSmsContent()" runat="server" onChange="CountSmsContent()" TextMode="MultiLine"
							Width="380px" Height="280px" meta:resourcekey="txtSmsContentResource1"></anthem:textbox><FONT face="穝灿砰"></FONT></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="left" style="DISPLAY: none" ><asp:Literal runat="server" Text="<%$ Resources:SSMsgTotal %>"/>
						<anthem:label id="lbLen" runat="server" Width="20px" ForeColor="Red" meta:resourcekey="lbLenResource1">0</anthem:label><asp:Literal runat="server" Text="<%$ Resources:SSMsgTotal2 %>"/>
						<anthem:label id="lbNum" runat="server" Width="20px" ForeColor="Red" meta:resourcekey="lbNumResource1">0</anthem:label><asp:Literal runat="server" Text="<%$ Resources:SSMsgTotal3 %>"/>
						<asp:TextBox id="txtoldcontent" runat="server" Visible="False" meta:resourcekey="txtoldcontentResource1"></asp:TextBox>
					<TD></TD>
				<TR>
					<TD align="left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<anthem:button id="btnUpdate" runat="server" Text="э" meta:resourcekey="btnUpdateResource1"></anthem:button>&nbsp;
						<anthem:label id="lbMsg" runat="server" Width="130px" ForeColor="Red" meta:resourcekey="lbMsgResource1"></anthem:label><INPUT   id="btnCannel"  runat="server"  onclick="window.close();" type="button" value="闽超" meta:resourcekey="SSMsgTotal3"  >
					</TD>
				</TR>
			</TABLE>
		</FORM>
	</body>
</HTML>
