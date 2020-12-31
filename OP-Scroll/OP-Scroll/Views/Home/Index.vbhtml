@Code
    ViewData("Title") = "Home Page"
End Code

<div class="logo">
    <h1>OP-Scroll</h1>
</div>

<div class="wrapper">
    <div class="search-input">
        <a href="" target="_blank" hidden></a>
        <input type="text" id="SearchAnime" placeholder="Type to search.." onkeyup="SearchAnime();">
        <div class="autocom-box">
            <!-- here list are inserted from javascript -->
        </div>
        <div class="icon"><i class="glyphicon glyphicon-search" aria-hidden="true"></i></div>
    </div>
</div>

<div class="video-view">
    <h2>Opening songs:</h2>
    @*@For Each item In ViewBag.OpeningYoutubeLinks
        @<iframe 
                 src="@item">
        </iframe>


    Next*@

    <h2>Ending songs:</h2>

    @*@For Each item In ViewBag.EndingYoutubeLinks
        @<iframe 
                 src="@item">
        </iframe>


    Next*@

</div>

<!-- sample spotify embed -->
<iframe src="https://open.spotify.com/embed/track/51Z2IzJvLCnZaIpBV0IYRr" width="300" height="380" frameborder="0" allowtransparency="true" allow="encrypted-media"></iframe>

<script type="text/javascript">
    // getting all required elements
    const searchWrapper = document.querySelector(".search-input");
    const inputBox = searchWrapper.querySelector("input");
    const suggBox = searchWrapper.querySelector(".autocom-box");
    const icon = searchWrapper.querySelector(".icon");
    let linkTag = searchWrapper.querySelector("a");
    let webLink;

    $(".autocom-box").change(function () {
        $(".autocom-box").attr('size', 1);
    });

    function SearchAnime() {
        var CurrentValue = $("#SearchAnime").val();
        var url = '@Url.Action("SearchAnime", "Home")?SearchKeyWord=' + CurrentValue;
        var selector = $(".autocom-box");

        $.getJSON(url, null,
            function (data) {
                searchWrapper.classList.add("active"); //show autocomplete box
                var DisplayDropdown = selector;
                DisplayDropdown.empty();
                DisplayDropdown.attr('size', 3);

                $.each(data, function (index, data) {
                    DisplayDropdown.append($('<li/>', {
                        text: data
                    }));
                });
            });
    }
    function select(element) {
        let selectData = element.textContent;
        inputBox.value = selectData;
        // fix javascript below to work with our site
        icon.onclick = () => {
            webLink = "https://www.google.com/search?q=" + selectData;
            linkTag.setAttribute("href", webLink);
            linkTag.click();
        }
        searchWrapper.classList.remove("active");
    }
</script>
