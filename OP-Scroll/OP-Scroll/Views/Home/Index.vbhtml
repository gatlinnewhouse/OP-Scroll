@Code
    ViewData("Title") = "Home Page"
End Code

<div class="jumbotron">
    <h1>OP-Scroll</h1>
    <p class="lead">OP-Scroll</p>

</div>

<div class="row">
    <input type="text" id="SearchAnime" onkeyup="SearchAnime();" />
    <button class="btn-default"></button>
    <select class="form-control"id="selector"></select>
</div>

<iframe width="420" height="315"
        src="@ViewData("YouTubeLink")">
</iframe>

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
                        value: data.lable,
                        text: data.lable

                    }));
                });
            });
    }

</script>
