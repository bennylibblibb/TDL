<%@ Control Language="c#" AutoEventWireup="false" Codebehind="SignIn.ascx.cs" Inherits="CENTASMS.UserControl.SignIn" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="anthem" Namespace="Anthem" Assembly="Anthem" %>
<table cellSpacing="0" cellPadding="0" border="0" style="height: 300px; width: 363px">
	<TR>
		<TD colSpan="2"  style ="vertical-align:top" > 
             <anthem:RadioButtonList id="rbLanguages" width="220px"    runat="server" Font-Size="Medium" Font-Bold="True"  AutoPostBack="true"   RepeatDirection="Horizontal">
                  <asp:ListItem Value ="zh" Selected ="True">中文</asp:ListItem> <asp:ListItem Value ="en">English</asp:ListItem>
            </anthem:RadioButtonList> 
		</TD>
	</TR>
	<TR    >
		<TD  > </TD>
		<TD   > <Anthem:checkbox id="rcLanguage" width="100px"  Text="English" runat="server" Font-Size="Medium" Font-Bold="True"   AutoPostBack="true" Visible="False"  /></TD>
	</TR>
	<tr   >
		<TD > </TD>
		<td ><span class="header-gray"  >
            <asp:Label  id="lbUserInfo" runat="server" cssclass="chrome-lable" width="200px" Font-Size="Medium"  >用戶登錄</asp:Label></span> 
            </td>
	</tr>
	<tr>
		<TD></TD>
		<td >
			<span>
            <br />
            <asp:Label  id="lbUserInfoID" runat="server" cssclass="chrome-lable" width="200px" Font-Size="Small" >用戶 ID:</asp:Label>  </span>
			<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="UserID"></asp:RequiredFieldValidator>
		</td>
	</tr>
	<tr>
		<TD> </TD>
		<td   >
			<asp:TextBox id="UserID" columns="9" width="200px" cssclass="safari-midtextbox" runat="server"></asp:TextBox>
		</td>
	</tr>
	<tr>
		<TD></TD>
		<td  ><span class="font-size: 16px;">
            <br />
            <asp:Label   id="lbUserInfoPwd"  runat="server" cssclass="chrome-lable" width="100px" Font-Size="Small"  > 密碼:</asp:Label>   </span>
			<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="Password"></asp:RequiredFieldValidator>
		</td>
	</tr>
	<tr>
		<TD></TD>
		<td  >
			<asp:TextBox id="Password" columns="9" width="200px" textmode="password" cssclass="safari-midtextbox"
				runat="server"></asp:TextBox>
		</td>
	</tr>
	<TR>
		<TD></TD>
		<TD style =" vertical-align:bottom"><STRONG> <asp:Label  id="lbValidateCode" runat="server" cssclass="chrome-lable" width="200px" Font-Size="Small" >驗證碼:</asp:Label></STRONG>
		</TD>
	</TR>
	<TR>
		<TD></TD>
		<TD style ="vertical-align:bottom">
			<asp:TextBox   id="txtValidate" runat="server" width="60px" cssclass="safari-midtextbox" columns="9"></asp:TextBox>&nbsp;&nbsp;
			<IMG id='vimg'  src="CheckCode.aspx" alt='"Click To Refresh"' OnClick="change()"  style="vertical-align:bottom">&nbsp;&nbsp;
			<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ControlToValidate="txtValidate" ErrorMessage="*"></asp:RequiredFieldValidator>
		</TD>
	</TR>
	<tr>
		<TD>
		</TD>
		<td > 
			<br>
			<asp:checkbox id="RememberCheckbox"   Text="在這部電腦上記住" runat="server"  Font-Size="Small"  /></td>
	</tr>
	<tr>
		<TD>
		</TD>
		<td  >
			<br>
			<asp:Button id="BtnSignin" runat="server" Text="登入" Width="78"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			<INPUT id="btnCCannel" style="WIDTH:78px" onclick="Clear()" type="button" value="重置"  runat="server" name="btnCCannel">
			<br>
		</td>
	</tr>
	<TR>
		<TD></TD>
		<TD >
			<asp:label   id="Message" runat="server" Width="280px" ForeColor="Red" Height="30px"></asp:label></TD>
	</TR>
	<TR>
		<TD   ></TD>
		<TD></TD>
	</TR>
</table>
