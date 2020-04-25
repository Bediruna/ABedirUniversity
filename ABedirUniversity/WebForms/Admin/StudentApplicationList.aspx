<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentApplicationList.aspx.cs" Inherits="ABedirUniversity.WebForms.Admin.StudentApplicationList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no" />
    <link rel="shortcut icon" href="/Images/capIcon.ico" />
    <title>ABU | Applications</title>
    <link href="https://fonts.googleapis.com/css?family=Lexend+Deca|Lexend+Zetta&display=swap" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="/CSS/MainStyle.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/bootstrap.min.css" />
    <script src="/JavaScript/jquery-3.4.1.min.js"></script>
    <script src="/JavaScript/jquery.mask.js"></script>
    <script src="/JavaScript/bootstrap.min.js"></script>
    <style>
        .main {
            padding: 100px;
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

        @media only screen and (max-width: 760px), (min-device-width: 768px) and (max-device-width: 1100px) {

            /* Force table to not be like tables anymore */
            table, thead, tbody, th, td, tr {
                display: block;
            }

                /* Hide table headers (but not display: none;, for accessibility) */
                thead tr {
                    position: absolute;
                    top: -9999px;
                    left: -9999px;
                }

            tr {
                /*margin: 0 0 1rem 0;*/
                border-bottom: 6px solid #888;
            }

                tr:first-child {
                    display: none;
                }

                tr:last-child {
                    border-bottom: none;
                }

                tr:nth-child(odd) {
                    background: #ccc;
                }

            td {
                /* Behave  like a "row" */
                border: none;
                border-bottom: 1px solid #eee;
                position: relative;
                padding-left: 50%;
            }

                td:last-child {
                    border-bottom: none;
                }

                td:before {
                    /* Now like a table header */
                    position: absolute;
                    left: 5px;
                    width: 45%;
                    padding-right: 10px;
                    white-space: nowrap;
                    border-right: 1px solid #eee;
                }

                /* Label the data */
                td:nth-of-type(1):before {
                    content: "Id";
                }

                td:nth-of-type(2):before {
                    content: "First Name";
                }

                td:nth-of-type(3):before {
                    content: "Last Name";
                }

                td:nth-of-type(4):before {
                    content: "Username";
                }

                td:nth-of-type(5):before {
                    content: "Password";
                }

                td:nth-of-type(6):before {
                    content: "Email";
                }

                td:nth-of-type(7):before {
                    content: "Phone Number";
                }

                td:nth-of-type(8):before {
                    content: "Address 1";
                }

                td:nth-of-type(9):before {
                    content: "Address 2";
                }

                td:nth-of-type(10):before {
                    content: "City";
                }

                td:nth-of-type(11):before {
                    content: "State";
                }

                td:nth-of-type(12):before {
                    content: "Zip Code";
                }
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
                        <a class="nav-link" href="AdminLogin.aspx">Active Students</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="StudentLogin.aspx">Student Applications</a>
                    </li>
                </ul>
            </div>
        </nav>
        <div class="p-4">
            <h2>Student Applications</h2>
            <hr />
            <asp:GridView runat="server" ID="ApplicationsGridView" OnRowDataBound="ApplicationsGridView_RowDataBound"></asp:GridView>
        </div>
    </form>
</body>
</html>
