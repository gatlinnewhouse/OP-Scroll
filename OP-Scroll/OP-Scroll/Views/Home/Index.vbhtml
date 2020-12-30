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
    <iframe style="position: absolute;top: 0;left: 0;bottom: 0;right: 0;width: 100%;height: 100%;"
        src="@ViewData("YouTubeLink")">
    </iframe>
</div>

<script type="text/javascript">

    $("#selector").change(function () {
        $("#selector").attr('size', 1);
    });

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
