<%@ Control Language="c#" AutoEventWireup="false" Codebehind="SignIn.ascx.cs" Inherits="CENTASMS.UserControl.SignIn" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="anthem" Namespace="Anthem" Assembly="Anthem" %>
<table cellSpacing="0" cellPadding="0" border="0" style="height: 250px; width: 100px">
	<TR>
		<TD colSpan="2"  style="HEIGHT:30px"> 
            <Anthem:checkbox id="rcLanguage" width="100px"  Text="English" runat="server" Font-Size="Medium" Font-Bold="True"   AutoPostBack="true"  /></TD>
	</TR>
	<TR >
		<TD style="HEIGHT:20px"></TD>
		<TD></TD>
	</TR>
	<tr >
		<TD> </TD>
		<td><span class="header-gray" style="HEIGHT:30px">
            <asp:Label  id="lbUserInfo" runat="server" cssclass="chrome-lable" width="200px" Font-Size="Medium"  >�Τ�n��</asp:Label></span> 
            </td>
	</tr>
	<tr>
		<TD></TD>
		<td style="HEIGHT:20px">
			<span>
            <br />
            <asp:Label  id="lbUserInfoID" runat="server" cssclass="chrome-lable" width="200px" Font-Size="Small" >�Τ� ID:</asp:Label>  </span>
			<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="UserID"></asp:RequiredFieldValidator>
		</td>
	</tr>
	<tr>
		<TD> </TD>
		<td  style="HEIGHT:20px">
			<asp:TextBox id="UserID" columns="9" width="200px" cssclass="safari-midtextbox" runat="server"></asp:TextBox>
		</td>
	</tr>
	<tr>
		<TD></TD>
		<td style="HEIGHT:20px"><span class="font-size: 16px;">
            <br />
            <asp:Label   id="lbUserInfoPwd"  runat="server" cssclass="chrome-lable" width="100px" Font-Size="Small"  > �K�X:</asp:Label>   </span>
			<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="Password"></asp:RequiredFieldValidator>
		</td>
	</tr>
	<tr>
		<TD></TD>
		<td style="HEIGHT:20px">
			<asp:TextBox id="Password" columns="9" width="200px" textmode="password" cssclass="safari-midtextbox"
				runat="server"></asp:TextBox>
		</td>
	</tr>
	<TR>
		<TD></TD>
		<TD style ="height:30px;vertical-align:bottom"><STRONG> <asp:Label  id="lbValidateCode" runat="server" cssclass="chrome-lable" width="200px" Font-Size="Small" >���ҽX:</asp:Label></STRONG>
		</TD>
	</TR>
	<TR>
		<TD></TD>
		<TD style ="height:20px;vertical-align:bottom">
			<asp:TextBox   id="txtValidate" runat="server" width="60px" cssclass="safari-midtextbox" columns="9"></asp:TextBox>&nbsp;&nbsp;
			<IMG id='vimg'  src="CheckCode.aspx" alt='"Click To Refresh"' OnClick="change()"  style="vertical-align:bottom">&nbsp;&nbsp;
			<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ControlToValidate="txtValidate" ErrorMessage="*"></asp:RequiredFieldValidator>
		</TD>
	</TR>
	<tr>
		<TD>
		</TD>
		<td style="HEIGHT:20px"> 
			<br>
			<asp:checkbox id="RememberCheckbox"   Text="�b�o���q���W�O��" runat="server"  Font-Size="Small"  /></td>
	</tr>
	<tr>
		<TD>
		</TD>
		<td style="HEIGHT:20px">
			<br>
			<asp:Button id="BtnSignin" runat="server" Text="�n�J" Width="78"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			<INPUT id="btnCCannel" style="WIDTH:78px" onclick="Clear()" type="button" value="���m"  runat="server" name="btnCCannel">
			<br>
		</td>
	</tr>
	<TR>
		<TD></TD>
		<TD style="HEIGHT:20px">
			<asp:label   id="Message" runat="server" Width="280px" ForeColor="Red" Height="30px"></asp:label></TD>
	</TR>
	<TR>
		<TD  style="HEIGHT:20px"></TD>
		<TD></TD>
	</TR>
</table>
