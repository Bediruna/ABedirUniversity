<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="ABedirUniversity.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>A Bedir University</title>
    <link href="https://fonts.googleapis.com/css?family=Lexend+Deca|Lexend+Zetta&display=swap" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="CSS/MainStyle.css" />
    <link rel="stylesheet" type="text/css" href="CSS/bootstrap.min.css" />
    <script src="JavaScript/jquery-3.4.1.min.js"></script>
    <script src="JavaScript/bootstrap.min.js"></script>
    <script>
        $(document).ready(function () {
            runCarousel();
            $("#ApplyBtn").click(function () {
                window.open('StudentApplication.aspx', '_blank');
            });
        });

        var imageIndex = 0;
        function runCarousel() {
            var imageSrcArray = ["Images/Classes.jpg", "Images/Education.jpg", "Images/Graduation.jpg"];

            $('#CarouselDiv').css("background-image", "url(" + imageSrcArray[imageIndex] + ")");
            if (imageIndex < imageSrcArray.length - 1) {
                imageIndex++;
            } else {
                imageIndex = 0;
            }

            setTimeout(runCarousel, 7000);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="CarouselDiv">

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
                        <li class="nav-item">
                            <a class="nav-link" href="StudentLogin.aspx">Student Portal</a>
                        </li>
                    </ul>
                </div>
            </nav>


            <div class="center">
                <div id="uniText">A Bedir University</div>
                <br />
                <br />
                <span id="ApplyBtn">APPLY NOW</span>
            </div>
        </div>
    </form>
</body>
</html>
