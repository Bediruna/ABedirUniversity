<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentApplicationList.aspx.cs" Inherits="ABedirUniversity.WebForms.AdminForms.StudentApplicationList" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no" />
    <link rel="shortcut icon" href="/Images/capIcon.ico" />
    <title>ABU | Applications</title>
    <link href="https://fonts.googleapis.com/css?family=Lexend+Deca|Lexend+Zetta&display=swap" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="/CSS/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/MainStyle.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/GridStyling.css" />
    <script src="/JavaScript/jquery-3.4.1.min.js"></script>
    <script src="/JavaScript/jquery.mask.js"></script>
    <script src="/JavaScript/bootstrap.min.js"></script>
    <style>
        #topSection {
            margin-bottom: 60px;
        }

        #InputSearch {
            width: 200px;
        }

        .right {
            float: right;
        }

        .left {
            float: left;
        }

        @media only screen and (max-width: 760px), (min-device-width: 768px) and (max-device-width: 1100px) {

            #topSection {
                margin-bottom: 180px;
            }

            /* Label the data */
            td:nth-of-type(1):before {
                content: "Id";
            }

            td:nth-of-type(2):before {
                content: "Status";
            }

            td:nth-of-type(3):before {
                content: "First Name";
            }

            td:nth-of-type(4):before {
                content: "Last Name";
            }
        }
    </style>
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
        <div class="p-4">
            <div id="topSection">
                <h2 class="left">Student Applications</h2>
                <div class="right">
                    <asp:Button ID="ExportBtn" runat="server" type="submit" CssClass="btn btn-success left mr-2 mb-2" Text="Generate Excel Report" OnClick="ExportBtn_Click" UseSubmitBehavior="false"></asp:Button>
                    <input runat="server" type="text" class="form-control left" id="InputSearch" placeholder="Search by Name" required="required" />
                    <asp:Button ID="SearchBtn" runat="server" type="submit" CssClass="btn btn-primary right" Text="Search" OnClick="SearchBtn_Click"></asp:Button>
                    <%--<asp:Button ID="ResetBtn" runat="server" type="submit" CssClass="btn btn-primary right" Text="Reset Search" OnClick="ResetBtn_Click"></asp:Button>--%>
                </div>
            </div>
            <hr />
            <asp:GridView runat="server" ID="ApplicationsGridView" OnRowDataBound="ApplicationsGridView_RowDataBound" AllowSorting="true" OnSorting="ApplicationsGridView_Sorting"></asp:GridView>
        </div>
    </form>
</body>
</html>
