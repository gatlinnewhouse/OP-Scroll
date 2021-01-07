<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no">
    <title>@ViewBag.Title - My ASP.NET Application</title>
    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")
</head>
<body>
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container-fluid body-content">
            <div class="container">
                <div class="navbar-header">
                    @Html.ActionLink("OP Scroll", "Index", "Home", New With {.area = ""}, New With {.class = "navbar-brand"})
                </div>
                <div class="wrapper">
                    <div class="search-input">
                        <a href="" target="_blank" hidden></a>
                        <input type="text" id="SearchAnime" placeholder="Type to search.." onkeyup="SearchAnime();">
                        <div id="autocom" class="autocom-box">

                        </div>
                        <div class="icon"><i class="glyphicon glyphicon-search" aria-hidden="true"></i></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid body-content">
        @RenderBody()
        <hr />
        <footer>
            <p>&copy; @DateTime.Now.Year - My ASP.NET Application</p>
        </footer>
    </div>
    
    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/bootstrap")
    @RenderSection("scripts", required:=False)
</body>
</html>
