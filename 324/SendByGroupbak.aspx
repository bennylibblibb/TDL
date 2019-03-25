<%@ Register TagPrefix="ajax" Namespace="Ajax" Assembly="AjaxLib" %>
<%@ Register TagPrefix="uc1" TagName="MenuTabs" Src="UserControl/MenuTabs.ascx" %>
<%@ Page language="c#" Codebehind="SendByGroup.aspx.cs" AutoEventWireup="false" Inherits="CENTASMS.SendByGroup" %>
<%@ Register TagPrefix="uc1" TagName="SendTabs" Src="UserControl/SendTabs.ascx" %>
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
		<script language="JavaScript" src="CalendarUtrl/Popup.js" type="text/javascript"></script>
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
//document.getElementById("lbMsg").innerHTML ="";     
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
    else if (nLen > 670) 
     document.getElementById("lbMsg").innerHTML ='超過最大字符數670！';                                             
 
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
      else if (nLen > 1530)                                              
     document.getElementById("lbMsg").innerHTML ='超過最大字符數1530！';        
    return 0;                                                    
}


        function change() {    
            var imgNode = document.getElementById("vimg");    
            imgNode.src = "CheckCode.asPx?t=" + (new Date()).valueOf();  // 234, 261??是 "WaterMark.ashx?t=" + (new Date()).valueOf(); ?句?可以改????，?里加???的??是?了防止??器?存的??    
        }  
        
     
            
           function myKeyDown()
{
 //document.getElementById("lbMsg").innerHTML ="";
    var    k=window.event.keyCode;   

    if ((k==46)||(k==8)||(k==189)||(k==109)||(k==190)||(k==110)|| (k>=48 && k<=57)||(k>=96 && k<=105)||(k>=37 && k<=40)) 
    {}
    else if(k==13){
         window.event.keyCode = 13;}//9 tab
    else{
         window.event.returnValue = false;}
} 



     function myKeyChange(obj)
     {   
     var original=obj.value; 
     var regex='\r\n';  
     var tempArray1 =original.split(regex); 
   var tempArray = new Array();
   var j=0;
    for (i=0;i<tempArray1.length;i++)
{ 
if(tempArray1[i] !='')
{ 
tempArray[j]=tempArray1[i];
j++; 
}
}
 
  for (i=0;i<tempArray.length;i++)
{
    if(tempArray[i].indexOf('組別')>-1)
    {
    }else
    {
  var strvalue= tempArray[i];
  var reg=/[9,5,6,7,8]{1}[0-9]{7}/;

    if(reg.exec(strvalue)||strvalue=="")
{  
if  (strvalue.length != 8)
{
alert("電話號碼位數不正確！"); 
return (false);
}
}else
{alert("請輸入正確號碼！");

return (false);
} 
    }
} 
}
    
			
dFeatures = 'dialogHeight: 450px; dialogWidth: 1049px; dialogTop: 646px; dialogLeft: 4px; edge: Raised; center: Yes; help: Yes; resizable: Yes; status: Yes;';//default features

