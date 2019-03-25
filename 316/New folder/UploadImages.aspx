<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadImages.aspx.cs" Inherits="CSLMMMS.UploadImages" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Upload Images</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table >
    <tr>
    <td> 
        <asp:Label  ID="lbID" runat="server">   </asp:Label>
    </td>
    </tr>
    <tr style ="height :20px"><td>
    </td></tr>
      <tr>
      <td>
          <asp:Image ID="igUpload" runat="server" /> </td>
    </tr>
    </table>
    </div>
    </form>
</body>
</html>
