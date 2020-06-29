<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddTermPage.aspx.cs" Inherits="ABedirUniversity.WebForms.StudentForms.AddTermPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no" />
    <link rel="shortcut icon" href="/Images/capIcon.ico" />
    <title>ABU | Add Term</title>
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
                    <a class="nav-link" href="TermList.aspx">Terms</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="AddTermPage.aspx">Add Term</a>
                </li>
            </ul>
        </div>
    </nav>
    <form id="form1" runat="server">
        <div class="loadingScreen"></div>
        <asp:Panel runat="server" ID="CreateTermFields" CssClass="p-4">
            <h2>Create Term</h2>
            <hr />
            <div class="form-row">
                <div class="form-group col-md-6 col-sm-12">
                    <label for="InputTermName">Term Name</label>
                    <input runat="server" type="text" class="form-control" id="InputTermName" placeholder="Term Name" required="required" />
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-6 col-sm-12">
                    <label for="InputStartDate">Start Date</label>
                    <input runat="server" type="date" class="form-control" id="InputStartDate" name="InputStartDate" placeholder="Start Date" required="required" />
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-6 col-sm-12">
                    <label for="InputEndDate">End Date</label>
                    <input runat="server" type="date" class="form-control" id="InputEndDate" name="InputEndDate" placeholder="End Date" required="required" />
                </div>
            </div>
            <asp:Label runat="server" ID="ErrorLabel" CssClass="ErrorMsg" Visible="false" />
            <br />
            <asp:Button ID="AddTermBtn" runat="server" type="submit" CssClass="btn btn-primary" Text="Add Term" OnClick="AddTermBtn_Click"></asp:Button>
        </asp:Panel>
    </form>
</body>
</html>