modalWin = "";
function xShowModalDialog( sURL, vArguments, sFeatures )
{
if (sURL==null||sURL=='')
{
alert ("Invalid URL input.");
return false;
}
if (vArguments==null||vArguments=='')
{
vArguments='';
}
if (sFeatures==null||sFeatures=='')
{
sFeatures=dFeatures;
}
if (window.navigator.appVersion.indexOf("MSIE")!=-1)
{
window.showModalDialog ( sURL, vArguments, sFeatures );
return false;
}
sFeatures = sFeatures.replace(/ /gi,'');
aFeatures = sFeatures.split(";");
sWinFeat = "directories=0,menubar=0,titlebar=0,toolbar=0,";
for ( x in aFeatures )
{
aTmp = aFeatures[x].split(":");
sKey = aTmp[0].toLowerCase();
sVal = aTmp[1];
switch (sKey)
{
case "dialogheight":
sWinFeat += "height="+sVal+",";
pHeight = sVal;
break;
case "dialogwidth":
sWinFeat += "width="+sVal+",";
pWidth = sVal;
break;
case "dialogtop":
sWinFeat += "screenY="+sVal+",";
break;
case "dialogleft":
sWinFeat += "screenX="+sVal+",";
break;
case "resizable":
sWinFeat += "resizable="+sVal+",";
break;
case "status":
sWinFeat += "status="+sVal+",";
break;
case "center":
if ( sVal.toLowerCase() == "yes" )
{
sWinFeat += "screenY="+((screen.availHeight-pHeight)/2)+",";
sWinFeat += "screenX="+((screen.availWidth-pWidth)/2)+",";
}
break;
}
}
modalWin=window.open(String(sURL),"",sWinFeat);
if (vArguments!=null&&vArguments!='')
{
modalWin.dialogArguments=vArguments;
}
}
    
    function ShowOrderContact(pagePath, winAttrs) 
			{
				xShowModalDialog(pagePath, '', winAttrs);
	        } 
    
            function Clear() 
			{
				  document.getElementById("txtSmsContent").innerHTML ="";
				  document.getElementById("tbNum").innerHTML ="";
                  document.getElementById("lbNum").innerHTML ="0";
				  document.getElementById("lbLen").innerHTML ="0"; 
				 
				 } 
            
            function ShowInputMiddle(pagePath, winAttrs) {
				window.showModalDialog(pagePath, '', winAttrs);
	        } 
	        
	        function  focusload()
  { 
 if (document.getElementById('txtSmsContent')!=null)
 { 
   document.getElementById("txtSmsContent").focus();
 }
  if (document.getElementById('txtUserLogion')!=null)
 { 
   document.getElementById("txtUserLogion").focus();
 }
 }
 
  function   Focus(  id)    
		   { 
		    document.getElementById(id).focus();
		   }
 
		</script>
	</HEAD>
	<body onload="focusload()" >
		<form id="fmSms" method="post"   runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
						<td class="top_bar01_bg"><img src="resource/mango_logo_title.gif" width="359" height="49">
					</td>
				</tr>
				<tr>
					<td class="top_bar02_bg" vAlign="top" height="15">
						<P align="left"><FONT color="#ffffff"><IMG height="15" src="resource/spacer.gif" width="15"></FONT>
							用戶:&nbsp;<asp:label id="lbUser" runat="server"></asp:label></P>
					</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr width="100%">
					<td vAlign="top">
						<table class="admin-tan-border" id="table1" height="500" cellSpacing="0" cellPadding="0"
							width="100%" border="0">
							<tr>
								<td class="admin-table" style="HEIGHT: 10px" vAlign="top" height="2"><IMG height="15" src="resource/spacer.gif" width="15">
								</td>
								<td style="HEIGHT: 2px" vAlign="top"><FONT face="新細明體"><uc1:sendtabs id="SendTabs1" runat="server"></uc1:sendtabs></FONT></td>
							</tr>
							<TR vAlign="top">
								<TD style="WIDTH: 169px; HEIGHT: 100%" vAlign="top" class="left_bar_bg"><uc1:menutabs id="MenuTabs1" runat="server"></uc1:menutabs></TD>
								<TD vAlign="top" class="tan-border02">
								
								<ajax:panel id="plSendLogion" runat="server">
														<TABLE id="Table2" style="WIDTH: 399px; HEIGHT: 182px" height="182" cellSpacing="0" cellPadding="0"
															width="399" border="0">
															<TR>
																<TD style="HEIGHT: 30px" width="14"><FONT face="新細明體"></FONT></TD>
																<TD style="HEIGHT: 30px">
																	<ASP:LABEL id="lbUserLogion" runat="server">用戶ID：</ASP:LABEL>
																	<ajax:DropDownList id="Dropdownlist1" runat="server" Width="100px" AutoCallBack="True"  Visible="false">
														<asp:ListItem Value="All" Selected="True">All</asp:ListItem></ajax:DropDownList>
													<asp:RequiredFieldValidator id="Requiredfieldvalidator2" runat="server" ErrorMessage="*" ControlToValidate="Dropdownlist1"></asp:RequiredFieldValidator>
																	</TD>
															</TR>
															<TR>
																<TD style="HEIGHT: 30px" width="14"></TD>
																<TD style="HEIGHT: 30px">
																	<ASP:TEXTBOX id="txtUserLogion" runat="server" Width="200px" CssClass="safari-midtextbox" MaxLength="11"
																		 ></ASP:TEXTBOX>
																	</TD>
															</TR>
															<TR>
																<TD style="HEIGHT: 30px" width="14">&nbsp;</TD>
																<TD style="HEIGHT: 30px">
																	<ASP:LABEL id="lbUserPWLogion" runat="server">用戶密碼：</ASP:LABEL></TD>
															</TR>
															<TR vAlign="top">
																<TD style="HEIGHT: 35px" width="14">&nbsp;</TD>
																<TD style="HEIGHT: 35px">
																	<ASP:TEXTBOX id="txtUserPWLogion" runat="server" Width="200px" CssClass="safari-midtextbox" MaxLength="21"
																		 TextMode="Password" ></ASP:TEXTBOX>
																	</TD>
															</TR>
															<TR>
																<TD style="HEIGHT: 25px" width="14">&nbsp;</TD>
																<TD style="HEIGHT: 25px">
			<script type="text/javascript">    
            function Clear() 
			{
				 document.getElementById("txtUserLogion").value ="";
				  document.getElementById("txtUserPWLogion").value =""; 
            }  
		</script>
																	<AJAX:BUTTON id="SaveLogin" runat="server" Width="64px" Text="登入"></AJAX:BUTTON>&nbsp;&nbsp;&nbsp;<INPUT id="btnCannelLogin" onclick="Clear()" type="button" value="重置" name="btnCannelLogin">&nbsp;&nbsp;
																	<AJAX:LABEL id="lbMsgError" runat="server" ForeColor="Red"></AJAX:LABEL></TD>
															</TR>
														</TABLE>
													</ajax:panel>
													
								<ajax:panel id="plSendMsg" runat="server" Visible="false">
										<TABLE style="WIDTH: 500px; BORDER-COLLAPSE: collapse; HEIGHT: 380px;" 
											cellSpacing="10" cellPadding="0" rules="none" align="left" border="0">
											<TR>
												<TD vAlign="top" align="left"  colspan=4  height="1">
												<AJAX:LABEL id="lbMsgLogin" runat="server" ForeColor="Red"></AJAX:LABEL>
												<ajax:Button id="btnLoginOut" runat="server" Text="登出" Visible="false" ></ajax:Button>
												 &nbsp;</TD>
												 
											</TR>
											<TR vAlign="top" width="100%">
												<TD vAlign="top" align="left" width="50%" height="1">短訊內容：
													<asp:RequiredFieldValidator id="rfvMsg" runat="server" ErrorMessage="|" ControlToValidate="txtSmsContent" Enabled="False"></asp:RequiredFieldValidator>
													<ajax:Label id="lbrfvContent" runat="server" Visible="false" ForeColor="Red">*</ajax:Label></TD>
												<TD></TD>
												<TD vAlign="top" align="left" width="28%" height="1">發送號碼：
													<asp:RequiredFieldValidator id="rfvNum" runat="server" ErrorMessage="|" ControlToValidate="tbNum" Enabled="False"></asp:RequiredFieldValidator>
													<ajax:Label id="lbrfvNum" runat="server" Visible="false" ForeColor="Red">*</ajax:Label></TD>
												<TD vAlign="top" align="left" width="22%" height="1">
													<ajax:Label id="lbSendGroup" runat="server">發送組別：</ajax:Label></TD>
											<TR width="100%">
												<TD vAlign="top" align="left" width="50%" height="256">
													<ajax:TextBox onkeypress="CountSmsContent()" id="txtSmsContent" onkeydown="CountSmsContent()"
														onblur="CountSmsContent()" onkeyup="CountSmsContent()"  runat="server" onChange="CountSmsContent()" TextMode="MultiLine"
														Width="380px" Height="264px"></ajax:TextBox></TD>
												<TD vAlign="middle" align="center">
												</TD>
												<TD vAlign="top" align="left" width="28%" height="256">
													<ajax:TextBox id="tbNum" onkeydown="myKeyDown()" style="IME-MODE: disabled" runat="server" onChange=" return myKeyChange(this)"
														TextMode="MultiLine" Width="210px" Height="264px"></ajax:TextBox>
														<AJAX:Label id="lbGroupIDContent"   Visible="False" runat="server"  ></AJAX:Label></TD>
												<TD vAlign="top" align="left" width="22%" height="256">
													<ajax:ListBox id="lstGroup" runat="server" Width="190px" Height="100%" AutoCallBack="True"></ajax:ListBox>
													
													</TD>
											
											</TR>
											<TR width="100%">
												<TD vAlign="top" align="left" width="50%" height="1">共
													<ajax:Label id="lbLen" runat="server" ForeColor="Red" Width="10px">0</ajax:Label>字元，短訊分：
													<ajax:Label id="lbNum" runat="server" ForeColor="Red" Width="10px">0</ajax:Label>條發送。<ajax:Label id="lbMsg" runat="server" ForeColor="Red"  Width="128px"></ajax:Label> 
													<asp:Button id="btnCount" runat="server" Visible =False   Text="計算長度"></asp:Button></TD>
												<TD></TD>
												<TD vAlign="top" align="left" width="28%" height="1"><FONT face="新細明體"></FONT></TD>
												<TD vAlign="top" align="left" width="22%" height="1"><FONT face="新細明體"></FONT></TD>
											</TR>
											<TR>
												<TD vAlign="baseline" align="left" width="50%" height="1">
													<P><FONT face="新細明體">預設時間：
															<ajax:RadioButton id="rbSendontime" runat="server" Visible="true" Text="即時發送" AutoCallBack="True"
																Checked="True"></ajax:RadioButton>
															<ajax:RadioButton id="rbSendbyTime" runat="server" Visible="true" Text="預設發送" AutoCallBack="True"></ajax:RadioButton></FONT></P>
													 												</TD>
												<TD></TD>
												<TD vAlign="top" align="left" width="28%" height="1"></TD>
												<TD vAlign="top" align="left" width="22%" height="1"><FONT face="新細明體"></FONT></TD>
											</TR>
											<TR >
												<TD  align="left" width="50%" height="1">
												<table  ><tr >
												<td  ><ajax:Button id="btnSend" runat="server" Text="發送"></ajax:Button></td>
												<td vAlign="top" align=left  width="200px"  >
												<DIV  id="div_load" runat="server"   > <IFRAME  id ="sendiframe" src="sendRefresh.aspx"  frameborder=no  scrolling =no  width ="200px" height ="60px"  ></iframe></div></td>
												<td  align=left  > <asp:Button id="btnCannel" runat="server"  Text="重置"></asp:Button></td>
												</tr></table>
													
												</TD>
												<TD></TD>
												<TD vAlign="top" align="left" width="28%" height="1"></TD>
												<TD vAlign="top" align="left" width="22%" height="1"><FONT face="新細明體"><INPUT id="btnCCannel" style="DISPLAY: none" onclick="Clear()" type="button" value="重置"></FONT></TD>
											</TR>
										</TABLE>
									</ajax:panel><asp:panel id="plMsgData" runat="server" Visible="false">
										<TABLE style="WIDTH: 100%; BORDER-COLLAPSE: collapse; HEIGHT: 380px;" 
											cellSpacing="10" cellPadding="0" rules="none" align="left" border="0">
											<TR vAlign="middle" width="100%">
												<TD vAlign="baseline" align="left" height="1">
													<P><STRONG>即時發送記錄：</STRONG></P>
												</TD>
												<TD align="left" height="1">用戶：
													<ajax:DropDownList id="dplUsers" runat="server" Width="100px" AutoCallBack="True">
														<asp:ListItem Value="All" Selected="True">All</asp:ListItem>
													</ajax:DropDownList></TD>
												<TD align="left" height="1">日期從：
													<asp:TextBox id="txtStartDate" onclick="fPopUpDlg('CalendarUtrl/calendar.htm', document.fmSms.txtStartDate, 'winpop', 234, 261);return false"
														runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
													<asp:RequiredFieldValidator id="rfv" runat="server" ErrorMessage="*" ControlToValidate="dplUsers"></asp:RequiredFieldValidator></TD>
												<TD align="left" height="1">到：
													<asp:TextBox id="txtEndDate" onclick="fPopUpDlg('CalendarUtrl/calendar.htm', document.fmSms.txtEndDate, 'winpop', 234, 261);return false"
														runat="server" Width="80px" ReadOnly="True"></asp:TextBox></TD>
												<TD align="left" width="15%" height="1"><FONT face="新細明體">
														<ajax:Button id="btnSearch" runat="server" Text="查詢"></ajax:Button>
														<asp:Button id="btnExportSms1" runat="server" Text="匯出"></asp:Button>
														</FONT></TD>
											<TR>
												<TD vAlign="baseline" align="left" height="1"></TD>
												<TD align="left" height="1"></TD>
												<TD align="left" height="1"></TD>
												<TD align="left" height="1"></TD>
												<TD align="left" width="15%" height="1"></TD>
											</TR>
											<TR width="100%">
												<TD vAlign="top" align="left" width="50%" colSpan="5" height="256">
													<ajax:DataGrid id="dgSmsData" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False">
														<PagerStyle Mode="NumericPages"></PagerStyle>
														<HeaderStyle Font-Bold="True"></HeaderStyle>
														<Columns>
															<asp:TemplateColumn HeaderText="ID">
																<HeaderStyle HorizontalAlign="Left" Wrap="false" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle Width="40px" CssClass="grid-item"></ItemStyle>
																<ItemTemplate> 
																<%#this.dgSmsData.CurrentPageIndex * this.dgSmsData.PageSize + Container.ItemIndex + 1%>
																 
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="CBATCHID">
																<HeaderStyle HorizontalAlign="Left" Width="80px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle CssClass="grid-item" Width="80px"></ItemStyle>
																<ItemTemplate>
																	<a href=# onclick=window.open('MemberofSent.aspx?Type=B&ID=<%# DataBinder.Eval(Container, "DataItem.CBATCHID") %>','','scrollbars=yes,width=500,height=360,top=300,left=300')>
																	<%# DataBinder.Eval(Container, "DataItem.CBATCHID")%>
																	</a> 
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="發送用戶">
																<HeaderStyle HorizontalAlign="Left" Wrap="false" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle CssClass="grid-item"></ItemStyle>
																<ItemTemplate>
																	<%# DataBinder.Eval(Container, "DataItem.CSENDER")%>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="短訊內容">
																<HeaderStyle HorizontalAlign="Left" Wrap="false" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle CssClass="grid-item"></ItemStyle>
																<ItemTemplate> 
																<a  class="blacklineheight" href='SendByGroup.aspx?csindex=0&sIndex=0&CBATCHID=<%# DataBinder.Eval(Container, "DataItem.CBATCHID") %>'>
														        <%# DataBinder.Eval(Container, "DataItem.CSMSMSG")%>
													            </a>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="字符數">
																<HeaderStyle HorizontalAlign="Left" Wrap="false" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle CssClass="grid-item"></ItemStyle>
																<ItemTemplate>
																	<%# DataBinder.Eval(Container, "DataItem.IMSGLEN")%>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="分段數">
																<HeaderStyle HorizontalAlign="Left" Wrap="false" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle CssClass="grid-item"></ItemStyle>
																<ItemTemplate>
																	<%# DataBinder.Eval(Container, "DataItem.ISMSMSGNO")%>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="號碼數">
																<HeaderStyle HorizontalAlign="Left" Wrap="false" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle CssClass="grid-item"></ItemStyle>
																<ItemTemplate>
																	<%# DataBinder.Eval(Container, "DataItem.IMOBILETOTAL")%>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="發送日期">
																<HeaderStyle HorizontalAlign="Left" Width="160px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle CssClass="grid-item" Width="160px"></ItemStyle>
																<ItemTemplate>
																	<%# DataBinder.Eval(Container, "DataItem.CREATE_DATE")%>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
													</ajax:DataGrid></TD>
											</TR>
											<TR width="100%">
												<TD colSpan="5"></TD>
											</TR>
										</TABLE>
									</asp:panel><asp:panel id="plSendHist" runat="server" Visible="false">
										<TABLE style="WIDTH: 100%; BORDER-COLLAPSE: collapse; HEIGHT: 380px;"
											cellSpacing="10" cellPadding="0" rules="none" align="left" border="0">
											<TR vAlign="middle" width="100%">
												<TD vAlign="baseline" align="left" height="1"><STRONG>預設發送記錄:</STRONG>
												</TD>
												<TD align="left" height="1">用戶：
													<ajax:DropDownList id="dplUser2" runat="server" Width="100px" AutoCallBack="True">
														<asp:ListItem Value="All" Selected="True">All</asp:ListItem>
													</ajax:DropDownList></TD>
												<TD align="left" height="1">日期從：
													<asp:TextBox id="txtStartDate2" onclick="fPopUpDlg('CalendarUtrl/calendar.htm', document.fmSms.txtStartDate2, 'winpop', 234, 261);return false"
														runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
													<asp:RequiredFieldValidator id="Requiredfieldvalidator1" runat="server" ErrorMessage="*" ControlToValidate="dplUser2"></asp:RequiredFieldValidator></TD>
												<TD align="left" height="1">到:
													<asp:TextBox id="txtEndDate2" onclick="fPopUpDlg('CalendarUtrl/calendar.htm', document.fmSms.txtEndDate2, 'winpop', 234, 261);return false"
														runat="server" Width="80px" ReadOnly="True"></asp:TextBox></TD>
												<TD align="left" width="15%" height="1"><FONT face="新細明體">
														<ajax:Button id="btnSearchSch" runat="server" Text="查詢"></ajax:Button>
														<ajax:Button id="btnDetailSch" runat="server" Text="詳情"></ajax:Button>
														<asp:Button id="btnExportSms2" runat="server" Text="匯出"></asp:Button>
														<ajax:Label id="lbMsgSch" runat="server" ForeColor="Red" Width="100px"></ajax:Label></FONT></TD>
											<TR>
												<TD vAlign="baseline" align="left" height="1"></TD>
												<TD align="left" height="1"></TD>
												<TD align="left" height="1"></TD>
												<TD align="left" height="1"></TD>
												<TD align="left" width="15%" height="1"></TD>
											</TR>
											<TR width="100%">
												<TD vAlign="top" align="left" width="50%" colSpan="5" height="256">
													<ajax:DataGrid id="dgSchedule" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False">
														<PagerStyle Mode="NumericPages"></PagerStyle>
														<HeaderStyle Font-Bold="True"></HeaderStyle>
														<EditItemStyle Height="36px"></EditItemStyle>
														<ItemStyle Height="36px" CssClass="grid-item"></ItemStyle>
														<Columns>
															<asp:TemplateColumn HeaderText="ID">
																<HeaderStyle HorizontalAlign="Left" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle Width="40px" CssClass="grid-item"></ItemStyle>
																<ItemTemplate> 
																 <%#this.dgSchedule.CurrentPageIndex * this.dgSchedule.PageSize + Container.ItemIndex + 1%>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="CBATCHID">
																<HeaderStyle HorizontalAlign="Left" Width="80px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle CssClass="grid-item" Width="80px"></ItemStyle>
																<ItemTemplate>
																	<ajax:Label id="lbBatchidD" runat="server" Visible =false Width="160px" Text='<%# DataBinder.Eval(Container, "DataItem.CBATCHID") %>'>
																	</ajax:Label>
																		<a href=# onclick=window.open('MemberofSent.aspx?Type=S&ID=<%# DataBinder.Eval(Container, "DataItem.CBATCHID") %>','','scrollbars=yes,width=500,height=360,top=300,left=300')>																	
																		<%# DataBinder.Eval(Container, "DataItem.CBATCHID")%>
																		</a>  
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="發送者">
																<HeaderStyle Wrap="false" HorizontalAlign="Left" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle CssClass="grid-item"></ItemStyle>
																<ItemTemplate>
																	<%# DataBinder.Eval(Container, "DataItem.CSENDER")%>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="發送日期">
																<HeaderStyle Wrap="false" HorizontalAlign="Left" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle Width="160px" CssClass="grid-item"></ItemStyle>
																<ItemTemplate>
																	<%# DataBinder.Eval(Container, "DataItem.CSEND_DATE")%>
																</ItemTemplate>
																<EditItemTemplate>
																	<ajax:Label id="lbdgCBATCHID" runat="server" Visible =false Width="160px" Text='<%# DataBinder.Eval(Container, "DataItem.CBATCHID") %>'>
																	</ajax:Label>
																	<ajax:Label id="lbdgOldSendDate" runat="server" Visible =false Width="160px" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.CSEND_DATE")).ToString("yyyy-MM-dd HH:mm")%>'>
																	</ajax:Label>
																	<ajax:TextBox id="txtdgSendDate" runat="server" Width="120px" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.CSEND_DATE")).ToString("yyyy-MM-dd HH:mm")%>'>
																	</ajax:TextBox>
																</EditItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="發送狀態">
																<HeaderStyle Wrap="false" HorizontalAlign="Left" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle CssClass="grid-item"></ItemStyle>
																<ItemTemplate>
																	<%# StringStatus(DataBinder.Eval(Container, "DataItem.STATUS")) %>
																	<ajax:Label id="lbdgSTATUS" runat="server" Visible =false Width="160px" Text='<%# DataBinder.Eval(Container, "DataItem.STATUS") %>'>
																	</ajax:Label>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="建立日期">
																<HeaderStyle HorizontalAlign="Left" Width="160px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle CssClass="grid-item" Width="160px"></ItemStyle>
																<ItemTemplate>
																	<%# DataBinder.Eval(Container, "DataItem.CREATE_DATE")%>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="更新" CancelText="取消" ItemStyle-Font-Bold="True"
																EditText="編輯">
																<HeaderStyle HorizontalAlign="Left" Width="60px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle Width="60px" CssClass="grid-item"></ItemStyle>
															</asp:EditCommandColumn>
															<asp:ButtonColumn Text="刪除" CommandName="Delete" ItemStyle-Font-Bold="True">
															<HeaderStyle HorizontalAlign="Left" Width="60px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle Width="60px" CssClass="grid-item"></ItemStyle>
															</asp:ButtonColumn>
														</Columns>
													</ajax:DataGrid>
													<ajax:DataGrid id="dgSchedule2" runat="server" Visible="false" Width="100%" AllowPaging="True"
														AutoGenerateColumns="False">
														<PagerStyle Mode="NumericPages"></PagerStyle>
														<HeaderStyle Font-Bold="True"></HeaderStyle>
														<ItemStyle Height="36px" CssClass="grid-item"> </ItemStyle>
														<Columns>
															<asp:TemplateColumn HeaderText="ID">
																<HeaderStyle HorizontalAlign="Left" Wrap="false" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle Width="40px" CssClass="grid-item"></ItemStyle>
																<ItemTemplate> 
																 <%#this.dgSchedule2.CurrentPageIndex * this.dgSchedule2.PageSize + Container.ItemIndex + 1%>
															  </ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="CBATCHID">
																<HeaderStyle HorizontalAlign="Left" Width="80px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle CssClass="grid-item" Width="80px"></ItemStyle>
																<ItemTemplate>
																	<ajax:Label id="lbdgSchedule2Batchid" runat="server" Visible =false Width="160px" Text='<%# DataBinder.Eval(Container, "DataItem.CBATCHID") %>'>
																	</ajax:Label>
																<a href=# onclick=window.open('MemberofSent.aspx?Type=S&ID=<%# DataBinder.Eval(Container, "DataItem.CBATCHID") %>','','scrollbars=yes,width=500,height=360,top=300,left=300')>																	
																		<%# DataBinder.Eval(Container, "DataItem.CBATCHID")%>
																</a>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="發送用戶">
																<HeaderStyle HorizontalAlign="Left" Wrap="false" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle CssClass="grid-item"></ItemStyle>
																<ItemTemplate>
																	<%# DataBinder.Eval(Container, "DataItem.CSENDER")%>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="短訊內容">
																<HeaderStyle HorizontalAlign="Left" Wrap="false" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle CssClass="grid-item"></ItemStyle>
																<ItemTemplate>
																	<a  class="blacklineheight" href='SendByGroup.aspx?csindex=0&sIndex=0&CBATCHID=<%# DataBinder.Eval(Container, "DataItem.CBATCHID") %>'>
														        <%# DataBinder.Eval(Container, "DataItem.CSMSMSG")%>
													            </a>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="字符數">
																<HeaderStyle HorizontalAlign="Left" Wrap="false" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle CssClass="grid-item"></ItemStyle>
																<ItemTemplate>
																	<%# DataBinder.Eval(Container, "DataItem.IMSGLEN")%>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="分段數">
																<HeaderStyle HorizontalAlign="Left" Wrap="false" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle CssClass="grid-item"></ItemStyle>
																<ItemTemplate>
																	<%# DataBinder.Eval(Container, "DataItem.ISMSMSGNO")%>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="號碼數">
																<HeaderStyle HorizontalAlign="Left" Wrap="false" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle CssClass="grid-item"></ItemStyle>
																<ItemTemplate>
																	<%# DataBinder.Eval(Container, "DataItem.IMOBILETOTAL")%>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="建立日期">
																<HeaderStyle HorizontalAlign="Left" Width="160px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle CssClass="grid-item" Width="160px"></ItemStyle>
																<ItemTemplate>
																	<%# DataBinder.Eval(Container, "DataItem.CREATE_DATE")%>
																</ItemTemplate>
															</asp:TemplateColumn>
																<asp:TemplateColumn >
																<HeaderStyle HorizontalAlign="Left" Width="80px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle CssClass="grid-item"  Width="80px"></ItemStyle>
																<ItemTemplate> 
																<a href=# onclick=window.open('AlertSmsData.aspx?Type=S&ID=<%# DataBinder.Eval(Container, "DataItem.CBATCHID") %>','','scrollbars=yes,width=500,height=360,top=300,left=300')>																	
																		<b>編輯短訊內容</b>
																</a>
																</ItemTemplate>
															</asp:TemplateColumn>
															
														</Columns>
													</ajax:DataGrid></TD>
											</TR>
											<TR width="100%">
												<TD colSpan="5"></TD>
											</TR>
										</TABLE>
									</asp:panel>
									<asp:panel id="plCallHist" runat="server" Visible="false">
										<TABLE style="WIDTH: 100%; BORDER-COLLAPSE: collapse; HEIGHT: 380px;" 
											cellSpacing="10" cellPadding="0" rules="none" align="left" border="0">
											<TR vAlign="middle" width="100%">
												<TD vAlign="baseline" align="left" height="1">
													<P><STRONG>落CALL發送記錄：</STRONG></P>
												</TD>
												<TD align="left" height="1">用戶：
													<ajax:DropDownList id="dplUsersCall" runat="server" Width="100px" AutoCallBack="True">
														<asp:ListItem Value="All" Selected="True">All</asp:ListItem>
													</ajax:DropDownList></TD>
												<TD align="left" height="1">日期從：
													<asp:TextBox id="txtStartDateCall" onclick="fPopUpDlg('CalendarUtrl/calendar.htm', document.fmSms.txtStartDateCall, 'winpop', 234, 261);return false"
														runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
													<asp:RequiredFieldValidator id="rfvCall" runat="server" ErrorMessage="*" ControlToValidate="dplUsersCall"></asp:RequiredFieldValidator></TD>
												<TD align="left" height="1">到：
													<asp:TextBox id="txtEndDateCall" onclick="fPopUpDlg('CalendarUtrl/calendar.htm', document.fmSms.txtEndDateCall, 'winpop', 234, 261);return false"
														runat="server" Width="80px" ReadOnly="True"></asp:TextBox></TD>
												<TD align="left" width="15%" height="1"><FONT face="新細明體">
														<ajax:Button id="btnSearchCall" runat="server" Text="查詢"></ajax:Button>
														<asp:Button id="btnExportSms3" runat="server" Text="匯出"></asp:Button>
														</FONT></TD>
											<TR>
												<TD vAlign="baseline" align="left" height="1"></TD>
												<TD align="left" height="1"></TD>
												<TD align="left" height="1"></TD>
												<TD align="left" height="1"></TD>
												<TD align="left" width="15%" height="1"></TD>
											</TR>
											<TR width="100%">
												<TD vAlign="top" align="left" width="50%" colSpan="5" height="256">
													<ajax:DataGrid id="dgSmsDataCall" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False">
														<PagerStyle Mode="NumericPages"></PagerStyle>
														<HeaderStyle Font-Bold="True"></HeaderStyle>
														<Columns>
															<asp:TemplateColumn HeaderText="ID">
																<HeaderStyle HorizontalAlign="Left" Wrap="false" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle Width="40px" CssClass="grid-item"></ItemStyle>
																<ItemTemplate> 
																<%#this.dgSmsData.CurrentPageIndex * this.dgSmsData.PageSize + Container.ItemIndex + 1%>
															  </ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="CBATCHID">
																<HeaderStyle HorizontalAlign="Left" Width="80px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle CssClass="grid-item" Width="80px"></ItemStyle>
																<ItemTemplate>
																<a href=# onclick=window.open('MemberofSent.aspx?Type=B&ID=<%# DataBinder.Eval(Container, "DataItem.CBATCHID") %>','','scrollbars=yes,width=500,height=360,top=300,left=300')>																	
																		<%# DataBinder.Eval(Container, "DataItem.CBATCHID")%>
																</a>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="發送用戶">
																<HeaderStyle HorizontalAlign="Left" Wrap="false" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle CssClass="grid-item"></ItemStyle>
																<ItemTemplate>
																	<%# DataBinder.Eval(Container, "DataItem.CSENDER")%>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="短訊內容">
																<HeaderStyle HorizontalAlign="Left" Wrap="false" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle CssClass="grid-item"></ItemStyle>
																<ItemTemplate>
																	<a  class="blacklineheight" href='SendByGroup.aspx?csindex=0&sIndex=0&CBATCHID=<%# DataBinder.Eval(Container, "DataItem.CBATCHID") %>'>
														        <%# DataBinder.Eval(Container, "DataItem.CSMSMSG")%>
													            </a></ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="字符數">
																<HeaderStyle HorizontalAlign="Left" Wrap="false" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle CssClass="grid-item"></ItemStyle>
																<ItemTemplate>
																	<%# DataBinder.Eval(Container, "DataItem.IMSGLEN")%>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="分段數">
																<HeaderStyle HorizontalAlign="Left" Wrap="false" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle CssClass="grid-item"></ItemStyle>
																<ItemTemplate>
																	<%# DataBinder.Eval(Container, "DataItem.ISMSMSGNO")%>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="號碼數">
																<HeaderStyle HorizontalAlign="Left" Wrap="false" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle CssClass="grid-item"></ItemStyle>
																<ItemTemplate>
																	<%# DataBinder.Eval(Container, "DataItem.IMOBILETOTAL")%>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="發送日期">
																<HeaderStyle HorizontalAlign="Left" Width="160px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle CssClass="grid-item" Width="160px"></ItemStyle>
																<ItemTemplate>
																	<%# DataBinder.Eval(Container, "DataItem.CREATE_DATE")%>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
													</ajax:DataGrid></TD>
											</TR>
											<TR width="100%">
												<TD colSpan="5"><FONT face="新細明體"></FONT></TD>
											</TR>
										</TABLE>
									</asp:panel></TD>
							</TR>
						</table>
					</td>
				</tr>
				
			</table>
		</form>
	</body>
</HTML>
