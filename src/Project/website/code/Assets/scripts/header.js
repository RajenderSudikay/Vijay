jQuery("#navbar a").click(function () {
    jQuery("#navbar a.active").removeClass("active");
    jQuery(this).addClass("active");
})