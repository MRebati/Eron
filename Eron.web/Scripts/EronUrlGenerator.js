(function () {
    var eronUrl = eronUrl | {};
    eronUrl.lang = eronUrl.lang | {};
    eronUrl.SetLang = function (defaultLang) {
        switch (defaultLang) {
            case "fa":
                eronUrl.CurrentLang = eronUrl.lang.fa;
                break;
            case "ru":
                eronUrl.CurrentLang = eronUrl.lang.ru;
                break;
            case "en":
                eronUrl.CurrentLang = eronUrl.lang.en;
                break;
            default:
                eronUrl.CurrentLang = eronUrl.CurrentLang | eronUrl.lang.fa;
        }
        eronUrl.lang.CurrentLang = defaultLang;
    }
    eronUrl.getServiceUrl = function () {
        //todo : must create registry Api Controller for this part!
        //todo : check RegistryController
    },
    eronUrl.ajaxService = function (url, id, element,defaultOption) {
        jQuery.getJSON(url + '/' + id, function (data) {
            var defaultoption = $('<option value="">'+defaultOption+'</option>');
            $(element).removeAttr("disabled").empty().append(defaultoption);
            jQuery.each(data, function (i) {
                var option2 = $('<option></option>').attr("value", data[i].Id).text(data[i].Name);
                $(element).append(option2);
            });
        });
    },
eronUrl.createElements = function (element,urlinput) {
    var div = $('<div></div>'),
        categorydiv = div.attr('id', 'category').addClass('form-group'),
        contentdiv = div.attr('id', 'content').addClass('form-group'),
        gallerydiv = div.attr('id', 'gallery').addClass('form-group'),
        pagediv = div.attr('id', 'page').addClass('form-group'),
        colmd12 = div.addClass('col-md-12'),
        select = $('<select class="form-control"></select>'),
        option = $('<option></option>'),
        pageselect = select.attr('id', 'pageselect'),
        contentselect = select.attr('id', 'contentselect'),
        categoryselect = select.attr('id', 'categoryselect'),
        galleryselect = select.attr('id', 'galleryselect'),
        mainOptionselectBox = '<div class="form-group"><div class="col-md-12"><select id="linkSelect" class="form-control">' +
        '<option value="">' +
        eronUrl.CurrentLang.ChooseLinkType
        + '</option>' +
            '<option value="1">' +
            eronUrl.CurrentLang.Page
        + '</option>' +
        '<option value="2">' +
            eronUrl.CurrentLang.Content
        + '</option>' +
            '<option value="3">' +
            eronUrl.CurrentLang.ContentCategory
        + '</option>' +
            '<option value="4">'
        + eronUrl.CurrentLang.Gallery +
        '</option>' +
            '</select></div></div>';

    //insert col-md-12
    $(pagediv).append(colmd12).append(pageselect);
    $(contentdiv).append(colmd12).append(contentselect);
    $(categorydiv).append(colmd12).append(categoryselect);
    $(gallerydiv).append(colmd12).append(galleryselect);

    //insert selectlists

    //insert all these things inside our element
    $(element).append(mainOptionselectBox);
    $(element).append(pagediv).append(contentdiv).append(categorydiv).append(gallerydiv);

},
eronUrl.changeOption = function () {
    var slct = document.getElementById('optionSelect');
    var opt = slct.options[e.selectedIndex].value;

    switch (opt) {
        case 1:

            break;
        case 2:

            break;
        case 3:

            break;
        case 4:

            break;
        default:

    }
};
});