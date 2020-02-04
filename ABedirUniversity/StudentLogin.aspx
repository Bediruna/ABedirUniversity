<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentLogin.aspx.cs" Inherits="ABedirUniversity.StudentLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ABU | Login</title>
    <link href="https://fonts.googleapis.com/css?family=Lexend+Deca|Lexend+Zetta&display=swap" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="CSS/MainStyle.css" />
    <link rel="stylesheet" type="text/css" href="CSS/bootstrap.min.css" />
    <script src="JavaScript/jquery-3.4.1.min.js"></script>
    <script src="JavaScript/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
            <a class="navbar-brand" href="HomePage.aspx">ABU</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarNav">
                <ul class="navbar-nav">
                    <li class="nav-item">
                        <a class="nav-link" href="#">About Us</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#">Admin Portal</a>
                    </li>
                    <li class="nav-item active">
                        <a class="nav-link" href="StudentLogin.aspx">Student Portal <span class="sr-only">(current)</span></a>
                    </li>
                </ul>
            </div>
        </nav>

        <h1 class="text-center mb-5">Login to student portal</h1>

        <div class="center">
            <div class="form-group">
                <input type="text" class="form-control" id="usernameInput" aria-describedby="emailHelp" placeholder="Username" />
            </div>
            <div class="form-group">
                <input type="password" class="form-control" id="passwordInput" placeholder="Password" />
            </div>
            <div>Not Enrolled? Apply <a href="StudentApplication.aspx">Here</a></div>
            <button type="submit" class="btn btn-primary">Submit</button>
        </div>
    </form>
</body>
</html>
