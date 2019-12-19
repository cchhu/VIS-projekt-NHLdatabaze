<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Players.aspx.cs" Inherits="WebApp.Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #form1 {
        }
    </style>
</head>
<body style="height: 305px; width: 547px">
    <form id="form1" runat="server" style="background:#66ccff">
        <div id="obsah" style="padding-left:10px; width: 529px; height: 308px;">
        <br />
            Vyber tým ze seznamu:<asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <br />
            Hráči v týmu<br />
            <asp:ListBox ID="ListBox1" runat="server" Height="150px" Width="338px" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged"></asp:ListBox>
            <br />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Vyhledat hráče" />
            </div>
    </form>
</body>
</html>
