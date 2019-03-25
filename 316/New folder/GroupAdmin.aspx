<%@ Register TagPrefix="anthem" Namespace="Anthem" Assembly="Anthem" %>
<%@ Page language="c#" Codebehind="GroupAdmin.aspx.cs" AutoEventWireup="false" Inherits="CENTASMS.GroupAdmin" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
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
              alert('<%= GetLocalResourceObject("GAError1").ToString() %>' + "！(" + strvalue + ')');
                  return (false);
               }
               else
               {
                if(reg.exec(str))
                {}else{
                    alert('<%= GetLocalResourceObject("GAError2").ToString() %>' + "！(" + strvalue + ')'); 
               return (false);
                }
               } 
         }
         else if(strvalue.indexOf("00") == 0 )
         { 
            if( strvalue.length<3)
            {
                alert('<%= GetLocalResourceObject("GAError1").ToString() %>' + "！(" + strvalue + ')');
              return (false);
            }
         }
         else
         {
         
           if  (strvalue.length != 8)
               {
               alert('<%= GetLocalResourceObject("GAError1").ToString() %>' + "！(" + strvalue + ')');
                  return (false);
               }
               else
               {
                if(reg.exec(strvalue))
                {}else{
                    alert('<%= GetLocalResourceObject("GAError2").ToString() %>' + "！(" + strvalue + ')'); 
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
              alert('<%= GetLocalResourceObject("GAError1").ToString() %>' + "！(" + strvalue + ')');
                  return (false);
               }
               else
               {
                if(reg.exec(str))
                {}else{
                    alert('<%= GetLocalResourceObject("GAError2").ToString() %>' + "！(" + strvalue + ')'); 
               return (false);
                }
               } 
         }
         else if(strvalue.indexOf("00") == 0 )
         { 
            if( strvalue.length<3)
            {
                alert('<%= GetLocalResourceObject("GAError1").ToString() %>' + "！(" + strvalue + ')');
              return (false);
            }
         }
         else
         {
         
           if  (strvalue.length != 8)
               {
               alert('<%= GetLocalResourceObject("GAError1").ToString() %>' + "！(" + strvalue + ')');
                  return (false);
               }
               else
               {
                if(reg.exec(strvalue))
                {}else{
                    alert('<%= GetLocalResourceObject("GAError2").ToString() %>' + "！(" + strvalue + ')'); 
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
              alert('<%= GetLocalResourceObject("GAError1").ToString() %>'+"！(" + strvalue+')');
                  return (false);
               }
               else
               {
                if(reg.exec(str))
                {}else{
                    alert('<%= GetLocalResourceObject("GAError2").ToString() %>' + "！(" + strvalue + ')'); 
               return (false);
                }
               } 
         }
         else if(strvalue.indexOf("00") == 0 )
         { 
            if( strvalue.length<3)
            {
                alert('<%= GetLocalResourceObject("GAError1").ToString() %>' + "！(" + strvalue + ')');
              return (false);
            }
         }
         else
         {
         
           if  (strvalue.length != 8)
               {
               alert('<%= GetLocalResourceObject("GAError1").ToString() %>' + "！(" + strvalue + ')');
                  return (false);
               }
               else
               {
                if(reg.exec(strvalue))
                {}else{
                    alert('<%= GetLocalResourceObject("GAError2").ToString() %>' + "！(" + strvalue + ')'); 
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
							<asp:Literal runat="server" Text="<%$ Resources:GAUser %>"/>&nbsp;<asp:label id="lbUser" runat="server" meta:resourcekey="lbUserResource1"></asp:label></P>
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
								<td vAlign="top"><anthem:panel id="panel1" runat="server" Visible="False" meta:resourcekey="panel1Resource1">
										<TABLE class="tan-border02" style="WIDTH: 100%; BORDER-COLLAPSE: collapse; HEIGHT: 380px"
											cellSpacing="10" cellPadding="0" rules="none" align="left" border="0">
											<TR style="DISPLAY: none" vAlign="middle" width="100%">
												<TD style="WIDTH: 200px" vAlign="baseline" align="left" height="1"><STRONG>  <asp:Literal runat="server" Text="<%$ Resources:GAPGroup %>"/>：</STRONG>
												</TD>
												<TD align="left"  style="WIDTH: 200px"  height="1"> <asp:Literal runat="server" Text="<%$ Resources:GAUser %>"/>
													<anthem:DROPDOWNLIST id="dplUsers" runat="server" Width="80px" meta:resourcekey="dplUsersResource1">
														<ASP:LISTITEM Selected="True" Value="All" meta:resourcekey="ListItemResource1">All</ASP:LISTITEM>
													</anthem:DROPDOWNLIST></TD>
												<TD align="left"  style="WIDTH: 200px"   height="1"> <asp:Literal runat="server" Text="<%$ Resources:GASelectDateFrom %>"/>
													<ASP:TEXTBOX id="txtStartDate" onclick="fPopUpDlg('CalendarUtrl/calendar.htm', document.fmSms.txtStartDate, 'winpop', 234, 261);return false"
														runat="server" Width="80px" meta:resourcekey="txtStartDateResource1"></ASP:TEXTBOX>
													<ASP:REQUIREDFIELDVALIDATOR id="rfv" runat="server" ErrorMessage="*" ControlToValidate="dplUsers" meta:resourcekey="rfvResource1"></ASP:REQUIREDFIELDVALIDATOR></TD>
												<TD align="left"  style="WIDTH: 200px"  height="1"> <asp:Literal runat="server" Text="<%$ Resources:GASelectDateTo  %>"/>
													<ASP:TEXTBOX id="txtEndDate" onclick="fPopUpDlg('CalendarUtrl/calendar.htm', document.fmSms.txtEndDate, 'winpop', 234, 261);return false"
														runat="server" Width="80px" meta:resourcekey="txtEndDateResource1"></ASP:TEXTBOX></TD>
												<TD align="left" width="50%" height="1"><FONT face="新細明體">
														<anthem:BUTTON id="btnSearch" runat="server" Text="查詢" meta:resourcekey="btnSearchResource1"></anthem:BUTTON></FONT></TD>
											<TR >
												<TD vAlign="bottom" align="left" height="8" ></TD>
												<TD vAlign="bottom" align="left" height="1"></TD>
												<TD vAlign="bottom" align="left" height="1"></TD>
												<TD vAlign="bottom" align="left"></TD>
												<TD></TD>
											</TR>
											<TR vAlign="bottom">
												<TD style="WIDTH: 200px" vAlign="bottom" align="left" height="1">
													<ASP:LABEL id="lbGroupPP" runat="server" Width="200px" Font-Bold="True" Font-Size ="Small" meta:resourcekey="lbGroupPPResource1">添加私人組別：</ASP:LABEL></TD>
												<TD  style="WIDTH: 200px" vAlign="bottom" align="left" height="1">
													<anthem:TEXTBOX id="txtGroupP" runat="server" Width="128px" meta:resourcekey="txtGroupPResource1"></anthem:TEXTBOX>
													<ASP:REQUIREDFIELDVALIDATOR id="Requiredfieldvalidator7" runat="server" ErrorMessage="*" ControlToValidate="txtGroupP"
														Enabled="False" meta:resourcekey="Requiredfieldvalidator7Resource1"></ASP:REQUIREDFIELDVALIDATOR>
													<anthem:LABEL id="lbmsgRP" runat="server" Width="1px" ForeColor="Red" meta:resourcekey="lbmsgRPResource1"></anthem:LABEL></TD>
												<TD style="WIDTH: 200px"  vAlign="bottom" align="left" height="1">
													<ASP:LABEL id="lbGroupPPwd" runat="server" Visible="False" Width="120px" Font-Bold="True" meta:resourcekey="lbGroupPPwdResource1">添加私人組別密碼：</ASP:LABEL></TD>
												<TD style="WIDTH: 100px"  vAlign="bottom" align="left">
													<anthem:TEXTBOX id="tbGroupPPwd" runat="server" Visible="False" Width="128px" meta:resourcekey="tbGroupPPwdResource1"></anthem:TEXTBOX></TD>
												<TD style="WIDTH:60%" align="left"  >
													<anthem:BUTTON id="btnAddGroupP" runat="server" Text="添加" meta:resourcekey="btnAddGroupPResource1"></anthem:BUTTON>
													<anthem:BUTTON id="btnDeleteP" runat="server" Text="刪除所有組別&amp;聯絡人" meta:resourcekey="btnDeletePResource1"></anthem:BUTTON>
													<anthem:LABEL id="lbMsgP" runat="server" Width="220px" ForeColor="Red" meta:resourcekey="lbMsgPResource1"></anthem:LABEL></TD>
											</TR>
											<TR>
												<TD vAlign="bottom" align="left" height="6"></TD>
												<TD vAlign="bottom" align="left" height="1"></TD>
												<TD vAlign="bottom" align="left" height="1"></TD>
												<TD vAlign="bottom" align="left" height="1"></TD>
												<TD vAlign="bottom" align="left" height="1"></TD>
											</TR>
											<TR width="100%">
												<TD vAlign="top" align="left" width="50%" colSpan="5" height="256">
													<anthem:DATAGRID id="dgData" runat="server" Width="98%" AutoGenerateColumns="False" AllowPaging="True" meta:resourcekey="dgDataResource1">
														<Columns>
                                                            <asp:TemplateColumn HeaderText="ID">
                                                                <ItemTemplate>
                                                                    <%# this.dgData.CurrentPageIndex * this.dgData.PageSize + Container.ItemIndex + 1 %><font face="新細明體"></font>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                                <ItemStyle CssClass="grid-item" Width="40px" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="<%$ Resources:GAGroupName %>">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtGroupPE" runat="server" meta:resourcekey="txtGroupPEResource1" Text='<%# DataBinder.Eval(Container, "DataItem.cgroup_NAME") %>' Width="160px"></asp:TextBox>
                                                                    <asp:Label ID="lboldGroupNamePE" runat="server" meta:resourcekey="lboldGroupNamePEResource1" Text='<%# DataBinder.Eval(Container, "DataItem.cgroup_NAME") %>' Visible="False" Width="10px"></asp:Label>
                                                                    <asp:Label ID="lbGroupIDPE" runat="server" meta:resourcekey="lbGroupIDPEResource1" Text='<%# DataBinder.Eval(Container, "DataItem.cgroup_ID") %>' Visible="False" Width="10px"></asp:Label>
                                                                </EditItemTemplate> 
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbGroupIDP" runat="server" meta:resourcekey="lbGroupIDPResource1" Text='<%# DataBinder.Eval(Container, "DataItem.cgroup_ID") %>' Visible="False" Width="10px"></asp:Label>
                                                                    <asp:Label ID="lbGroupIDNameP" runat="server" meta:resourcekey="lbGroupIDNamePResource1" Text='<%# DataBinder.Eval(Container, "DataItem.cgroup_NAME") %>' Width="150px"></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                                <ItemStyle CssClass="grid-item" Width="160px" Wrap="False" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtGroupPwdPE" runat="server" meta:resourcekey="txtGroupPwdPEResource1" Text='<%# DataBinder.Eval(Container, "DataItem.cgroup_pwd") %>' Width="100px"></asp:TextBox>
                                                                    <asp:Label ID="lbGroupPwdPE" runat="server" meta:resourcekey="lbGroupPwdPEResource1" Text='<%# DataBinder.Eval(Container, "DataItem.cgroup_pwd") %>' Visible="False" Width="10px"></asp:Label>
                                                                </EditItemTemplate>
                                                                <HeaderTemplate>
                                                                    組別密碼
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbGroupPwdP" runat="server" meta:resourcekey="lbGroupPwdPResource1" Text='<%# DataBinder.Eval(Container, "DataItem.cgroup_pwd") %>' Visible="False" Width="10px"></asp:Label>
                                                                    <%# DataBinder.Eval(Container, "DataItem.cgroup_pwd") %>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                                <ItemStyle CssClass="grid-item" Width="100px" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="<%$ Resources:GAGroupNum %>">
                                                                <ItemTemplate>
                                                                    <%# DataBinder.Eval(Container, "DataItem.CREATE_COUNT") %>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Width="80px" Wrap="False" />
                                                                <ItemStyle CssClass="grid-item" Width="80px" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="<%$ Resources:GAGroupOwner %>">
                                                                <ItemTemplate>
                                                                    <%# DataBinder.Eval(Container, "DataItem.cgroup_owner") %>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Width="80px" Wrap="False" />
                                                                <ItemStyle CssClass="grid-item" Width="80px" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="<%$ Resources:GAGroupType %>">
                                                                <ItemTemplate>
                                                                    <%# DataBinder.Eval(Container, "DataItem.cgroup_type") %>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                                <ItemStyle CssClass="grid-item" Width="40px" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="<%$ Resources:GAGroupAddDate %>">
                                                                <ItemTemplate>
                                                                    <%# DataBinder.Eval(Container, "DataItem.create_date") %>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Width="160px" />
                                                                <ItemStyle CssClass="grid-item" Width="160px" />
                                                            </asp:TemplateColumn>
                                                            <asp:EditCommandColumn CancelText="取消" EditText="編輯" meta:resourcekey="EditCommandColumnResource1" UpdateText="更新">
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Width="60px" />
                                                                <ItemStyle CssClass="grid-item" Font-Bold="True" Width="60px" />
                                                            </asp:EditCommandColumn>
                                                            <asp:ButtonColumn CommandName="Delete" meta:resourcekey="ButtonColumnResource1" Text="刪除">
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Width="60px" />
                                                                <ItemStyle CssClass="grid-item" Font-Bold="True" Width="60px" />
                                                            </asp:ButtonColumn>
                                                        </Columns>
                                                        <EditItemStyle Height="36px" />
                                                        <HeaderStyle Font-Bold="True" Height="20px" Wrap="False" />
                                                        <ItemStyle Height="36px" />
														<PAGERSTYLE Mode="NumericPages"></PAGERSTYLE>
													</anthem:DATAGRID></TD>
											</TR>
											<TR width="100%">
												<TD colSpan="5"><FONT face="新細明體"></FONT></TD>
											</TR>
										</TABLE>
									</anthem:panel><anthem:panel id="panel2" runat="server" Visible="False" meta:resourcekey="panel2Resource1">
										<TABLE class="tan-border02" style="WIDTH: 100%; BORDER-COLLAPSE: collapse; HEIGHT: 380px"
											cellSpacing="10" cellPadding="0" rules="none" align="left" border="0">
											<TR style="DISPLAY: none" vAlign="middle" width="100%">
												<TD style="WIDTH: 257px" vAlign="baseline" align="left" height="1"><STRONG> <asp:Literal runat="server" Text="<%$ Resources:GASGroup %>"/>：  </STRONG>
												</TD>
												<TD align="left" height="1"><asp:Literal runat="server" Text="<%$ Resources:GAUser %>"/> ：
													<anthem:DROPDOWNLIST id="dplUsers11" runat="server" Width="80px" meta:resourcekey="dplUsers11Resource1">
														<ASP:LISTITEM Selected="True" Value="All" meta:resourcekey="ListItemResource2">All</ASP:LISTITEM>
													</anthem:DROPDOWNLIST></TD>
												<TD align="left" height="1"><asp:Literal runat="server" Text="<%$ Resources:GASelectDateFrom %>"/>
													<ASP:TEXTBOX id="txtStartDate1" onclick="fPopUpDlg('CalendarUtrl/calendar.htm', document.fmSms.txtStartDate, 'winpop', 234, 261);return false"
														runat="server" Width="80px" meta:resourcekey="txtStartDate1Resource1"></ASP:TEXTBOX>
													<ASP:REQUIREDFIELDVALIDATOR id="rfv11" runat="server" ErrorMessage="*" ControlToValidate="dplUsers" meta:resourcekey="rfv11Resource1"></ASP:REQUIREDFIELDVALIDATOR></TD>
												<TD align="left" height="1"><asp:Literal runat="server" Text="<%$ Resources:GASelectDateTo %>"/>
													<ASP:TEXTBOX id="txtEndDate11" onclick="fPopUpDlg('CalendarUtrl/calendar.htm', document.fmSms.txtEndDate11, 'winpop', 234, 261);return false"
														runat="server" Width="80px" meta:resourcekey="txtEndDate11Resource1"></ASP:TEXTBOX></TD>
												<TD align="left" width="18%" height="1">
													<anthem:BUTTON id="btnSearch11" runat="server" Text="查詢" meta:resourcekey="btnSearch11Resource1"></anthem:BUTTON></TD>
											<TR>
												<TD vAlign="bottom" align="left" height="8"></TD>
												<TD vAlign="bottom" align="left" height="1"></TD>
												<TD vAlign="bottom" align="left" height="1"></TD>
												<TD vAlign="bottom" align="left"></TD>
												<TD></TD>
											</TR>
											<TR vAlign="bottom">
												<TD style="WIDTH: 200px" vAlign="bottom" align="left" height="1">
													<ASP:LABEL id="lbGroupS" runat="server" Width="200px" Font-Bold="True" meta:resourcekey="lbGroupSResource1">添加共享組別：</ASP:LABEL></TD>
												<TD style="WIDTH: 200px" vAlign="bottom" align="left" height="1"><FONT face="新細明體">
														<anthem:TEXTBOX id="txtGroupS" runat="server" Width="128px" meta:resourcekey="txtGroupSResource1"></anthem:TEXTBOX></FONT>
													<ASP:REQUIREDFIELDVALIDATOR id="Requiredfieldvalidator8" runat="server" ErrorMessage="*" ControlToValidate="txtGroupS" meta:resourcekey="Requiredfieldvalidator8Resource1"></ASP:REQUIREDFIELDVALIDATOR>
													<anthem:LABEL id="lbmsgRS" runat="server" Width="1px" ForeColor="Red" meta:resourcekey="lbmsgRSResource1"></anthem:LABEL></TD>
												<TD style="WIDTH:100px" vAlign="bottom" align="left" height="1">
													<ASP:LABEL id="lbGroupSPwd" runat="server" Visible="False" Width="120px" Font-Bold="True" meta:resourcekey="lbGroupSPwdResource1">添加共享組別密碼：</ASP:LABEL></TD>
												<TD style="WIDTH: 200px" vAlign="bottom" align="left">
													<anthem:TEXTBOX id="tbGroupSPwd" runat="server" Visible="False" Width="128px" meta:resourcekey="tbGroupSPwdResource1"></anthem:TEXTBOX></TD>
												<TD style="WIDTH:60%">
													<anthem:BUTTON id="btnAddGroupS" runat="server" Text="添加" meta:resourcekey="btnAddGroupSResource1"></anthem:BUTTON>
													<anthem:BUTTON id="btnDeleteS" runat="server" Text="刪除所有組別&amp;聯絡人" meta:resourcekey="btnDeleteSResource1"></anthem:BUTTON>
													<anthem:LABEL id="lbMsgS" runat="server" Width="220px" ForeColor="Red" meta:resourcekey="lbMsgSResource1"></anthem:LABEL></TD>
											</TR>
											<TR>
												<TD vAlign="bottom" align="left" height="6"></TD>
												<TD vAlign="bottom" align="left" height="1"></TD>
												<TD vAlign="bottom" align="left" height="1"></TD>
												<TD vAlign="bottom" align="left"></TD>
												<TD></TD>
											</TR>
											<TR width="100%">
												<TD vAlign="top" align="left" width="50%" colSpan="5" height="256">
													<anthem:DATAGRID id="dgData2" runat="server" Width="98%" AutoGenerateColumns="False" AllowPaging="True" meta:resourcekey="dgData2Resource1">
														<Columns>
                                                            <asp:TemplateColumn HeaderText="ID">
                                                                <ItemTemplate>
                                                                    <%# this.dgData2.CurrentPageIndex * this.dgData2.PageSize + Container.ItemIndex + 1 %><font face="新細明體"></font>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                                <ItemStyle CssClass="grid-item" Width="40px" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn  HeaderText="<%$ Resources:GAGroupName %>">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtGroupSE" runat="server" meta:resourcekey="txtGroupSEResource1" Text='<%# DataBinder.Eval(Container, "DataItem.cgroup_NAME") %>' Width="160px"></asp:TextBox>
                                                                    <asp:Label ID="lboldGroupNameSE" runat="server" meta:resourcekey="lboldGroupNameSEResource1" Text='<%# DataBinder.Eval(Container, "DataItem.cgroup_NAME") %>' Visible="False" Width="10px"></asp:Label>
                                                                    <asp:Label ID="lbGroupIDSE" runat="server" meta:resourcekey="lbGroupIDSEResource1" Text='<%# DataBinder.Eval(Container, "DataItem.cgroup_ID") %>' Visible="False" Width="10px"></asp:Label>
                                                                </EditItemTemplate> 
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbGroupIDS" runat="server" meta:resourcekey="lbGroupIDSResource1" Text='<%# DataBinder.Eval(Container, "DataItem.cgroup_ID") %>' Visible="False" Width="10px"></asp:Label>
                                                                    <asp:Label ID="lbGroupIDNameS" runat="server" meta:resourcekey="lbGroupIDNameSResource1" Text='<%# DataBinder.Eval(Container, "DataItem.cgroup_NAME") %>' Width="150px"></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                                <ItemStyle CssClass="grid-item" Width="160px" Wrap="False" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtGroupPwdSE" runat="server" meta:resourcekey="txtGroupPwdSEResource1" Text='<%# DataBinder.Eval(Container, "DataItem.cgroup_pwd") %>' Width="100px"></asp:TextBox>
                                                                    <asp:Label ID="lbGroupPwdSE" runat="server" meta:resourcekey="lbGroupPwdSEResource1" Text='<%# DataBinder.Eval(Container, "DataItem.cgroup_pwd") %>' Visible="False" Width="10px"></asp:Label>
                                                                </EditItemTemplate>
                                                                <HeaderTemplate>
                                                                    組別密碼
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbGroupPwdS" runat="server" meta:resourcekey="lbGroupPwdSResource1" Text='<%# DataBinder.Eval(Container, "DataItem.cgroup_pwd") %>' Visible="False" Width="10px"></asp:Label>
                                                                    <%# DataBinder.Eval(Container, "DataItem.cgroup_pwd") %>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                                <ItemStyle CssClass="grid-item" Width="100px" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="<%$ Resources:GAGroupNum %>">
                                                                <ItemTemplate>
                                                                    <%# DataBinder.Eval(Container, "DataItem.CREATE_COUNT") %>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Width="80px" Wrap="False" />
                                                                <ItemStyle CssClass="grid-item" Width="80px" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="<%$ Resources:GAGroupOwner %>">
                                                                <ItemTemplate>
                                                                    <%# DataBinder.Eval(Container, "DataItem.cgroup_owner") %>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Width="80px" Wrap="False" />
                                                                <ItemStyle CssClass="grid-item" Width="80px" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="<%$ Resources:GAGroupType %>">
                                                                <ItemTemplate>
                                                                    <%# DataBinder.Eval(Container, "DataItem.cgroup_type") %>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                                <ItemStyle CssClass="grid-item" Width="40px" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="<%$ Resources:GAGroupAddDate %>">
                                                                <ItemTemplate>
                                                                    <%# DataBinder.Eval(Container, "DataItem.create_date") %>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Width="160px" />
                                                                <ItemStyle CssClass="grid-item" Width="160px" />
                                                            </asp:TemplateColumn>
                                                            <asp:EditCommandColumn CancelText="取消" EditText="編輯" meta:resourcekey="EditCommandColumnResource2" UpdateText="更新">
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Width="60px" />
                                                                <ItemStyle CssClass="grid-item" Font-Bold="True" Width="60px" />
                                                            </asp:EditCommandColumn>
                                                            <asp:ButtonColumn CommandName="Delete" meta:resourcekey="ButtonColumnResource2" Text="刪除">
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Width="60px" />
                                                                <ItemStyle CssClass="grid-item" Font-Bold="True" Width="60px" />
                                                            </asp:ButtonColumn>
                                                        </Columns>
                                                        <EditItemStyle Height="36px" />
                                                        <HeaderStyle Font-Bold="True" Height="20px" Wrap="False" />
                                                        <ItemStyle Height="36px" />
														<PAGERSTYLE Mode="NumericPages"></PAGERSTYLE>
													</anthem:DATAGRID></TD>
											</TR>
											<TR width="100%">
												<TD colSpan="5"><FONT face="新細明體"></FONT></TD>
											</TR>
										</TABLE>
									</anthem:panel><anthem:panel id="panel4" runat="server" Visible="False" meta:resourcekey="panel4Resource1">
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
														<ASP:LABEL id="Label9" runat="server" Width="70px" Font-Bold="True" meta:resourcekey="Label9Resource1">組別類型 
                  ：</ASP:LABEL></STRONG></TD>
												<TD align="left" height="1">
													<anthem:DROPDOWNLIST id="dplGroupType" runat="server" Width="80px" AutoCallBack="True" meta:resourcekey="dplGroupTypeResource1">
														<ASP:LISTITEM Selected="True" Value="P" meta:resourcekey="ListItemResource3">私人</ASP:LISTITEM>
														<ASP:LISTITEM Value="S" meta:resourcekey="ListItemResource4">共享</ASP:LISTITEM>
													</anthem:DROPDOWNLIST></TD>
												<TD align="left" height="1">
													<anthem:DROPDOWNLIST id="dplAllGroup" runat="server" Width="120px" AutoCallBack="True" meta:resourcekey="dplAllGroupResource1"></anthem:DROPDOWNLIST></TD>
												<TD align="right" height="1"><asp:Literal runat="server" Text="<%$ Resources:GAByName %>"/></TD>
												<TD align="left" height="1">
													<anthem:TEXTBOX id="txtName4" runat="server" Width="80px" meta:resourcekey="txtName4Resource1"></anthem:TEXTBOX>
													<ASP:REQUIREDFIELDVALIDATOR id="Requiredfieldvalidator2" runat="server" ErrorMessage="*" ControlToValidate="txtName4"
														Enabled="False" meta:resourcekey="Requiredfieldvalidator2Resource1"></ASP:REQUIREDFIELDVALIDATOR></TD>
												<TD align="right" height="1"><FONT face="新細明體"><asp:Literal runat="server" Text="<%$ Resources:GAByNum %>"/></FONT></TD>
												<TD align="left" height="1">
													<anthem:TEXTBOX id="txtMobile4" runat="server" Width="80px" MaxLength="25" onChange="return CheckNum4()" meta:resourcekey="txtMobile4Resource1"></anthem:TEXTBOX>
													<ASP:REQUIREDFIELDVALIDATOR id="Requiredfieldvalidator9" runat="server" ErrorMessage="*" ControlToValidate="txtMobile4"
														Enabled="False" meta:resourcekey="Requiredfieldvalidator9Resource1"></ASP:REQUIREDFIELDVALIDATOR></TD>
												<TD align="left" height="1">
													<anthem:BUTTON id="btnSearch4" runat="server" Text="查詢" vAlign="baseline" meta:resourcekey="btnSearch4Resource1"></anthem:BUTTON></TD>
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
													<anthem:DATAGRID id="dgdata4" runat="server" Width="98%" AutoGenerateColumns="False" AllowPaging="True" meta:resourcekey="dgdata4Resource1">
														<Columns>
                                                            <asp:TemplateColumn HeaderText="ID">
                                                                <ItemTemplate>
                                                                    <%# this.dgdata4.CurrentPageIndex * this.dgdata4.PageSize + Container.ItemIndex + 1 %>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                                <ItemStyle CssClass="grid-item" Width="40px" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="ITEM_NO">
                                                                <ItemTemplate>
                                                                    <%# DataBinder.Eval(Container, "DataItem.IITEM_NO") %>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                <ItemStyle CssClass="grid-item" Width="40px" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText=" <%$ Resources:GAName %>">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtdg4Name4" runat="server" meta:resourcekey="txtdg4Name4Resource1" Text='<%# DataBinder.Eval(Container, "DataItem.CMEMBER_NAME").ToString().Trim() %>' Width="120px"></asp:TextBox>
                                                                    <asp:Label ID="lbdg4Name4E" runat="server" meta:resourcekey="lbdg4Name4EResource1" Text='<%# DataBinder.Eval(Container, "DataItem.CMEMBER_NAME").ToString().Trim() %>' Visible="False" Width="120px"></asp:Label>
                                                                </EditItemTemplate>
                                                                
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbdg4Name4" runat="server" meta:resourcekey="lbdg4Name4Resource1" Text='<%# DataBinder.Eval(Container, "DataItem.CMEMBER_NAME") %>' Width="120px"></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                <ItemStyle CssClass="grid-item" Width="120px" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn  HeaderText=" <%$ Resources:GAMobile %>">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtdg4Mobile4" runat="server" MaxLength="8" meta:resourcekey="txtdg4Mobile4Resource1" Text='<%# DataBinder.Eval(Container, "DataItem.CMOBILENO").ToString().Trim() %>' Width="100px"></asp:TextBox>
                                                                    <asp:Label ID="lbdg4Mobile4E" runat="server" meta:resourcekey="lbdg4Mobile4EResource1" Text='<%# DataBinder.Eval(Container, "DataItem.CMOBILENO").ToString().Trim() %>' Visible="False" Width="10px"></asp:Label>
                                                                </EditItemTemplate>
                                                              
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbdg4Mobile4" runat="server" meta:resourcekey="lbdg4Mobile4Resource1" Text='<%# DataBinder.Eval(Container, "DataItem.CMOBILENO") %>' Width="100px"></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                <ItemStyle CssClass="grid-item" Width="100px" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="  <%$ Resources:GAGroup %>">
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lbdg4GroupID4E" runat="server" meta:resourcekey="lbdg4GroupID4EResource1" Text='<%# DataBinder.Eval(Container, "DataItem.cgroup_id") %>' Visible="False" Width="10px"></asp:Label>
                                                                    <asp:Label ID="lbdg4GroupName4E" runat="server" meta:resourcekey="lbdg4GroupName4EResource1" Text='<%# GetGroupName(DataBinder.Eval(Container, "DataItem.cgroup_id")) %>' Visible="False" Width="10px"></asp:Label>
                                                                    <asp:DropDownList ID="dpldg4Group4" runat="server" meta:resourcekey="dpldg4Group4Resource1" Width="160px">
                                                                    </asp:DropDownList>
                                                                </EditItemTemplate>
                                                              
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbdg4GroupID4" runat="server" meta:resourcekey="lbdg4GroupID4Resource1" Text='<%# DataBinder.Eval(Container, "DataItem.cgroup_id") %>' Visible="False" Width="160px"></asp:Label>
                                                                    <asp:Label ID="lbdg4GroupName4" runat="server" meta:resourcekey="lbdg4GroupName4Resource1" Text='<%# GetGroupName(DataBinder.Eval(Container, "DataItem.cgroup_id")) %>' Width="160px"></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                <ItemStyle CssClass="grid-item" Width="140px" />
                                                            </asp:TemplateColumn>
                                                            <asp:EditCommandColumn CancelText="取消" EditText="編輯" meta:resourcekey="EditCommandColumnResource3" UpdateText="更新">
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Width="60px" />
                                                                <ItemStyle CssClass="grid-item" Font-Bold="True" Width="60px" />
                                                            </asp:EditCommandColumn>
                                                            <asp:ButtonColumn CommandName="Delete" meta:resourcekey="ButtonColumnResource3" Text="刪除">
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Width="60px" />
                                                                <ItemStyle CssClass="grid-item" Font-Bold="True" Width="60px" />
                                                            </asp:ButtonColumn>
                                                        </Columns>
                                                        <EditItemStyle Height="36px" />
                                                        <HeaderStyle Font-Bold="True" Height="20px" Wrap="False" />
                                                        <ItemStyle Height="36px" />
														<PAGERSTYLE Mode="NumericPages"></PAGERSTYLE>
													</anthem:DATAGRID></TD>
											</TR>
											<TR width="100%">
												<TD colSpan="8"><FONT face="新細明體"></FONT></TD>
											</TR>
										</TABLE>
									</anthem:panel><anthem:panel id="panel3" runat="server" Visible="False" meta:resourcekey="panel3Resource1">
										<TABLE class="tan-border02" style="WIDTH: 100%; BORDER-COLLAPSE: collapse; HEIGHT: 380px"
											cellSpacing="10" cellPadding="0" rules="none" align="left" border="0">
											<TR>
												<TD style="WIDTH: 10px" height="1"></TD>
												<TD align="left" colSpan="3" height="1"><FONT face="新細明體">
														<ASP:LABEL id="lbRightShow" runat="server" Visible="False" Width="112px" Font-Bold="True" meta:resourcekey="lbRightShowResource1">共享組別許可權 ：</ASP:LABEL>&nbsp;
														<ASP:REQUIREDFIELDVALIDATOR id="REQUIREDFIELDVALIDATOR1" runat="server" ErrorMessage="*" ControlToValidate="dplUsers" meta:resourcekey="REQUIREDFIELDVALIDATOR1Resource1"></ASP:REQUIREDFIELDVALIDATOR></FONT></TD>
												<TD align="left" width="15%" height="1"><FONT face="新細明體"></FONT></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 10px" height="1"></TD>
												<TD align="center" colSpan="3" height="1"><FONT face="新細明體"></FONT>
													<TABLE style="HEIGHT: 142px" borderColor="#edecd1" cellSpacing="1" cellPadding="0" rules="none"
														width="100%" align="center" border="1">
														<TR>
															<TD style="HEIGHT: 59px" align="center" colSpan="2">
																<ASP:CHECKBOXLIST id="cblCheck" runat="server" Width="80%" RepeatDirection="Horizontal" RepeatColumns="4" meta:resourcekey="cblCheckResource1"></ASP:CHECKBOXLIST>
																<P><FONT face="新細明體"></FONT></P>
															</TD>
														</TR>
														<TR>
															<TD style="HEIGHT: 1px" align="center" width="50%"><FONT face="新細明體"></FONT></TD>
															<TD align="left" width="50%">
																<anthem:CHECKBOX id="cbCheckAll" onclick="DoCheck(this.checked) " runat="server" Text="全選" AutoCallBack="True" meta:resourcekey="cbCheckAllResource1"></anthem:CHECKBOX></TD>
														</TR>
														<TR>
															<TD style="HEIGHT: 1px" align="right" width="50%">
																<anthem:BUTTON id="btnSaveRight" runat="server" Text="保存" meta:resourcekey="btnSaveRightResource1"></anthem:BUTTON></TD>
															<TD align="left" width="50%"><INPUT id="btnCannel" onclick="Clear()" type="button" value="重置" name="btnCannel">
																<anthem:LABEL id="lbRightResult" runat="server" Width="62px" ForeColor="Red" meta:resourcekey="lbRightResultResource1"></anthem:LABEL></TD>
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
									</anthem:panel><anthem:panel id="panel5" runat="server" Visible="False" meta:resourcekey="panel5Resource1">
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
																	<ASP:LABEL id="Label2" runat="server" Width="112px" Font-Bold="True" meta:resourcekey="Label2Resource1">選擇組別類型 
                        ：</ASP:LABEL></TD>
																<TD style="WIDTH: 118px; HEIGHT: 1px" align="left" height="1">
																	<anthem:RADIOBUTTON id="rbGroupP" runat="server" Text="私人組別" AutoCallBack="True" Checked="True" meta:resourcekey="rbGroupPResource1"></anthem:RADIOBUTTON></TD>
																<TD style="HEIGHT: 24px" align="left" height="24">
																	<anthem:RADIOBUTTON id="rbGroupS" runat="server" Text="共享組別" AutoCallBack="True" meta:resourcekey="rbGroupSResource1"></anthem:RADIOBUTTON></TD>
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
																	<ASP:LABEL id="Label7" runat="server" Width="112px" Font-Bold="True" meta:resourcekey="Label7Resource1">上傳方式 
                        ：</ASP:LABEL></TD>
																<TD style="WIDTH: 118px" align="left" height="1">
																	<anthem:RADIOBUTTON id="rbTypeAdd" runat="server" Width="130px" Text="新增上傳組別的號碼" AutoCallBack="True"
																		Checked="True" meta:resourcekey="rbTypeAddResource1"></anthem:RADIOBUTTON></TD>
																<TD align="left" height="1">
																	<anthem:RADIOBUTTON id="rbTypeCover" runat="server" Width="130px" Text="上傳覆蓋組別的號碼" AutoCallBack="True" meta:resourcekey="rbTypeCoverResource1"></anthem:RADIOBUTTON></TD>
																<TD align="left" width="15%" height="1">
																	<anthem:BUTTON id="btnUpload" runat="server" Visible="False" Width="52px" Text="上傳" meta:resourcekey="btnUploadResource1"></anthem:BUTTON></TD>
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
																	<ASP:LABEL id="Label8" runat="server" Width="130px" Font-Bold="True" meta:resourcekey="Label8Resource1">EXCEL/CSV 附件 
                        ：</ASP:LABEL></TD>
																<TD style="HEIGHT: 23px" align="left" colSpan="2" height="23"><INPUT id="btnUploadMode" type="file"  accept="application/msexcel,application/csv" runat="server">
																	&nbsp;<anthem:Label ID="lbrfvUpload" runat="server" ForeColor="Red" meta:resourcekey="lbrfvUploadResource1" Visible="False">
                                                                        *</anthem:Label>
                                                                </TD>
																<TD style="HEIGHT: 23px" align="left" width="15%" height="23"><INPUT id="Submit1" style="WIDTH: 48px; HEIGHT: 24px" type="submit" value="上傳"
																		runat="server">&nbsp;</TD>
																<TD style="HEIGHT: 23px" align="left" width="15%" height="23"></TD>
															</TR>
															<TR bgColor="#edecd1" height="1">
																<TD style="WIDTH: 10px" height="1"></TD>
																<TD align="right" height="1"><FONT face="新細明體"></FONT></TD>
																<TD align="left" colSpan="3" height="1"><FONT face="新細明體">&nbsp;&nbsp;
																		<anthem:LABEL id="lbUploadResult" runat="server" Visible="False" Width="100%" ForeColor="Red" meta:resourcekey="lbUploadResultResource1"></anthem:LABEL></FONT></TD>
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
																								<asp:Image id="imgLoad" runat="server" ImageUrl="resource/indicator.gif" meta:resourcekey="imgLoadResource1"></asp:Image></P>
																						</TD>
																						<TD>
																							<P>
																								<asp:Label id="lab_state" runat="server" ForeColor="Red" meta:resourcekey="lab_stateResource1"></asp:Label></P>
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
													<asp:TextBox id="TextBox4" runat="server" Visible="False" meta:resourcekey="TextBox4Resource1">str</asp:TextBox>
													<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator"
														ControlToValidate="TextBox4" meta:resourcekey="RequiredFieldValidator3Resource1"></asp:RequiredFieldValidator></TD>
												<TD align="left" width="15%" height="1"></TD>
											</TR>
										</TABLE>
									</anthem:panel><anthem:panel id="panel6" runat="server" Visible="False" meta:resourcekey="panel6Resource1">
										<TABLE class="tan-border02" style="WIDTH: 100%; BORDER-COLLAPSE: collapse; HEIGHT: 380px"
											cellSpacing="10" cellPadding="0" rules="none" align="left" border="0">
											<TR style="DISPLAY: none" vAlign="middle" width="100%">
												<TD vAlign="baseline" align="right" width="80" height="1"><STRONG>
														<ASP:LABEL id="Label10" runat="server" Width="112px" Font-Bold="True" meta:resourcekey="Label10Resource1">私人組別 ：</ASP:LABEL></STRONG></TD>
												<TD align="left" width="80" height="1"><asp:Literal runat="server" Text="<%$ Resources:GAUser %>"/> 
													<anthem:DROPDOWNLIST id="Dropdownlist4" runat="server" Width="80px" meta:resourcekey="Dropdownlist4Resource1">
														<ASP:LISTITEM Selected="True" Value="All" meta:resourcekey="ListItemResource5">All</ASP:LISTITEM>
													</anthem:DROPDOWNLIST></TD>
												<TD align="left" height="1"><asp:Literal runat="server" Text="<%$ Resources:GASelectDateFrom %>"/> 
													<ASP:TEXTBOX id="Textbox7" onclick="fPopUpDlg('CalendarUtrl/calendar.htm', document.fmSms.txtStartDate, 'winpop', 234, 261);return false"
														runat="server" Width="80px" meta:resourcekey="Textbox7Resource1"></ASP:TEXTBOX>
													<ASP:REQUIREDFIELDVALIDATOR id="Requiredfieldvalidator4" runat="server" ErrorMessage="*" ControlToValidate="dplUsers" meta:resourcekey="Requiredfieldvalidator4Resource1"></ASP:REQUIREDFIELDVALIDATOR></TD>
												<TD align="left" width="200" height="1"><asp:Literal runat="server" Text="<%$ Resources:GASelectDateTo %>"/> 
													<ASP:TEXTBOX id="Textbox8" onclick="fPopUpDlg('CalendarUtrl/calendar.htm', document.fmSms.txtEndDate, 'winpop', 234, 261);return false"
														runat="server" Width="80px" meta:resourcekey="Textbox8Resource1"></ASP:TEXTBOX></TD>
												<TD align="left" width="1%" height="1"><FONT face="新細明體">
														<anthem:BUTTON id="Button4" runat="server" Text="查詢" meta:resourcekey="Button4Resource1"></anthem:BUTTON></FONT></TD>
											<TR>
												<TD vAlign="baseline" align="right" width="80" height="1"><FONT face="新細明體"><STRONG>
															<ASP:LABEL id="Label11" runat="server" Visible="False" Width="112px" Font-Bold="True" meta:resourcekey="Label11Resource1">添加聯絡人 
                  ：</ASP:LABEL></STRONG></FONT></TD>
												<TD align="left" width="80" height="1"><FONT face="新細明體"></FONT></TD>
												<TD align="left" width="220" height="1"><FONT face="新細明體"></FONT></TD>
												<TD align="left" height="1"></TD>
												<TD align="left" width="1%" height="1"></TD>
											</TR>
											<TR>
												<TD vAlign="baseline" align="right" width="80" height="1"><FONT face="新細明體"></FONT></TD>
												<TD align="right" width="80" height="1"><FONT face="新細明體"><asp:Literal runat="server" Text="<%$ Resources:GASelectGroup %>"/> </FONT></TD>
												<TD align="left" width="220" height="1">
													<anthem:DROPDOWNLIST id="dplGroups" runat="server" Width="200px" AutoCallBack="True" meta:resourcekey="dplGroupsResource1"></anthem:DROPDOWNLIST></TD>
												<TD align="left" height="1"><FONT face="新細明體">
														<ASP:BUTTON id="btnAdd" runat="server" Text="添加" meta:resourcekey="btnAddResource1"></ASP:BUTTON></FONT></TD>
												<TD align="left" width="1%" height="1"></TD>
											</TR>
											<TR>
												<TD vAlign="baseline" align="right" width="80" height="1"><FONT face="新細明體"></FONT></TD>
												<TD align="right" width="80" height="1"><FONT face="新細明體"><asp:Literal runat="server" Text="<%$ Resources:GAName %>"/></FONT></TD>
												<TD align="left" width="220" height="1">
													<anthem:TEXTBOX id="txtName" runat="server" Width="200px" meta:resourcekey="txtNameResource1"></anthem:TEXTBOX>
													<ASP:REQUIREDFIELDVALIDATOR id="RequiredFieldValidator5" runat="server" Visible="False" ErrorMessage="|" ControlToValidate="txtName"
														Enabled="False" meta:resourcekey="RequiredFieldValidator5Resource1"></ASP:REQUIREDFIELDVALIDATOR>
													<anthem:LABEL id="lbrfvname" runat="server" Visible="False" ForeColor="Red" meta:resourcekey="lbrfvnameResource1">*</anthem:LABEL></TD>
												<TD align="left" height="1"><FONT face="新細明體"></FONT></TD>
												<TD align="left" width="1%" height="1"></TD>
											</TR>
											<TR>
												<TD vAlign="baseline" align="right" width="80" height="1"></TD>
												<TD align="right" width="80" height="1"><FONT face="新細明體"><asp:Literal runat="server" Text="<%$ Resources:GAMobile %>"/></FONT></TD>
												<TD align="left" width="220" height="1">
													<anthem:TEXTBOX id="txtMobile" runat="server" Width="200px" MaxLength="8" onChange="return CheckNum()" meta:resourcekey="txtMobileResource1"></anthem:TEXTBOX>
													<ASP:REQUIREDFIELDVALIDATOR id="RequiredFieldValidator6" runat="server" Visible="False" ErrorMessage="|" ControlToValidate="txtMobile"
														Enabled="False" meta:resourcekey="RequiredFieldValidator6Resource1"></ASP:REQUIREDFIELDVALIDATOR>
													<anthem:LABEL id="lbrfvmobile" runat="server" Visible="False" ForeColor="Red" meta:resourcekey="lbrfvmobileResource1">*</anthem:LABEL></TD>
												<TD align="left" height="1"><FONT face="新細明體">
														<anthem:BUTTON id="btnDeleteMember" runat="server" Text="刪除所選組別聯絡人" meta:resourcekey="btnDeleteMemberResource1"></anthem:BUTTON>&nbsp;
														<anthem:LABEL id="lbMsg6" runat="server" Width="240px" ForeColor="Red" meta:resourcekey="lbMsg6Resource1"></anthem:LABEL></FONT></TD>
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
													<anthem:DATAGRID id="dgMember" runat="server" Width="98%" AutoGenerateColumns="False" AllowPaging="True" meta:resourcekey="dgMemberResource1">
														<Columns>
                                                            <asp:TemplateColumn HeaderText="ID">
                                                                <ItemTemplate>
                                                                    <%# this.dgMember.CurrentPageIndex * this.dgMember.PageSize + Container.ItemIndex + 1 %>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                <ItemStyle CssClass="grid-item" Width="40px" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="ITEM_NO">
                                                                <ItemTemplate>
                                                                    <%# DataBinder.Eval(Container, "DataItem.IITEM_NO") %>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                <ItemStyle CssClass="grid-item" Width="40px" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText =" <%$ Resources:GAGroupName %>">
                                                           
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbdgMemberGroupID" runat="server" meta:resourcekey="lbdgMemberGroupIDResource1" Text='<%# DataBinder.Eval(Container, "DataItem.cgroup_id") %>' Visible="False" Width="160px"></asp:Label>
                                                                    <asp:Label ID="lbdgMemberGroupName" runat="server" meta:resourcekey="lbdgMemberGroupNameResource1" Text='<%# GetGroupName(DataBinder.Eval(Container, "DataItem.cgroup_id")) %>' Width="160px"></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                <ItemStyle CssClass="grid-item" Width="160px" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText ="<%$ Resources:GAName %>" >
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtdgMemberName" runat="server" meta:resourcekey="txtdgMemberNameResource1" Text='<%# DataBinder.Eval(Container, "DataItem.CMEMBER_NAME") .ToString().Trim() %>' Width="120px"></asp:TextBox>
                                                                    <asp:Label ID="lbdgMemberName" runat="server" meta:resourcekey="lbdgMemberNameResource1" Text='<%# DataBinder.Eval(Container, "DataItem.CMEMBER_NAME").ToString().Trim() %>' Visible="False" Width="10px"></asp:Label>
                                                                </EditItemTemplate> 
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbUName" runat="server" meta:resourcekey="lbUNameResource1" Text='<%# DataBinder.Eval(Container, "DataItem.CMEMBER_NAME") %>' Width="120px"></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                <ItemStyle CssClass="grid-item" Width="120px" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText ="  <%$ Resources:GAMobile %>">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtdgMemberMobile" runat="server" MaxLength="8" meta:resourcekey="txtdgMemberMobileResource1" Text='<%# DataBinder.Eval(Container, "DataItem.CMOBILENO").ToString().Trim() %>' Width="120px"></asp:TextBox>
                                                                    <asp:Label ID="lbdgMemberMobile" runat="server" meta:resourcekey="lbdgMemberMobileResource1" Text='<%# DataBinder.Eval(Container, "DataItem.CMOBILENO").ToString().Trim() %>' Visible="False" Width="10px"></asp:Label>
                                                                </EditItemTemplate>
                                                                 
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbUMobile" runat="server" meta:resourcekey="lbUMobileResource1" Text='<%# DataBinder.Eval(Container, "DataItem.CMOBILENO") %>' Width="120px"></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                <ItemStyle CssClass="grid-item" Width="120px" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="  <%$ Resources:GAGroupAddDate %>">
                                                                <ItemTemplate>
                                                                    <%# DataBinder.Eval(Container, "DataItem.create_date") %>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                <ItemStyle CssClass="grid-item" Width="120px" />
                                                            </asp:TemplateColumn>
                                                            <asp:EditCommandColumn CancelText="取消" EditText="編輯" meta:resourcekey="EditCommandColumnResource4" UpdateText="更新">
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Width="60px" />
                                                                <ItemStyle CssClass="grid-item" Font-Bold="True" Width="60px" />
                                                            </asp:EditCommandColumn>
                                                            <asp:ButtonColumn CommandName="Delete" meta:resourcekey="ButtonColumnResource4" Text="刪除">
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Width="60px" />
                                                                <ItemStyle CssClass="grid-item" Font-Bold="True" Width="60px" />
                                                            </asp:ButtonColumn>
                                                        </Columns>
                                                        <EditItemStyle Height="36px" />
                                                        <HeaderStyle Font-Bold="True" Height="20px" Wrap="False" />
                                                        <ItemStyle Height="36px" />
														<PAGERSTYLE Mode="NumericPages"></PAGERSTYLE>
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
