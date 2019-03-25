<%@ Register TagPrefix="anthem" Namespace="Anthem" Assembly="Anthem" %>
<%@ Register TagPrefix="uc1" TagName="MenuTabs" Src="UserControl/MenuTabs.ascx" %>
<%@ Page language="c#" Codebehind="SendByGroup.aspx.cs" AutoEventWireup="false" Inherits="CENTASMS.SendByGroup"  ValidateRequest="false" %>
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
		        else { document.getElementById("lbMsg").innerHTML = '超過最大字符數670！' }

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
		        else if (nLen <= 1071) {
		            document.getElementById("lbMsg").innerHTML = ''
		            return 7;
		        }
		        else if (nLen <= 1224) {
		            document.getElementById("lbMsg").innerHTML = ''
		            return 8;
		        }
		        else if (nLen <= 1377) {
		            document.getElementById("lbMsg").innerHTML = ''
		            return 9;
		        }
		        else if (nLen <= 1530) {
		            document.getElementById("lbMsg").innerHTML = ''
		            return 10;
		        }
		        else { document.getElementById("lbMsg").innerHTML = '超過最大字符數1530！' }
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
		            if (tempArray[i].indexOf('組別') > -1) {
		            }
		            else {
		                var strvalue = tempArray[i];
		                //var reg = /[9,5,6]{1}[0-9]{7}/;
		                var reg = /['<%=ConfigurationSettings.AppSettings["ValidPrefixes"]%>']{1}[0-9]{7}/;
		                if (strvalue.indexOf("00852") == 0) {
		                    var str = strvalue.substring(5);
		                    if (str.length != 8) {
		                        alert("電話號碼位數不正確！(" + strvalue + ')');
		                        return (false);
		                    }
		                    else {
		                        if (reg.exec(str))
		                        { } else {
		                            alert("請輸入正確號碼！(" + strvalue + ')');
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
		                        alert("電話號碼位數不正確！(" + strvalue + ')');
		                        return (false);
		                    }
		                    else {
		                        if (reg.exec(strvalue))
		                        { } else {
		                            alert("請輸入正確號碼！(" + strvalue + ')');
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
                    if (tempArray[i].indexOf('組別') > -1) {
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
		                        alert("電話號碼位數不正確！" + strvalue);
		                        return (false);
		                    }
		                } else {
		                    alert("請輸入正確號碼！" + strvalue);

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
                    return confirm('確定發送?');
                }
                else
                {
                  
                } 
            }

            function btnSureUpload() {
                if (document.getElementById("btnUploadMode").value != "") {
                    return confirm('確定發送?');
                }
                else {
                }
            }
            function btnSureUploadAction() {
                if (document.getElementById("btnUploadMode2").value != "") {
                    return confirm('確定上載?');
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
								
								<anthem:panel id="plSendLogion" runat="server" Visible="false">
														<TABLE id="Table2" style="WIDTH: 399px; HEIGHT: 182px" height="182" cellSpacing="0" cellPadding="0"
															width="399" border="0">
															<TR>
																<TD style="HEIGHT: 30px" width="14"><FONT face="新細明體"></FONT></TD>
																<TD style="HEIGHT: 30px">
																	<ASP:LABEL id="lbUserLogion" runat="server">用戶ID：</ASP:LABEL>
																	<anthem:DropDownList id="Dropdownlist1" runat="server" Width="100px" AutoCallBack="True"  Visible="false">
														<asp:ListItem Value="All" Selected="True">All</asp:ListItem></anthem:DropDownList>
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
			    function Clear() {
			        document.getElementById("txtUserLogion").value = "";
			        document.getElementById("txtUserPWLogion").value = "";
			    }
		</script>
																	<anthem:BUTTON id="SaveLogin" runat="server" Width="64px" Text="登入"></anthem:BUTTON>&nbsp;&nbsp;&nbsp;<INPUT id="btnCannelLogin" onclick="Clear()" type="button" value="重置" name="btnCannelLogin">&nbsp;&nbsp;
																	<anthem:LABEL id="lbMsgError" runat="server" ForeColor="Red"></anthem:LABEL></TD>
															</TR>
														</TABLE>
													</anthem:panel>
													
								    <anthem:panel id="plSendMsg" runat="server" Visible="false">
										<TABLE style="WIDTH: 500px; BORDER-COLLAPSE: collapse; HEIGHT: 380px;" 
											cellSpacing="10" cellPadding="0" rules="none" align="left" border="0">
											<TR><TD vAlign="top" align="left"  colspan=4  height="1"><anthem:LABEL id="lbMsgLogin" runat="server" ForeColor="Red"></anthem:LABEL><anthem:Button id="btnLoginOut" runat="server" Text="登出" Visible="false" ></anthem:Button>&nbsp;</TD></TR>
											<TR vAlign="top" width="100%">
                                                <TD vAlign="top" align="left" width="40%" height="1" ><anthem:Label id="lbSendSMS" runat="server" Font-Size="Medium">短訊內容：</anthem:Label>  <asp:RequiredFieldValidator id="rfvMsg" runat="server" ErrorMessage="|" ControlToValidate="txtSmsContent" Enabled="False"></asp:RequiredFieldValidator><anthem:Label id="lbrfvContent" runat="server" Visible="false" ForeColor="Red">*</anthem:Label></TD>
                                                <TD vAlign="top" align="left" width="24%" height="1"><anthem:Label id="lbSendNo" runat="server" Font-Size="Medium">發送號碼：</anthem:Label> <asp:RequiredFieldValidator id="rfvNum" runat="server" ErrorMessage="|" ControlToValidate="tbNum" Enabled="False"></asp:RequiredFieldValidator><anthem:Label id="lbrfvNum" runat="server" Visible="false" ForeColor="Red">*</anthem:Label><INPUT type="checkbox" style="DISPLAY: none" id="ckIdd"  onclick="checkIdd()"><FONT face="新細明體"  style="DISPLAY: none" id="valueIDD">IDD</FONT></TD>
                                                <TD vAlign="top" align="left" width="18%" height="1"><anthem:Label id="lbSendGroup" runat="server" Font-Size="Medium">發送組別：</anthem:Label></TD>
                                                <TD vAlign="top" align="left" width="18%" height="1"><anthem:Label id="lbSendMember" runat="server"   Font-Size="Medium">發送組員：</anthem:Label></TD>
                                                <TR width="100%">
                                                <TD vAlign="top" align="left" width="40%" height="256"><anthem:TextBox onkeypress="CountSmsContent()" id="txtSmsContent" onkeydown="CountSmsContent()"	onblur="CountSmsContent()" onkeyup="CountSmsContent()"  runat="server" onChange="CountSmsContent()" TextMode="MultiLine"	Width="380px" Height="264px"></anthem:TextBox></TD>
                                                <TD vAlign="top" align="left" width="24%" height="256"><anthem:TextBox id="tbNum" onkeydown="myKeyDown()" style="IME-MODE: disabled" runat="server" onblur="myKeyChange(this)" TextMode="MultiLine" Width="210px" Height="264px"></anthem:TextBox><anthem:Label id="lbGroupIDContent"   Visible="False" runat="server"  ></anthem:Label></TD>
                                                <TD vAlign="top" align="left" width="18%" height="256"><anthem:ListBox id="lstGroup" runat="server" Width="190px" Height="100%" AutoCallBack="True"></anthem:ListBox></TD>
                                                <TD vAlign="top" align="left" width="18%" height="256"><anthem:ListBox id="lstGroupMember" runat="server"    Width="190px" AutoCallBack="True" Height="100%" ></anthem:ListBox></TD>
                                                </TR>
                                            <TR width="100%"><TD vAlign="top" align="left" width="50%" height="1">共 <anthem:Label id="lbLen" runat="server" ForeColor="Red" Width="40px">0</anthem:Label>字元，短訊分： <anthem:Label id="lbNum" runat="server" ForeColor="Red" Width="20px">0</anthem:Label>條發送。 <anthem:Label id="lbMsg" runat="server" ForeColor="Red"  Width="128px"></anthem:Label><asp:Button id="btnCount" runat="server" Visible =False   Text="計算長度"></asp:Button></TD><TD></TD><TD vAlign="top" align="left" width="28%" height="1"><FONT face="新細明體"></FONT></TD><TD vAlign="top" align="left" width="22%" height="1"><FONT face="新細明體"></FONT></TD></TR><TR><TD vAlign="baseline" align="left" width="50%" height="1"><P><FONT face="新細明體">預設時間： <anthem:RadioButton id="rbSendontime" runat="server" Visible="true" Text="即時發送" AutoCallBack="True"
																Checked="True"></anthem:RadioButton><anthem:RadioButton id="rbSendbyTime" runat="server" Visible="true" Text="預設發送" AutoCallBack="True"></anthem:RadioButton></FONT></P></TD><TD></TD><TD vAlign="top" align="left" width="28%" height="1"></TD><TD vAlign="top" align="left" width="22%" height="1"><FONT face="新細明體"></FONT></TD></TR><TR ><TD  align="left" width="50%" height="1"><table  ><tr ><td  ><anthem:Button id="btnSend" runat="server" Text="發送"></anthem:Button></td><td vAlign="top" align=left  width="200px"  ><DIV  id="div_load" runat="server"   ><IFRAME  id ="sendiframe" src="sendRefresh.aspx"  frameborder=no  scrolling =no  width ="200px" height ="60px"  ></iframe></div></td><td  align=left  ><asp:Button id="btnCannel" runat="server"  Text="重置"></asp:Button></td></tr></table></TD><TD></TD><TD vAlign="top" align="left" width="28%" height="1"></TD><TD vAlign="top" align="left" width="22%" height="1"><FONT face="新細明體"><INPUT id="btnCCannel" style="DISPLAY: none" onclick="Clear()" type="button" value="重置"></FONT></TD></TR>
										</TABLE>
									</anthem:panel>
                                    
                                    <asp:panel id="plMsgData" runat="server" Visible="false">
										<table style="WIDTH: 100%; BORDER-COLLAPSE: collapse; HEIGHT: 380px;" 
											cellSpacing="10" cellPadding="0" rules="none" align="left" border="0">
											<TR vAlign="middle" width="100%">
												<TD vAlign="baseline" align="left" height="1">
													<P><STRONG>即時發送記錄：</STRONG></P>
												</TD>
												<TD align="left" height="1">用戶：




													<anthem:DropDownList id="dplUsers" runat="server" Width="100px" AutoCallBack="True">
														<asp:ListItem Value="All" Selected="True">All</asp:ListItem>
													</anthem:DropDownList></TD>
												<TD align="left" height="1">日期從：
													<asp:TextBox id="txtStartDate" onChange="return CheckDate(this)"
														runat="server" Width="80px"  ></asp:TextBox>
													<asp:RequiredFieldValidator id="rfv" runat="server" ErrorMessage="*" ControlToValidate="dplUsers"></asp:RequiredFieldValidator></TD>
												<TD align="left" height="1">到：
													<asp:TextBox id="txtEndDate" onChange="return CheckDate(this)"
														runat="server" Width="80px" ></asp:TextBox></TD>
												<TD align="left" width="15%" height="1"><FONT face="新細明體">
														<anthem:Button id="btnSearch" runat="server" Text="查詢"></anthem:Button>
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
													<anthem:DataGrid id="dgSmsData" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False">
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
														   <!--      Server.HtmlEncode((DataBinder.Eval(Container, "DataItem.CSMSMSG")).ToString())  -->
													           <%# GetText(DataBinder.Eval(Container, "DataItem.CSMSMSG")) %> </a>
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

                                                             <asp:TemplateColumn HeaderText="未發送/已發送">
																<HeaderStyle HorizontalAlign="Left" Wrap="false" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle CssClass="grid-item"></ItemStyle>
																<ItemTemplate>
																<%--	<%# DataBinder.Eval(Container, "DataItem.IMOBILETOTAL")%>--%>
                                                                    	<%# CountData(DataBinder.Eval(Container, "DataItem.CBATCHID"), DataBinder.Eval(Container, "DataItem.IMOBILETOTAL"), DataBinder.Eval(Container, "DataItem.ISMSMSGNO"), DataBinder.Eval(Container, "DataItem.UnSendCount"))%>
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
													</anthem:DataGrid></TD>
											</TR>
											<TR width="100%">
												<TD colSpan="5"></TD>
											</TR>
										</TABLE>
									</asp:panel>

                                    <asp:panel id="plSendHist" runat="server" Visible="false">
										<TABLE style="WIDTH: 100%; BORDER-COLLAPSE: collapse; HEIGHT: 380px;"
											cellSpacing="10" cellPadding="0" rules="none" align="left" border="0">
											<TR vAlign="middle" width="100%">
												<TD vAlign="baseline" align="left" height="1"><STRONG>預設發送記錄:</STRONG>
												</TD>
												<TD align="left" height="1">用戶：




													<anthem:DropDownList id="dplUser2" runat="server" Width="100px" AutoCallBack="True">
														<asp:ListItem Value="All" Selected="True">All</asp:ListItem>
													</anthem:DropDownList></TD>
												<TD align="left" height="1">日期從：
													<asp:TextBox id="txtStartDate2" onChange="return CheckDate(this)"
														runat="server" Width="80px" ></asp:TextBox>
													<asp:RequiredFieldValidator id="Requiredfieldvalidator1" runat="server" ErrorMessage="*" ControlToValidate="dplUser2"></asp:RequiredFieldValidator></TD>
												<TD align="left" height="1">到:
													<asp:TextBox id="txtEndDate2" onChange="return CheckDate(this)"
														runat="server" Width="80px"  ></asp:TextBox></TD>
												<TD align="left" width="15%" height="1"><FONT face="新細明體">
														<anthem:Button id="btnSearchSch" runat="server" Text="查詢"></anthem:Button>
														<anthem:Button id="btnDetailSch" runat="server" Text="詳情"></anthem:Button>
														<asp:Button id="btnExportSms2" runat="server" Text="匯出"></asp:Button>
														<anthem:Label id="lbMsgSch" runat="server" ForeColor="Red" Width="100px"></anthem:Label></FONT></TD>
											<TR>
												<TD vAlign="baseline" align="left" height="1"></TD>
												<TD align="left" height="1"></TD>
												<TD align="left" height="1"></TD>
												<TD align="left" height="1"></TD>
												<TD align="left" width="15%" height="1"></TD>
											</TR>
											<TR width="100%">
												<TD vAlign="top" align="left" width="50%" colSpan="5" height="256">
													<anthem:DataGrid id="dgSchedule" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False">
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
																	<anthem:Label id="lbBatchidD" runat="server" Visible =false Width="160px" Text='<%# DataBinder.Eval(Container, "DataItem.CBATCHID") %>'>
																	</anthem:Label>
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
																	<anthem:Label id="lbdgCBATCHID" runat="server" Visible =false Width="160px" Text='<%# DataBinder.Eval(Container, "DataItem.CBATCHID") %>'>
																	</anthem:Label>
																	<anthem:Label id="lbdgOldSendDate" runat="server" Visible =false Width="160px" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.CSEND_DATE")).ToString("yyyy-MM-dd HH:mm")%>'>
																	</anthem:Label>
																	<anthem:TextBox id="txtdgSendDate" runat="server" Width="120px" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.CSEND_DATE")).ToString("yyyy-MM-dd HH:mm")%>'>
																	</anthem:TextBox>
																</EditItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="發送狀態">
																<HeaderStyle Wrap="false" HorizontalAlign="Left" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle CssClass="grid-item"></ItemStyle>
																<ItemTemplate>
																	<%# StringStatus(DataBinder.Eval(Container, "DataItem.STATUS")) %>
																	<anthem:Label id="lbdgSTATUS" runat="server" Visible =false Width="160px" Text='<%# DataBinder.Eval(Container, "DataItem.STATUS") %>'>
																	</anthem:Label>
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
													</anthem:DataGrid>
													<anthem:DataGrid id="dgSchedule2" runat="server" Visible="false" Width="100%" AllowPaging="True"
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
																	<anthem:Label id="lbdgSchedule2Batchid" runat="server" Visible =false Width="160px" Text='<%# DataBinder.Eval(Container, "DataItem.CBATCHID") %>'>
																	</anthem:Label>
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
														         <!--      Server.HtmlEncode((DataBinder.Eval(Container, "DataItem.CSMSMSG")).ToString())  -->
													           <%# GetText(DataBinder.Eval(Container, "DataItem.CSMSMSG")) %> 
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

                                                               <asp:TemplateColumn HeaderText="未發送/已發送">
																<HeaderStyle HorizontalAlign="Left" Wrap="false" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle CssClass="grid-item"></ItemStyle>
																<ItemTemplate>
																 <%# CountData2(DataBinder.Eval(Container, "DataItem.CBATCHID"), DataBinder.Eval(Container, "DataItem.IMOBILETOTAL"), DataBinder.Eval(Container, "DataItem.ISMSMSGNO"), DataBinder.Eval(Container, "DataItem.UnSendCount"))%>
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
													</anthem:DataGrid></TD>
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




													<anthem:DropDownList id="dplUsersCall" runat="server" Width="100px" AutoCallBack="True">
														<asp:ListItem Value="All" Selected="True">All</asp:ListItem>
													</anthem:DropDownList></TD>
												<TD align="left" height="1">日期從：
													<asp:TextBox id="txtStartDateCall" onChange="return CheckDate(this)"
														runat="server" Width="80px"  ></asp:TextBox>
													<asp:RequiredFieldValidator id="rfvCall" runat="server" ErrorMessage="*" ControlToValidate="dplUsersCall"></asp:RequiredFieldValidator></TD>
												<TD align="left" height="1">到：
													<asp:TextBox id="txtEndDateCall" onChange="return CheckDate(this)"
														runat="server" Width="80px"  ></asp:TextBox></TD>
												<TD align="left" width="15%" height="1"><FONT face="新細明體">
														<anthem:Button id="btnSearchCall" runat="server" Text="查詢"></anthem:Button>
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
													<anthem:DataGrid id="dgSmsDataCall" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False">
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
														          <!--      Server.HtmlEncode((DataBinder.Eval(Container, "DataItem.CSMSMSG")).ToString())  -->
													           <%# GetText(DataBinder.Eval(Container, "DataItem.CSMSMSG")) %> 
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
													</anthem:DataGrid></TD>
											</TR>
											<TR width="100%">
												<TD colSpan="5"><FONT face="新細明體"></FONT></TD>
											</TR>
										</TABLE>
									</asp:panel>
									
									<asp:panel id="plDefineScheduleMsg" runat="server" Visible="false"> 
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
												<TD vAlign="bottom" align="left" height="1"><anthem:TextBox id="txtScheduleMsgTitle"   style="IME-MODE: disabled" runat="server"     ></anthem:TextBox></TD>
												<TD vAlign="bottom" align="left" height="1"></TD>
												<TD vAlign="bottom" align="left" height="1"></TD>
												<TD vAlign="bottom" align="left" height="1"></TD>
											</TR>
											<TR vAlign="bottom">
												<TD vAlign=bottom align="left" height="1" width="95px">
													<ASP:LABEL id="lbAddMsg" runat="server" Width="95px"  >預設短訊內容：</ASP:LABEL>
													<anthem:TextBox id="txtRfv"  Width="1px"  runat="server"  Visible =false  ></anthem:TextBox>
													<asp:RequiredFieldValidator id="Requiredfieldvalidator3" runat="server" ErrorMessage="*" ControlToValidate="txtRfv"></asp:RequiredFieldValidator>
													 
                                                </TD>
												<TD  vAlign=bottom align=right height="1" width="400px"  ><FONT face="新細明體" color="red" style="font-weight: bold">(MRT/CSDL/CSN) IS SIGN</FONT>  
												<anthem:TextBox id="txtScheduleMsg"   style="IME-MODE: disabled" runat="server" TextMode="MultiLine" Width="400px" Height="60px" ></anthem:TextBox>
												 </TD>
												<TD vAlign="bottom"   Width="30px" align="left"  >
												<anthem:LABEL id="lbmsgRP" runat="server" Width="30px" ForeColor="Red"></anthem:LABEL>
												 </TD>
											 <TD vAlign="bottom" align="left" width="20px">	<asp:CheckBox ID="chkDefault" Runat =server Checked =False Text ="Default" > </asp:CheckBox>
											 </TD>
												<TD  vAlign=bottom Width="600px" >
													<anthem:BUTTON id="btnAddMsg" runat="server" Text="添加"></anthem:BUTTON>
													<anthem:LABEL id="lbMsgS" runat="server" Width="200px" ForeColor="Red"></anthem:LABEL></FONT><FONT face="新細明體"></FONT><FONT face="新細明體"></FONT>
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
													<anthem:DATAGRID id="dgData2" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True">
														<PAGERSTYLE Mode="NumericPages"></PAGERSTYLE>
														<EDITITEMSTYLE Height="36px"></EDITITEMSTYLE>
														<ITEMSTYLE Height="36px"></ITEMSTYLE>
														<HEADERSTYLE Font-Bold="True" Height="20px" Wrap="False"></HEADERSTYLE>
														<COLUMNS>
															<ASP:TEMPLATECOLUMN>
																<HEADERSTYLE Wrap="false" VerticalAlign="Middle" CssClass="grid-header" HorizontalAlign="Left"></HEADERSTYLE>
																<ITEMSTYLE Width="20px" CssClass="grid-item" Wrap="false"></ITEMSTYLE>
																<HEADERTEMPLATE>
																	<FONT face="新細明體">ID</FONT>
																</HEADERTEMPLATE><ITEMTEMPLATE>
																
																<ASP:LABEL id="lbStatusID" runat="server"   Width="10px" Text='<%# DataBinder.Eval(Container, "DataItem.ID") %>'>
																	</ASP:LABEL>
																
																 </ITEMTEMPLATE>
															</ASP:TEMPLATECOLUMN>
															<ASP:TEMPLATECOLUMN>
																<HEADERSTYLE Wrap="false" VerticalAlign="Middle" CssClass="grid-header" HorizontalAlign="Left"></HEADERSTYLE>
																<ITEMSTYLE Width="80px" CssClass="grid-item" Wrap="false"></ITEMSTYLE>
																<HEADERTEMPLATE>
																	<FONT face="新細明體">STATUS</FONT>
																</HEADERTEMPLATE>
																<ITEMTEMPLATE>
																	 <%# DataBinder.Eval(Container, "DataItem.Status") %>
																</ITEMTEMPLATE>
																<EDITITEMTEMPLATE>
																	<ASP:DROPDOWNLIST id="dplStatus" runat="server" Width="80px"></ASP:DROPDOWNLIST>
																	<ASP:LABEL id=lbStatus runat="server" Visible="False" Width="2px" Text='<%# DataBinder.Eval(Container, "DataItem.Status") %>'>
																	</ASP:LABEL>
																	
																</EDITITEMTEMPLATE>
															</ASP:TEMPLATECOLUMN>
                                                            <ASP:TEMPLATECOLUMN HeaderText="MSG_TITLE">
																<HEADERSTYLE Wrap="false" VerticalAlign="Middle" CssClass="grid-header" HorizontalAlign="Left"></HEADERSTYLE>
																<ITEMSTYLE Width="150px" CssClass="grid-item"></ITEMSTYLE>
																<ITEMTEMPLATE>
																	<%# DataBinder.Eval(Container, "DataItem.CTITLE")%>
																</ITEMTEMPLATE>
                                                                  <EDITITEMTEMPLATE >
															
																	<ASP:TEXTBOX id=txtCTITLE runat="server"   Width="150px"   TextMode="MultiLine" Text=' <%#(DataBinder.Eval(Container, "DataItem.CTITLE")) %>'>
																	</ASP:TEXTBOX>
																	<ASP:LABEL id=lbCTITLE runat="server" Visible="False" Width="2px" Text=' <%# (DataBinder.Eval(Container, "DataItem.CTITLE")) %>'>
																	</ASP:LABEL>
																</EDITITEMTEMPLATE>


															</ASP:TEMPLATECOLUMN>
															<ASP:TEMPLATECOLUMN>
																<HEADERSTYLE Wrap="false" VerticalAlign="Middle" CssClass="grid-header" HorizontalAlign="Left"></HEADERSTYLE>
																<ITEMSTYLE Width="360px" CssClass="grid-item"></ITEMSTYLE>
																<HEADERTEMPLATE>CONTENT   </HEADERTEMPLATE>
																<ITEMTEMPLATE>
																	  <!--      Server.HtmlEncode((DataBinder.Eval(Container, "DataItem.CSMSMSG")).ToString())  -->
													           <%# GetText(DataBinder.Eval(Container, "DataItem.CSMSMSG")) %> 
																</ITEMTEMPLATE>
																<EDITITEMTEMPLATE >
															
																	<ASP:TEXTBOX id=txtCSMSMSG runat="server"  TextMode="MultiLine" Width="360px" Height="60px" Text=' <%#(DataBinder.Eval(Container, "DataItem.CSMSMSG")) %>'>
																	</ASP:TEXTBOX>
																	<ASP:LABEL id=lbCSMSMSG runat="server" Visible="False" Width="2px" Text=' <%# Server.HtmlEncode((DataBinder.Eval(Container, "DataItem.CSMSMSG")).ToString()) %>'>
																	</ASP:LABEL>
																</EDITITEMTEMPLATE>
															</ASP:TEMPLATECOLUMN>
															<ASP:TEMPLATECOLUMN HeaderText="MSG_LEN">
																<HEADERSTYLE Width="30px" Wrap="false" VerticalAlign="Middle" CssClass="grid-header" HorizontalAlign="Left"></HEADERSTYLE>
																<ITEMSTYLE Width="30px" CssClass="grid-item"></ITEMSTYLE>
																<ITEMTEMPLATE>
																	<%# DataBinder.Eval(Container, "DataItem.IMSGLEN")%>
																</ITEMTEMPLATE>
															</ASP:TEMPLATECOLUMN>
															 
																<ASP:TEMPLATECOLUMN HeaderText="OWNER">
																<HEADERSTYLE Wrap="false" VerticalAlign="Middle" CssClass="grid-header" HorizontalAlign="Left"></HEADERSTYLE>
																<ITEMSTYLE Width="50px" CssClass="grid-item"></ITEMSTYLE>
																<ITEMTEMPLATE>
																	<%# DataBinder.Eval(Container, "DataItem.CSENDER")%>
																</ITEMTEMPLATE>
															</ASP:TEMPLATECOLUMN>
															<ASP:TEMPLATECOLUMN HeaderText="CREAT DATE">
																<HeaderStyle HorizontalAlign="Left" Width="100px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle CssClass="grid-item" Width="100px"></ItemStyle>
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
									</asp:panel>

                                    <asp:panel id="plUploadSms" runat="server" Visible="false"> 
                                    <TABLE class="tan-border02" style="WIDTH: 100%; BORDER-COLLAPSE: collapse;  HEIGHT: 100%;vertical-align:top"
											cellSpacing="10" cellPadding="0" rules="none" align="left" border="0">
											<TR>
												 	<TD style="WIDTH: 10px" height="3"> </TD> 
											</TR>
											<TR>
												<TD style="WIDTH: 10px" height="1"><FONT face="新細明體"></FONT></TD>
												<TD align="center" colSpan="3" height="1"><FONT face="新細明體">
														<TABLE id="Table4" borderColor="#edecd1" height="100%" cellSpacing="1" cellPadding="0"
															rules="none" width="80%" align="left" border="1">
														 
																<TD style="WIDTH: 10px" height="1"></TD>
																<TD style="WIDTH: 143px" align="right" height="1"></TD>
																<TD style="WIDTH: 118px" align="left" height="1"></TD>
																<TD align="left" height="1"><FONT face="新細明體">&nbsp;</FONT></TD>
																<TD align="left" width="15%" height="1"></TD>
																<TD align="left" width="15%" height="1"></TD>
															</TR>
															<TR style ="display:none">
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
																<TD style="HEIGHT: 23px;WIDTH: 100px;" align="right" height="23" colspan="2">
																	<ASP:LABEL id="Label8" runat="server" Width="200px" Font-Bold="True">EXCEL 附件：</ASP:LABEL></TD>
																<TD style="HEIGHT: 23px;WIDTH: 180px;" align="left" colspan="1" height="23">
                                                                <INPUT id="btnUploadMode" type="file"  accept="application/msexcel,application/csv" runat="server">
																</TD>							
                                                                	<TD style="HEIGHT: 23px;WIDTH: 100px;" align="center"  height="23"><asp:CheckBox ID="chkAction" Runat =server  Enabled="true" Visible ="False" Width ="160px" Checked =False Text ="With Account Action" > </asp:CheckBox> </TD>
																<TD style="HEIGHT: 23px" align="left" width="5%" height="23">
                                                                	<anthem:LABEL id="lbrfvUpload" runat="server" Visible="false" ForeColor="Red" style="Width: 60px">*</anthem:LABEL>
                                                                  </TD>
																<TD style="HEIGHT: 23px" align="left" width="25%" height="23">
                                                                <INPUT id="Submit1" style="WIDTH: 48px; HEIGHT: 24px" type="submit"  onclick="return btnSureUpload();" value="上傳" name="Submit1"
																		runat="server"></TD>
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
																<TD align="center" colSpan="5" height="1" style="WIDTH: 160px;height:100%" > 
																		<DIV id="div1" runat="server"><IFRAME src="UploadSmsRefresh.aspx" frameBorder="no" width="100%" height="500px"><TABLE class="font" style="FILTER: Alpha(opacity=80); WIDTH: 152px; HEIGHT: 42px" borderColor="#cccccc"
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
										 
										</TABLE>
                                    </asp:panel>

                          <asp:panel id="plUploadSmsAction" runat="server" Visible="false"> 
                                    <TABLE class="tan-border02" style="WIDTH: 100%; BORDER-COLLAPSE: collapse;  HEIGHT: 100%;vertical-align:top "
											cellSpacing="10" cellPadding="0" rules="none" align="left" border="0">
											<TR>
												<TD style="WIDTH: 10px" height="3"> </TD> 
											</TR>
											<TR  valign ="top" style ="height:100%" >
												<TD style="WIDTH: 10px" height="1"><FONT face="新細明體"></FONT></TD>
												<TD align="center" colSpan="3" height="1"><FONT face="新細明體">
														<TABLE id="Table3" borderColor="#edecd1" height="100%" cellSpacing="1" cellPadding="0"
															rules="none" width="80%" align="left" border="1">
														 
																<TD style="WIDTH: 10px" height="1"></TD>
																<TD style="WIDTH: 143px" align="right" height="1"></TD>
																<TD style="WIDTH: 118px" align="left" height="1"></TD>
																<TD align="left" height="1"><FONT face="新細明體">&nbsp;</FONT></TD>
																<TD align="left" width="15%" height="1"></TD>
																<TD align="left" width="15%" height="1"></TD>
															</TR>
															<TR style ="display:none">
																<TD vAlign="baseline" align="left" height="1"></TD>
																<TD align="right" height="1">
																	<ASP:LABEL id="Label1" runat="server" Width="112px" Font-Bold="True">上傳方式 
                        ：</ASP:LABEL></TD>
																<TD style="WIDTH: 118px" align="left" height="1">
																	<anthem:RADIOBUTTON id="RADIOBUTTON1" runat="server" Width="130px" Text="新增上傳組別的號碼" AutoCallBack="True"
																		Checked="True"></anthem:RADIOBUTTON></TD>
																<TD align="left" height="1">
																	<anthem:RADIOBUTTON id="RADIOBUTTON2" runat="server" Width="130px" Text="上傳覆蓋組別的號碼" AutoCallBack="True"></anthem:RADIOBUTTON></TD>
																<TD align="left" width="15%" height="1">
																	<anthem:BUTTON id="BUTTON1" runat="server" Visible="False" Width="52px" Text="上傳"></anthem:BUTTON></TD>
																<TD align="left" width="15%" height="1"></TD>
															</TR>
															 
															<TR>
																 
																<TD style="HEIGHT: 23px;WIDTH: 200px;" align="right" height="23" colspan="2">
																	<ASP:LABEL id="Label2" runat="server" Width="200px" Font-Bold="True">Account Action EXCEL 附件：</ASP:LABEL></TD>
																<TD style="HEIGHT: 23px;WIDTH: 180px;" align="left" colspan="2" height="23">
                                                                <INPUT id="btnUploadMode2" type="file"  accept="application/msexcel,application/csv" runat="server">
																</TD>
																<TD style="HEIGHT: 23px" align="left" width="5%" height="23">
                                                                	<anthem:LABEL id="lbrfvUpload2" runat="server" Visible="false" ForeColor="Red" style="Width: 60px">*</anthem:LABEL>
                                                                  </TD>
																<TD style="HEIGHT: 23px" align="left" width="25%" height="23">
                                                                <INPUT id="Submit2" style="WIDTH: 48px; HEIGHT: 24px" type="submit"  onclick="return btnSureUploadAction();" value="上傳" name="Submit2"
																		runat="server"></TD>
															</TR>
															<TR bgColor="#edecd1" height="1">
																<TD style="WIDTH: 10px" height="1"></TD>
																<TD align="right" height="1"><FONT face="新細明體"></FONT></TD>
																<TD align="left" colSpan="3" height="1"><FONT face="新細明體">&nbsp;&nbsp;
																		<anthem:LABEL id="lbUploadResult2" runat="server" Visible="False" Width="100%" ForeColor="Red"></anthem:LABEL></FONT></TD>
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
																								<asp:Image id="Image1" runat="server" ImageUrl="resource/indicator.gif"></asp:Image></P>
																						</TD>
																						<TD>
																							<P>
																								<asp:Label id="Label5" runat="server" ForeColor="Red"></asp:Label></P>
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
										 
										</TABLE>
                                    </asp:panel>
             <asp:panel id="plAgentSMS" runat="server" Visible="false"> 
                                    <TABLE class="tan-border02" style="WIDTH: 100%; BORDER-COLLAPSE: collapse; HEIGHT: 100%;vertical-align:top "
											cellSpacing="10"  cellPadding="0" rules="none" align="left" border="0"  >
											<TR>
												<TD style="WIDTH: 10px" height="1"> </TD> 
											</TR>
											<TR  valign ="top" style ="height:100%" >
												<TD style="WIDTH: 10px" height="1"><FONT face="新細明體"></FONT></TD>
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
                                                                        <asp:Label ID="Label3" runat="server" Font-Bold="True" Width="112px">上傳方式 ：</asp:Label>
                                                                    </td>
                                                                    <td align="left" height="1" style="WIDTH: 118px">
                                                                        <anthem:RadioButton ID="RADIOBUTTON3" runat="server" AutoCallBack="True" Checked="True" Text="新增上傳組別的號碼" Width="130px" />
                                                                    </td>
                                                                    <td align="left" height="1">
                                                                        <anthem:RadioButton ID="RADIOBUTTON4" runat="server" AutoCallBack="True" Text="上傳覆蓋組別的號碼" Width="130px" />
                                                                    </td>
                                                                    <td align="left" height="1" width="10%">
                                                                        <anthem:Button ID="BUTTON2" runat="server" Text="上傳" Visible="False" Width="52px" />
                                                                    </td>
                                                                    <td align="left" height="1" width="10%"></td>
                                                                </tr>
                                                                <tr style="display:none">
                                                                    <TD style="HEIGHT: 23px;WIDTH: 200px;" align="right" height="23" colspan="2">
                                                                        <asp:Label ID="Label4" runat="server" Font-Bold="True" Width="200px">Account Action EXCEL 附件：</asp:Label>
                                                                    </td>
                                                                    <td align="left" colspan="2" height="23" style="HEIGHT: 23px;WIDTH: 180px;">
                                                                        <input id="File1" runat="server" accept="application/msexcel,application/csv" type="file">
                                                                        </input>
                                                                    </td>
                                                                    <td align="left" height="23" style="HEIGHT: 23px" width="10%">
                                                                        <anthem:Label ID="LABEL6" runat="server" ForeColor="Red" style="Width: 60px" Visible="false">
                                                                            *</anthem:Label>
                                                                    </td>
                                                                    <td align="left" height="23" style="HEIGHT: 23px" width="10%">
                                                                        <input id="Submit3" runat="server" name="Submit2" style="WIDTH: 48px; HEIGHT: 24px" type="submit" value="上傳">
                                                                        </input>
                                                                    </td>
                                                                </tr>
                                                          	<TR style="display:none">
																<TD style="WIDTH: 10px" height="1"></TD>
																<TD align="right" height="1"><FONT face="新細明體"></FONT></TD>
																<TD align="left" colSpan="3" height="1"></TD>
																<TD align="left" height="1"></TD>
															</TR> 
                                                            <tr style="height:10px"><td></td></tr>
                                                             <tr>
                                                                 <td height="1" style="WIDTH: 10px"></td>
                                                                 <td align="center" height="1">發送號碼 : </td>
                                                                 <td align="left" colspan="3" height="1">
                                                                 <div id="div11">    <anthem:TextBox ID="txtSmsPhone" runat="server" onkeyup="SyncSMSPhone()"  onblur="SyncSMSContent()"  Width="200px"></anthem:TextBox>
                                                                 </div></td>
                                                                </tr> 
                                                                <tr  >
                                                                    <td height="1" style="WIDTH: 10px"> </td>
                                                                    <td align="center" height="1">轉台號碼 : </td>
                                                                    <td align="left" colspan="3" height="1"> <div id="div22"><anthem:TextBox id="txtAgentPhone"  onblur="SyncSMSContent2()"   runat="server"   Width="200px"  ></anthem:TextBox>
                                                                    </div></td> 
                                                                </tr>
                                                             <tr> 
                                                                 <td height="1" style="WIDTH: 10px"> </td>
                                                                    <td align="center" height="1">銷售員名稱 : </td>
                                                                    <td align="left" colspan="3" height="1"> <div id="div3"><anthem:TextBox id="txtSaleName"  onblur="SyncSMSContentSaleName()"   runat="server"   Width="200px"  ></anthem:TextBox>
                                                                    </div></td> </tr>
                                                             <tr>
                                                                  <td height="1" style="WIDTH: 10px"> </td>
                                                                    <td align="center" height="1">銷售員直線 : </td>
                                                                    <td align="left" colspan="3" height="1"> <div id="div4"><anthem:TextBox id="txtSalePhone"  onblur="SyncSMSContentSalePhone()"   runat="server"   Width="200px"  ></anthem:TextBox>
                                                                    </div></td> </tr>
                                                             <tr>
                                                                 <td height="1" style="WIDTH: 10px"></td>
                                                                 <td align="center" height="1">短訊內容 : </td>
                                                                 <td align="left" colspan="3" height="1">
                                                                     <anthem:DropDownList ID="dplAgentSmsNum" runat="server" Width="500px" AutoCallBack="True">
                                                                      </anthem:DropDownList>
                                                                 </td>
                                                                </tr>
                                                             <tr style="height:70px"><td></td></tr>
                                                            <tr>
                                                                <td height="1" style="WIDTH: 10px"></td>
                                                                <td align="center" height="1">  </td>
                                                                <td align="left" colspan="3" height="1">
                                                                    <anthem:TextBox ID="txtAgentSmsContent" runat="server" Width="500px" Height="150px" style="IME-MODE: disabled" TextMode="MultiLine"></anthem:TextBox>
                                                                </td>
                                                                </tr>
                                                              <tr style="height:20px"><td></td></tr>
                                                              <tr>
                                                                <td height="1" style="WIDTH: 10px"></td>
                                                                <td align="center" height="1">  </td>
                                                                <td align="left" colspan="1" height="1">  <anthem:Button ID="btnAgentSend" runat="server" Text="發送"   Width="80px" />
                                                                 </td>
                                                                  <td align="left" height="1">  
                                                                  <anthem:LABEL id="lbAgentSmsResult" runat="server" Visible="true" Width="100%" ForeColor="Red"> </anthem:LABEL>
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
 <asp:panel id="plUploadSmsAgent" runat="server" Visible="false"> 
                                    <TABLE class="tan-border02" style="WIDTH: 100%; BORDER-COLLAPSE: collapse;  HEIGHT: 100%;vertical-align:top "
											cellSpacing="10" cellPadding="0" rules="none" align="left" border="0">
											<TR>
												<TD style="WIDTH: 10px" height="3"> </TD> 
											</TR>
											<TR  valign ="top" style ="height:100%" >
												<TD style="WIDTH: 10px" height="1"><FONT face="新細明體"></FONT></TD>
												<TD align="center" colSpan="3" height="1"><FONT face="新細明體">
														<TABLE id="Table6" borderColor="#edecd1" height="100%" cellSpacing="1" cellPadding="0"
															rules="none" width="80%" align="left" border="1">
														 
																<TD style="WIDTH: 10px" height="1"></TD>
																<TD style="WIDTH: 143px" align="right" height="1"></TD>
																<TD style="WIDTH: 118px" align="left" height="1"></TD>
																<TD align="left" height="1"><FONT face="新細明體">&nbsp;</FONT></TD>
																<TD align="left" width="15%" height="1"></TD>
																<TD align="left" width="15%" height="1"></TD>
															</TR>
															<TR style ="display:none">
																<TD vAlign="baseline" align="left" height="1"></TD>
																<TD align="right" height="1">
																	<ASP:LABEL id="lbAgentUpload" runat="server" Width="112px" Font-Bold="True">上傳方式 
                        ：</ASP:LABEL></TD>
																<TD style="WIDTH: 118px" align="left" height="1">
																	<anthem:RADIOBUTTON id="RADIOBUTTON17" runat="server" Width="130px" Text="新增上傳組別的號碼" AutoCallBack="True"
																		Checked="True"></anthem:RADIOBUTTON></TD>
																<TD align="left" height="1">
																	<anthem:RADIOBUTTON id="RADIOBUTTON27" runat="server" Width="130px" Text="上傳覆蓋組別的號碼" AutoCallBack="True"></anthem:RADIOBUTTON></TD>
																<TD align="left" width="15%" height="1">
																	<anthem:BUTTON id="BUTTON17" runat="server" Visible="False" Width="52px" Text="上傳"></anthem:BUTTON></TD>
																<TD align="left" width="15%" height="1"></TD>
															</TR>
															 
															<TR>
																 
																<TD style="HEIGHT: 23px;WIDTH: 200px;" align="left" height="23" colspan="2">
																	<ASP:LABEL id="Label27" runat="server" Width="200px" Font-Bold="True">Bulk Sms EXCEL 附件：</ASP:LABEL></TD>
																<TD style="HEIGHT: 23px;WIDTH: 180px;" align="left" colspan="2" height="23">
                                                                <INPUT id="btnUploadMode3" type="file"  accept="application/msexcel,application/csv" style ="width :500px" runat="server">
																  <asp:RequiredFieldValidator id="reqbtnUploadMode3" runat="server" ErrorMessage="*" ControlToValidate="btnUploadMode3"></asp:RequiredFieldValidator>

																</TD> 
																<TD style="HEIGHT: 23px" align="right" width="25%" height="23">
                                                                </TD>
															</TR>
															    <tr style="height:10px"><td></td></tr>
															
															            <tr>
                                                                 <td height="1" style="WIDTH: 10px"></td>
                                                                 <td align="center" height="1">短訊內容 : </td>
                                                                 <td align="left" colspan="3" height="1">
                                                                     <anthem:DropDownList ID="dplUploadAgentSmsNum" runat="server" Width="500px" AutoCallBack="True">
                                                                      </anthem:DropDownList>
                                                                 </td>
                                                                </tr>
                                                             <tr style="height:10px"><td></td></tr>
                                                            <tr>
                                                                <td height="1" style="WIDTH: 10px"></td>
                                                                <td align="center" height="1">  </td>
                                                                <td align="left" colspan="2" height="1">
                                                                    <anthem:TextBox ID="txtUploadAgentSmsContent" runat="server" Width="500px" Height="150px" style="IME-MODE: disabled" TextMode="MultiLine"></anthem:TextBox>
                                                                	<anthem:LABEL id="lbrfvUpload3" runat="server" Visible="false" ForeColor="Red" style="Width: 60px">*</anthem:LABEL>
                                                                 </td>
                                                                   <td valign="bottom" align="center"> <INPUT id="subUploadAgentSms" onclick="return btnSure();"  style="WIDTH: 60px; HEIGHT: 24px" type="submit" value="發送" name="Submit3"
																		runat="server"></td>
                                                                </tr>
                                                                 <tr style="height:10px"><td></td></tr>
															<TR bgColor="#edecd1" height="1">
																<TD style="WIDTH: 10px" height="1"></TD>
																<TD align="right" height="1"><FONT face="新細明體"></FONT></TD>
																<TD align="left" colSpan="3" height="1"><FONT face="新細明體">&nbsp;&nbsp;
																		<anthem:LABEL id="lbUploadResult3" runat="server" Visible="False" Width="100%" ForeColor="Red"></anthem:LABEL></FONT></TD>
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
																								<asp:Image id="Image17" runat="server" ImageUrl="resource/indicator.gif"></asp:Image></P>
																						</TD>
																						<TD>
																							<P>
																								<asp:Label id="Label57" runat="server" ForeColor="Red"></asp:Label></P>
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
