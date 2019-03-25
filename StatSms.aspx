<%@ Register TagPrefix="anthem" Namespace="Anthem" Assembly="Anthem" %>
<%@ Register TagPrefix="uc1" TagName="MenuTabs" Src="UserControl/MenuTabs.ascx" %>
<%@ Register TagPrefix="uc1" TagName="SendTabs" Src="UserControl/SendTabs.ascx" %>
<%@ Page language="c#" Codebehind="StatSms.aspx.cs" AutoEventWireup="false" Inherits="CENTASMS.StatSms" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
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
    else if (nLen <= 1000)////1071
      return 7;
    ////else if (nLen <= 1224)      
    ////  return 8;
    ////else if (nLen <= 1377)
    ////  return 9;
    ////else if (nLen <= 1530)      
    ////  return 10;                                              

    return 0;                                                    
}


        function change() {    
            var imgNode = document.getElementById("vimg");    
            imgNode.src = "CheckCode.asPx?t=" + (new Date()).valueOf();  // 234, 261??是 "WaterMark.ashx?t=" + (new Date()).valueOf(); ?句?可以改????，?里加???的??是?了防止??器?存的??    
        }  
        
     
            
           function myKeyDown()
{
 document.getElementById("lbMsg").innerHTML ="";
    var    k=window.event.keyCode;   

    if ((k==46)||(k==8)||(k==189)||(k==109)||(k==190)||(k==110)|| (k>=48 && k<=57)||(k>=96 && k<=105)||(k>=37 && k<=40)) 
    {}
    else if(k==13){
         window.event.keyCode = 13;}//9 tab
    else{
         window.event.returnValue = false;}
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
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="fmSms" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="top_bar01_bg"><img src="resource/mango_logo_title.gif" width="359" height="49">
					</td>
				</tr>
				<tr>
					<td class="top_bar02_bg" vAlign="top" height="15">
						<P align="left"><IMG height="15" src="resource/spacer.gif" width="15"> 
							<asp:Literal runat="server" Text="<%$ Resources:SSUser %>"/>&nbsp;<asp:label id="lbUser" runat="server" meta:resourcekey="lbUserResource1"></asp:label></P>
					</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="100%" border="0" height="500">
				<tr width="100%">
					<td vAlign="top">
						<table class="admin-tan-border1" id="table1" cellSpacing="0" cellPadding="0" width="100%"
							height="500" border="0">
							<tr vAlign="top">
								<td class="admin-table" vAlign="top"><IMG height="15" src="resource/spacer.gif" width="15">
								</td>
								<td style="HEIGHT: 36px" vAlign="top">
								</td>
							</tr>
							<TR vAlign="top">
								<TD  vAlign="top" style="WIDTH: 169px; HEIGHT: 100%"  class="left_bar_bg"><uc1:menutabs id="MenuTabs1" runat="server"></uc1:menutabs></TD>
								<TD vAlign="top" align="center" >
									<TABLE style="WIDTH: 100%; BORDER-COLLAPSE: collapse; HEIGHT: 100%" class="tan-border01" cellSpacing="10" cellPadding="0" rules="none" align="left" border="0">
									 
                                        <TR>
											<TD vAlign="bottom"  align="left" height="1"><STRONG> <asp:Literal runat="server" Text="<%$ Resources:SStatistic %>"/></STRONG>
											</TD>
											<TD vAlign="bottom"  align="left" height="1"> <asp:Literal runat="server" Text="<%$ Resources:SSUser %>"/>
												<anthem:DropDownList id="dplUsers" runat="server" Width="120px" AutoCallBack="True" meta:resourcekey="dplUsersResource1">
													<asp:ListItem Value="All" Selected="True" meta:resourcekey="ListItemResource1">All</asp:ListItem>
												</anthem:DropDownList></TD>
											<TD vAlign="bottom" align="left" height="1"> <asp:Literal runat="server" Text="<%$ Resources:SSSelectDateFrom %>"/>
												<asp:TextBox id="txtStartDate2" runat="server" Width="80px"   meta:resourcekey="txtStartDate2Resource1"></asp:TextBox>
												<asp:RequiredFieldValidator id="Requiredfieldvalidator1" runat="server" ControlToValidate="dplUsers" ErrorMessage="*" meta:resourcekey="Requiredfieldvalidator1Resource1"></asp:RequiredFieldValidator></TD>
											<TD  vAlign="bottom" align="left" height="1"> <asp:Literal runat="server" Text="<%$ Resources:SSSelectDateTo %>"/>
												<asp:TextBox id="txtEndDate2" runat="server" Width="80px"  meta:resourcekey="txtEndDate2Resource1"></asp:TextBox></TD>
											<TD  vAlign="bottom" align="left" width="15%" height="1"><FONT face="新細明體">
													<anthem:Button id="btnSearchSch" runat="server" Text="查詢" meta:resourcekey="btnSearchSchResource1"></anthem:Button>
													<anthem:Label id="lbMsgSch" runat="server" ForeColor="Red" Width="100px" meta:resourcekey="lbMsgSchResource1"></anthem:Label></FONT></TD>
										  <TR style="height:1px ">
											<TD align="left" style="vertical-align:bottom"   colspan="5"><hr/></TD>
										</TR>
										<TR>
											<TD vAlign="top" align="left" width="50%" colSpan="5">
												<anthem:DataGrid id="dgData" runat="server" Width="98%" AutoGenerateColumns="False" AllowPaging="True" meta:resourcekey="dgDataResource1">
													<PagerStyle Mode="NumericPages"></PagerStyle>
													<HeaderStyle Font-Bold="True" ></HeaderStyle>
													<Columns>
														<asp:TemplateColumn HeaderText="ID">
															<HeaderStyle Wrap="False" HorizontalAlign="Left" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
															<ItemStyle Width="30px" CssClass="grid-item"></ItemStyle>
															<ItemTemplate>
																<%#this.dgData.CurrentPageIndex * this.dgData.PageSize + Container.ItemIndex + 1%>
															 </ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="<%$ Resources:SSUserName %>">
															<HeaderStyle Wrap="False" Width="100px" HorizontalAlign="Left" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"   CssClass="grid-item"></ItemStyle>
															<ItemTemplate>
																<%# DataBinder.Eval(Container, "DataItem.name") %>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="<%$ Resources:SSTotal %>">
															<HeaderStyle Wrap="True" HorizontalAlign="Left" Width="200px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left" CssClass="grid-item"></ItemStyle>
															<ItemTemplate>
																<%# DataBinder.Eval(Container, "DataItem.SMS_COUNT") %>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="<%$ Resources:SSTotalBilled %>">
															<HeaderStyle Wrap="false" HorizontalAlign="Left" Width="200px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left" CssClass="grid-item"></ItemStyle>
															<ItemTemplate>
																<%# DataBinder.Eval(Container, "DataItem.SMS_PART")%>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="<%$ Resources:SSTotalNum %>">
															<HeaderStyle Wrap="True" HorizontalAlign="Left" Width="200px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left" CssClass="grid-item"></ItemStyle>
															<ItemTemplate>
																<%# DataBinder.Eval(Container, "DataItem.SMS_NUM")%>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="<%$ Resources:SSTotalSent %>">
															<HeaderStyle Wrap="True" Width="100px" HorizontalAlign="Left" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left" Wrap="True" Width="200px" CssClass="grid-item"></ItemStyle>
															<ItemTemplate>
																<%# DataBinder.Eval(Container, "DataItem.SMS_ALLCOUNT")%>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="<%$ Resources:SSRemarks %>">
															<HeaderStyle Wrap="True" Width="180px"  HorizontalAlign="Left" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"  CssClass="grid-item"></ItemStyle>
															<ItemTemplate>
																<%# DataBinder.Eval(Container, "DataItem.SMS_REMARK")%>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
												</anthem:DataGrid>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
