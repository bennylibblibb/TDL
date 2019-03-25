<%@ Register TagPrefix="anthem" Namespace="Anthem" Assembly="Anthem" %>
<%@ Page language="c#" Codebehind="GroupAdmin.aspx.cs" AutoEventWireup="false" Inherits="CENTASMS.GroupAdmin" %>
<%@ Register TagPrefix="uc1" TagName="GroupTabs" Src="UserControl/GroupTabs.ascx" %>
<%@ Register TagPrefix="uc1" TagName="MenuTabs" Src="UserControl/MenuTabs.ascx" %>
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
		<script language="javascript" src="script.js"></script>
		<script type="text/javascript">   
		
 var pb_strConfirmCloseMessage='Are you sure to leave?';
    var pb_blnCloseWindow = false;

    function ConfirmClose() {
     window.event.returnValue = pb_strConfirmCloseMessage;
     pb_blnCloseWindow = true;
    }

    function ShowConfirmClose(blnValue) {
     if(blnValue) {
      document.body.onbeforeunload = ConfirmClose;
     } else {
      document.body.onbeforeunload = null;
     }
    }

		  function   Focus(   id,   name)     {   
  var   targetControl   =   FindControl(   id,   name   );   
  if   (   targetControl   !=   null   &&   targetControl.focus   )   {   
  targetControl.focus();   
  }   
  }   
    
  function   FindControl(   id,   name   )   {   
  if   (   typeof(document.getElementById)   !=   "undefined"   )   {   
  var   focusControl   =   document.getElementById(id);   
  if   (   focusControl   !=   null   )   {   
  return   focusControl;   
  }   
  }   
  for(   var   i   =   0;   i   <   document.forms.length;   i++   )   {   
  var   theForm   =   document.forms[i];   
  var   focusControl   =   theForm[name];   
  if   (   focusControl   !=   null   )   {   
  return   focusControl;   
  }   
  }   
  return   null;   
  }  
  
  function  focusload()
  { 
 if (document.getElementById('txtGroupP')!=null)
 { 
   document.getElementById("txtGroupP").focus();
 }
 else if(document.getElementById('txtGroupS')!=null) 
 { 
 document.getElementById("txtGroupS").focus();
 }
  else if(document.getElementById('txtName')!=null) 
 { 
 document.getElementById("txtName").focus();
 } 
  }

		  function   Focuss(  id,clear)    
		   {     
		   if(clear=='All')
		   {
		   if(id=='txtGroupP')
		   {
		      document.getElementById("txtGroupP").value =""; 
		  //    document.getElementById("tbGroupPPwd").value =""; 
		   }
		    else if(id=='txtGroupS')
		   {
		      document.getElementById("txtGroupS").value =""; 
		    //  document.getElementById("tbGroupSPwd").value =""; 
		   }
		       else if(id=='txtName')
		   {
		      document.getElementById("txtName").value =""; 
		      document.getElementById("txtMobile").value =""; 
		   }
		   } 
		   document.getElementById(id).focus();
         }   



        function change() {    
            var imgNode = document.getElementById("vimg");    
            imgNode.src = "CheckCode.asPx?t=" + (new Date()).valueOf();  // ??是 "WaterMark.ashx?t=" + (new Date()).valueOf(); ?句?可以改????，?里加???的??是?了防止??器?存的??    
        }     
         function   DoCheck(flag) 
{  
var   inputs   =   document.forms[0].elements; 
if   (flag) 
{ 
for   (var   i=0;   i   <   inputs.length;   i++) 
if   (inputs[i].type   ==   'checkbox') 
{ 
inputs[i].checked   =   true; 
} 
} 
else 
{ 
for   (var   i=0;   i   <   inputs.length;   i++) 
if   (inputs[i].type   ==   'checkbox') 
{ 
inputs[i].checked   =   false; 
}  
} 
} 

 function   Clear() 
{  
var   inputs   =   document.forms[0].elements; 
 
for   (var   i=0;   i   <   inputs.length;   i++) 
if   (inputs[i].type   ==   'checkbox') 
{ 
inputs[i].checked   =   false; 
}   
} 

