﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentLogin.aspx.cs" Inherits="ABedirUniversity.WebForms.StudentLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no" />
    <link rel="shortcut icon" href="/Images/capIcon.ico" />
    <title>ABU | Login</title>
    <link href="https://fonts.googleapis.com/css?family=Lexend+Deca|Lexend+Zetta&display=swap" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="/CSS/MainStyle.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/bootstrap.min.css" />
    <script src="/JavaScript/jquery-3.4.1.min.js"></script>
    <script src="/JavaScript/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
            <a class="navbar-brand" href="/default.htm">ABU</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarNav">
                <ul class="navbar-nav">
                    <li class="nav-item">
                        <a class="nav-link" href="AdminLogin.aspx">Admin Portal</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="StudentLogin.aspx">Student Portal</a>
                    </li>
                </ul>
            </div>
        </nav>
        <div class="p-4">
            <h1 class="text-center">Login to student portal</h1>
        </div>

        <div class="loginWidth center">
            <div class="form-group">
                <input runat="server" type="text" class="form-control" id="usernameInput" aria-describedby="emailHelp" placeholder="Username" />
            </div>
            <div class="form-group">
                <input runat="server" type="password" class="form-control" id="passwordInput" placeholder="Password" />
            </div>
            <div class="mb-2">Not Enrolled? Apply <a href="StudentApplicationForm.aspx">Here</a></div>
            <asp:Button runat="server" ID="LoginSubmitBtn" OnClick="LoginSubmitBtn_Click" type="submit" class="btn btn-primary" Text="Submit" />
        </div>
    </form>
</body>
</html>
