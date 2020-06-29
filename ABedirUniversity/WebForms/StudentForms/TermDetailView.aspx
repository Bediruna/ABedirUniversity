<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TermDetailView.aspx.cs" Inherits="ABedirUniversity.WebForms.StudentForms.TermDetailView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no" />
    <link rel="shortcut icon" href="/Images/capIcon.ico" />
    <title>ABU | Term Details</title>
    <link href="https://fonts.googleapis.com/css?family=Lexend+Deca|Lexend+Zetta&display=swap" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="/CSS/MainStyle.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/GridStyling.css" />
    <script src="/JavaScript/jquery-3.4.1.min.js"></script>
    <script src="/JavaScript/bootstrap.min.js"></script>
    <script src="/JavaScript/MainScript.js"></script>
    <style>
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
                content: "Name";
            }

            td:nth-of-type(3):before {
                content: "Start Date";
            }

            td:nth-of-type(4):before {
                content: "End Date";
            }

        #TermDetailsLabel {
            font-weight: bold;
            font-size: 2em;
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
            <asp:Label runat="server" ID="TermDetailsLabel"></asp:Label>
            <hr />
            <asp:GridView runat="server" ID="TermDetailGridView"></asp:GridView>
            <br /><br /><br />
            <h3>Term Classes</h3>
            <br />
            <asp:GridView runat="server" ID="ClassesGridView" OnRowDataBound="ClassesGridView_RowDataBound"></asp:GridView>
            <div class="pt-4">
                <%--<h5>Warning, deleting a term will delete all classes in term and all assignments in classes.</h5>--%>
                <asp:Button runat="server" ID="DeleteButton" OnClick="DeleteButton_Click" Text="Delete Term" CssClass="button redFillButton" />
                <asp:Button runat="server" ID="AddClassButton" OnClick="AddClassButton_Click" Text="Add Class" CssClass="button greenFillButton float-lg-right" />
                <%--<asp:Button runat="server" ID="EditButton" OnClick="EditButton_Click" Text="Approve" CssClass="button greenFillButton float-lg-right" />--%>
            </div>
        </div>
    </form>
</body>
</html>
