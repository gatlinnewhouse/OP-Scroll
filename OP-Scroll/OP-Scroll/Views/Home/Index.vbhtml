@Code
    ViewData("Title") = "Home Page"
End Code

<div class="jumbotron">
    <h1>PISS</h1>
    <p class="lead">PISS</p>

</div>

<div class="row">
    <input type="text" id="SearchAnime" onkeyup="SearchAnime();" />
    <button class="btn-default"></button>
</div>

<script type="text/javascript">
    function SearchAnime() {
        var CurrentValue = $("#SearchAnime").val();
        var url = '@Url.Action("SearchAnime", "Home")?SearchKeyWord=' + CurrentValue;

        $.getJSON(url, null,
            function (data) {
                $.each(data, function (index, data) {
                })
            }
        )
    }

</script>
