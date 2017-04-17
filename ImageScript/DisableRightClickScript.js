$("a").on('contextmenu', function (e) {
    e.preventDefault();
});
$("a").click(function () {
    $(".lb-image").on('contextmenu', function (e) {
        e.preventDefault();
    });
});