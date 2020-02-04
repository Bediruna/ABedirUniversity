<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplicationsView.aspx.cs" Inherits="ABedirUniversity.ApplicationsView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="CSS/MainStyle.css"/>
    <style>
        #ApplicationsGridView{

        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="ApplicationsGridView" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
