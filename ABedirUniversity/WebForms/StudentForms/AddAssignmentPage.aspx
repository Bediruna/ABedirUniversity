<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddAssignmentPage.aspx.cs" Inherits="ABedirUniversity.WebForms.StudentForms.AddAssignmentPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no" />
    <link rel="shortcut icon" href="/Images/capIcon.ico" />
    <title>ABU | Add Assignment</title>
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
        <asp:HiddenField runat="server" ID="hiddenClassID" />
        <div class="loadingScreen"></div>
        <asp:Panel runat="server" ID="AddAssignmentFields" CssClass="p-4">
            <h2>Add Assignment</h2>
            <hr />
            <div class="form-row">
                <div class="form-group col-md-6 col-sm-12">
                    <label for="InputAssignmentName">Assignment Name</label>
                    <input runat="server" type="text" class="form-control" id="InputAssignmentName" placeholder="Assignment Name" required="required" />
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-6 col-sm-12">
                    <label for="SelectAssignmentType">Assignment Type</label>
                    <select runat="server" class="form-control" id="SelectAssignmentType" name="SelectAssignmentType" placeholder="Assignment Type" required="required" >
                        <option></option>
                        <option value="Objective Assessment">Objective Assessment</option>
                        <option value="Performance Assessment">Performance Assessment</option>
                    </select>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-6 col-sm-12">
                    <label for="InputAssignmentDescription">Assignment Description</label>
                    <textarea runat="server" type="text" class="form-control" id="InputAssignmentDescription" placeholder="Assignment Description" required="required"></textarea>
                </div>
            </div>
            <asp:Label runat="server" ID="ErrorLabel" CssClass="ErrorMsg" Visible="false" />
            <br />
            <asp:Button ID="AddAssignmentBtn" runat="server" type="submit" CssClass="btn btn-primary" Text="Add Term" OnClick="AddAssignmentBtn_Click"></asp:Button>
        </asp:Panel>
    </form>
</body>
</html>
