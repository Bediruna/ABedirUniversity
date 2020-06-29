<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddClassPage.aspx.cs" Inherits="ABedirUniversity.WebForms.StudentForms.AddClassPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no" />
    <link rel="shortcut icon" href="/Images/capIcon.ico" />
    <title>ABU | Add Class</title>
    <link href="https://fonts.googleapis.com/css?family=Lexend+Deca|Lexend+Zetta&display=swap" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="/CSS/MainStyle.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/GridStyling.css" />
    <script src="/JavaScript/jquery-3.4.1.min.js"></script>
    <script src="/JavaScript/jquery.mask.js"></script>
    <script src="/JavaScript/bootstrap.min.js"></script>
    <script src="/JavaScript/MainScript.js"></script>
</head>
<body>
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
        <a class="navbar-brand" href="/default.htm">ABU</a>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarNav">
            <ul class="navbar-nav">
                <li class="nav-item">
                    <a class="nav-link" href="TermList.aspx">Terms</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="AddTermPage.aspx">Add Term</a>
                </li>
            </ul>
        </div>
    </nav>
    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="hiddenTermID" />
        <div class="loadingScreen"></div>
        <div class="p-4">            
            <h2>Select class to add to term</h2>
            <hr />
            <asp:GridView runat="server" ID="ClassesGridView" OnRowDataBound="ClassesGridView_RowDataBound"></asp:GridView>
        </div>
    </form>
</body>
</html>
