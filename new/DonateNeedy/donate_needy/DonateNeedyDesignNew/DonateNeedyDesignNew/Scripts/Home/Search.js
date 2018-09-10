$("button[id='buttonlove'").click(function () {
    debugger;
    var backgroundColor = $(this).css('color');

    if (backgroundColor == "rgb(101, 101, 101)") {
        $(this).css("color", "#f00");
    }
    else {
        $(this).css("color", "#656565");
    }
});

$(function () {
        $("div[id='divcontent']").slice(0, 1).show();
    $("#loadMore").on('click', function (e) {
        e.preventDefault();
    $("div[id='divcontent']:hidden").slice(0, 1).slideDown();
        if ($("div[id='divcontent']:hidden").length == 0) {
            debugger;
            $("#loadMore").css("display", "none");
    }
        $('html,body').animate({
        scrollTop: $(this).offset().top
        }, 1500);
    });
});