function   CheckNum() 
{
var strvalue= document.getElementById("txtMobile").value;
 
  //var reg = /[9,5,6]{1}[0-9]{7}/;
    var reg = /['<%=ConfigurationSettings.AppSettings["ValidPrefixes"]%>']{1}[0-9]{7}/;
         if(strvalue.indexOf("00852") == 0 )
         {
          var  str = strvalue.substring(5); 
          if  (str.length != 8)
               {
                  alert("電話號碼位數不正確！(" + strvalue+')');
                  return (false);
               }
               else
               {
                if(reg.exec(str))
                {}else{
               alert("請輸入正確號碼！(" + strvalue+')'); 
               return (false);
                }
               } 
         }
         else if(strvalue.indexOf("00") == 0 )
         { 
            if( strvalue.length<3)
            {
              alert("電話號碼位數不正確！(" + strvalue+')');
              return (false);
            }
         }
         else
         {
         
           if  (strvalue.length != 8)
               {
                  alert("電話號碼位數不正確！(" + strvalue+')');
                  return (false);
               }
               else
               {
                if(reg.exec(strvalue))
                {}else{
               alert("請輸入正確號碼！(" + strvalue+')'); 
               return (false);
                }
               } 
         }
}

 function CheckNumAll(obj) 
{
  
var strvalue= obj.value;
   //var reg = /[9,5,6]{1}[0-9]{7}/;
     var reg = /['<%=ConfigurationSettings.AppSettings["ValidPrefixes"]%>']{1}[0-9]{7}/;
         if(strvalue.indexOf("00852") == 0 )
         {
          var  str = strvalue.substring(5); 
          if  (str.length != 8)
               {
                  alert("電話號碼位數不正確！(" + strvalue+')');
                  return (false);
               }
               else
               {
                if(reg.exec(str))
                {}else{
               alert("請輸入正確號碼！(" + strvalue+')'); 
               return (false);
                }
               } 
         }
         else if(strvalue.indexOf("00") == 0 )
         { 
            if( strvalue.length<3)
            {
              alert("電話號碼位數不正確！(" + strvalue+')');
              return (false);
            }
         }
         else
         {
         
           if  (strvalue.length != 8)
               {
                  alert("電話號碼位數不正確！(" + strvalue+')');
                  return (false);
               }
               else
               {
                if(reg.exec(strvalue))
                {}else{
               alert("請輸入正確號碼！(" + strvalue+')'); 
               return (false);
                }
               } 
         }
}
function   CheckNum4() 
{
var strvalue= document.getElementById("txtMobile4").value;
   //var reg = /[9,5,6]{1}[0-9]{7}/;
     var reg = /['<%=ConfigurationSettings.AppSettings["ValidPrefixes"]%>']{1}[0-9]{7}/;
         if(strvalue.indexOf("00852") == 0 )
         {
          var  str = strvalue.substring(5); 
          if  (str.length != 8)
               {
                  alert("電話號碼位數不正確！(" + strvalue+')');
                  return (false);
               }
               else
               {
                if(reg.exec(str))
                {}else{
               alert("請輸入正確號碼！(" + strvalue+')'); 
               return (false);
                }
               } 
         }
         else if(strvalue.indexOf("00") == 0 )
         { 
            if( strvalue.length<3)
            {
              alert("電話號碼位數不正確！(" + strvalue+')');
              return (false);
            }
         }
         else
         {
         
           if  (strvalue.length != 8)
               {
                  alert("電話號碼位數不正確！(" + strvalue+')');
                  return (false);
               }
               else
               {
                if(reg.exec(strvalue))
                {}else{
               alert("請輸入正確號碼！(" + strvalue+')'); 
               return (false);
                }
               } 
         }
}
	
	 
		</script>
	</HEAD>
	<body onload="focusload()">
		<form id="Reports" method="post" runat="server">
			<table id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="top_bar01_bg"><IMG height="49" src="resource/mango_logo_title.gif" width="359">
					</td>
				</tr>
				<tr>
					<td class="top_bar02_bg" vAlign="top" height="15">
						<P align="left"><FONT color="#ffffff"><IMG height="15" src="resource/spacer.gif" width="15"></FONT>
							用戶:&nbsp;<asp:label id="lbUser" runat="server"></asp:label></P>
					</td>
				</tr>
			</table>
			<table id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr width="100%">
					<td vAlign="top">
						<table class="admin-tan-border" id="Table3" height="500" cellSpacing="0" cellPadding="0"
							width="100%" border="0">
							<tr>
								<td class="admin-table" style="HEIGHT: 10px" vAlign="top"><IMG height="15" src="resource/spacer.gif" width="15">
								</td>
								<td vAlign="top"><FONT face="新細明體"><uc1:grouptabs id="GroupTabs1" runat="server"></uc1:grouptabs></FONT></td>
							</tr>
							<tr vAlign="top">
								<td class="left_bar_bg" style="WIDTH: 169px; HEIGHT: 100%" vAlign="top"><uc1:menutabs id="MenuTabs1" runat="server"></uc1:menutabs></td>
								<td vAlign="top"><anthem:panel id="panel1" runat="server" Visible="false">
										<TABLE class="tan-border02" style="WIDTH: 100%; BORDER-COLLAPSE: collapse; HEIGHT: 380px"
											cellSpacing="10" cellPadding="0" rules="none" align="left" border="0">
											<TR style="DISPLAY: none" vAlign="middle" width="100%">
												<TD style="WIDTH: 257px" vAlign="baseline" align="left" height="1"><STRONG>私人組別：</STRONG>
												</TD>
												<TD align="left" height="1">用戶：
													<anthem:DROPDOWNLIST id="dplUsers" runat="server" Width="80px">
														<ASP:LISTITEM Selected="True" Value="All">All</ASP:LISTITEM>
													</anthem:DROPDOWNLIST></TD>
												<TD align="left" height="1">日期從：
													<ASP:TEXTBOX id="txtStartDate" onclick="fPopUpDlg('CalendarUtrl/calendar.htm', document.fmSms.txtStartDate, 'winpop', 234, 261);return false"
														runat="server" Width="80px"></ASP:TEXTBOX>
													<ASP:REQUIREDFIELDVALIDATOR id="rfv" runat="server" ErrorMessage="*" ControlToValidate="dplUsers"></ASP:REQUIREDFIELDVALIDATOR></TD>
												<TD align="left" height="1">到:
													<ASP:TEXTBOX id="txtEndDate" onclick="fPopUpDlg('CalendarUtrl/calendar.htm', document.fmSms.txtEndDate, 'winpop', 234, 261);return false"
														runat="server" Width="80px"></ASP:TEXTBOX></TD>
												<TD align="left" width="18%" height="1"><FONT face="新細明體">
														<anthem:BUTTON id="btnSearch" runat="server" Text="查詢"></anthem:BUTTON></FONT></TD>
											<TR>
												<TD vAlign="bottom" align="left" height="1"></TD>
												<TD vAlign="bottom" align="left" height="1"></TD>
												<TD vAlign="bottom" align="left" height="1"></TD>
												<TD vAlign="bottom" align="left"></TD>
												<TD></TD>
											</TR>
											<TR vAlign="bottom">
												<TD vAlign="bottom" align="left" height="1">
													<ASP:LABEL id="lbGroupPP" runat="server" Width="100px" Font-Bold="True">添加私人組別：</ASP:LABEL></TD>
												<TD vAlign="bottom" align="left" height="1">
													<anthem:TEXTBOX id="txtGroupP" runat="server" Width="128px"></anthem:TEXTBOX>
													<ASP:REQUIREDFIELDVALIDATOR id="Requiredfieldvalidator7" runat="server" ErrorMessage="*" ControlToValidate="txtGroupP"
														Enabled="false"></ASP:REQUIREDFIELDVALIDATOR>
													<anthem:LABEL id="lbmsgRP" runat="server" Width="1px" ForeColor="Red"></anthem:LABEL></TD>
												<TD vAlign="bottom" align="left" height="1">
													<ASP:LABEL id="lbGroupPPwd" runat="server" Visible="False" Width="120px" Font-Bold="True">添加私人組別密碼：</ASP:LABEL></TD>
												<TD vAlign="bottom" align="left">
													<anthem:TEXTBOX id="tbGroupPPwd" runat="server" Visible="False" Width="128px">123456</anthem:TEXTBOX></TD>
												<TD>
													<anthem:BUTTON id="btnAddGroupP" runat="server" Text="添加"></anthem:BUTTON>
													<anthem:BUTTON id="btnDeleteP" runat="server" Text="刪除所有組別&amp;聯絡人"></anthem:BUTTON>
													<anthem:LABEL id="lbMsgP" runat="server" Width="220px" ForeColor="Red"></anthem:LABEL></TD>
											</TR>
											<TR>
												<TD vAlign="bottom" align="left" height="1"></TD>
												<TD vAlign="bottom" align="left" height="1"></TD>
												<TD vAlign="bottom" align="left" height="1"></TD>
												<TD vAlign="bottom" align="left"></TD>
												<TD></TD>
											</TR>
											<TR width="100%">
												<TD vAlign="top" align="left" width="50%" colSpan="5" height="256">
													<anthem:DATAGRID id="dgData" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True">
														<PAGERSTYLE Mode="NumericPages"></PAGERSTYLE>
														<EDITITEMSTYLE Height="36px"></EDITITEMSTYLE>
														<ITEMSTYLE Height="36px"></ITEMSTYLE>
														<HEADERSTYLE Font-Bold="True" Height="20px" Wrap="False"></HEADERSTYLE>
														<COLUMNS>
															<ASP:TEMPLATECOLUMN HeaderText="ID">
																<HEADERSTYLE Wrap="false" VerticalAlign="Middle" CssClass="grid-header" HorizontalAlign="Left"></HEADERSTYLE>
																<ITEMSTYLE Width="40px" CssClass="grid-item"></ITEMSTYLE>
																<ITEMTEMPLATE>
																	<%#this.dgData.CurrentPageIndex * this.dgData.PageSize + Container.ItemIndex + 1%>
																	<FONT face="新細明體"></FONT>
																</ITEMTEMPLATE>
															</ASP:TEMPLATECOLUMN>
															<ASP:TEMPLATECOLUMN>
																<HEADERSTYLE Wrap="false" VerticalAlign="Middle" CssClass="grid-header" HorizontalAlign="Left"></HEADERSTYLE>
																<ITEMSTYLE Width="160px" CssClass="grid-item" Wrap="false"></ITEMSTYLE>
																<HEADERTEMPLATE>組別名稱 
                  </HEADERTEMPLATE>
																<ITEMTEMPLATE>
																	<ASP:LABEL id=lbGroupIDP runat="server" Visible="False" Width="10px" Text='<%# DataBinder.Eval(Container, "DataItem.cgroup_ID") %>'>
																	</ASP:LABEL>
																	<ASP:LABEL id="lbGroupIDNameP" runat="server" Width="150px" Text='<%# DataBinder.Eval(Container, "DataItem.cgroup_NAME") %>'>
																	</ASP:LABEL>
																</ITEMTEMPLATE>
																<EDITITEMTEMPLATE>
																	<ASP:TEXTBOX id=txtGroupPE runat="server" Width="160px" Text='<%# DataBinder.Eval(Container, "DataItem.cgroup_NAME") %>'>
																	</ASP:TEXTBOX>
																	<ASP:LABEL id=lboldGroupNamePE runat="server" Visible="False" Width="10px" Text='<%# DataBinder.Eval(Container, "DataItem.cgroup_NAME") %>'>
																	</ASP:LABEL>
																	<ASP:LABEL id=lbGroupIDPE runat="server" Visible="False" Width="10px" Text='<%# DataBinder.Eval(Container, "DataItem.cgroup_ID") %>'>
																	</ASP:LABEL>
																</EDITITEMTEMPLATE>
															</ASP:TEMPLATECOLUMN>
															<ASP:TEMPLATECOLUMN>
																<HEADERSTYLE Wrap="false" VerticalAlign="Middle" CssClass="grid-header" HorizontalAlign="Left"></HEADERSTYLE>
																<ITEMSTYLE Width="100px" CssClass="grid-item"></ITEMSTYLE>
																<HEADERTEMPLATE>組別密碼 
                  </HEADERTEMPLATE>
																<ITEMTEMPLATE>
																	<ASP:LABEL id=lbGroupPwdP runat="server" Visible="False" Width="10px" Text='<%# DataBinder.Eval(Container, "DataItem.cgroup_pwd") %>'>
																	</ASP:LABEL>
																	<%# DataBinder.Eval(Container, "DataItem.cgroup_pwd") %>
																</ITEMTEMPLATE>
																<EDITITEMTEMPLATE>
																	<ASP:TEXTBOX id=txtGroupPwdPE runat="server" Width="100px" Text='<%# DataBinder.Eval(Container, "DataItem.cgroup_pwd") %>'>
																	</ASP:TEXTBOX>
																	<ASP:LABEL id=lbGroupPwdPE runat="server" Visible="False" Width="10px" Text='<%# DataBinder.Eval(Container, "DataItem.cgroup_pwd") %>'>
																	</ASP:LABEL>
																</EDITITEMTEMPLATE>
															</ASP:TEMPLATECOLUMN>
                                                            	<ASP:TEMPLATECOLUMN HeaderText="組別成員數目">
																<HEADERSTYLE Width="80px" Wrap="false" VerticalAlign="Middle" CssClass="grid-header" HorizontalAlign="Left"></HEADERSTYLE>
																<ITEMSTYLE Width="80px" CssClass="grid-item"></ITEMSTYLE>
																<ITEMTEMPLATE>
																	<%# DataBinder.Eval(Container, "DataItem.CREATE_COUNT")%>
																</ITEMTEMPLATE>
															</ASP:TEMPLATECOLUMN>
															<ASP:TEMPLATECOLUMN HeaderText="組別擁有者">
																<HEADERSTYLE Width="80px" Wrap="false" VerticalAlign="Middle" CssClass="grid-header" HorizontalAlign="Left"></HEADERSTYLE>
																<ITEMSTYLE Width="80px" CssClass="grid-item"></ITEMSTYLE>
																<ITEMTEMPLATE>
																	<%# DataBinder.Eval(Container, "DataItem.cgroup_owner")%>
																</ITEMTEMPLATE>
															</ASP:TEMPLATECOLUMN>
															<ASP:TEMPLATECOLUMN HeaderText="組別類型">
																<HEADERSTYLE Wrap="false" VerticalAlign="Middle" CssClass="grid-header" HorizontalAlign="Left"></HEADERSTYLE>
																<ITEMSTYLE Width="40px" CssClass="grid-item"></ITEMSTYLE>
																<ITEMTEMPLATE>
																	<%# DataBinder.Eval(Container, "DataItem.cgroup_type")%>
																</ITEMTEMPLATE>
															</ASP:TEMPLATECOLUMN>
															<ASP:TEMPLATECOLUMN HeaderText="添加日期">
																<HeaderStyle HorizontalAlign="Left" Width="160px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle CssClass="grid-item" Width="160px"></ItemStyle>
																<ITEMTEMPLATE>
																	<%# DataBinder.Eval(Container, "DataItem.create_date")%>
																</ITEMTEMPLATE>
															</ASP:TEMPLATECOLUMN>
															<ASP:EDITCOMMANDCOLUMN EditText="編輯" CancelText="取消" UpdateText="更新" ItemStyle-Font-Bold="True" ButtonType="LinkButton">
																<HEADERSTYLE Width="60px" VerticalAlign="Middle" CssClass="grid-header" HorizontalAlign="Left"></HEADERSTYLE>
																<ITEMSTYLE Width="60px" CssClass="grid-item"></ITEMSTYLE>
															</ASP:EDITCOMMANDCOLUMN>
															<ASP:BUTTONCOLUMN Text="刪除" ItemStyle-Font-Bold="True" CommandName="Delete">
																<HEADERSTYLE Width="60px" VerticalAlign="Middle" CssClass="grid-header" HorizontalAlign="Left"></HEADERSTYLE>
																<ITEMSTYLE Width="60px" CssClass="grid-item"></ITEMSTYLE>
															</ASP:BUTTONCOLUMN>
														</COLUMNS>
													</anthem:DATAGRID></TD>
											</TR>
											<TR width="100%">
												<TD colSpan="5"><FONT face="新細明體"></FONT></TD>
											</TR>
										</TABLE>
									</anthem:panel><anthem:panel id="panel2" runat="server" Visible="false">
										<TABLE class="tan-border02" style="WIDTH: 100%; BORDER-COLLAPSE: collapse; HEIGHT: 380px"
											cellSpacing="10" cellPadding="0" rules="none" align="left" border="0">
											<TR style="DISPLAY: none" vAlign="middle" width="100%">
												<TD style="WIDTH: 257px" vAlign="baseline" align="left" height="1"><STRONG>共享組別：</STRONG>
												</TD>
												<TD align="left" height="1">用戶：
													<anthem:DROPDOWNLIST id="dplUsers11" runat="server" Width="80px">
														<ASP:LISTITEM Selected="True" Value="All">All</ASP:LISTITEM>
													</anthem:DROPDOWNLIST></TD>
												<TD align="left" height="1">日期從：
													<ASP:TEXTBOX id="txtStartDate1" onclick="fPopUpDlg('CalendarUtrl/calendar.htm', document.fmSms.txtStartDate, 'winpop', 234, 261);return false"
														runat="server" Width="80px"></ASP:TEXTBOX>
													<ASP:REQUIREDFIELDVALIDATOR id="rfv11" runat="server" ErrorMessage="*" ControlToValidate="dplUsers"></ASP:REQUIREDFIELDVALIDATOR></TD>
												<TD align="left" height="1">到:
													<ASP:TEXTBOX id="txtEndDate11" onclick="fPopUpDlg('CalendarUtrl/calendar.htm', document.fmSms.txtEndDate11, 'winpop', 234, 261);return false"
														runat="server" Width="80px"></ASP:TEXTBOX></TD>
												<TD align="left" width="18%" height="1">
													<anthem:BUTTON id="btnSearch11" runat="server" Text="查詢"></anthem:BUTTON></TD>
											<TR>
												<TD vAlign="bottom" align="left" height="1"></TD>
												<TD vAlign="bottom" align="left" height="1"></TD>
												<TD vAlign="bottom" align="left" height="1"></TD>
												<TD vAlign="bottom" align="left"></TD>
												<TD></TD>
											</TR>
											<TR vAlign="bottom">
												<TD vAlign="bottom" align="left" height="1">
													<ASP:LABEL id="lbGroupS" runat="server" Width="100px" Font-Bold="True">添加共享組別：</ASP:LABEL></TD>
												<TD vAlign="bottom" align="left" height="1"><FONT face="新細明體">
														<anthem:TEXTBOX id="txtGroupS" runat="server" Width="128px"></anthem:TEXTBOX></FONT>
													<ASP:REQUIREDFIELDVALIDATOR id="Requiredfieldvalidator8" runat="server" ErrorMessage="*" ControlToValidate="txtGroupS"></ASP:REQUIREDFIELDVALIDATOR>
													<anthem:LABEL id="lbmsgRS" runat="server" Width="1px" ForeColor="Red"></anthem:LABEL></TD>
												<TD vAlign="bottom" align="left" height="1">
													<ASP:LABEL id="lbGroupSPwd" runat="server" Visible="False" Width="120px" Font-Bold="True">添加共享組別密碼：</ASP:LABEL></TD>
												<TD vAlign="bottom" align="left">
													<anthem:TEXTBOX id="tbGroupSPwd" runat="server" Visible="False" Width="128px">123456</anthem:TEXTBOX></TD>
												<TD>
													<anthem:BUTTON id="btnAddGroupS" runat="server" Text="添加"></anthem:BUTTON>
													<anthem:BUTTON id="btnDeleteS" runat="server" Text="刪除所有組別&amp;聯絡人"></anthem:BUTTON>
													<anthem:LABEL id="lbMsgS" runat="server" Width="220px" ForeColor="Red"></anthem:LABEL></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT></TD>
											</TR>
											<TR>
												<TD vAlign="bottom" align="left" height="1"></TD>
												<TD vAlign="bottom" align="left" height="1"></TD>
												<TD vAlign="bottom" align="left" height="1"></TD>
												<TD vAlign="bottom" align="left"></TD>
												<TD></TD>
											</TR>
											<TR width="100%">
												<TD vAlign="top" align="left" width="50%" colSpan="5" height="256">
													<anthem:DATAGRID id="dgData2" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True">
														<PAGERSTYLE Mode="NumericPages"></PAGERSTYLE>
														<EDITITEMSTYLE Height="36px"></EDITITEMSTYLE>
														<ITEMSTYLE Height="36px"></ITEMSTYLE>
														<HEADERSTYLE Font-Bold="True" Height="20px" Wrap="False"></HEADERSTYLE>
														<COLUMNS>
															<ASP:TEMPLATECOLUMN HeaderText="ID">
																<HEADERSTYLE Wrap="false" VerticalAlign="Middle" CssClass="grid-header" HorizontalAlign="Left"></HEADERSTYLE>
																<ITEMSTYLE Width="40px" CssClass="grid-item"></ITEMSTYLE>
																<ITEMTEMPLATE>
																	<%#this.dgData2.CurrentPageIndex * this.dgData2.PageSize + Container.ItemIndex + 1%>
																	<FONT face="新細明體"></FONT>
																</ITEMTEMPLATE>
															</ASP:TEMPLATECOLUMN>
															<ASP:TEMPLATECOLUMN>
																<HEADERSTYLE Wrap="false" VerticalAlign="Middle" CssClass="grid-header" HorizontalAlign="Left"></HEADERSTYLE>
																<ITEMSTYLE Width="160px" CssClass="grid-item" Wrap="false"></ITEMSTYLE>
																<HEADERTEMPLATE>
																	<FONT face="新細明體">組別名稱</FONT>
																</HEADERTEMPLATE>
																<ITEMTEMPLATE>
																	<ASP:LABEL id=lbGroupIDS runat="server" Visible="False" Width="10px" Text='<%# DataBinder.Eval(Container, "DataItem.cgroup_ID") %>'>
																	</ASP:LABEL>
																	<ASP:LABEL id="lbGroupIDNameS" runat="server" Width="150px" Text='<%# DataBinder.Eval(Container, "DataItem.cgroup_NAME") %>'>
																	</ASP:LABEL>
																</ITEMTEMPLATE>
																<EDITITEMTEMPLATE>
																	<ASP:TEXTBOX id=txtGroupSE runat="server" Width="160px" Text='<%# DataBinder.Eval(Container, "DataItem.cgroup_NAME") %>'>
																	</ASP:TEXTBOX>
																	<ASP:LABEL id=lboldGroupNameSE runat="server" Visible="False" Width="10px" Text='<%# DataBinder.Eval(Container, "DataItem.cgroup_NAME") %>'>
																	</ASP:LABEL>
																	<ASP:LABEL id=lbGroupIDSE runat="server" Visible="False" Width="10px" Text='<%# DataBinder.Eval(Container, "DataItem.cgroup_ID") %>'>
																	</ASP:LABEL>
																</EDITITEMTEMPLATE>
															</ASP:TEMPLATECOLUMN>
															<ASP:TEMPLATECOLUMN>
																<HEADERSTYLE Wrap="false" VerticalAlign="Middle" CssClass="grid-header" HorizontalAlign="Left"></HEADERSTYLE>
																<ITEMSTYLE Width="100px" CssClass="grid-item"></ITEMSTYLE>
																<HEADERTEMPLATE>組別密碼 
                  </HEADERTEMPLATE>
																<ITEMTEMPLATE>
																	<ASP:LABEL id=lbGroupPwdS runat="server" Visible="False" Width="10px" Text='<%# DataBinder.Eval(Container, "DataItem.cgroup_pwd") %>'>
																	</ASP:LABEL>
																	<%# DataBinder.Eval(Container, "DataItem.cgroup_pwd") %>
																</ITEMTEMPLATE>
																<EDITITEMTEMPLATE>
																	<ASP:TEXTBOX id=txtGroupPwdSE runat="server" Width="100px" Text='<%# DataBinder.Eval(Container, "DataItem.cgroup_pwd") %>'>
																	</ASP:TEXTBOX>
																	<ASP:LABEL id=lbGroupPwdSE runat="server" Visible="False" Width="10px" Text='<%# DataBinder.Eval(Container, "DataItem.cgroup_pwd") %>'>
																	</ASP:LABEL>
																</EDITITEMTEMPLATE>
															</ASP:TEMPLATECOLUMN>
                                                            	<ASP:TEMPLATECOLUMN HeaderText="組別成員數目">
																<HEADERSTYLE Width="80px" Wrap="false" VerticalAlign="Middle" CssClass="grid-header" HorizontalAlign="Left"></HEADERSTYLE>
																<ITEMSTYLE Width="80px" CssClass="grid-item"></ITEMSTYLE>
																<ITEMTEMPLATE>
																	<%# DataBinder.Eval(Container, "DataItem.CREATE_COUNT")%>
																</ITEMTEMPLATE>
															</ASP:TEMPLATECOLUMN>
															<ASP:TEMPLATECOLUMN HeaderText="組別擁有者">
																<HEADERSTYLE Width="80px" Wrap="false" VerticalAlign="Middle" CssClass="grid-header" HorizontalAlign="Left"></HEADERSTYLE>
																<ITEMSTYLE Width="80px" CssClass="grid-item"></ITEMSTYLE>
																<ITEMTEMPLATE>
																	<%# DataBinder.Eval(Container, "DataItem.cgroup_owner")%>
																</ITEMTEMPLATE>
															</ASP:TEMPLATECOLUMN>
															<ASP:TEMPLATECOLUMN HeaderText="組別類型">
																<HEADERSTYLE Wrap="false" VerticalAlign="Middle" CssClass="grid-header" HorizontalAlign="Left"></HEADERSTYLE>
																<ITEMSTYLE Width="40px" CssClass="grid-item"></ITEMSTYLE>
																<ITEMTEMPLATE>
																	<%# DataBinder.Eval(Container, "DataItem.cgroup_type")%>
																</ITEMTEMPLATE>
															</ASP:TEMPLATECOLUMN>
															<ASP:TEMPLATECOLUMN HeaderText="添加日期">
																<HeaderStyle HorizontalAlign="Left" Width="160px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle CssClass="grid-item" Width="160px"></ItemStyle>
																<ITEMTEMPLATE>
																	<%# DataBinder.Eval(Container, "DataItem.create_date")%>
																</ITEMTEMPLATE>
															</ASP:TEMPLATECOLUMN>
															<ASP:EDITCOMMANDCOLUMN EditText="編輯" CancelText="取消" UpdateText="更新" ItemStyle-Font-Bold="True" ButtonType="LinkButton">
																<HEADERSTYLE Width="60px" VerticalAlign="Middle" CssClass="grid-header" HorizontalAlign="Left"></HEADERSTYLE>
																<ITEMSTYLE Width="60px" CssClass="grid-item"></ITEMSTYLE>
															</ASP:EDITCOMMANDCOLUMN>
															<ASP:BUTTONCOLUMN Text="刪除" ItemStyle-Font-Bold="True" CommandName="Delete">
																<HEADERSTYLE Width="60px" VerticalAlign="Middle" CssClass="grid-header" HorizontalAlign="Left"></HEADERSTYLE>
																<ITEMSTYLE Width="60px" CssClass="grid-item"></ITEMSTYLE>
															</ASP:BUTTONCOLUMN>
														</COLUMNS>
													</anthem:DATAGRID></TD>
											</TR>
											<TR width="100%">
												<TD colSpan="5"><FONT face="新細明體"></FONT></TD>
											</TR>
										</TABLE>
									</anthem:panel><anthem:panel id="panel4" runat="server" Visible="false">
										<TABLE class="tan-border02" style="WIDTH: 100%; BORDER-COLLAPSE: collapse; HEIGHT: 380px"
											cellSpacing="10" cellPadding="0" rules="none" align="left" border="0">
											<TR>
												<TD vAlign="baseline" align="left" height="1"></TD>
												<TD align="left" height="1"></TD>
												<TD align="left" height="1"></TD>
												<TD align="right" height="1"></TD>
												<TD align="left" height="1"></TD>
												<TD align="right" height="1"></TD>
												<TD align="left" height="1"></TD>
												<TD align="left" height="1"></TD>
											</TR>
											<TR vAlign="middle" width="100%">
												<TD vAlign="baseline" align="left" height="1"><STRONG>
														<ASP:LABEL id="Label9" runat="server" Width="70px" Font-Bold="True">組別類型 
                  ：</ASP:LABEL></STRONG></TD>
												<TD align="left" height="1">
													<anthem:DROPDOWNLIST id="dplGroupType" runat="server" Width="80px" AutoCallBack="True">
														<ASP:LISTITEM Selected="True" Value="P">私人</ASP:LISTITEM>
														<ASP:LISTITEM Value="S">共享</ASP:LISTITEM>
													</anthem:DROPDOWNLIST></TD>
												<TD align="left" height="1">
													<anthem:DROPDOWNLIST id="dplAllGroup" runat="server" Width="120px" AutoCallBack="True"></anthem:DROPDOWNLIST></TD>
												<TD align="right" height="1">按姓名：
												</TD>
												<TD align="left" height="1">
													<anthem:TEXTBOX id="txtName4" runat="server" Width="80px"></anthem:TEXTBOX>
													<ASP:REQUIREDFIELDVALIDATOR id="Requiredfieldvalidator2" runat="server" ErrorMessage="*" ControlToValidate="txtName4"
														Enabled="False"></ASP:REQUIREDFIELDVALIDATOR></TD>
												<TD align="right" height="1"><FONT face="新細明體">按號碼：</FONT></TD>
												<TD align="left" height="1">
													<anthem:TEXTBOX id="txtMobile4" runat="server" Width="80px" MaxLength="25" onChange="return CheckNum4()"></anthem:TEXTBOX>
													<ASP:REQUIREDFIELDVALIDATOR id="Requiredfieldvalidator9" runat="server" ErrorMessage="*" ControlToValidate="txtMobile4"
														Enabled="False"></ASP:REQUIREDFIELDVALIDATOR></TD>
												<TD align="left" height="1">
													<anthem:BUTTON id="btnSearch4" runat="server" Text="查詢" vAlign="baseline"></anthem:BUTTON></TD>
											<TR>
												<TD vAlign="baseline" align="left" height="1"></TD>
												<TD align="left" height="1"></TD>
												<TD align="left" height="1"></TD>
												<TD align="right" height="1"></TD>
												<TD align="left" height="1"></TD>
												<TD align="right" height="1"></TD>
												<TD align="left" height="1"></TD>
												<TD align="left" height="1"></TD>
											</TR>
											<TR width="100%">
												<TD vAlign="top" align="left" width="50%" colSpan="8" height="256">
													<anthem:DATAGRID id="dgdata4" runat="server" Width="100%" AutoGenerateColumns="false" AllowPaging="True">
														<PAGERSTYLE Mode="NumericPages"></PAGERSTYLE>
														<EDITITEMSTYLE Height="36px"></EDITITEMSTYLE>
														<ITEMSTYLE Height="36px"></ITEMSTYLE>
														<HEADERSTYLE Font-Bold="True" Height="20px" Wrap="False"></HEADERSTYLE>
														<COLUMNS>
															<ASP:TEMPLATECOLUMN HeaderText="ID">
																<HEADERSTYLE Wrap="False" VerticalAlign="Middle" CssClass="grid-header" HorizontalAlign="Left"></HEADERSTYLE>
																<ITEMSTYLE Width="40px" CssClass="grid-item"></ITEMSTYLE>
																<ITEMTEMPLATE>
																	<%#this.dgdata4.CurrentPageIndex * this.dgdata4.PageSize + Container.ItemIndex + 1%>
																</ITEMTEMPLATE>
															</ASP:TEMPLATECOLUMN>
															<asp:TemplateColumn HeaderText="ITEM_NO">
																<HeaderStyle HorizontalAlign="Left" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle Width="40px" CssClass="grid-item"></ItemStyle>
																<ItemTemplate>
																	<%# DataBinder.Eval(Container, "DataItem.IITEM_NO") %>
																</ItemTemplate>
															</asp:TemplateColumn>
															<ASP:TEMPLATECOLUMN>
																<HEADERSTYLE VerticalAlign="Middle" CssClass="grid-header" HorizontalAlign="Left"></HEADERSTYLE>
																<ITEMSTYLE Width="120px" CssClass="grid-item"></ITEMSTYLE>
																<HEADERTEMPLATE>
																	<FONT face="新細明體">姓名</FONT>
																</HEADERTEMPLATE>
																<ITEMTEMPLATE>
																	<ASP:LABEL id=lbdg4Name4 runat="server" Width="120px" Text='<%# DataBinder.Eval(Container, "DataItem.CMEMBER_NAME") %>'>
																	</ASP:LABEL>
																</ITEMTEMPLATE>
																<EDITITEMTEMPLATE>
																	<ASP:TEXTBOX id=txtdg4Name4 runat="server" Width="120px" Text='<%# DataBinder.Eval(Container, "DataItem.CMEMBER_NAME").ToString().Trim() %>'>
																	</ASP:TEXTBOX>
																	<ASP:LABEL id=lbdg4Name4E runat="server" Visible="False" Width="120px" Text='<%# DataBinder.Eval(Container, "DataItem.CMEMBER_NAME").ToString().Trim() %>'>
																	</ASP:LABEL>
																</EDITITEMTEMPLATE>
															</ASP:TEMPLATECOLUMN>
															<ASP:TEMPLATECOLUMN>
																<HEADERSTYLE VerticalAlign="Middle" CssClass="grid-header" HorizontalAlign="Left"></HEADERSTYLE>
																<ITEMSTYLE Width="100px" CssClass="grid-item"></ITEMSTYLE>
																<HEADERTEMPLATE>
																	<FONT face="新細明體">手機號碼</FONT>
																</HEADERTEMPLATE>
																<ITEMTEMPLATE>
																	<ASP:LABEL id=lbdg4Mobile4 runat="server" Width="100px" Text='<%# DataBinder.Eval(Container, "DataItem.CMOBILENO") %>'>
																	</ASP:LABEL>
																</ITEMTEMPLATE>
																<EDITITEMTEMPLATE>
																	<ASP:TEXTBOX id=txtdg4Mobile4 runat="server" Width="100px" Text='<%# DataBinder.Eval(Container, "DataItem.CMOBILENO").ToString().Trim() %>' MaxLength="8">
																	</ASP:TEXTBOX>
																	<ASP:LABEL id=lbdg4Mobile4E runat="server" Visible="False" Width="10px" Text='<%# DataBinder.Eval(Container, "DataItem.CMOBILENO").ToString().Trim() %>'>
																	</ASP:LABEL>
																</EDITITEMTEMPLATE>
															</ASP:TEMPLATECOLUMN>
															<ASP:TEMPLATECOLUMN>
																<HEADERSTYLE VerticalAlign="Middle" CssClass="grid-header" HorizontalAlign="Left"></HEADERSTYLE>
																<ITEMSTYLE Width="140px" CssClass="grid-item"></ITEMSTYLE>
																<HEADERTEMPLATE>
																	<FONT face="新細明體">組別</FONT>
																</HEADERTEMPLATE>
																<ITEMTEMPLATE>
																	<ASP:LABEL id=lbdg4GroupID4 runat="server" Visible="false" Width="160px" Text='<%#  DataBinder.Eval(Container, "DataItem.cgroup_id")%>'>
																	</ASP:LABEL>
																	<ASP:LABEL id=lbdg4GroupName4 runat="server" Width="160px" Text='<%# GetGroupName(DataBinder.Eval(Container, "DataItem.cgroup_id"))%>'>
																	</ASP:LABEL>
																</ITEMTEMPLATE>
																<EDITITEMTEMPLATE>
																	<ASP:LABEL id=lbdg4GroupID4E runat="server" Visible="false" Width="10px" Text='<%# DataBinder.Eval(Container, "DataItem.cgroup_id") %>'>
																	</ASP:LABEL>
																	<ASP:LABEL id=lbdg4GroupName4E runat="server" Visible="false" Width="10px" Text='<%# GetGroupName(DataBinder.Eval(Container, "DataItem.cgroup_id"))%>'>
																	</ASP:LABEL>
																	<ASP:DROPDOWNLIST id="dpldg4Group4" runat="server" Width="160px"></ASP:DROPDOWNLIST>
																</EDITITEMTEMPLATE>
															</ASP:TEMPLATECOLUMN>
															<ASP:EDITCOMMANDCOLUMN EditText="編輯" CancelText="取消" UpdateText="更新" ButtonType="LinkButton">
																<HEADERSTYLE Width="60px" VerticalAlign="Middle" CssClass="grid-header" HorizontalAlign="Left"></HEADERSTYLE>
																<ITEMSTYLE Width="60px" Font-Bold="True" CssClass="grid-item"></ITEMSTYLE>
															</ASP:EDITCOMMANDCOLUMN>
															<ASP:BUTTONCOLUMN Text="刪除" CommandName="Delete">
																<HEADERSTYLE Width="60px" VerticalAlign="Middle" CssClass="grid-header" HorizontalAlign="Left"></HEADERSTYLE>
																<ITEMSTYLE Width="60px" Font-Bold="True" CssClass="grid-item"></ITEMSTYLE>
															</ASP:BUTTONCOLUMN>
														</COLUMNS>
													</anthem:DATAGRID></TD>
											</TR>
											<TR width="100%">
												<TD colSpan="8"><FONT face="新細明體"></FONT></TD>
											</TR>
										</TABLE>
									</anthem:panel><anthem:panel id="panel3" runat="server" Visible="false">
										<TABLE class="tan-border02" style="WIDTH: 100%; BORDER-COLLAPSE: collapse; HEIGHT: 380px"
											cellSpacing="10" cellPadding="0" rules="none" align="left" border="0">
											<TR>
												<TD style="WIDTH: 10px" height="1"></TD>
												<TD align="left" colSpan="3" height="1"><FONT face="新細明體">
														<ASP:LABEL id="lbRightShow" runat="server" Visible="False" Width="112px" Font-Bold="True">共享組別許可權 ：</ASP:LABEL>&nbsp;
														<ASP:REQUIREDFIELDVALIDATOR id="REQUIREDFIELDVALIDATOR1" runat="server" ErrorMessage="*" ControlToValidate="dplUsers"></ASP:REQUIREDFIELDVALIDATOR></FONT></TD>
												<TD align="left" width="15%" height="1"><FONT face="新細明體"></FONT></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 10px" height="1"></TD>
												<TD align="center" colSpan="3" height="1"><FONT face="新細明體"></FONT>
													<TABLE style="HEIGHT: 142px" borderColor="#edecd1" cellSpacing="1" cellPadding="0" rules="none"
														width="100%" align="center" border="1">
														<TR>
															<TD style="HEIGHT: 59px" align="center" colSpan="2">
																<ASP:CHECKBOXLIST id="cblCheck" runat="server" Width="80%" RepeatDirection="Horizontal" RepeatColumns="4"></ASP:CHECKBOXLIST>
																<P><FONT face="新細明體"></FONT></P>
															</TD>
														</TR>
														<TR>
															<TD style="HEIGHT: 1px" align="center" width="50%"><FONT face="新細明體"></FONT></TD>
															<TD align="left" width="50%">
																<anthem:CHECKBOX id="cbCheckAll" onclick="DoCheck(this.checked) " runat="server" Text="全選" AutoCallBack="True"></anthem:CHECKBOX></TD>
														</TR>
														<TR>
															<TD style="HEIGHT: 1px" align="right" width="50%">
																<anthem:BUTTON id="btnSaveRight" runat="server" Text="保存"></anthem:BUTTON></TD>
															<TD align="left" width="50%"><INPUT id="btnCannel" onclick="Clear()" type="button" value="重置" name="btnCannel">
																<anthem:LABEL id="lbRightResult" runat="server" Width="62px" ForeColor="Red"></anthem:LABEL></TD>
														</TR>
													</TABLE>
												</TD>
												<TD align="left" width="15%" height="1"><FONT face="新細明體"></FONT></TD>
											</TR>
											<TR width="100%">
												<TD vAlign="top" align="left" width="50%" colSpan="5" height="1"><FONT face="新細明體"></FONT></TD>
											</TR>
											<TR width="100%">
												<TD colSpan="5"><FONT face="新細明體"></FONT></TD>
											</TR>
										</TABLE>
									</anthem:panel><anthem:panel id="panel5" runat="server" Visible="false">
										<TABLE class="tan-border02" style="WIDTH: 100%; BORDER-COLLAPSE: collapse; HEIGHT: 100%"
											cellSpacing="10" cellPadding="0" rules="none" align="left" border="0">
											<TR>
												<TD style="WIDTH: 10px" height="1"><FONT face="新細明體"></FONT></TD>
												<TD align="center" colSpan="3" height="1"><FONT face="新細明體">&nbsp;</FONT></TD>
												<TD align="left" width="15%" height="1"><FONT face="新細明體"></FONT></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 10px" height="1"><FONT face="新細明體"></FONT></TD>
												<TD align="center" colSpan="3" height="1"><FONT face="新細明體">
														<TABLE id="Table4" borderColor="#edecd1" height="100%" cellSpacing="1" cellPadding="0"
															rules="none" width="80%" align="left" border="1">
															<TR vAlign="middle">
																<TD style="WIDTH: 10px" vAlign="baseline" align="left" height="1"></TD>
																<TD align="right" height="1">
																	<ASP:LABEL id="Label2" runat="server" Width="112px" Font-Bold="True">選擇組別類型 
                        ：</ASP:LABEL></TD>
																<TD style="WIDTH: 118px; HEIGHT: 1px" align="left" height="1">
																	<anthem:RADIOBUTTON id="rbGroupP" runat="server" Text="私人組別" AutoCallBack="True" Checked="True"></anthem:RADIOBUTTON></TD>
																<TD style="HEIGHT: 24px" align="left" height="24">
																	<anthem:RADIOBUTTON id="rbGroupS" runat="server" Text="共享組別" AutoCallBack="True"></anthem:RADIOBUTTON></TD>
																<TD style="HEIGHT: 24px" align="left" width="10%" height="23"></TD>
																<TD style="HEIGHT: 24px" align="left" width="10%" height="23"><FONT face="新細明體"></FONT></TD>
															<TR>
																<TD style="WIDTH: 10px" height="1"></TD>
																<TD style="WIDTH: 143px" align="right" height="1"></TD>
																<TD style="WIDTH: 118px" align="left" height="1"></TD>
																<TD align="left" height="1"><FONT face="新細明體">&nbsp;</FONT></TD>
																<TD align="left" width="15%" height="1"></TD>
																<TD align="left" width="15%" height="1"></TD>
															</TR>
															<TR>
																<TD vAlign="baseline" align="left" height="1"></TD>
																<TD align="right" height="1">
																	<ASP:LABEL id="Label7" runat="server" Width="112px" Font-Bold="True">上傳方式 
                        ：</ASP:LABEL></TD>
																<TD style="WIDTH: 118px" align="left" height="1">
																	<anthem:RADIOBUTTON id="rbTypeAdd" runat="server" Width="130px" Text="新增上傳組別的號碼" AutoCallBack="True"
																		Checked="True"></anthem:RADIOBUTTON></TD>
																<TD align="left" height="1">
																	<anthem:RADIOBUTTON id="rbTypeCover" runat="server" Width="130px" Text="上傳覆蓋組別的號碼" AutoCallBack="True"></anthem:RADIOBUTTON></TD>
																<TD align="left" width="15%" height="1">
																	<anthem:BUTTON id="btnUpload" runat="server" Visible="False" Width="52px" Text="上傳"></anthem:BUTTON></TD>
																<TD align="left" width="15%" height="1"></TD>
															</TR>
															<TR>
																<TD style="WIDTH: 10px" height="1"><FONT face="新細明體"></FONT></TD>
																<TD style="WIDTH: 143px" align="right" height="1"></TD>
																<TD style="WIDTH: 118px" align="left" height="1"></TD>
																<TD align="left" height="1"><FONT face="新細明體">&nbsp;</FONT></TD>
																<TD align="left" width="15%" height="1"></TD>
																<TD align="left" width="15%" height="1"></TD>
															</TR>
															<TR>
																<TD style="WIDTH: 10px; HEIGHT: 23px" height="23"></TD>
																<TD style="HEIGHT: 23px" align="right" height="23">
																	<ASP:LABEL id="Label8" runat="server" Width="130px" Font-Bold="True">EXCEL/CSV 附件 
                        ：</ASP:LABEL></TD>
																<TD style="HEIGHT: 23px" align="left" colSpan="2" height="23"><INPUT id="btnUploadMode" type="file"  accept="application/msexcel,application/csv" runat="server">
																	<anthem:LABEL id="lbrfvUpload" runat="server" Visible="false" ForeColor="Red">*</anthem:LABEL></TD>
																<TD style="HEIGHT: 23px" align="left" width="15%" height="23"><INPUT id="Submit1" style="WIDTH: 48px; HEIGHT: 24px" type="submit" value="上傳" name="Submit1"
																		runat="server"></TD>
																<TD style="HEIGHT: 23px" align="left" width="15%" height="23"></TD>
															</TR>
															<TR bgColor="#edecd1" height="1">
																<TD style="WIDTH: 10px" height="1"></TD>
																<TD align="right" height="1"><FONT face="新細明體"></FONT></TD>
																<TD align="left" colSpan="3" height="1"><FONT face="新細明體">&nbsp;&nbsp;
																		<anthem:LABEL id="lbUploadResult" runat="server" Visible="False" Width="100%" ForeColor="Red"></anthem:LABEL></FONT></TD>
																<TD align="left" height="1"></TD>
															</TR>
															<TR>
																<TD style="WIDTH: 10px" height="1"></TD>
																<TD align="center" colSpan="5" height="1"><FONT face="新細明體"></FONT><FONT face="新細明體">
																		<DIV id="div_load" runat="server"><IFRAME src="UploadRefresh.aspx" frameBorder="no" width="100%" height="500px"><TABLE class="font" style="FILTER: Alpha(opacity=80); WIDTH: 152px; HEIGHT: 42px" borderColor="#cccccc"
																					height="80" cellSpacing="1" cellPadding="5" width="160" border="0">
																					<TR>
																						<TD style="WIDTH: 55px">
																							<P>
																								<asp:Image id="imgLoad" runat="server" ImageUrl="resource/indicator.gif"></asp:Image></P>
																						</TD>
																						<TD>
																							<P>
																								<asp:Label id="lab_state" runat="server" ForeColor="Red"></asp:Label></P>
																						</TD>
																					</TR>
																				</TABLE>
																			</IFRAME>
																		</DIV>
																		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </FONT>
																</TD>
															</TR>
														</TABLE>
													</FONT>
												</TD>
												<TD align="left" width="15%" height="1"><FONT face="新細明體"></FONT></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 10px" height="1"></TD>
												<TD align="center" colSpan="3" height="1">
													<asp:TextBox id="TextBox4" runat="server" Visible="False">str</asp:TextBox>
													<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator"
														ControlToValidate="TextBox4"></asp:RequiredFieldValidator></TD>
												<TD align="left" width="15%" height="1"></TD>
											</TR>
										</TABLE>
									</anthem:panel><anthem:panel id="panel6" runat="server" Visible="false">
										<TABLE class="tan-border02" style="WIDTH: 100%; BORDER-COLLAPSE: collapse; HEIGHT: 380px"
											cellSpacing="10" cellPadding="0" rules="none" align="left" border="0">
											<TR style="DISPLAY: none" vAlign="middle" width="100%">
												<TD vAlign="baseline" align="right" width="80" height="1"><STRONG>
														<ASP:LABEL id="Label10" runat="server" Width="112px" Font-Bold="True">私人組別 ：</ASP:LABEL></STRONG></TD>
												<TD align="left" width="80" height="1">用戶：
													<anthem:DROPDOWNLIST id="Dropdownlist4" runat="server" Width="80px">
														<ASP:LISTITEM Selected="True" Value="All">All</ASP:LISTITEM>
													</anthem:DROPDOWNLIST></TD>
												<TD align="left" height="1">日期從：
													<ASP:TEXTBOX id="Textbox7" onclick="fPopUpDlg('CalendarUtrl/calendar.htm', document.fmSms.txtStartDate, 'winpop', 234, 261);return false"
														runat="server" Width="80px"></ASP:TEXTBOX>
													<ASP:REQUIREDFIELDVALIDATOR id="Requiredfieldvalidator4" runat="server" ErrorMessage="*" ControlToValidate="dplUsers"></ASP:REQUIREDFIELDVALIDATOR></TD>
												<TD align="left" width="200" height="1">到:
													<ASP:TEXTBOX id="Textbox8" onclick="fPopUpDlg('CalendarUtrl/calendar.htm', document.fmSms.txtEndDate, 'winpop', 234, 261);return false"
														runat="server" Width="80px"></ASP:TEXTBOX></TD>
												<TD align="left" width="1%" height="1"><FONT face="新細明體">
														<anthem:BUTTON id="Button4" runat="server" Text="查詢"></anthem:BUTTON></FONT></TD>
											<TR>
												<TD vAlign="baseline" align="right" width="80" height="1"><FONT face="新細明體"><STRONG>
															<ASP:LABEL id="Label11" runat="server" Visible="False" Width="112px" Font-Bold="True">添加聯絡人 
                  ：</ASP:LABEL></STRONG></FONT></TD>
												<TD align="left" width="80" height="1"><FONT face="新細明體"></FONT></TD>
												<TD align="left" width="220" height="1"><FONT face="新細明體"></FONT></TD>
												<TD align="left" height="1"></TD>
												<TD align="left" width="1%" height="1"></TD>
											</TR>
											<TR>
												<TD vAlign="baseline" align="right" width="80" height="1"><FONT face="新細明體"></FONT></TD>
												<TD align="right" width="80" height="1"><FONT face="新細明體">選擇組別：</FONT></TD>
												<TD align="left" width="220" height="1">
													<anthem:DROPDOWNLIST id="dplGroups" runat="server" Width="200px" AutoCallBack="True"></anthem:DROPDOWNLIST></TD>
												<TD align="left" height="1"><FONT face="新細明體">
														<ASP:BUTTON id="btnAdd" runat="server" Text="添加"></ASP:BUTTON></FONT></TD>
												<TD align="left" width="1%" height="1"></TD>
											</TR>
											<TR>
												<TD vAlign="baseline" align="right" width="80" height="1"><FONT face="新細明體"></FONT></TD>
												<TD align="right" width="80" height="1"><FONT face="新細明體">姓名：</FONT></TD>
												<TD align="left" width="220" height="1">
													<anthem:TEXTBOX id="txtName" runat="server" Width="200px"></anthem:TEXTBOX>
													<ASP:REQUIREDFIELDVALIDATOR id="RequiredFieldValidator5" runat="server" Visible="false" ErrorMessage="|" ControlToValidate="txtName"
														Enabled="False"></ASP:REQUIREDFIELDVALIDATOR>
													<anthem:LABEL id="lbrfvname" runat="server" Visible="false" ForeColor="Red">*</anthem:LABEL></TD>
												<TD align="left" height="1"><FONT face="新細明體"></FONT></TD>
												<TD align="left" width="1%" height="1"></TD>
											</TR>
											<TR>
												<TD vAlign="baseline" align="right" width="80" height="1"></TD>
												<TD align="right" width="80" height="1"><FONT face="新細明體">手機號碼：</FONT></TD>
												<TD align="left" width="220" height="1">
													<anthem:TEXTBOX id="txtMobile" runat="server" Width="200px" MaxLength="8" onChange="return CheckNum()"></anthem:TEXTBOX>
													<ASP:REQUIREDFIELDVALIDATOR id="RequiredFieldValidator6" runat="server" Visible="false" ErrorMessage="|" ControlToValidate="txtMobile"
														Enabled="False"></ASP:REQUIREDFIELDVALIDATOR>
													<anthem:LABEL id="lbrfvmobile" runat="server" Visible="false" ForeColor="Red">*</anthem:LABEL></TD>
												<TD align="left" height="1"><FONT face="新細明體">
														<anthem:BUTTON id="btnDeleteMember" runat="server" Text="刪除所選組別聯絡人"></anthem:BUTTON>&nbsp;
														<anthem:LABEL id="lbMsg6" runat="server" Width="240px" ForeColor="Red"></anthem:LABEL></FONT></TD>
												<TD align="left" width="1%" height="1"></TD>
											</TR>
											<TR>
												<TD vAlign="baseline" align="right" width="80" height="1"></TD>
												<TD align="right" width="80" height="1"></TD>
												<TD align="right" width="220" height="1"></TD>
												<TD align="left" height="1"><FONT face="新細明體">&nbsp; </FONT>
												</TD>
												<TD align="left" width="1%" height="1"></TD>
											</TR>
											<TR width="100%">
												<TD vAlign="top" align="left" width="50%" colSpan="5" height="256">
													<anthem:DATAGRID id="dgMember" runat="server" Width="100%" AutoGenerateColumns="false" AllowPaging="True">
														<PAGERSTYLE Mode="NumericPages"></PAGERSTYLE>
														<EDITITEMSTYLE Height="36px"></EDITITEMSTYLE>
														<ITEMSTYLE Height="36px"></ITEMSTYLE>
														<HEADERSTYLE Font-Bold="True" Height="20px" Wrap="False"></HEADERSTYLE>
														<COLUMNS>
															<ASP:TEMPLATECOLUMN HeaderText="ID">
																<HEADERSTYLE VerticalAlign="Middle" CssClass="grid-header" HorizontalAlign="Left"></HEADERSTYLE>
																<ITEMSTYLE Width="40px" CssClass="grid-item"></ITEMSTYLE>
																<ITEMTEMPLATE>
																	<%#this.dgMember.CurrentPageIndex * this.dgMember.PageSize + Container.ItemIndex + 1%>
																</ITEMTEMPLATE>
															</ASP:TEMPLATECOLUMN>
															<asp:TemplateColumn HeaderText="ITEM_NO">
																<HeaderStyle HorizontalAlign="Left" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle Width="40px" CssClass="grid-item"></ItemStyle>
																<ItemTemplate>
																	<%# DataBinder.Eval(Container, "DataItem.IITEM_NO") %>
																</ItemTemplate>
															</asp:TemplateColumn>
															<ASP:TEMPLATECOLUMN>
																<HEADERSTYLE VerticalAlign="Middle" CssClass="grid-header" HorizontalAlign="Left"></HEADERSTYLE>
																<ITEMSTYLE Width="160px" CssClass="grid-item"></ITEMSTYLE>
																<HEADERTEMPLATE>
																	<FONT face="新細明體">組別</FONT>
																</HEADERTEMPLATE>
																<ITEMTEMPLATE>
																	<ASP:LABEL id="lbdgMemberGroupID" Visible =False runat="server" Width="160px" Text='<%# DataBinder.Eval(Container, "DataItem.cgroup_id") %>'>
																	</ASP:LABEL>
																	<ASP:LABEL id=lbdgMemberGroupName runat="server" Width="160px" Text='<%# GetGroupName(DataBinder.Eval(Container, "DataItem.cgroup_id")) %>'>
																	</ASP:LABEL>
																</ITEMTEMPLATE>
															</ASP:TEMPLATECOLUMN>
															<ASP:TEMPLATECOLUMN>
																<HEADERSTYLE VerticalAlign="Middle" CssClass="grid-header" HorizontalAlign="Left"></HEADERSTYLE>
																<ITEMSTYLE Width="120px" CssClass="grid-item"></ITEMSTYLE>
																<HEADERTEMPLATE>
																	<FONT face="新細明體">姓名</FONT>
																</HEADERTEMPLATE>
																<ITEMTEMPLATE>
																	<ASP:LABEL id=lbUName runat="server" Width="120px" 
                  　Text='<%# DataBinder.Eval(Container, "DataItem.CMEMBER_NAME") %>'>
																	</ASP:LABEL>
																</ITEMTEMPLATE>
																<EDITITEMTEMPLATE>
																	<ASP:TEXTBOX id=txtdgMemberName runat="server" Width="120px" Text='<%# DataBinder.Eval(Container, "DataItem.CMEMBER_NAME") .ToString().Trim()%>'>
																	</ASP:TEXTBOX>
																	<ASP:LABEL id=lbdgMemberName runat="server" Visible="False" Width="10px" Text='<%# DataBinder.Eval(Container, "DataItem.CMEMBER_NAME").ToString().Trim() %>'>
																	</ASP:LABEL>
																</EDITITEMTEMPLATE>
															</ASP:TEMPLATECOLUMN>
															<ASP:TEMPLATECOLUMN>
																<HEADERSTYLE VerticalAlign="Middle" CssClass="grid-header" HorizontalAlign="Left"></HEADERSTYLE>
																<ITEMSTYLE Width="120px" CssClass="grid-item"></ITEMSTYLE>
																<HEADERTEMPLATE>
																	<FONT face="新細明體">手機號碼</FONT>
																</HEADERTEMPLATE>
																<ITEMTEMPLATE>
																	<ASP:LABEL id=lbUMobile runat="server" Width="120px" 
                  　Text='<%# DataBinder.Eval(Container, "DataItem.CMOBILENO") %>'>
																	</ASP:LABEL>
																</ITEMTEMPLATE>
																<EDITITEMTEMPLATE>
																	<ASP:TEXTBOX id=txtdgMemberMobile runat="server" Width="120px" Text='<%# DataBinder.Eval(Container, "DataItem.CMOBILENO").ToString().Trim() %>' MaxLength="8">
																	</ASP:TEXTBOX>
																	<ASP:LABEL id=lbdgMemberMobile runat="server" Visible="False" Width="10px" Text='<%# DataBinder.Eval(Container, "DataItem.CMOBILENO").ToString().Trim() %>'>
																	</ASP:LABEL>
																</EDITITEMTEMPLATE>
															</ASP:TEMPLATECOLUMN>
															<ASP:TEMPLATECOLUMN HeaderText="添加日期">
																<HEADERSTYLE VerticalAlign="Middle" CssClass="grid-header" HorizontalAlign="Left"></HEADERSTYLE>
																<ITEMSTYLE Width="120px" CssClass="grid-item"></ITEMSTYLE>
																<ITEMTEMPLATE>
																	<%# DataBinder.Eval(Container, "DataItem.create_date")%>
																</ITEMTEMPLATE>
															</ASP:TEMPLATECOLUMN>
															<ASP:EDITCOMMANDCOLUMN EditText="編輯" CancelText="取消" UpdateText="更新" ItemStyle-Font-Bold="True" ButtonType="LinkButton">
																<HEADERSTYLE Width="60px" VerticalAlign="Middle" CssClass="grid-header" HorizontalAlign="Left"></HEADERSTYLE>
																<ITEMSTYLE Width="60px" CssClass="grid-item"></ITEMSTYLE>
															</ASP:EDITCOMMANDCOLUMN>
															<ASP:BUTTONCOLUMN Text="刪除" ItemStyle-Font-Bold="True" CommandName="Delete">
																<HEADERSTYLE Width="60px" VerticalAlign="Middle" CssClass="grid-header" HorizontalAlign="Left"></HEADERSTYLE>
																<ITEMSTYLE Width="60px" CssClass="grid-item"></ITEMSTYLE>
															</ASP:BUTTONCOLUMN>
														</COLUMNS>
													</anthem:DATAGRID></TD>
											</TR>
											<TR width="100%">
												<TD colSpan="5"></TD>
											</TR>
										</TABLE>
									</anthem:panel></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			</TD></TR></TABLE></TD></TR></TABLE></TD></TR></TABLE></form>
	</body>
</HTML>
