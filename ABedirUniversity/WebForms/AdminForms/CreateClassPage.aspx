<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateClassPage.aspx.cs" Inherits="ABedirUniversity.WebForms.AdminForms.CreateClassPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no" />
    <link rel="shortcut icon" href="/Images/capIcon.ico" />
    <title>ABU | Create Class</title>
    <link href="https://fonts.googleapis.com/css?family=Lexend+Deca|Lexend+Zetta&display=swap" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="/CSS/MainStyle.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/bootstrap.min.css" />
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
                    <a class="nav-link" href="ActiveStudentsList.aspx">Active Students</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="StudentApplicationList.aspx">Student Applications</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="ClassList.aspx">Class List</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="CreateClassPage.aspx">Create New Class</a>
                </li>
            </ul>
        </div>
    </nav>
    <form id="form1" runat="server">
        <div class="loadingScreen"></div>
        <asp:Panel runat="server" ID="CreateClassFields" CssClass="p-4">
            <h2>Create Class</h2>
            <hr />
            <div class="form-row">
                <div class="form-group col-md-6 col-sm-12">
                    <label for="InputClassName">Class Name</label>
                    <input runat="server" type="text" class="form-control" id="InputClassName" placeholder="Class Name" required="required" />
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-6 col-sm-12">
                    <label for="InputClassDescription">Class Description</label>
                    <textarea runat="server" type="text" class="form-control" id="InputClassDescription" placeholder="Class Description" required="required"></textarea>
                </div>
            </div>
            <asp:Label runat="server" ID="ErrorLabel" CssClass="ErrorMsg" Visible="false" />
            <br />
            <asp:Button ID="CreateClassBtn" runat="server" type="submit" CssClass="btn btn-primary" Text="Create" OnClick="CreateClassBtn_Click"></asp:Button>
        </asp:Panel>
        <asp:Panel runat="server" ID="SuccessPanel" CssClass="p-4" Visible="false">
            <h2>Created Class ID is</h2>
            <asp:Label runat="server" ID="DisplayClassID" CssClass="h2"></asp:Label>
        </asp:Panel>
    </form>
</body>
</html>
