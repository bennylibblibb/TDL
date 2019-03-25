<%@ Page language="c#" Codebehind="test.aspx.cs" AutoEventWireup="false" Inherits="CENTASMS.WebForm1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body style="WIDTH: 500px; HEIGHT: 258px" MS_POSITIONING="GridLayout">
		<form id="fmInput" method="post" runat="server">
			<hr align="center" width="400">
			<table class="admin-tan-border" id="tablea" style="WIDTH: 384px; HEIGHT: 123px" cellSpacing="0"
				cellPadding="0" align="center" border="0">
				<tr>
					<td style="HEIGHT: 121px">
						<table style="WIDTH: 327px; HEIGHT: 79px" cellSpacing="0" cellPadding="0" align="center"
							border="0">
							<tr>
								<FONT face="新細明體"></FONT>
							</tr>
							<tr>
							</tr>
							<tr>
								<td style="WIDTH: 68px" align="right"><STRONG>日期:</STRONG></td>
								<td style="WIDTH: 104px"><STRONG></STRONG></td>
								<td style="WIDTH: 69px" align="right"><FONT face="新細明體"><STRONG>時間:</STRONG></FONT></td>
								<td><FONT face="新細明體"></FONT></td>
							</tr>
							<TR>
								<TD style="WIDTH: 68px" align="right"><FONT face="新細明體"><FONT face="Verdana"><STRONG>&nbsp;</STRONG></FONT></FONT></TD>
								<TD style="WIDTH: 104px" colSpan="3"><FONT face="新細明體"></FONT></TD>
							</TR>
							<TR>
							</TR>
							<tr>
								<td style="WIDTH: 68px"><FONT face="新細明體"></FONT></td>
								<td style="WIDTH: 104px"><FONT face="新細明體"></FONT></td>
								<td style="WIDTH: 69px" align="right"><FONT face="新細明體"></FONT></td>
								<TD align="left"><FONT face="新細明體"></FONT></TD>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<ajax:panel id="plMsgData" runat="server" Visible="false"></ajax:panel>
			<TABLE style="WIDTH: 98%; BORDER-COLLAPSE: collapse; HEIGHT: 380px" borderColor="#edecd1"
				cellSpacing="0" cellPadding="0" rules="none" align="left" border="2">
				<TR vAlign="middle" width="100%">
					<TD vAlign="baseline" align="left" height="1">
						<P><STRONG>即時發送記錄：</STRONG></P>
					</TD>
					<TD align="left" height="1">用戶：
						<AJAX:DROPDOWNLIST id="dplUsers" runat="server" Width="80px"></AJAX:DROPDOWNLIST>
						<ASP:LISTITEM Selected="True" Value="All">All</ASP:LISTITEM>
						</AJAX:DROPDOWNLIST></TD>
					<TD align="left" height="1">日期從：
						<asp:TextBox id="txtStartDate" onclick="fPopUpDlg('CalendarUtrl/calendar.htm', document.fmSms.txtStartDate, 'winpop', 234, 261);return false"
							runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
						<asp:RequiredFieldValidator id="rfv" runat="server" ControlToValidate="dplUsers" ErrorMessage="*"></asp:RequiredFieldValidator></TD>
					<TD align="left" height="1">到：
						<asp:TextBox id="txtEndDate" onclick="fPopUpDlg('CalendarUtrl/calendar.htm', document.fmSms.txtEndDate, 'winpop', 234, 261);return false"
							runat="server" Width="80px" ReadOnly="True"></asp:TextBox></TD>
					<TD align="left" width="15%" height="1"><FONT face="新細明體">
							<AJAX:BUTTON id="btnSearch" runat="server" Text="查詢"></AJAX:BUTTON></AJAX:BUTTON></FONT></TD>
				<TR>
					<TD vAlign="baseline" align="left" height="1"></TD>
					<TD align="left" height="1"></TD>
					<TD align="left" height="1"></TD>
					<TD align="left" height="1"></TD>
					<TD align="left" width="15%" height="1"></TD>
				</TR>
				<TR width="100%">
					<TD vAlign="top" align="left" width="50%" colSpan="5" height="256">
						<AJAX:DATAGRID id="dgSmsData" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True"></AJAX:DATAGRID><PAGERSTYLE Mode="NumericPages"></PAGERSTYLE><HEADERSTYLE Font-Bold="True"></HEADERSTYLE><COLUMNS>
							<ASP:TEMPLATECOLUMN HeaderText="ID">
								<HEADERSTYLE VerticalAlign="Middle" CssClass="grid-header" Wrap="false" HorizontalAlign="Left"></HEADERSTYLE>
								<ITEMSTYLE CssClass="grid-item"></ITEMSTYLE>
								<ITEMTEMPLATE>
									<%#this.dgSmsData.CurrentPageIndex * this.dgSmsData.PageSize + Container.ItemIndex + 1%>
								</ITEMTEMPLATE>
							</ASP:TEMPLATECOLUMN>
							<ASP:TEMPLATECOLUMN HeaderText="CBATCHID">
								<HEADERSTYLE VerticalAlign="Middle" CssClass="grid-header" Wrap="false" HorizontalAlign="Left"></HEADERSTYLE>
								<ITEMSTYLE CssClass="grid-item"></ITEMSTYLE>
								<ITEMTEMPLATE>
									<%# DataBinder.Eval(Container, "DataItem.CBATCHID")%>
								</ITEMTEMPLATE>
							</ASP:TEMPLATECOLUMN>
							<ASP:TEMPLATECOLUMN HeaderText="發送用戶">
								<HEADERSTYLE VerticalAlign="Middle" CssClass="grid-header" Wrap="false" HorizontalAlign="Left"></HEADERSTYLE>
								<ITEMSTYLE CssClass="grid-item"></ITEMSTYLE>
								<ITEMTEMPLATE>
									<%# DataBinder.Eval(Container, "DataItem.CSENDER")%>
								</ITEMTEMPLATE>
							</ASP:TEMPLATECOLUMN>
							<ASP:TEMPLATECOLUMN HeaderText="短訊內容">
								<HEADERSTYLE VerticalAlign="Middle" CssClass="grid-header" Wrap="false" HorizontalAlign="Left"></HEADERSTYLE>
								<ITEMSTYLE CssClass="grid-item"></ITEMSTYLE>
								<ITEMTEMPLATE>
									<%# DataBinder.Eval(Container, "DataItem.CSMSMSG")%>
								</ITEMTEMPLATE>
							</ASP:TEMPLATECOLUMN>
							<ASP:TEMPLATECOLUMN HeaderText="字符數">
								<HEADERSTYLE VerticalAlign="Middle" CssClass="grid-header" Wrap="false" HorizontalAlign="Left"></HEADERSTYLE>
								<ITEMSTYLE CssClass="grid-item"></ITEMSTYLE>
								<ITEMTEMPLATE>
									<%# DataBinder.Eval(Container, "DataItem.IMSGLEN")%>
								</ITEMTEMPLATE>
							</ASP:TEMPLATECOLUMN>
							<ASP:TEMPLATECOLUMN HeaderText="分段數">
								<HEADERSTYLE VerticalAlign="Middle" CssClass="grid-header" Wrap="false" HorizontalAlign="Left"></HEADERSTYLE>
								<ITEMSTYLE CssClass="grid-item"></ITEMSTYLE>
								<ITEMTEMPLATE>
									<%# DataBinder.Eval(Container, "DataItem.ISMSMSGNO")%>
								</ITEMTEMPLATE>
							</ASP:TEMPLATECOLUMN>
							<ASP:TEMPLATECOLUMN HeaderText="號碼數">
								<HEADERSTYLE VerticalAlign="Middle" CssClass="grid-header" Wrap="false" HorizontalAlign="Left"></HEADERSTYLE>
								<ITEMSTYLE CssClass="grid-item"></ITEMSTYLE>
								<ITEMTEMPLATE>
									<%# DataBinder.Eval(Container, "DataItem.IMOBILETOTAL")%>
								</ITEMTEMPLATE>
							</ASP:TEMPLATECOLUMN>
							<ASP:TEMPLATECOLUMN HeaderText="發送日期">
								<HEADERSTYLE VerticalAlign="Middle" CssClass="grid-header" Wrap="False" HorizontalAlign="Left"></HEADERSTYLE>
								<ITEMSTYLE CssClass="grid-item"></ITEMSTYLE>
								<ITEMTEMPLATE>
								<a title=" Edit  "  target=_blank style  class="blacklineheight" href='MemberofSent.aspx?ID=<%# DataBinder.Eval(Container, "DataItem.CBATCHID") %> '>
																		<%#this.dgSmsData.CurrentPageIndex * this.dgSmsData.PageSize + Container.ItemIndex + 1%>
																	</a></ITEMTEMPLATE>
							</ASP:TEMPLATECOLUMN>
						</COLUMNS></AJAX:DATAGRID></TD>
				</TR>
				<TR width="100%">
					<TD colSpan="5"></TD>
				</TR>
			</TABLE>
			</AJAX:PANEL>
			<HR align="center" width="400">
			<asp:datagrid id="DataGrid2" style="Z-INDEX: 101; LEFT: 480px; POSITION: absolute; TOP: 272px"
				runat="server" AutoGenerateColumns="False">
				<EditItemStyle Width="120px"></EditItemStyle>
				<ItemStyle Width="600px"></ItemStyle>
				<Columns>
					<asp:TemplateColumn HeaderText="ID">
						<HeaderStyle HorizontalAlign="Left" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
						<ItemStyle Width="40px" CssClass="grid-item"></ItemStyle>
						<ItemTemplate>
							<%#this.dgData.CurrentPageIndex * this.dgData.PageSize + Container.ItemIndex + 1%>
							<FONT face="新細明體"></FONT>
						</ItemTemplate>
						<EditItemTemplate>
							<EditItemStyle Width="120px"></EditItemStyle>
							<FONT face="新細明體"></FONT>
						</EditItemTemplate>
					</asp:TemplateColumn>
					<asp:EditCommandColumn ItemStyle-Width="80px"  ItemStyle-Font-Bold="True" ButtonType="LinkButton" UpdateText="更新" CancelText="取消" EditText="編輯"></asp:EditCommandColumn>
					<asp:ButtonColumn Text="刪除" ItemStyle-Font-Bold="True" CommandName="Delete"></asp:ButtonColumn>
				</Columns>
			</asp:datagrid>
			<DIV style="Z-INDEX: 102; LEFT: 128px; WIDTH: 684px; POSITION: absolute; TOP: 264px; HEIGHT: 256px"
				ms_positioning="FlowLayout">function ConfirmSendontime() { if (confirm("Are you 
				sure?")) { //<% strsure="Y"; %>
				; alert('y') return true; } else { alert('n') //<% strsure="N" ;%>; return 
				false; } }
			</DIV>
			<DIV style="Z-INDEX: 103; LEFT: 8px; POSITION: absolute; TOP: 8px" ms_positioning="text2D">&nbsp;function 
				ConfirmSendontime() { if (confirm("Are you sure?")) { //<% strsure="Y"; %>
				; // alert('y'); return true; } else { // alert('n') ; //<% strsure="N" ;%>; 
				return false; } } function ConfirmSend() { if( 
				document.getElementById("txtSmsContent").value 
				==""||document.getElementById("tbNum").value =="") { } else { if (confirm("Are 
				you sure?")) { alert('s'); document.getElementById("hiSure").innerHTML="Y"; 
				alert('sure'); }else { alert('n'); hiSure.value ="N"; alert('no'); } } }</DIV>
		</form>
	</body>
</HTML>
