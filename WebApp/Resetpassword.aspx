<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Resetpassword.aspx.cs" Inherits="WebApp.Resetpassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #form1 {
            width: 295px;
            height: 176px;
        }
    </style>
</head>
<body style="width: 303px; height: 172px;">
    <form id="form1" runat="server" style="background:#66ccff;padding-left:10px">
        <div style="color:red; font-size:18px">
            Změna hesla uživatele<br />
            <br />
            </div>
        <div>
            Email:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </div>
        Nové heslo:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        Nové heslo znovu:<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Obnovit" OnClick="Button1_Click" />
 
        <br />
        </div>
  
    </form>
</body>
</html>
