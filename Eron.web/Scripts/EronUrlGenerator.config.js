
(function () {
    var eronUrl = eronUrl | {};
    eronUrl.lang.fa = eronUrl.lang.fa |
    {
        "ChooseLinkType": "به چه لینکی متضل شود؟",
        "Content": "مطلب",
        "ContentCategory": "مجموعه مطالب",
        "Gallery": "گالری",
        "Page": "صفحه"
    };
});




$("#State").on('change', function () {
    var loadingoption = $('<option></option>').text("لطفا منتظر بمانید...");
    $('#city').attr("disabled", "disabled").empty().append(loadingoption);

    jQuery.getJSON("/Home/SubStateJson/" + $("#State > option:selected").attr("value"), function (data) {
        var defaultoption = $('<option value="">شهر مورد تظر را انتخاب کنید</option>');
        $('#city').removeAttr("disabled").empty().append(defaultoption);
        jQuery.each(data, function (i) {
            var option2 = $('<option></option>').attr("value", data[i].Name).text(data[i].Name);
            $("#city").append(option2);
        });
    });
});
