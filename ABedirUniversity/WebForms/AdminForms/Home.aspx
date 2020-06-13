<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ABedirUniversity.WebForms.AdminForms.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no" />
    <link rel="shortcut icon" href="/Images/capIcon.ico" />
    <title>ABU | Admin Home</title>
    <link href="https://fonts.googleapis.com/css?family=Lexend+Deca|Lexend+Zetta&display=swap" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="/CSS/MainStyle.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/bootstrap.min.css" />
    <script src="/JavaScript/jquery-3.4.1.min.js"></script>
    <script src="/JavaScript/jquery.mask.js"></script>
    <script src="/JavaScript/bootstrap.min.js"></script>
    <style>
        .box {
            border-radius: 10px;
            border: 1px solid black;
            min-height: 400px;
        }

        .boxHeader {
            border-top-left-radius: 8px;
            border-top-right-radius: 8px;
            width: 100%;
            height: 50px;
            font-size: 28px;
            background-color: #4287f5;
            padding: 5px 15px;
            color: white;
        }

        #UsernameLabel {
            font-size: 2em;
        }

        table {
            width: 100%;
            border-collapse: collapse;
        }

        tr {
            cursor: pointer;
        }

            tr:hover {
                background-color: cornflowerblue !important;
            }
            /* Alternating shading */
            tr:nth-of-type(odd) {
                background: #eee;
            }

        th {
            background: #333;
            color: white;
            font-weight: bold;
        }

        td, th {
            padding: 6px;
            border: 1px solid #ccc;
            text-align: left;
            word-wrap: break-word;
        }
    </style>
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
        <div class="p-4">
            <div style="text-align: center">
                <asp:Label runat="server" ID="UsernameLabel"></asp:Label>
            </div>
            <div class="container">
                <div class="row">
                    <div class="col-md pt-4">
                        <div class="box">
                            <div class="boxHeader">New Applications</div>
                            <asp:GridView runat="server" ID="NewApplicationsGridView" OnRowDataBound="NewApplicationsGridView_RowDataBound"></asp:GridView>
                        </div>
                    </div>
                    <%--<div class="col-md pt-4">
                        <div class="box">
                            <div class="boxHeader">Class List</div>
                        </div>
                    </div>--%>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
