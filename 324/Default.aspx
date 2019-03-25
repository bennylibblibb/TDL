<%@ Page language="c#" Codebehind="Default.aspx.cs" AutoEventWireup="false" Inherits="CENTASMS._Default" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<%@ Register TagPrefix="uc1" TagName="SignIn" Src="UserControl/SignIn.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Telecom Digital SMS Services-Login</title>
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
         function Clear() 
			{ 
				 document.forms[0].SignIn1_UserID.value ="";
                 document.forms[0].SignIn1_txtValidate.value=""; 
				 document.forms[0].SignIn1_Password.value="";
				  document.getElementById("SignIn1_Message").innerHTML="";
				 }
		</script>
	    <style type="text/css">
            .auto-style1 {
                height: 403px;
            }
            .auto-style2 {
                width: 100px;
            }
        </style>
	</HEAD>
	<body OnLoad="document.forms[0].SignIn1_UserID.focus()">
		<form id="Reports" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0"  >
				<tr>
					<td class="top_bar01_bg"><img src="resource/mango_logo_title.gif" width="359" height="49">
					</td>
				</tr>
				<tr>
					<td class="top_bar02_bg"><IMG height="15" src="resource/spacer.gif" width="15"></td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="100%" border="0"  >
				<tr width="100%">
					<td vAlign="top">
						<table class="admin-tan-border" height="100%" cellSpacing="0" cellPadding="0" width="100%"
							border="0">
							<tr>
								<td height="20"><FONT face="新細明體"></FONT></td>
							</tr>
							<tr valign="top">
								<td align="center" valign="middle" class="auto-style1"><br>
									<table width="600" border="0" cellpadding="0" cellspacing="0">
										<tr>
											<td align="center" class="auto-style2"><img src="resource/login_left.gif" width="236" height="245"></td>
											<td width="1" class="line_bg"></td>
											<td width="300"><P>
													<uc1:SignIn id="SignIn1" runat="server"></uc1:SignIn></P>
											</td>
										</tr>
									</table>
									<br>
								</td>
							</tr>
							<tr bgcolor="#edecd1">
								<td class="bottom_bar_bg"><FONT face="新細明體"></FONT></td>
							</tr>
						</table>
					</td>
				</tr>
				</table>
			<TABLE id="Table10" width="90%" >
				<TR valign="top" style ="height:30px">
					<TD valign="top">
						<P align="left"><FONT color="#000000"><STRONG>  <asp:Literal ID="lDefaultTxt1" runat="server" Text="<%$ Resources:DefaultTxt1 %>"/>
									 </STRONG><br>
									<br>  
							</FONT> </P> </TD> 
				</TR>
                <tr  style ="height:60px">
                    <td>  <P align="left"> 
                            <asp:Literal ID="lDefaultTxt2" runat="server" Text="<%$ Resources:DefaultTxt2 %>"/>
						 <P/>  </td>
                </tr>
                <tr style ="height:30px" ><td> 
						<P style="LINE-HEIGHT: 150%" align="left"> 
                                 <SPAN class="style9"><BR>
								<IMG id="ctl00_image3" style="BORDER-TOP-WIDTH: 0px; BORDER-LEFT-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; WIDTH: 7px; HEIGHT: 7px; BORDER-RIGHT-WIDTH: 0px"
									src="resource/yellow.bmp"> <asp:Literal  ID="lDefaultTxt3" runat="server" Text="<%$ Resources:DefaultTxt3 %>"/><BR>
								<IMG id="ctl00_image4" style="BORDER-TOP-WIDTH: 0px; BORDER-LEFT-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; WIDTH: 7px; HEIGHT: 7px; BORDER-RIGHT-WIDTH: 0px"
									src="resource/images_41.gif"> <asp:Literal  ID="lDefaultTxt4" runat="server" Text="<%$ Resources:DefaultTxt4 %>"/></SPAN><SPAN class="style2" style="COLOR: #cc3333">[19/3/2018]</SPAN></P>
					
                    </td></tr>
			</TABLE> 
		</form>
	</body>
</HTML>
