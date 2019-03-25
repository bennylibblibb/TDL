<%@ Register TagPrefix="anthem" Namespace="Anthem" Assembly="Anthem" %>
<%@ Register TagPrefix="uc1" TagName="MenuTabs" Src="UserControl/MenuTabs.ascx" %>
<%@ Page language="c#" Codebehind="SendByGroup.aspx.cs" AutoEventWireup="false" Inherits="CENTASMS.SendByGroup"  ValidateRequest="false" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<%@ Register TagPrefix="uc1" TagName="SendTabs" Src="UserControl/SendTabs.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Telecom Digital SMS Services</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<SCRIPT language="javascript" event="onkeypress" for="document"> if (event.keyCode == 34) event.returnValue = false;</SCRIPT>
		<LINK href="CentaSmsStyle.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="CalendarUtrl/Popup.js" type="text/javascript"></script>
		<script type="text/javascript">

		    function CountSmsContent() {
		        var txt = document.getElementById("txtSmsContent").value;
		        var nByte = CheckLength(txt);
		        var nChar = txt.length;

		        if (nChar != nByte) {
		            document.getElementById("lbLen").innerHTML = nChar;
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

		    function CountSmsBig5(nLen) {

		        if (nLen == 0)
		            return 0;
		        else if (nLen <= 70) {
		            document.getElementById("lbMsg").innerHTML = ''
		            return 1;
		        }
		        else if (nLen <= 134) {
		            document.getElementById("lbMsg").innerHTML = ''
		            return 2;
		        }
		        else if (nLen <= 201) {
		            document.getElementById("lbMsg").innerHTML = ''
		            return 3;
		        }
		        else if (nLen <= 268) {
		            document.getElementById("lbMsg").innerHTML = ''
		            return 4;
		        }
		        else if (nLen <= 335) {
		            document.getElementById("lbMsg").innerHTML = ''
		            return 5;
		        }
		        else if (nLen <= 402) {
		            document.getElementById("lbMsg").innerHTML = ''
		            return 6;
		        }
		        else if (nLen <= 469) {
		            document.getElementById("lbMsg").innerHTML = ''
		            return 7;
		        }
		        else if (nLen <= 536) {
		            document.getElementById("lbMsg").innerHTML = ''
		            return 8;
		        }
		        else if (nLen <= 603) {
		            document.getElementById("lbMsg").innerHTML = ''
		            return 9;
		        }
		        else if (nLen <= 670) {
		            document.getElementById("lbMsg").innerHTML = ''
		            return 10;
		        }
		        else { document.getElementById("lbMsg").innerHTML = '<%= GetLocalResourceObject("SGMoreThan2").ToString() %>' }

		        return 0;
		    }


		    function CountSmsNoBig5(nLen) {
		        if (nLen == 0)
		            return 0;
		        else if (nLen <= 160) {
		            document.getElementById("lbMsg").innerHTML = ''
		            return 1;
		        }
		        else if (nLen <= 306) {
		            document.getElementById("lbMsg").innerHTML = ''
		            return 2;
		        }
		        else if (nLen <= 459) {
		            document.getElementById("lbMsg").innerHTML = ''
		            return 3;
		        }
		        else if (nLen <= 612) {
		            document.getElementById("lbMsg").innerHTML = ''
		            return 4;
		        }
		        else if (nLen <= 765) {
		            document.getElementById("lbMsg").innerHTML = ''
		            return 5;
		        }
		        else if (nLen <= 918) {
		            document.getElementById("lbMsg").innerHTML = ''
		            return 6;
		        }
		        else if (nLen <= 1000) {////1071
		            document.getElementById("lbMsg").innerHTML = ''
		            return 7;
		        }
		        ////else if (nLen <= 1224) {
		        ////    document.getElementById("lbMsg").innerHTML = ''
		        ////    return 8;
		        ////}
		        ////else if (nLen <= 1377) {
		        ////    document.getElementById("lbMsg").innerHTML = ''
		        ////    return 9;
		        ////}
		        ////else if (nLen <= 1530) {
		        ////    document.getElementById("lbMsg").innerHTML = ''
		        ////    return 10;
		        ////}
		        else { document.getElementById("lbMsg").innerHTML ='<%= GetLocalResourceObject("SGMoreThan").ToString() %>' }
		        return 0;
		    }


		    function change() {
		        var imgNode = document.getElementById("vimg");
		        imgNode.src = "CheckCode.asPx?t=" + (new Date()).valueOf();  // 234, 261??是 "WaterMark.ashx?t=" + (new Date()).valueOf(); ?句?可以改????，?里加???的??是?了防止??器?存的??    
		    }



		    function myKeyDown() {
		         
		        document.getElementById("lbMsg").innerHTML = "";
		        var k = window.event.keyCode;

		        if ((k == 46) || (k == 8) || (k == 189) || (k == 109) || (k == 190) || (k == 110) || (k >= 48 && k <= 57) || (k >= 96 && k <= 105) || (k >= 37 && k <= 40))
		        { }
		        else if (k == 13) {
		            window.event.keyCode = 13;
		        } //9 tab
		        else {
		            window.event.returnValue = false;
		        }
		    }

		    function sendiframeReload() {
		        var userAgent = navigator.userAgent; 
		        if (userAgent.indexOf("compatible") > -1 && userAgent.indexOf("MSIE") > -1 && !isOpera) { 
		            sendiframe.window.location.reload();
		        }
		        else if (userAgent.indexOf("Chrome") > -1) { 
		            sendiframe.contentWindow.location.reload();
		        }
		        else if (userAgent.indexOf("Firefox") > -1) {
		            sendiframe.contentWindow.location.reload();
		        }
		        else { 
		            sendiframe.window.location.reload();
		        }
		    }


		    function checkIdd() {
		        document.getElementById("tbNum").value = "";
		        if (document.getElementById('ckIdd').checked == true) {
		            document.getElementById('valueIDD').color = "#ff0000";
		        } else {
		            document.getElementById('valueIDD').color = "#000000";
		        }
		    }


		    function myKeyChange(obj) {
		        // if (document.getElementById('ckIdd').checked != true)
		        // {
		         
		        var original = obj.value; 
		        var tempArray1;
		        if (original.indexOf("\r\n") > -1)   {
		            tempArray1 = original.split("\r\n"); 
		        }
		        else if (original.indexOf("\n") > -1) {
		            tempArray1 = original.split("\n"); 
		        }
		        else {
		            tempArray1 =(original + "\n").split("\n");
		        }
		        var tempArray = new Array();
		        var j = 0;
		        for (i = 0; i < tempArray1.length; i++) {
		            if (tempArray1[i] != '') {
		                tempArray[j] = tempArray1[i];
		                j++;
		            }
		        }

		        for (i = 0; i < tempArray.length; i++) {
		            if (tempArray[i].indexOf('組別') > -1 || tempArray[i].indexOf('(Share)') > -1 || tempArray[i].indexOf('(Private)') > -1) {
		            }
		            else {
		                var strvalue = tempArray[i];
		                //var reg = /[9,5,6]{1}[0-9]{7}/;
		                var reg = /['<%=ConfigurationSettings.AppSettings["ValidPrefixes"]%>']{1}[0-9]{7}/;
		                if (strvalue.indexOf("00852") == 0) {
		                    var str = strvalue.substring(5);
		                    if (str.length != 8) {
		                        alert('<%= GetLocalResourceObject("GAError1").ToString() %>' + "！(" + strvalue + ')');
		                        return (false);
		                    }
		                    else {
		                        if (reg.exec(str))
		                        { } else {
		                            alert('<%= GetLocalResourceObject("GAError2").ToString() %>' + "！(" + strvalue + ')');
		                            return (false);
		                        }
		                    }
		                }
		                    //else if(strvalue.indexOf("00") == 0 )
		                    //{ 
		                    //   if( strvalue.length<3)
		                    //   {
		                    //     alert("電話號碼位數不正確！(" + strvalue+')');
		                    //     return (false);
		                    //   }
		                    //}
		                else {

		                    if (strvalue.length != 8) {
		                        alert('<%= GetLocalResourceObject("GAError1").ToString() %>' + "！(" + strvalue + ')');
		                        return (false);
		                    }
		                    else {
		                        if (reg.exec(strvalue))
		                        { } else {
		                            alert('<%= GetLocalResourceObject("GAError2").ToString() %>' + "！(" + strvalue + ')');
		                            return (false);
		                        }
		                    }
		                }
                    }
                }
		        // }
            }


            function myKeyChangde(obj) {
                // if (document.getElementById('ckIdd').checked != true) 
                // {  
                var original = obj.value;
                var regex = '\r\n';
                var tempArray1 = original.split(regex);
                var tempArray = new Array();
                var j = 0;
                for (i = 0; i < tempArray1.length; i++) {
                    if (tempArray1[i] != '') {
                        tempArray[j] = tempArray1[i];
                        j++;
                    }
                }

                for (i = 0; i < tempArray.length; i++) {
                    if (tempArray[i].indexOf('組別') > -1 || tempArray[i].indexOf('(Share)') > -1 || tempArray[i].indexOf('(Private)') > -1) {
                    }
                    else {
                        var strvalue = tempArray[i];
                        //var reg=/[9,5,6]{1}[0-9]{7}/;
                        var reg = /['<%=ConfigurationSettings.AppSettings["ValidPrefixes"]%>']{1}[0-9]{7}/;
		                if (strvalue.indexOf("00852") == 0) {
		                    strvalue = strvalue.substring(5);
		                }
		                else if (strvalue.indexOf("00") == 0) {

		                } else {

		                }
		                if (reg.exec(strvalue) || strvalue == "") {
		                    if (strvalue.length != 8) {
		                        alert('<%= GetLocalResourceObject("GAError1").ToString() %>' + "！" + strvalue);
		                        return (false);
		                    }
		                } else {
		                    alert('<%= GetLocalResourceObject("GAError2").ToString() %>' + "！" + strvalue);
		                     return (false);
		                }
                    }
                }
		        //}
            }

            dFeatures = 'dialogHeight: 450px; dialogWidth: 1049px; dialogTop: 646px; dialogLeft: 4px; edge: Raised; center: Yes; help: Yes; resizable: Yes; status: Yes;'; //default features

            modalWin = "";
            function xShowModalDialog(sURL, vArguments, sFeatures) {
                if (sURL == null || sURL == '') {
                    alert("Invalid URL input.");
                    return false;
                }
                if (vArguments == null || vArguments == '') {
                    vArguments = '';
                }
                if (sFeatures == null || sFeatures == '') {
                    sFeatures = dFeatures;
                }
                if (window.navigator.appVersion.indexOf("MSIE") != -1) {
                    window.showModalDialog(sURL, vArguments, sFeatures);
                    return false;
                }
                sFeatures = sFeatures.replace(/ /gi, '');
                aFeatures = sFeatures.split(";");
                sWinFeat = "directories=0,menubar=0,titlebar=0,toolbar=0,";
                for (x in aFeatures) {
                    aTmp = aFeatures[x].split(":");
                    sKey = aTmp[0].toLowerCase();
                    sVal = aTmp[1];
                    switch (sKey) {
                        case "dialogheight":
                            sWinFeat += "height=" + sVal + ",";
                            pHeight = sVal;
                            break;
                        case "dialogwidth":
                            sWinFeat += "width=" + sVal + ",";
                            pWidth = sVal;
                            break;
                        case "dialogtop":
                            sWinFeat += "screenY=" + sVal + ",";
                            break;
                        case "dialogleft":
                            sWinFeat += "screenX=" + sVal + ",";
                            break;
                        case "resizable":
                            sWinFeat += "resizable=" + sVal + ",";
                            break;
                        case "status":
                            sWinFeat += "status=" + sVal + ",";
                            break;
                        case "center":
                            if (sVal.toLowerCase() == "yes") {
                                sWinFeat += "screenY=" + ((screen.availHeight - pHeight) / 2) + ",";
                                sWinFeat += "screenX=" + ((screen.availWidth - pWidth) / 2) + ",";
                            }
                            break;
                    }
                }
                modalWin = window.open(String(sURL), "", sWinFeat);
                if (vArguments != null && vArguments != '') {
                    modalWin.dialogArguments = vArguments;
                }
            }

            function ShowOrderContact(pagePath, winAttrs) {
                xShowModalDialog(pagePath, '', winAttrs);
            }

            function Clear() {
                document.getElementById("txtSmsContent").innerHTML = "";
                document.getElementById("tbNum").innerHTML = "";
                document.getElementById("lbNum").innerHTML = "0";
                document.getElementById("lbLen").innerHTML = "0";

            }

            function ShowInputMiddle(pagePath, winAttrs) {
                window.open(pagePath, '', winAttrs);
            }

            function focusload() {
                if (document.getElementById('txtSmsContent') != null) {
                    document.getElementById("txtSmsContent").focus();
                }
                if (document.getElementById('txtUserLogion') != null) {
                    document.getElementById("txtUserLogion").focus();
                }
            }

            function Focus(id) {
                document.getElementById(id).focus();
            }

            function CheckDate(obj) {
                var strvalue = (obj.value).replace(/(^\s*)|(\s*$)/g, "");

                var reg = /^((((19|20)\d{2})-(0?(1|[3-9])|1[012])-(0?[1-9]|[12]\d|30))|(((19|20)\d{2})-(0?[13578]|1[02])-31)|(((19|20)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|((((19|20)([13579][26]|[2468][048]|0[48]))|(2000))-0?2-29))$/
                if (reg.exec(strvalue)) {
                } else {
                    alert("請輸入正確日期！");
                    obj.focus();
                    return (false);
                }

            }

            function SyncSMSPhone() {
                var obj1 = document.getElementById("txtSmsPhone").value;
                // var obj2 = document.getElementById("txtAgentPhone").value;
                document.getElementById("txtAgentPhone").value = obj1;
                // obj2.value = obj1.value;
            };
            var strstr = "";
            function SyncSMSContent() {
                var str = document.getElementById("txtAgentSmsContent").value;
                var obj1 = document.getElementById("txtAgentPhone").value;
                if (strstr == "") {
                    var str2 = str.replace("MRT", obj1);
                } else {
                    var str2 = str.replace(strstr, obj1);
                }
                document.getElementById("txtAgentSmsContent").value = str2;
                strstr = document.getElementById("txtAgentPhone").value;
            }

            function SyncSMSContent2() {
                var str = document.getElementById("txtAgentSmsContent").value;
                var obj1 = document.getElementById("txtAgentPhone").value;
                var str2 = str.replace(strstr, obj1);
                document.getElementById("txtAgentSmsContent").value = str2;
                strstr = document.getElementById("txtAgentPhone").value;
            }

            var strSaleName = "";
            function SyncSMSContentSaleName() {
                var str = document.getElementById("txtAgentSmsContent").value;
                var obj1 = document.getElementById("txtSaleName").value;

                if (strSaleName == "") {
                    var str2 = str.replace("CSDL", obj1);
                } else {
                    var str2 = str.replace(strSaleName, obj1);
                }
                document.getElementById("txtAgentSmsContent").value = str2;
                strSaleName = document.getElementById("txtSaleName").value;
            }

            var strSalePhone = "";
            function SyncSMSContentSalePhone() {
                var str = document.getElementById("txtAgentSmsContent").value;
                var obj1 = document.getElementById("txtSalePhone").value;
                // var str2 = ""
                if (strSalePhone == "") {
                    var str2 = str.replace("CSN", obj1);
                } else {
                    var str2 = str.replace(strSalePhone, obj1);
                }
                document.getElementById("txtAgentSmsContent").value = str2;
                strSalePhone = document.getElementById("txtSalePhone").value;
            }
             
            function btnSure() {
                if (document.getElementById("btnUploadMode3").value != ""
                 //   && document.getElementById("txtUploadAgentSmsContent").value != ""
                    // && document.getElementById("btnUploadMode3").value != ""
                    //&& document.getElementById("txtUploadAgentSmsContent").value != ""
                    )
                {
                    return confirm('<%= GetLocalResourceObject("SGSureSend").ToString() %>');
                }
                else
                {
                  
                } 
            }

            function btnSureUpload() {
                if (document.getElementById("btnUploadMode").value != "") {
                    return confirm('<%= GetLocalResourceObject("SGSureSend").ToString() %>');
                }
                else {
                }
            }
            function btnSureUploadAction() {
                if (document.getElementById("btnUploadMode2").value != "") {
                    return confirm('<%= GetLocalResourceObject("SGSureUpload").ToString() %>');
                }
                else {
                }
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
						<P align="left"><FONT color="black"><IMG height="15" src="resource/spacer.gif" width="15">
							  <asp:Literal runat="server"  Text="<%$ Resources:SGUser %>"/></FONT>&nbsp;<asp:label id="lbUser" Font-Size ="Smaller"  ForeColor ="Black"  runat="server" meta:resourcekey="lbUserResource1"></asp:label></P>
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
								<td style="HEIGHT: 2px" vAlign="top"><uc1:sendtabs id="SendTabs1" runat="server"></uc1:sendtabs></td>
							</tr>
							<TR vAlign="top">
								<TD style="WIDTH: 169px; HEIGHT: 100%" vAlign="top" class="left_bar_bg"><uc1:menutabs id="MenuTabs1" runat="server"></uc1:menutabs></TD>
								<TD vAlign="top" class="tan-border02">

								   	<anthem:panel id="plSendLogion" runat="server" Visible="False" meta:resourcekey="plSendLogionResource1">
														<TABLE id="Table2" style="WIDTH: 399px; HEIGHT: 182px" height="182" cellSpacing="0" cellPadding="0"
															width="399" border="0">
															<TR>
																<TD style="HEIGHT: 30px" width="14"></TD>
																<TD style="HEIGHT: 30px">
																	<ASP:LABEL id="lbUserLogion" runat="server" meta:resourcekey="lbUserLogionResource1">用戶ID：</ASP:LABEL>
																	<anthem:DropDownList id="Dropdownlist1" runat="server" Width="100px" AutoCallBack="True"  Visible="False" meta:resourcekey="Dropdownlist1Resource1">
														<asp:ListItem Value="All" Selected="True" meta:resourcekey="ListItemResource1">All</asp:ListItem></anthem:DropDownList>
													<asp:RequiredFieldValidator id="Requiredfieldvalidator2" runat="server" ErrorMessage="*" ControlToValidate="Dropdownlist1" meta:resourcekey="Requiredfieldvalidator2Resource1"></asp:RequiredFieldValidator>
																	</TD>
															</TR>
															<TR>
																<TD style="HEIGHT: 30px" width="14"></TD>
																<TD style="HEIGHT: 30px">
																	<ASP:TEXTBOX id="txtUserLogion" runat="server" Width="200px" CssClass="safari-midtextbox" MaxLength="11" meta:resourcekey="txtUserLogionResource1"
																		 ></ASP:TEXTBOX>
																	</TD>
															</TR>
															<TR>
																<TD style="HEIGHT: 30px" width="14">&nbsp;</TD>
																<TD style="HEIGHT: 30px">
																	<ASP:LABEL id="lbUserPWLogion" runat="server" meta:resourcekey="lbUserPWLogionResource1">用戶密碼：</ASP:LABEL></TD>
															</TR>
															<TR vAlign="top">
																<TD style="HEIGHT: 35px" width="14">&nbsp;</TD>
																<TD style="HEIGHT: 35px">
																	<ASP:TEXTBOX id="txtUserPWLogion" runat="server" Width="200px" CssClass="safari-midtextbox" MaxLength="21"
																		 TextMode="Password" meta:resourcekey="txtUserPWLogionResource1" ></ASP:TEXTBOX>
																	</TD>
															</TR>
															<TR>
																<TD style="HEIGHT: 25px" width="14">&nbsp;</TD>
																<TD style="HEIGHT: 25px">
			<script type="text/javascript">
			    function Clear() {
			        document.getElementById("txtUserLogion").value = "";
			        document.getElementById("txtUserPWLogion").value = "";
			    }
		</script>
																	<anthem:BUTTON id="SaveLogin" runat="server" Width="64px" Text="登入" meta:resourcekey="SaveLoginResource1"></anthem:BUTTON>&nbsp;&nbsp;&nbsp;<INPUT id="btnCannelLogin" onclick="Clear()" type="button" value="重置" name="btnCannelLogin">&nbsp;&nbsp;
																	<anthem:LABEL id="lbMsgError" runat="server" ForeColor="Red" meta:resourcekey="lbMsgErrorResource1"></anthem:LABEL></TD>
															</TR>
														</TABLE>
													</anthem:panel>
													
								    <anthem:panel id="plSendMsg" runat="server" Visible="False" meta:resourcekey="plSendMsgResource1">
										<TABLE style="WIDTH: 500px; BORDER-COLLAPSE: collapse; HEIGHT: 380px;" 
											cellSpacing="10" cellPadding="0" rules="none" align="left" border="0">
											<TR vAlign="top" style="height:12px" >
                                                <TD vAlign="top" align="left"  colspan=4 ><anthem:LABEL id="lbMsgLogin"   runat="server" ForeColor="Red" meta:resourcekey="lbMsgLoginResource1"></anthem:LABEL><anthem:Button id="btnLoginOut" runat="server" Text="登出" Visible="False" meta:resourcekey="btnLoginOutResource1" ></anthem:Button></TD>
                                            </TR>
											<TR vAlign="top" style="height:22px" >
                                                <TD vAlign="top" align="left" width="40%" height="1" >&nbsp;<anthem:Label id="lbSendSMS" runat="server" Font-Size="Small" Font-Bold="true" meta:resourcekey="lbSendSMSResource1">短訊內容：</anthem:Label>  <asp:RequiredFieldValidator id="rfvMsg" runat="server" ErrorMessage="|" ControlToValidate="txtSmsContent" Enabled="False" meta:resourcekey="rfvMsgResource1"></asp:RequiredFieldValidator><anthem:Label id="lbrfvContent" runat="server" Visible="False" ForeColor="Red" meta:resourcekey="lbrfvContentResource1">*</anthem:Label></TD>
                                                <TD vAlign="top" align="left" width="24%" height="1">&nbsp;<anthem:Label id="lbSendNo" runat="server" Font-Size="Small" Font-Bold="true" meta:resourcekey="lbSendNoResource1">發送號碼：</anthem:Label> <asp:RequiredFieldValidator id="rfvNum" runat="server" ErrorMessage="|" ControlToValidate="tbNum" Enabled="False" meta:resourcekey="rfvNumResource1"></asp:RequiredFieldValidator><anthem:Label id="lbrfvNum" runat="server" Visible="False" ForeColor="Red" meta:resourcekey="lbrfvNumResource1">*</anthem:Label><INPUT type="checkbox" style="DISPLAY: none" id="ckIdd"  onclick="checkIdd()"><FONT face="新細明體"  style="DISPLAY: none" id="valueIDD">IDD</TD>
                                                <TD vAlign="top" align="left" width="18%" height="1">&nbsp;<anthem:Label id="lbSendGroup" runat="server" Font-Size="Small" Font-Bold="true" meta:resourcekey="lbSendGroupResource1">發送組別：</anthem:Label></TD>
                                                <TD vAlign="top" align="left" width="18%" height="1">&nbsp;<anthem:Label id="lbSendMember" runat="server"   Font-Size="Small" Font-Bold="true" meta:resourcekey="lbSendMemberResource1">發送組員：</anthem:Label></TD>
                                                <TR>
                                                <TD vAlign="top" align="left" width="40%" height="256"><anthem:TextBox onkeypress="CountSmsContent()" id="txtSmsContent" onkeydown="CountSmsContent()"	onblur="CountSmsContent()" onkeyup="CountSmsContent()"  runat="server" onChange="CountSmsContent()" TextMode="MultiLine"	Width="380px" Height="264px" meta:resourcekey="txtSmsContentResource1"></anthem:TextBox></TD>
                                                <TD vAlign="top" align="left" width="24%" height="256"><anthem:TextBox id="tbNum" onkeydown="myKeyDown()" style="IME-MODE: disabled" runat="server" onblur="myKeyChange(this)" TextMode="MultiLine" Width="210px" Height="264px" meta:resourcekey="tbNumResource1"></anthem:TextBox><anthem:Label id="lbGroupIDContent"   Visible="False" runat="server" meta:resourcekey="lbGroupIDContentResource1"  ></anthem:Label></TD>
                                                <TD vAlign="top" align="left" width="18%" height="256"><anthem:ListBox id="lstGroup" runat="server" Width="190px" Height="100%" AutoCallBack="True" meta:resourcekey="lstGroupResource1"></anthem:ListBox></TD>
                                                <TD vAlign="top" align="left" width="18%" height="256"><anthem:ListBox id="lstGroupMember" runat="server"    Width="190px" AutoCallBack="True" Height="100%" meta:resourcekey="lstGroupMemberResource1" ></anthem:ListBox></TD>
                                                </TR>
                                            <TR >
                                                <TD vAlign="top" align="left" width="50%" height="1">   <br />                  <asp:Literal runat="server" Text="<%$ Resources:SSMsgTotal %>"/>
                                                     <anthem:Label id="lbLen" runat="server" ForeColor="Red" Width="40px" meta:resourcekey="lbLenResource1">0</anthem:Label>
                                                    <asp:Literal runat="server" Text="<%$ Resources:SSMsgTotal2 %>"/><anthem:Label id="lbNum" runat="server" ForeColor="Red" Width="20px" meta:resourcekey="lbNumResource1">0</anthem:Label>
                                                    <asp:Literal runat="server" Text="<%$ Resources:SSMsgTotal3 %>"/>  <anthem:Label id="lbMsg" runat="server" ForeColor="Red"  Width="128px" meta:resourcekey="lbMsgResource1"></anthem:Label>
                                                    <asp:Button id="btnCount" runat="server" Visible =False   Text="計算長度" meta:resourcekey="btnCountResource1"></asp:Button></TD>
                                                <TD></TD>
                                                <TD vAlign="top" align="left" width="28%" height="1"></TD>
                                                <TD vAlign="top" align="left" width="22%" height="1"></TD> 
                                            </TR>
                                            <TR>
                                                <TD vAlign="baseline" align="left" width="50%" height="1"><P> 
                                                     <asp:Literal runat="server" Text="<%$ Resources:SSSclDatetime %>"/>
                                                     <anthem:RadioButton id="rbSendontime" runat="server" Text="即時發送" AutoCallBack="True" Checked="True" meta:resourcekey="rbSendontimeResource1" ></anthem:RadioButton>
                                                     <anthem:RadioButton id="rbSendbyTime" runat="server" Text="預設發送" AutoCallBack="True" meta:resourcekey="rbSendbyTimeResource1"  ></anthem:RadioButton>
                                                      </P></TD>
                                                  <TD></TD>
                                                  <TD vAlign="top" align="left" width="28%" height="1"></TD>
                                                  <TD vAlign="top" align="left" width="22%" height="1"></TD>
                                            </TR>
                                            <TR >
                                                <TD  align="left" width="50%" height="1">
                                                    <table>
                                                        <tr>
                                                        <td><anthem:Button id="btnSend" runat="server" Text="發送" meta:resourcekey="btnSendResource1"></anthem:Button></td><td vAlign="top" align=left  width="200px"  ><DIV  id="div_load" runat="server"   ><IFRAME  id ="sendiframe" src="sendRefresh.aspx"  frameborder=no  scrolling =no  width ="200px" height ="60px"  ></iframe></div></td>
                                                            <td  align=left  ><asp:Button id="btnCannel" runat="server"  Text="重置" meta:resourcekey="btnCannelResource1"></asp:Button></td>
                                                        </tr>
                                                    </table>
                                                    </TD>
                                                <TD></TD>
                                                <TD vAlign="top" align="left" width="28%" height="1"></TD><TD vAlign="top" align="left" width="22%" height="1"><INPUT id="btnCCannel" style="DISPLAY: none" onclick="Clear()" type="button" value="重置"></TD>
                                            </TR>
										</TABLE>
									</anthem:panel>
                                    
                                    <asp:panel id="plMsgData" runat="server" Visible="False" meta:resourcekey="plMsgDataResource1">
										<table style="WIDTH: 100%; BORDER-COLLAPSE: collapse; HEIGHT: 380px;"			cellSpacing="10" cellPadding="0" rules="none" align="left" border="0">
											<TR vAlign="middle" style="height:33px" >
												<TD  style="width :200px" align="left" height="1">	
                                                    <P><STRONG>&nbsp;<asp:Literal runat="server" Text="<%$ Resources:SGplMsg %>"/></STRONG>      </P>
                                                 </TD> 
												<TD style="width :200px" align="left" height="1">
                                                        <asp:Literal runat="server" Text="<%$ Resources:SGUser %>"/>	
                                                    	<anthem:DropDownList id="dplUsers" runat="server" Width="100px" AutoCallBack="True" meta:resourcekey="dplUsersResource1">
														<asp:ListItem Value="All" Selected="True" meta:resourcekey="ListItemResource2">All</asp:ListItem>	</anthem:DropDownList>
                                                 </TD>
												<TD style="width :200px" align="left" height="1"><asp:Literal runat="server" Text="<%$ Resources:SGDateTimeForm %>"/>
													<asp:TextBox id="txtStartDate" onChange="return CheckDate(this)"														runat="server" Width="80px" meta:resourcekey="txtStartDateResource1"  ></asp:TextBox>
													<asp:RequiredFieldValidator id="rfv" runat="server" ErrorMessage="*" ControlToValidate="dplUsers" meta:resourcekey="rfvResource1"></asp:RequiredFieldValidator></TD>
												<TD  style="width :200px" align="left" height="1"><asp:Literal runat="server" Text="<%$ Resources:SGDateTimeTo %>"/>													<asp:TextBox id="txtEndDate" onChange="return CheckDate(this)"
														runat="server" Width="80px" meta:resourcekey="txtEndDateResource1" ></asp:TextBox></TD>
												<TD align="left"  height="1"> 
														<anthem:Button id="btnSearch" runat="server" Text="查詢" meta:resourcekey="btnSearchResource1"></anthem:Button>
														<asp:Button id="btnExportSms1" runat="server" Text="匯出" meta:resourcekey="btnExportSms1Resource1"></asp:Button>
												  </TD>
											<TR>
												<TD vAlign="baseline" align="left" height="1"></TD>
												<TD align="left" height="1"></TD>
												<TD align="left" height="1"></TD>
												<TD align="left" height="1"></TD>
												<TD align="left"   height="1"></TD>
											</TR>
											<TR width="100%">
												<TD vAlign="top" align="left" width="50%" colSpan="5" height="256">
													<anthem:DataGrid id="dgSmsData" runat="server" Width="98%" AllowPaging="True" AutoGenerateColumns="False" meta:resourcekey="dgSmsDataResource1">
														<Columns>
                                                            <asp:TemplateColumn HeaderText="ID">
                                                                <ItemTemplate>
                                                                    <%# this.dgSmsData.CurrentPageIndex * this.dgSmsData.PageSize + Container.ItemIndex + 1 %>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                                <ItemStyle CssClass="grid-item" Width="40px" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="CBATCHID">
                                                                <ItemTemplate>
                                                                    <a href="#" onclick='window.open(&#039;MemberofSent.aspx?Type=B&amp;ID=<%# DataBinder.Eval(Container, "DataItem.CBATCHID") %>&#039;,&#039;&#039;,&#039;scrollbars=yes,width=500,height=360,top=300,left=300&#039;)'><%# DataBinder.Eval(Container, "DataItem.CBATCHID") %></a>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Width="80px" />
                                                                <ItemStyle CssClass="grid-item" Width="80px" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="<%$ Resources:SGSender %>" >
                                                                <ItemTemplate>
                                                                    <%# DataBinder.Eval(Container, "DataItem.CSENDER") %>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                                <ItemStyle CssClass="grid-item" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="<%$ Resources:SGSmsContent %>">
                                                                <ItemTemplate>
                                                                    <a class="blacklineheight" href='SendByGroup.aspx?csindex=0&amp;sIndex=0&amp;CBATCHID=<%# DataBinder.Eval(Container, "DataItem.CBATCHID") %>'>
                                                                    <!--      Server.HtmlEncode((DataBinder.Eval(Container, "DataItem.CSMSMSG")).ToString())  --><%# GetText(DataBinder.Eval(Container, "DataItem.CSMSMSG")) %></a>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                                <ItemStyle CssClass="grid-item"  Width="500px"  Wrap="true" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="<%$ Resources:SGSmsLen %>">
                                                                <ItemTemplate>
                                                                    <%# DataBinder.Eval(Container, "DataItem.IMSGLEN") %>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                                <ItemStyle CssClass="grid-item" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="<%$ Resources:SGSmsPart %>">
                                                                <ItemTemplate>
                                                                    <%# DataBinder.Eval(Container, "DataItem.ISMSMSGNO") %>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                                <ItemStyle CssClass="grid-item" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="<%$ Resources:SGSmsNum %>">
                                                                <ItemTemplate>
                                                                    <%# DataBinder.Eval(Container, "DataItem.IMOBILETOTAL") %>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                                <ItemStyle CssClass="grid-item" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="<%$ Resources:SGSmsStatus %>">
                                                                <ItemTemplate>
                                                                    <%# CountData(DataBinder.Eval(Container, "DataItem.CBATCHID"), DataBinder.Eval(Container, "DataItem.IMOBILETOTAL"), DataBinder.Eval(Container, "DataItem.ISMSMSGNO"), DataBinder.Eval(Container, "DataItem.UnSendCount")) %>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                                <ItemStyle CssClass="grid-item" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="<%$ Resources:SGSmsCreateTime %>">
                                                                <ItemTemplate>
                                                                    <%# DataBinder.Eval(Container, "DataItem.CREATE_DATE") %>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Width="160px" />
                                                                <ItemStyle CssClass="grid-item" Width="160px" />
                                                            </asp:TemplateColumn>
                                                        </Columns>
                                                        <HeaderStyle Font-Bold="True" />
														<PagerStyle Mode="NumericPages"></PagerStyle>
													</anthem:DataGrid></TD>
											</TR>
											<TR width="100%">
												<TD colSpan="5"></TD>
											</TR>
										</TABLE>
									</asp:panel>

                                    <asp:panel id="plSendHist" runat="server" Visible="False" meta:resourcekey="plSendHistResource1">
										<TABLE style="WIDTH: 100%; BORDER-COLLAPSE: collapse; HEIGHT: 380px;"
											cellSpacing="10" cellPadding="0" rules="none" align="left" border="0">
											<TR vAlign="middle" style="height:33px" >
												<TD  style="width :200px"  align="left" height="1"><STRONG>&nbsp;<asp:Literal runat="server" Text="<%$ Resources:SGSclMsg %>"/></STRONG>
												</TD>
												<TD style="width :200px"  align="left" height="1"><asp:Literal runat="server" Text="<%$ Resources:SGUser %>"/>
													<anthem:DropDownList id="dplUser2" runat="server" Width="100px" AutoCallBack="True" meta:resourcekey="dplUser2Resource1">
														<asp:ListItem Value="All" Selected="True" meta:resourcekey="ListItemResource3">All</asp:ListItem>
													</anthem:DropDownList></TD>
												<TD  style="width :200px" align="left" height="1"><asp:Literal runat="server" Text="<%$ Resources:SGDateTimeForm %>"/>
													<asp:TextBox id="txtStartDate2" onChange="return CheckDate(this)"
														runat="server" Width="80px" meta:resourcekey="txtStartDate2Resource1" ></asp:TextBox>
													<asp:RequiredFieldValidator id="Requiredfieldvalidator1" runat="server" ErrorMessage="*" ControlToValidate="dplUser2" meta:resourcekey="Requiredfieldvalidator1Resource1"></asp:RequiredFieldValidator></TD>
												<TD style="width :200px" align="left" height="1"><asp:Literal runat="server" Text="<%$ Resources:SGDateTimeTo %>"/>
													<asp:TextBox id="txtEndDate2" onChange="return CheckDate(this)"
														runat="server" Width="80px" meta:resourcekey="txtEndDate2Resource1"  ></asp:TextBox></TD>
												<TD align="left"   height="1">
														<anthem:Button id="btnSearchSch" runat="server" Text="查詢" meta:resourcekey="btnSearchSchResource1"></anthem:Button>
														<anthem:Button id="btnDetailSch" runat="server" Text="詳情" meta:resourcekey="btnDetailSchResource1"></anthem:Button>
														<asp:Button id="btnExportSms2" runat="server" Text="匯出" meta:resourcekey="btnExportSms2Resource1"></asp:Button>
														<anthem:Label id="lbMsgSch" runat="server" ForeColor="Red" Width="100px" meta:resourcekey="lbMsgSchResource1"></anthem:Label></TD>
											<TR>
												<TD vAlign="baseline" align="left" height="1"></TD>
												<TD align="left" height="1"></TD>
												<TD align="left" height="1"></TD>
												<TD align="left" height="1"></TD>
												<TD align="left"  height="1"></TD>
											</TR>
											<TR width="100%">
												<TD vAlign="top" align="left" width="50%" colSpan="5" height="256">
													<anthem:DataGrid id="dgSchedule" runat="server" Width="98%" AllowPaging="True" AutoGenerateColumns="False" meta:resourcekey="dgScheduleResource1">
														<Columns>
                                                            <asp:TemplateColumn HeaderText="ID">
                                                                <ItemTemplate>
                                                                    <%# this.dgSchedule.CurrentPageIndex * this.dgSchedule.PageSize + Container.ItemIndex + 1 %>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                <ItemStyle CssClass="grid-item" Width="40px" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="CBATCHID">
                                                                <ItemTemplate>
                                                                    <anthem:Label ID="lbBatchidD" runat="server" meta:resourcekey="lbBatchidDResource1" Text='<%# DataBinder.Eval(Container, "DataItem.CBATCHID") %>' Visible="False" Width="160px">
                                                                    </anthem:Label>
                                                                    <a href="#" onclick='window.open(&#039;MemberofSent.aspx?Type=S&amp;ID=<%# DataBinder.Eval(Container, "DataItem.CBATCHID") %>&#039;,&#039;&#039;,&#039;scrollbars=yes,width=500,height=360,top=300,left=300&#039;)'><%# DataBinder.Eval(Container, "DataItem.CBATCHID") %></a>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Width="80px" />
                                                                <ItemStyle CssClass="grid-item" Width="80px" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="<%$ Resources:SGUser %>">
                                                                <ItemTemplate>
                                                                    <%# DataBinder.Eval(Container, "DataItem.CSENDER") %>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                                <ItemStyle CssClass="grid-item" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="<%$ Resources:SGSmsSendTime %>">
                                                                <EditItemTemplate>
                                                                    <anthem:Label ID="lbdgCBATCHID" runat="server" meta:resourcekey="lbdgCBATCHIDResource1" Text='<%# DataBinder.Eval(Container, "DataItem.CBATCHID") %>' Visible="False" Width="160px">
                                                                    </anthem:Label>
                                                                    <anthem:Label ID="lbdgOldSendDate" runat="server" meta:resourcekey="lbdgOldSendDateResource1" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.CSEND_DATE")).ToString("yyyy-MM-dd HH:mm") %>' Visible="False" Width="160px">
                                                                    </anthem:Label>
                                                                    <anthem:TextBox ID="txtdgSendDate" runat="server" meta:resourcekey="txtdgSendDateResource1" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.CSEND_DATE")).ToString("yyyy-MM-dd HH:mm") %>' Width="120px"></anthem:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <%# DataBinder.Eval(Container, "DataItem.CSEND_DATE") %>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                                <ItemStyle CssClass="grid-item" Width="160px" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="<%$ Resources:SGStatus %>">
                                                                <ItemTemplate>
                                                                    <%# StringStatus(DataBinder.Eval(Container, "DataItem.STATUS")) %>
                                                                    <anthem:Label ID="lbdgSTATUS" runat="server" meta:resourcekey="lbdgSTATUSResource1" Text='<%# DataBinder.Eval(Container, "DataItem.STATUS") %>' Visible="False" Width="160px">
                                                                    </anthem:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                                <ItemStyle CssClass="grid-item" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="<%$ Resources:SGSmsCreateTime %>">
                                                                <ItemTemplate>
                                                                    <%# DataBinder.Eval(Container, "DataItem.CREATE_DATE") %>
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
                                                        <HeaderStyle Font-Bold="True" />
                                                        <ItemStyle CssClass="grid-item" Height="36px" />
														<PagerStyle Mode="NumericPages"></PagerStyle>
													</anthem:DataGrid>
													<anthem:DataGrid id="dgSchedule2" runat="server" Visible="False" Width="98%" AllowPaging="True"
														AutoGenerateColumns="False" meta:resourcekey="dgSchedule2Resource1">
														<Columns>
                                                            <asp:TemplateColumn HeaderText="ID">
                                                                <ItemTemplate>
                                                                    <%# this.dgSchedule2.CurrentPageIndex * this.dgSchedule2.PageSize + Container.ItemIndex + 1 %>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                                <ItemStyle CssClass="grid-item" Width="20px" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="CBATCHID">
                                                                <ItemTemplate>
                                                                    <anthem:Label ID="lbdgSchedule2Batchid" runat="server" meta:resourcekey="lbdgSchedule2BatchidResource1" Text='<%# DataBinder.Eval(Container, "DataItem.CBATCHID") %>' Visible="False" Width="160px">
                                                                    </anthem:Label>
                                                                    <a href="#" onclick='window.open(&#039;MemberofSent.aspx?Type=S&amp;ID=<%# DataBinder.Eval(Container, "DataItem.CBATCHID") %>&#039;,&#039;&#039;,&#039;scrollbars=yes,width=500,height=360,top=300,left=300&#039;)'><%# DataBinder.Eval(Container, "DataItem.CBATCHID") %></a>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Width="80px" />
                                                                <ItemStyle CssClass="grid-item" Width="80px" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="<%$ Resources:SGSender %>">
                                                                <ItemTemplate>
                                                                    <%# DataBinder.Eval(Container, "DataItem.CSENDER") %>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                                <ItemStyle CssClass="grid-item" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="<%$ Resources:SGSmsContent %>">
                                                                <ItemTemplate>
                                                                    <a class="blacklineheight" href='SendByGroup.aspx?csindex=0&amp;sIndex=0&amp;CBATCHID=<%# DataBinder.Eval(Container, "DataItem.CBATCHID") %>'>
                                                                    <!--      Server.HtmlEncode((DataBinder.Eval(Container, "DataItem.CSMSMSG")).ToString())  --><%# GetText(DataBinder.Eval(Container, "DataItem.CSMSMSG")) %></a>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                               <ItemStyle CssClass="grid-item" Width="500px"  Wrap="true"/>
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="<%$ Resources:SGSmsLen %>">
                                                                <ItemTemplate>
                                                                    <%# DataBinder.Eval(Container, "DataItem.IMSGLEN") %>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                                <ItemStyle CssClass="grid-item" Width="100px" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="<%$ Resources:SGSmsPart %>">
                                                                <ItemTemplate>
                                                                    <%# DataBinder.Eval(Container, "DataItem.ISMSMSGNO") %>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                              <ItemStyle CssClass="grid-item" Width="100px" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="<%$ Resources:SGSmsNum %>">
                                                                <ItemTemplate>
                                                                    <%# DataBinder.Eval(Container, "DataItem.IMOBILETOTAL") %>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                                <ItemStyle CssClass="grid-item" Width="100px" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="<%$ Resources:SGSmsStatus %>">
                                                                <ItemTemplate>
                                                                    <%# CountData2(DataBinder.Eval(Container, "DataItem.CBATCHID"), DataBinder.Eval(Container, "DataItem.IMOBILETOTAL"), DataBinder.Eval(Container, "DataItem.ISMSMSGNO"), DataBinder.Eval(Container, "DataItem.UnSendCount")) %>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                                <ItemStyle CssClass="grid-item" Width="100px" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="<%$ Resources:SGSmsCreateTime %>">
                                                                <ItemTemplate>
                                                                    <%# DataBinder.Eval(Container, "DataItem.CREATE_DATE") %>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Width="160px" />
                                                                <ItemStyle CssClass="grid-item" Width="160px" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn>
                                                                <ItemTemplate>
                                                                    <a href="#" onclick='window.open(&#039;AlertSmsData.aspx?Type=S&amp;ID=<%# DataBinder.Eval(Container, "DataItem.CBATCHID") %>&#039;,&#039;&#039;,&#039;scrollbars=yes,width=500,height=360,top=300,left=300&#039;)'><b><asp:Literal runat="server" Text="<%$ Resources:SSEditSms %>"/></b> </a>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Width="80px" />
                                                                <ItemStyle CssClass="grid-item" Width="160px" />
                                                            </asp:TemplateColumn>
                                                        </Columns>
                                                        <HeaderStyle Font-Bold="True" />
                                                        <ItemStyle CssClass="grid-item" Height="36px" />
														<PagerStyle Mode="NumericPages"></PagerStyle>
													</anthem:DataGrid></TD>
											</TR>
											<TR width="100%">
												<TD colSpan="5"></TD>
											</TR>
										</TABLE>
									</asp:panel>

									<asp:panel id="plCallHist" runat="server" Visible="False" meta:resourcekey="plCallHistResource1">
										<TABLE style="WIDTH: 100%; BORDER-COLLAPSE: collapse; HEIGHT: 380px;" 
											cellSpacing="10" cellPadding="0" rules="none" align="left" border="0">
											<TR vAlign="middle" style="height:33px" >
												<TD  align="left" height="1">
													<P><STRONG>&nbsp;<asp:Literal runat="server" Text="<%$ Resources:SGSmsCall %>"/></STRONG></P>
												</TD>
												<TD align="left" height="1"><asp:Literal runat="server" Text="<%$ Resources:SGUser %>"/>
													<anthem:DropDownList id="dplUsersCall" runat="server" Width="100px" AutoCallBack="True" meta:resourcekey="dplUsersCallResource1">
														<asp:ListItem Value="All" Selected="True" meta:resourcekey="ListItemResource4">All</asp:ListItem>
													</anthem:DropDownList></TD>
												<TD align="left" height="1"> <asp:Literal runat="server" Text="<%$ Resources:SGDateTimeForm %>"/>
													<asp:TextBox id="txtStartDateCall" onChange="return CheckDate(this)"
														runat="server" Width="80px" meta:resourcekey="txtStartDateCallResource1"  ></asp:TextBox>
													<asp:RequiredFieldValidator id="rfvCall" runat="server" ErrorMessage="*" ControlToValidate="dplUsersCall" meta:resourcekey="rfvCallResource1"></asp:RequiredFieldValidator></TD>
												<TD align="left" height="1"><asp:Literal runat="server" Text="<%$ Resources:SGDateTimeTo %>"/>
													<asp:TextBox id="txtEndDateCall" onChange="return CheckDate(this)"
														runat="server" Width="80px" meta:resourcekey="txtEndDateCallResource1"  ></asp:TextBox></TD>
												<TD align="left" width="15%" height="1">
														<anthem:Button id="btnSearchCall" runat="server" Text="查詢" meta:resourcekey="btnSearchCallResource1"></anthem:Button>
														<asp:Button id="btnExportSms3" runat="server" Text="匯出" meta:resourcekey="btnExportSms3Resource1"></asp:Button>
														</TD>
											<TR>
												<TD vAlign="baseline" align="left" height="1"></TD>
												<TD align="left" height="1"></TD>
												<TD align="left" height="1"></TD>
												<TD align="left" height="1"></TD>
												<TD align="left" width="15%" height="1"></TD>
											</TR>
											<TR width="100%">
												<TD vAlign="top" align="left" width="50%" colSpan="5" height="256">
													<anthem:DataGrid id="dgSmsDataCall" runat="server" Width="98%" AllowPaging="True" AutoGenerateColumns="False" meta:resourcekey="dgSmsDataCallResource1">
														<Columns>
                                                            <asp:TemplateColumn HeaderText="ID">
                                                                <ItemTemplate>
                                                                    <%# this.dgSmsData.CurrentPageIndex * this.dgSmsData.PageSize + Container.ItemIndex + 1 %>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                                <ItemStyle CssClass="grid-item" Width="40px" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="CBATCHID">
                                                                <ItemTemplate>
                                                                    <a href="#" onclick='window.open(&#039;MemberofSent.aspx?Type=B&amp;ID=<%# DataBinder.Eval(Container, "DataItem.CBATCHID") %>&#039;,&#039;&#039;,&#039;scrollbars=yes,width=500,height=360,top=300,left=300&#039;)'><%# DataBinder.Eval(Container, "DataItem.CBATCHID") %></a>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Width="80px" />
                                                                <ItemStyle CssClass="grid-item" Width="80px" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="<%$ Resources:SGSender %>">
                                                                <ItemTemplate>
                                                                    <%# DataBinder.Eval(Container, "DataItem.CSENDER") %>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                                <ItemStyle CssClass="grid-item" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="<%$ Resources:SGSmsContent %>">
                                                                <ItemTemplate>
                                                                    <a class="blacklineheight" href='SendByGroup.aspx?csindex=0&amp;sIndex=0&amp;CBATCHID=<%# DataBinder.Eval(Container, "DataItem.CBATCHID") %>'>
                                                                    <!--      Server.HtmlEncode((DataBinder.Eval(Container, "DataItem.CSMSMSG")).ToString())  --><%# GetText(DataBinder.Eval(Container, "DataItem.CSMSMSG")) %></a>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                                <ItemStyle CssClass="grid-item"  Width="500px"  Wrap="true" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="<%$ Resources:SGSmsLen %>">
                                                                <ItemTemplate>
                                                                    <%# DataBinder.Eval(Container, "DataItem.IMSGLEN") %>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                                <ItemStyle CssClass="grid-item" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="<%$ Resources:SGSmsPart %>">
                                                                <ItemTemplate>
                                                                    <%# DataBinder.Eval(Container, "DataItem.ISMSMSGNO") %>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                                <ItemStyle CssClass="grid-item" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="<%$ Resources:SGSmsNum %>">
                                                                <ItemTemplate>
                                                                    <%# DataBinder.Eval(Container, "DataItem.IMOBILETOTAL") %>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                                <ItemStyle CssClass="grid-item" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="<%$ Resources:SGSmsCreateTime %>">
                                                                <ItemTemplate>
                                                                    <%# DataBinder.Eval(Container, "DataItem.CREATE_DATE") %>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Width="160px" />
                                                                <ItemStyle CssClass="grid-item" Width="160px" />
                                                            </asp:TemplateColumn>
                                                        </Columns>
                                                        <HeaderStyle Font-Bold="True" />
														<PagerStyle Mode="NumericPages"></PagerStyle>
													</anthem:DataGrid></TD>
											</TR>
											<TR width="100%">
												<TD colSpan="5"></TD>
											</TR>
										</TABLE>
									</asp:panel>
									
									<asp:panel id="plDefineScheduleMsg" runat="server" Visible="False" meta:resourcekey="plDefineScheduleMsgResource1"> 
										<TABLE style="WIDTH: 100%; BORDER-COLLAPSE: collapse; HEIGHT: 380px;" 
											cellSpacing="10" cellPadding="0" rules="none" align="left" border="0">
										<TR>
												<TD vAlign="bottom" align="left" height="1"></TD>
												<TD vAlign="bottom" align="left" height="1"></TD>
												<TD vAlign="bottom" align="left" height="1"></TD>
												<TD vAlign="bottom" align="left" height="1"></TD>
												<TD vAlign="bottom" align="left" height="1"></TD>
											</TR>
                                            <TR  vAlign="bottom">
												<TD vAlign="bottom" align="left" height="1">預設短訊標題：</TD>
												<TD vAlign="bottom" align="left" height="1"><anthem:TextBox id="txtScheduleMsgTitle"   style="IME-MODE: disabled" runat="server" meta:resourcekey="txtScheduleMsgTitleResource1"     ></anthem:TextBox></TD>
												<TD vAlign="bottom" align="left" height="1"></TD>
												<TD vAlign="bottom" align="left" height="1"></TD>
												<TD vAlign="bottom" align="left" height="1"></TD>
											</TR>
											<TR vAlign="bottom">
												<TD vAlign=bottom align="left" height="1" width="95px">
													<ASP:LABEL id="lbAddMsg" runat="server" Width="95px" meta:resourcekey="lbAddMsgResource1"  >預設短訊內容：</ASP:LABEL>
													<anthem:TextBox id="txtRfv"  Width="1px"  runat="server"  Visible =False meta:resourcekey="txtRfvResource1"  ></anthem:TextBox>
													<asp:RequiredFieldValidator id="Requiredfieldvalidator3" runat="server" ErrorMessage="*" ControlToValidate="txtRfv" meta:resourcekey="Requiredfieldvalidator3Resource1"></asp:RequiredFieldValidator>
													 
                                                </TD>
												<TD  vAlign=bottom align=right height="1" width="400px"  ><FONT face="新細明體" color="red" style="font-weight: bold">(MRT/CSDL/CSN) IS SIGN  
												<anthem:TextBox id="txtScheduleMsg"   style="IME-MODE: disabled" runat="server" TextMode="MultiLine" Width="400px" Height="60px" meta:resourcekey="txtScheduleMsgResource1" ></anthem:TextBox>
												 </TD>
												<TD vAlign="bottom"   Width="30px" align="left"  >
												<anthem:LABEL id="lbmsgRP" runat="server" Width="30px" ForeColor="Red" meta:resourcekey="lbmsgRPResource1"></anthem:LABEL>
												 </TD>
											 <TD vAlign="bottom" align="left" width="20px">	<asp:CheckBox ID="chkDefault" Runat =server Text ="Default" meta:resourcekey="chkDefaultResource1" > </asp:CheckBox>
											 </TD>
												<TD  vAlign=bottom Width="600px" >
													<anthem:BUTTON id="btnAddMsg" runat="server" Text="添加" meta:resourcekey="btnAddMsgResource1"></anthem:BUTTON>
													<anthem:LABEL id="lbMsgS" runat="server" Width="200px" ForeColor="Red" meta:resourcekey="lbMsgSResource1"></anthem:LABEL>
													</TD>
											</TR>
											<TR>
												<TD vAlign="bottom" align="left" height="1"></TD>
												<TD vAlign="bottom" align="left" height="1"></TD>
												<TD vAlign="bottom" align="left" height="1"></TD>
												<TD vAlign="bottom" align="left" height="1"></TD>
												<TD vAlign="bottom" align="left" height="1"></TD>
											</TR>
											<TR width="100%">
												<TD vAlign="top" align="left" width="50%" colSpan="5" height="256">
													<anthem:DATAGRID id="dgData2" runat="server" Width="98%" AutoGenerateColumns="False" AllowPaging="True" meta:resourcekey="dgData2Resource1">
														<Columns>
                                                            <asp:TemplateColumn>
                                                                <HeaderTemplate>
                                                                    <font face="新細明體">ID</font>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbStatusID" runat="server" meta:resourcekey="lbStatusIDResource1" Text='<%# DataBinder.Eval(Container, "DataItem.ID") %>' Width="10px"></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                                <ItemStyle CssClass="grid-item" Width="20px" Wrap="False" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn>
                                                                <EditItemTemplate>
                                                                    <asp:DropDownList ID="dplStatus" runat="server" meta:resourcekey="dplStatusResource1" Width="80px">
                                                                    </asp:DropDownList>
                                                                    <asp:Label ID="lbStatus" runat="server" meta:resourcekey="lbStatusResource1" Text='<%# DataBinder.Eval(Container, "DataItem.Status") %>' Visible="False" Width="2px"></asp:Label>
                                                                </EditItemTemplate>
                                                                <HeaderTemplate>
                                                                    <font face="新細明體">STATUS</font>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%# DataBinder.Eval(Container, "DataItem.Status") %>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                                <ItemStyle CssClass="grid-item" Width="80px" Wrap="False" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="MSG_TITLE">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtCTITLE" runat="server" meta:resourcekey="txtCTITLEResource1" Text='<%# (DataBinder.Eval(Container, "DataItem.CTITLE")) %>' TextMode="MultiLine" Width="150px"></asp:TextBox>
                                                                    <asp:Label ID="lbCTITLE" runat="server" meta:resourcekey="lbCTITLEResource1" Text='<%# (DataBinder.Eval(Container, "DataItem.CTITLE")) %>' Visible="False" Width="2px"></asp:Label>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <%# DataBinder.Eval(Container, "DataItem.CTITLE") %>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                                <ItemStyle CssClass="grid-item" Width="150px" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtCSMSMSG" runat="server" Height="60px" meta:resourcekey="txtCSMSMSGResource1" Text='<%# (DataBinder.Eval(Container, "DataItem.CSMSMSG")) %>' TextMode="MultiLine" Width="360px"></asp:TextBox>
                                                                    <asp:Label ID="lbCSMSMSG" runat="server" meta:resourcekey="lbCSMSMSGResource1" Text='<%# Server.HtmlEncode((DataBinder.Eval(Container, "DataItem.CSMSMSG")).ToString()) %>' Visible="False" Width="2px"></asp:Label>
                                                                </EditItemTemplate>
                                                                <HeaderTemplate>
                                                                    CONTENT
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <!--      Server.HtmlEncode((DataBinder.Eval(Container, "DataItem.CSMSMSG")).ToString())  --><%# GetText(DataBinder.Eval(Container, "DataItem.CSMSMSG")) %>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                                <ItemStyle CssClass="grid-item" Width="360px" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="MSG_LEN">
                                                                <ItemTemplate>
                                                                    <%# DataBinder.Eval(Container, "DataItem.IMSGLEN") %>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Width="30px" Wrap="False" />
                                                                <ItemStyle CssClass="grid-item" Width="30px" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="OWNER">
                                                                <ItemTemplate>
                                                                    <%# DataBinder.Eval(Container, "DataItem.CSENDER") %>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                                <ItemStyle CssClass="grid-item" Width="50px" />
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="CREAT DATE">
                                                                <ItemTemplate>
                                                                    <%# DataBinder.Eval(Container, "DataItem.create_date") %>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="grid-header" HorizontalAlign="Left" VerticalAlign="Middle" Width="100px" />
                                                                <ItemStyle CssClass="grid-item" Width="100px" />
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
												<TD colSpan="5"></TD>
											</TR>
										</TABLE>
									</asp:panel>

                                    <asp:panel id="plUploadSms" runat="server" Visible="False" meta:resourcekey="plUploadSmsResource1"> 
                                    <TABLE class="tan-border02" style="WIDTH: 100%; BORDER-COLLAPSE: collapse;  HEIGHT: 100%;vertical-align:top"
											cellSpacing="10" cellPadding="0" rules="none" align="left" border="0">
											<TR>
												 	<TD style="WIDTH: 10px" height="3"> </TD> 
											</TR>
											<TR>
												<TD style="WIDTH: 10px" height="1"></TD>
												<TD align="center" colSpan="3" height="1"> 
														<TABLE id="Table4" borderColor="#edecd1" height="100%" cellSpacing="1" cellPadding="0"
															rules="none" width="80%" align="left" border="1">
														     <tr>
																<td height="1" style="WIDTH: 10px"></td>
                                                                <td align="right" height="1" style="WIDTH: 143px"></td>
                                                                <td align="left" height="1" style="WIDTH: 118px"></td>
                                                                <td align="left" height="1"></td>
                                                                <td align="left" height="1" width="15%"></td>
                                                                <td align="left" height="1" width="15%"></td>
															</TR>
															<tr style="display:none">
                                                                <td align="left" height="1" valign="baseline"></td>
                                                                <td align="right" height="1">
                                                                    <asp:Label ID="Label7" runat="server" Font-Bold="True" meta:resourcekey="Label7Resource1" Width="112px">上傳方式 ：</asp:Label>
                                                                </td>
                                                                <td align="left" height="1" style="WIDTH: 118px">
                                                                    <anthem:RadioButton ID="rbTypeAdd" runat="server" AutoCallBack="True" Checked="True" meta:resourcekey="rbTypeAddResource1" Text="新增上傳組別的號碼" Width="130px" />
                                                                </td>
                                                                <td align="left" height="1">
                                                                    <anthem:RadioButton ID="rbTypeCover" runat="server" AutoCallBack="True" meta:resourcekey="rbTypeCoverResource1" Text="上傳覆蓋組別的號碼" Width="130px" />
                                                                </td>
                                                                <td align="left" height="1" width="15%">
                                                                    <anthem:Button ID="btnUpload" runat="server" meta:resourcekey="btnUploadResource1" Text="上傳" Visible="False" Width="52px" />
                                                                </td>
                                                                <td align="left" height="1" width="15%"></td>
                                            </tr>
                                            <tr>
                                                <td align="right" colspan="2" height="23" style="HEIGHT: 23px;WIDTH: 100px;">
                                                    <asp:Label ID="Label8" runat="server" Font-Bold="True" meta:resourcekey="Label8Resource1" Width="200px">EXCEL 附件：</asp:Label>
                                                </td>
                                                <td align="left" colspan="1" height="23" style="HEIGHT: 23px;WIDTH: 180px;">
                                                    <input id="btnUploadMode" runat="server" accept="application/msexcel,application/csv" type="file"></input> </td>
                                                <td align="center" height="23" style="HEIGHT: 23px;WIDTH: 100px;">
                                                    <asp:CheckBox ID="chkAction" runat="server" meta:resourcekey="chkActionResource1" Text="With Account Action" Visible="True" Checked="true" Width="160px" />
                                                </td>
                                                <td align="left" height="23" style="HEIGHT: 23px" width="5%">
                                                    <anthem:Label ID="lbrfvUpload" runat="server" ForeColor="Red" meta:resourcekey="lbrfvUploadResource1" style="Width: 60px" Visible="False">
                                                        *</anthem:Label>
                                                </td>
                                                <td align="left" height="23" style="HEIGHT: 23px" width="25%">
                                                    <input id="Submit1" runat="server" onclick="return btnSureUpload();" style="WIDTH: 48px; HEIGHT: 24px" type="submit" value="上傳"></input> </td>
                                            </tr>
                                            <tr bgcolor="#edecd1" height="1">
                                                <td height="1" style="WIDTH: 10px"></td>
                                                <td align="right" height="1"></td>
                                                <td align="left" colspan="3" height="1">&nbsp;&nbsp;
                                                    <anthem:Label ID="lbUploadResult" runat="server" ForeColor="Red" meta:resourcekey="lbUploadResultResource1" Visible="False" Width="100%">
                                                    </anthem:Label>
                                                    </td>
                                                <td align="left" height="1"></td>
                                            </tr>
                                            <tr>
                                                <td height="1" style="WIDTH: 10px"></td>
                                                <td align="center" colspan="5" height="1" style="WIDTH: 160px;height:100%">
                                                    <div id="div1" runat="server">
                                                        <iframe frameborder="no" height="500px" src="UploadSmsRefresh.aspx" width="100%">
                                                            <table border="0" bordercolor="#cccccc" cellpadding="5" cellspacing="1" class="font" height="80" style="FILTER: Alpha(opacity=80); WIDTH: 152px; HEIGHT: 42px" width="160">
                                                                <tr>
                                                                    <td style="WIDTH: 55px">
                                                                        <p>
                                                                            <asp:Image ID="imgLoad" runat="server" ImageUrl="resource/indicator.gif" meta:resourcekey="imgLoadResource1" />
                                                                        </p>
                                                                    </td>
                                                                    <td>
                                                                        <p>
                                                                            <asp:Label ID="lab_state" runat="server" ForeColor="Red" meta:resourcekey="lab_stateResource1"></asp:Label>
                                                                        </p>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </iframe>
                                                    </div>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                            </tr>
														</TABLE>
													 
												</TD>
												<TD align="left" width="15%" height="1"></TD>
											</TR>
										 
										</TABLE>
                                    </asp:panel>

                                    <asp:panel id="plUploadSmsAction" runat="server" Visible="False" meta:resourcekey="plUploadSmsActionResource1"> 
                                    <TABLE class="tan-border02" style="WIDTH: 100%; BORDER-COLLAPSE: collapse;  HEIGHT: 100%;vertical-align:top "
											cellSpacing="10" cellPadding="0" rules="none" align="left" border="0">
											<TR>
												<TD style="WIDTH: 10px" height="3"> </TD> 
											</TR>
											<TR  valign ="top" style ="height:100%" >
												<TD style="WIDTH: 10px" height="1"></TD>
												<TD align="center" colSpan="3" height="1">
														<TABLE id="Table3" borderColor="#edecd1" height="100%" cellSpacing="1" cellPadding="0"
															rules="none" width="80%" align="left" border="1">
														 <tr>
																<TD style="WIDTH: 10px" height="1"></TD>
																<TD style="WIDTH: 143px" align="right" height="1"></TD>
																<TD style="WIDTH: 118px" align="left" height="1"></TD>
																<TD align="left" height="1">&nbsp;</TD>
																<TD align="left" width="15%" height="1"></TD>
																<TD align="left" width="15%" height="1"></TD>
															</TR>
															<TR style ="display:none">
																<TD vAlign="baseline" align="left" height="1"></TD>
																<TD align="right" height="1">
																	<ASP:LABEL id="Label1" runat="server" Width="112px" Font-Bold="True" meta:resourcekey="Label1Resource1">上傳方式 
                        ：</ASP:LABEL></TD>
																<TD style="WIDTH: 118px" align="left" height="1">
																	<anthem:RADIOBUTTON id="RADIOBUTTON1" runat="server" Width="130px" Text="新增上傳組別的號碼" AutoCallBack="True"
																		Checked="True" meta:resourcekey="RADIOBUTTON1Resource1"></anthem:RADIOBUTTON></TD>
																<TD align="left" height="1">
																	<anthem:RADIOBUTTON id="RADIOBUTTON2" runat="server" Width="130px" Text="上傳覆蓋組別的號碼" AutoCallBack="True" meta:resourcekey="RADIOBUTTON2Resource1"></anthem:RADIOBUTTON></TD>
																<TD align="left" width="15%" height="1">
																	<anthem:BUTTON id="BUTTON1" runat="server" Visible="False" Width="52px" Text="上傳" meta:resourcekey="BUTTON1Resource2"></anthem:BUTTON></TD>
																<TD align="left" width="15%" height="1"></TD>
															</TR>
															 
															<TR>
																 
																<TD style="HEIGHT: 23px;WIDTH: 200px;" align="right" height="23" colspan="2">
																	<ASP:LABEL id="Label2" runat="server" Width="200px" Font-Bold="True" meta:resourcekey="Label2Resource1">Account Action EXCEL 附件：</ASP:LABEL></TD>
																<TD style="HEIGHT: 23px;WIDTH: 180px;" align="left" colspan="2" height="23">
                                                                <INPUT id="btnUploadMode2" type="file"  accept="application/msexcel,application/csv" runat="server">
																&nbsp;</TD>
																<TD style="HEIGHT: 23px" align="left" width="5%" height="23">
                                                                	<anthem:LABEL id="lbrfvUpload2" runat="server" Visible="False" ForeColor="Red" style="Width: 60px" meta:resourcekey="lbrfvUpload2Resource1">*</anthem:LABEL>
                                                                  </TD>
																<TD style="HEIGHT: 23px" align="left" width="25%" height="23">
                                                                <INPUT id="Submit2" style="WIDTH: 48px; HEIGHT: 24px" type="submit"  onclick="return btnSureUploadAction();" value="上傳"
																		runat="server">&nbsp;</TD>
															</TR>
															<TR bgColor="#edecd1" height="1">
																<TD style="WIDTH: 10px" height="1"></TD>
																<TD align="right" height="1"></TD>
																<TD align="left" colSpan="3" height="1">&nbsp;&nbsp;
																		<anthem:LABEL id="lbUploadResult2" runat="server" Visible="False" Width="100%" ForeColor="Red" meta:resourcekey="lbUploadResult2Resource1"></anthem:LABEL></TD>
																<TD align="left" height="1"></TD>
															</TR>
															<TR>
																<TD style="WIDTH: 10px" height="1"></TD>
																<TD align="center" colSpan="5" height="1" style="WIDTH: 160px;height:100%" > 
																		<DIV id="div2" runat="server"><IFRAME src="UploadSmsActionRefresh.aspx" frameBorder="no" width="100%" height="500px"><TABLE class="font" style="FILTER: Alpha(opacity=80); WIDTH: 152px; HEIGHT: 42px" borderColor="#cccccc"
																					height="80" cellSpacing="1" cellPadding="5" width="160" border="0">
																					<TR>
																						<TD style="WIDTH: 55px">
																							<P>
																								<asp:Image id="Image1" runat="server" ImageUrl="resource/indicator.gif" meta:resourcekey="Image1Resource1"></asp:Image></P>
																						</TD>
																						<TD>
																							<P>
																								<asp:Label id="Label5" runat="server" ForeColor="Red" meta:resourcekey="Label5Resource1"></asp:Label></P>
																						</TD>
																					</TR>
																				</TABLE>
																			</IFRAME>
																		</DIV>
																		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
																</TD>
															</TR>
														</TABLE>
													
												</TD>
												<TD align="left" width="15%" height="1"></TD>
											</TR>
										 
										</TABLE>
                                    </asp:panel>

                                    <asp:panel id="plAgentSMS" runat="server" Visible="False" meta:resourcekey="plAgentSMSResource1"> 
                                    <TABLE class="tan-border02" style="WIDTH: 100%; BORDER-COLLAPSE: collapse; HEIGHT: 100%;vertical-align:top "
											cellSpacing="10"  cellPadding="0" rules="none" align="left" border="0"  >
											<TR>
												<TD style="WIDTH: 10px" height="1"> </TD> 
											</TR>
											<TR  valign ="top" style ="height:100%" >
												<TD style="WIDTH: 10px" height="1"></TD>
												<TD align="center" height="1"> 
														<TABLE id="Table5" borderColor="#edecd1" height="100%" cellSpacing="1" cellPadding="0"
															rules="none" width="80%" align="left" border="1"> 
																<tr>
                                                                    <td height="1" style="WIDTH: 10px"></td>
                                                                    <td align="right" height="1" style="WIDTH: 143px"></td>
                                                                    <td align="left" height="1" style="WIDTH: 118px"></td>
                                                                    <td align="left" height="1">&nbsp; </td>
                                                                    <td align="left" height="1" width="10%"></td>
                                                                    <td align="left" height="1" width="10%"></td>
                                                                </tr>
                                                                <tr style="display:none">
                                                                    <td align="left" height="1" valign="baseline"></td>
                                                                    <td align="right" height="1">
                                                                        <asp:Label ID="Label3" runat="server" Font-Bold="True" Width="112px" meta:resourcekey="Label3Resource1">上傳方式 ：</asp:Label>
                                                                    </td>
                                                                    <td align="left" height="1" style="WIDTH: 118px">
                                                                        <anthem:RadioButton ID="RADIOBUTTON3" runat="server" AutoCallBack="True" Checked="True" Text="新增上傳組別的號碼" Width="130px" meta:resourcekey="RADIOBUTTON3Resource1" />
                                                                    </td>
                                                                    <td align="left" height="1">
                                                                        <anthem:RadioButton ID="RADIOBUTTON4" runat="server" AutoCallBack="True" Text="上傳覆蓋組別的號碼" Width="130px" meta:resourcekey="RADIOBUTTON4Resource1" />
                                                                    </td>
                                                                    <td align="left" height="1" width="10%">
                                                                        <anthem:Button ID="BUTTON2" runat="server" Text="上傳" Visible="False" Width="52px" meta:resourcekey="BUTTON2Resource2" />
                                                                    </td>
                                                                    <td align="left" height="1" width="10%"></td>
                                                                </tr>
                                                                <tr style="display:none">
                                                                    <TD style="HEIGHT: 23px;WIDTH: 200px;" align="right" height="23" colspan="2">
                                                                        <asp:Label ID="Label4" runat="server" Font-Bold="True" Width="200px" meta:resourcekey="Label4Resource1">Account Action EXCEL 附件：</asp:Label>
                                                                    </td>
                                                                    <td align="left" colspan="2" height="23" style="HEIGHT: 23px;WIDTH: 180px;">
                                                                        <input id="File1" runat="server" accept="application/msexcel,application/csv" type="file"></input>
                                                                     </td>
                                                                    <td align="left" height="23" style="HEIGHT: 23px" width="10%">
                                                                        <anthem:Label ID="LABEL6" runat="server" ForeColor="Red" style="Width: 60px" Visible="False" meta:resourcekey="LABEL6Resource1">
                                                                            *</anthem:Label>
                                                                    </td>
                                                                    <td align="left" height="23" style="HEIGHT: 23px" width="10%">
                                                                        <input id="Submit3" runat="server" style="WIDTH: 48px; HEIGHT: 24px" type="submit" value="上傳"></input>
                                                                     </td>
                                                                </tr>
                                                          	<TR style="display:none">
																<TD style="WIDTH: 10px" height="1"></TD>
																<TD align="right" height="1"></TD>
																<TD align="left" colSpan="3" height="1"></TD>
																<TD align="left" height="1"></TD>
															</TR> 
                                                            <tr style="height:10px"><td></td></tr>
                                                             <tr>
                                                                 <td height="1" style="WIDTH: 10px"></td>
                                                                 <td align="center" height="1">發送號碼 : </td>
                                                                 <td align="left" colspan="3" height="1">
                                                                 <div id="div11">    <anthem:TextBox ID="txtSmsPhone" runat="server" onkeyup="SyncSMSPhone()"  onblur="SyncSMSContent()"  Width="200px" meta:resourcekey="txtSmsPhoneResource1"></anthem:TextBox>
                                                                 </div></td>
                                                                </tr> 
                                                                <tr  >
                                                                    <td height="1" style="WIDTH: 10px"> </td>
                                                                    <td align="center" height="1">轉台號碼 : </td>
                                                                    <td align="left" colspan="3" height="1"> <div id="div22"><anthem:TextBox id="txtAgentPhone"  onblur="SyncSMSContent2()"   runat="server"   Width="200px" meta:resourcekey="txtAgentPhoneResource1"  ></anthem:TextBox>
                                                                    </div></td> 
                                                                </tr>
                                                             <tr> 
                                                                 <td height="1" style="WIDTH: 10px"> </td>
                                                                    <td align="center" height="1">銷售員名稱 : </td>
                                                                    <td align="left" colspan="3" height="1"> <div id="div3"><anthem:TextBox id="txtSaleName"  onblur="SyncSMSContentSaleName()"   runat="server"   Width="200px" meta:resourcekey="txtSaleNameResource1"  ></anthem:TextBox>
                                                                    </div></td> </tr>
                                                             <tr>
                                                                  <td height="1" style="WIDTH: 10px"> </td>
                                                                    <td align="center" height="1">銷售員直線 : </td>
                                                                    <td align="left" colspan="3" height="1"> <div id="div4"><anthem:TextBox id="txtSalePhone"  onblur="SyncSMSContentSalePhone()"   runat="server"   Width="200px" meta:resourcekey="txtSalePhoneResource1"  ></anthem:TextBox>
                                                                    </div></td> </tr>
                                                             <tr>
                                                                 <td height="1" style="WIDTH: 10px"></td>
                                                                 <td align="center" height="1">短訊內容 : </td>
                                                                 <td align="left" colspan="3" height="1">
                                                                     <anthem:DropDownList ID="dplAgentSmsNum" runat="server" Width="500px" AutoCallBack="True" meta:resourcekey="dplAgentSmsNumResource1">
                                                                      </anthem:DropDownList>
                                                                 </td>
                                                                </tr>
                                                             <tr style="height:70px"><td></td></tr>
                                                            <tr>
                                                                <td height="1" style="WIDTH: 10px"></td>
                                                                <td align="center" height="1">  </td>
                                                                <td align="left" colspan="3" height="1">
                                                                    <anthem:TextBox ID="txtAgentSmsContent" runat="server" Width="500px" Height="150px" style="IME-MODE: disabled" TextMode="MultiLine" meta:resourcekey="txtAgentSmsContentResource1"></anthem:TextBox>
                                                                </td>
                                                                </tr>
                                                              <tr style="height:20px"><td></td></tr>
                                                              <tr>
                                                                <td height="1" style="WIDTH: 10px"></td>
                                                                <td align="center" height="1">  </td>
                                                                <td align="left" colspan="1" height="1">  <anthem:Button ID="btnAgentSend" runat="server" Text="發送"   Width="80px" meta:resourcekey="btnAgentSendResource1" />
                                                                 </td>
                                                                  <td align="left" height="1">  
                                                                  <anthem:LABEL id="lbAgentSmsResult" runat="server" Width="100%" ForeColor="Red" meta:resourcekey="lbAgentSmsResultResource1"> </anthem:LABEL>
                                                                 </td>
                                                                  <td align="center" height="1">  </td>
                                                              </tr>
                                                             <tr>
                                                                 <td height="1" style="WIDTH: 10px"></td>
                                                                 <td align="center" colspan="5" height="1" style="WIDTH: 160px;height:100%"></td>
                                                            </TABLE>
                                                            </TD>    
											</TR>
										</TABLE>
                                    </asp:panel>

                                    <asp:panel id="plUploadSmsAgent" runat="server" Visible="False" meta:resourcekey="plUploadSmsAgentResource1"> 
                                    <TABLE class="tan-border02" style="WIDTH: 100%; BORDER-COLLAPSE: collapse;  HEIGHT: 100%;vertical-align:top" cellSpacing="10" cellPadding="0" rules="none" align="left" border="0">
											<TR>
												<TD style="WIDTH: 10px" height="3"> </TD> 
											</TR>
											<TR  valign ="top" style ="height:100%" >
												<TD style="WIDTH: 10px" height="1"></TD>
												<TD align="center" colSpan="3" height="1">
														<TABLE id="Table6" borderColor="#edecd1" height="100%" cellSpacing="1" cellPadding="0"
															rules="none" width="80%" align="left" border="1">
														 <tr>
																<TD style="WIDTH: 10px" height="1"></TD>
																<TD style="WIDTH: 143px" align="right" height="1"></TD>
																<TD style="WIDTH: 118px" align="left" height="1"></TD>
																<TD align="left" height="1">&nbsp;</TD>
																<TD align="left" width="15%" height="1"></TD>
																<TD align="left" width="15%" height="1"></TD>
															</TR>
															<TR style ="display:none">
																<TD vAlign="baseline" align="left" height="1"></TD>
																<TD align="right" height="1">
																	<ASP:LABEL id="lbAgentUpload" runat="server" Width="112px" Font-Bold="True" meta:resourcekey="lbAgentUploadResource1">上傳方式                         ：</ASP:LABEL></TD>
																<TD style="WIDTH: 118px" align="left" height="1">
																	<anthem:RADIOBUTTON id="RADIOBUTTON17" runat="server" Width="130px" Text="新增上傳組別的號碼" AutoCallBack="True"
																		Checked="True" meta:resourcekey="RADIOBUTTON17Resource1"></anthem:RADIOBUTTON></TD>
																<TD align="left" height="1">
																	<anthem:RADIOBUTTON id="RADIOBUTTON27" runat="server" Width="130px" Text="上傳覆蓋組別的號碼" AutoCallBack="True" meta:resourcekey="RADIOBUTTON27Resource1"></anthem:RADIOBUTTON></TD>
																<TD align="left" width="15%" height="1">
																	<anthem:BUTTON id="BUTTON17" runat="server" Visible="False" Width="52px" Text="上傳" meta:resourcekey="BUTTON17Resource2"></anthem:BUTTON></TD>
																<TD align="left" width="15%" height="1"></TD>
															</TR>
															<TR>
																 
																<TD style="HEIGHT: 23px;WIDTH: 200px;" align="left" height="23" colspan="2">
																	<ASP:LABEL id="Label27" runat="server" Width="200px" Font-Bold="True" meta:resourcekey="Label27Resource1">Bulk Sms EXCEL 附件：</ASP:LABEL></TD>
																<TD style="HEIGHT: 23px;WIDTH: 180px;" align="left" colspan="2" height="23">
                                                                <INPUT id="btnUploadMode3" type="file"  accept="application/msexcel,application/csv" style ="width :500px" runat="server">
																  &nbsp;<asp:RequiredFieldValidator ID="reqbtnUploadMode3" runat="server" ControlToValidate="btnUploadMode3" ErrorMessage="*" meta:resourcekey="reqbtnUploadMode3Resource1"></asp:RequiredFieldValidator>

																</TD> 
																<TD style="HEIGHT: 23px" align="right" width="25%" height="23">
                                                                </TD>
															</TR>
															    <tr style="height:10px"><td></td></tr>
															    <tr>
                                                                 <td height="1" style="WIDTH: 10px"></td>
                                                                 <td align="center" height="1">短訊內容 : </td>
                                                                 <td align="left" colspan="3" height="1">
                                                                     <anthem:DropDownList ID="dplUploadAgentSmsNum" runat="server" Width="500px" AutoCallBack="True" meta:resourcekey="dplUploadAgentSmsNumResource1">
                                                                      </anthem:DropDownList>
                                                                 </td>
                                                                </tr>
                                                             <tr style="height:10px"><td></td></tr>
                                                            <tr>
                                                                <td height="1" style="WIDTH: 10px"></td>
                                                                <td align="center" height="1">  </td>
                                                                <td align="left" colspan="2" height="1">
                                                                    <anthem:TextBox ID="txtUploadAgentSmsContent" runat="server" Width="500px" Height="150px" style="IME-MODE: disabled" TextMode="MultiLine" meta:resourcekey="txtUploadAgentSmsContentResource1"></anthem:TextBox>
                                                                	<anthem:LABEL id="lbrfvUpload3" runat="server" Visible="False" ForeColor="Red" style="Width: 60px" meta:resourcekey="lbrfvUpload3Resource1">*</anthem:LABEL>
                                                                 </td>
                                                                   <td valign="bottom" align="center"> <INPUT id="subUploadAgentSms" onclick="return btnSure();"  style="WIDTH: 60px; HEIGHT: 24px" type="submit" value="發送"
																		runat="server">&nbsp;</td>
                                                                </tr>
                                                                 <tr style="height:10px"><td></td></tr>
															<TR bgColor="#edecd1" height="1">
																<TD style="WIDTH: 10px" height="1"></TD>
																<TD align="right" height="1"></TD>
																<TD align="left" colSpan="3" height="1">&nbsp;&nbsp;
																		<anthem:LABEL id="lbUploadResult3" runat="server" Visible="False" Width="100%" ForeColor="Red" meta:resourcekey="lbUploadResult3Resource1"></anthem:LABEL></TD>
																<TD align="left" height="1"></TD>
															</TR>
															<TR>
																<TD style="WIDTH: 10px" height="1"></TD>
																<TD align="center" colSpan="5" height="1" style="WIDTH: 160px;height:100%" > 
																		<DIV id="div27" runat="server"><IFRAME src="UploadSmsAgentRefresh.aspx" frameBorder="no" width="100%" height="500px"><TABLE class="font" style="FILTER: Alpha(opacity=80); WIDTH: 152px; HEIGHT: 42px" borderColor="#cccccc"
																					height="80" cellSpacing="1" cellPadding="5" width="160" border="0">
																					<TR>
																						<TD style="WIDTH: 55px">
																							<P>
																								<asp:Image id="Image17" runat="server" ImageUrl="resource/indicator.gif" meta:resourcekey="Image17Resource1"></asp:Image></P>
																						</TD>
																						<TD>
																							<P>
																								<asp:Label id="Label57" runat="server" ForeColor="Red" meta:resourcekey="Label57Resource1"></asp:Label></P>
																						</TD>
																					</TR>
																				</TABLE>
																			</IFRAME>
																		</DIV>
																		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
																</TD>
															</TR>
														</TABLE>
													 
												</TD>
												<TD align="left" width="15%" height="1"></TD>
											</TR>
										 
									</TABLE>

                                    </asp:panel>
									</TD>
							</TR>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
