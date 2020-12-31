@Code
    ViewData("Title") = "Home Page"
End Code

<div class="logo">
    <h1>OP-Scroll</h1>
</div>

<div class="search">
    <input class="search-form" type="text" id="SearchAnime" onkeyup="SearchAnime();" />
    <button class="search-button"><span class="glyphicon glyphicon-search" aria-hidden="true"></span></button>
    <select class="search-autocomplete" id="selector"></select>
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

<script type="text/javascript">

    //$("#selector").change(function () {
    //    $("#selector").attr('size', 1);
    //});

    function SearchAnime() {
        var CurrentValue = $("#SearchAnime").val();
        var url = '@Url.Action("SearchAnime", "Home")?SearchKeyWord=' + CurrentValue;
        var selector = $("#selector");

        $.getJSON(url, null,
            function (data) {
                var DisplayDropdown = selector;
                DisplayDropdown.empty();
                DisplayDropdown.attr('size', 3);


                $.each(data, function (index, data) {
                    DisplayDropdown.append($('<option/>', {
                        value: data,
                        text: data

                    }));
                });
            });
    }

</script>
