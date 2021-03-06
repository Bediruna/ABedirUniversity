﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentApplicationForm.aspx.cs" Inherits="ABedirUniversity.WebForms.StudentApplicationForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no" />
    <link rel="shortcut icon" href="/Images/capIcon.ico" />
    <title>ABU | Application</title>
    <link href="https://fonts.googleapis.com/css?family=Lexend+Deca|Lexend+Zetta&display=swap" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="/CSS/MainStyle.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/bootstrap.min.css" />
    <script src="/JavaScript/jquery-3.4.1.min.js"></script>
    <script src="/JavaScript/jquery.mask.js"></script>
    <script src="/JavaScript/bootstrap.min.js"></script>
    <script>
        $(document).ready(function () {
            $("#inputPhoneNumber").mask('(999) 999-9999');
        });
    </script>
    <style>
        .ErrorMsg {
            color: red;
            font-size: 1.3em;
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
                    <a class="nav-link" href="AdminLogin.aspx">Admin Portal</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="StudentLogin.aspx">Student Portal</a>
                </li>
            </ul>
        </div>
    </nav>
    <form id="form1" runat="server">
        <asp:Panel runat="server" ID="ApplicationPanel" CssClass="p-5">
            <h1 class="text-center mb-5">Apply to A Bedir University</h1>
            <div class="form-row">
                <div class="form-group col-md-6 col-sm-12">
                    <label for="inputUsername">Username</label>
                    <input runat="server" type="text" class="form-control" id="inputUsername" placeholder="Username" required="required" />
                </div>
                <div class="form-group col-md-6 col-sm-12">
                    <label for="inputPassword">Password</label>
                    <input runat="server" type="password" class="form-control" id="inputPassword" placeholder="Password" required="required" />
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-6 col-sm-12">
                    <label for="inputFirstName">First Name</label>
                    <input runat="server" type="text" class="form-control" id="inputFirstName" placeholder="First Name" required="required" />
                </div>
                <div class="form-group col-md-6 col-sm-12">
                    <label for="inputLastName">Last Name</label>
                    <input runat="server" type="text" class="form-control" id="inputLastName" placeholder="Last Name" required="required" />
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-6 col-sm-12">
                    <label for="inputEmail">Email</label>
                    <input runat="server" type="email" class="form-control" id="inputEmail" placeholder="Email" />
                </div>
                <div class="form-group col-md-6 col-sm-12">
                    <label for="inputPhoneNumber">Phone Number</label>
                    <input runat="server" type="tel" class="form-control" id="inputPhoneNumber" placeholder="Phone Number" />
                </div>
            </div>
            <div class="form-group">
                <label for="inputAddress">Address</label>
                <input runat="server" type="text" class="form-control" id="inputAddress" placeholder="1234 Main St" required="required" />
            </div>
            <div class="form-group">
                <label for="inputAddress2">Address 2</label>
                <input runat="server" type="text" class="form-control" id="inputAddress2" placeholder="Apartment, studio, or floor" />
            </div>
            <div class="form-row">
                <div class="form-group col-md-6 col-sm-12">
                    <label for="inputCity">City</label>
                    <input runat="server" type="text" class="form-control" id="inputCity" placeholder="City" required="required" />
                </div>
                <div class="form-group col-md-4 col-sm-12">
                    <label for="inputState">State</label>
                    <select runat="server" id="inputState" class="form-control" required="required">
                        <option>Choose...</option>
                        <option value="AL">Alabama</option>
                        <option value="AK">Alaska</option>
                        <option value="AZ">Arizona</option>
                        <option value="AR">Arkansas</option>
                        <option value="CA">California</option>
                        <option value="CO">Colorado</option>
                        <option value="CT">Connecticut</option>
                        <option value="DE">Delaware</option>
                        <option value="DC">District Of Columbia</option>
                        <option value="FL">Florida</option>
                        <option value="GA">Georgia</option>
                        <option value="HI">Hawaii</option>
                        <option value="ID">Idaho</option>
                        <option value="IL">Illinois</option>
                        <option value="IN">Indiana</option>
                        <option value="IA">Iowa</option>
                        <option value="KS">Kansas</option>
                        <option value="KY">Kentucky</option>
                        <option value="LA">Louisiana</option>
                        <option value="ME">Maine</option>
                        <option value="MD">Maryland</option>
                        <option value="MA">Massachusetts</option>
                        <option value="MI">Michigan</option>
                        <option value="MN">Minnesota</option>
                        <option value="MS">Mississippi</option>
                        <option value="MO">Missouri</option>
                        <option value="MT">Montana</option>
                        <option value="NE">Nebraska</option>
                        <option value="NV">Nevada</option>
                        <option value="NH">New Hampshire</option>
                        <option value="NJ">New Jersey</option>
                        <option value="NM">New Mexico</option>
                        <option value="NY">New York</option>
                        <option value="NC">North Carolina</option>
                        <option value="ND">North Dakota</option>
                        <option value="OH">Ohio</option>
                        <option value="OK">Oklahoma</option>
                        <option value="OR">Oregon</option>
                        <option value="PA">Pennsylvania</option>
                        <option value="RI">Rhode Island</option>
                        <option value="SC">South Carolina</option>
                        <option value="SD">South Dakota</option>
                        <option value="TN">Tennessee</option>
                        <option value="TX">Texas</option>
                        <option value="UT">Utah</option>
                        <option value="VT">Vermont</option>
                        <option value="VA">Virginia</option>
                        <option value="WA">Washington</option>
                        <option value="WV">West Virginia</option>
                        <option value="WI">Wisconsin</option>
                        <option value="WY">Wyoming</option>
                    </select>
                </div>
                <div class="form-group col-md-2 col-sm-12">
                    <label for="inputZip">Zip</label>
                    <input runat="server" type="text" class="form-control" id="inputZip" placeholder="Zip" required="required" />
                </div>
            </div>
            <asp:Label runat="server" ID="ErrorLabel" CssClass="ErrorMsg" Visible="false"/>
            <div class="mb-3">Already Enrolled? <a href="StudentLogin.aspx">Sign In</a></div>
            <asp:Button ID="SubmitApplicationBtn" runat="server" type="submit" CssClass="btn btn-primary" Text="Submit" OnClick="SubmitApplicationBtn_Click"></asp:Button>
            <asp:Label runat="server" ID="SuccessMsg" CssClass="text-center mb-5" Visible="false">Thank you for applying to A Bedir University</asp:Label>
        </asp:Panel>
    </form>
</body>
</html>
