<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApp.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #form1 {
            height: 146px;
            width: 314px;
            margin-left: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" style="background:#66ccff">
        <div id´="obsha" style="padding-left:10px; width: 286px;">
            <div id="lognad" style="color:red;font-size:18px">
            Přihlášení<br />
        </div>
                    <br />
            Login: <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
        Heslo: <asp:TextBox ID="TextBox2" runat="server" Width="118px"></asp:TextBox>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Příhlásit" OnClick="Button1_Click" />
        &nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" Text="Reset hesla" OnClick="Button2_Click" />
        </p>
            </div>
    </form>
    <p>
&nbsp;&nbsp;&nbsp;
    </p>
</body>
</html>
