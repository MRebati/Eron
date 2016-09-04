//Origional Part for all ajax Requests.

function begin() {
    $(".loading").fadeIn();
}

function success(actionName) {

    toastr.success(actionName + " با موفقیت انجام شد.");
    $(".wrapper-content").addClass('animated').removeClass('fadeIn').removeClass('fade').addClass('fadeInLeft');
    //$.ajax({
    //    type: "GET",
    //    url: url,
    //    dataType: "html",
    //    success: function (result) {
    //        $("#list").html(result);
    //        $(".loading").fadeOut();
    //        $(".fade").removeClass("in");
    //    },
    //    error: function () {
    //        $("#list-box").html('<p style="margin: 0 auto;">در پردازش اطلاعات مشکلی به وجود آمده، لطفا <a href="#" onclick="reloadlist">دوباره امتحان کنید. </a></p>');
    //    }
    //});
}

function successTable(url) {
    $.ajax({
        type: "GET",
        url: url,
        dataType: "html",
        success: function (result) {
            $("#list").html(result);
            $(".loading").fadeOut();
            $(".fade").removeClass("in");
            $('#table').dataTable({
                "order": [0, 'desc'],
                "bPaginate": true,
                "bLengthChange": true,
                "bFilter": true,
                "bSort": true,
                "bInfo": true,
                "bAutoWidth": true
            });
        },
        error: function () {
            $("#boxlist").html('<p style="margin: 0 auto;">در پردازش اطلاعات مشکلی به وجود آمده، لطفا <a href="#" onclick="reloadlist">دوباره امتحان کنید. </a></p>');
        }
    });
}

function complete() {
    $(".wrapper-content").addClass('animated').removeClass('fadeIn').removeClass('fade').addClass('fadeInLeft');
}

function fail(actionName) {

    toastr.error(actionName + " با مشکل مواجه شد.");
    $(".wrapper-content").addClass('animated').removeClass('fadeIn').removeClass('fade').addClass('fadeInLeft');
    //$.ajax({
    //    type: "GET",
    //    url: url,
    //    dataType: "html",
    //    success: function (result) {
    //        $("#list").html(result);
    //        $(".loading").fadeOut();
    //        $(".fade").removeClass("in");
    //    },
    //    error: function () {
    //        $("#boxlist").html('<p style="margin: 0 auto;">در پردازش اطلاعات مشکلی به وجود آمده، لطفا <a href="#" onclick="reloadlist">دوباره امتحان کنید. </a></p>');
    //    }
    //});
}

function failTabel(url) {
    $.ajax({
        type: "GET",
        url: url,
        dataType: "html",
        success: function (result) {
            $("#list").html(result);
            $(".loading").fadeOut();
            $(".fade").removeClass("in");
            $('#table').dataTable({
                "order": [0, 'desc'],
                "bPaginate": true,
                "bLengthChange": true,
                "bFilter": true,
                "bSort": true,
                "bInfo": true,
                "bAutoWidth": true
            });
        },
        error: function () {
            $("#boxlist").html('<p style="margin: 0 auto;">در پردازش اطلاعات مشکلی به وجود آمده، لطفا <a href="#" onclick="reloadlist">دوباره امتحان کنید. </a></p>');
        }
    });
}

function createAjaxForm(url,actionname) {

    $('#createform').on('submit', function (e) {
        e.preventDefault();
        console.log("actionname:" + actionname);
        $(this).ajaxSubmit({
            beforeSend: function () {
            },
            success: function () {
                toastr.success(actionname + " با موفقیت انجام شد.");
                complete();
                //$.ajax({
                //    type: "GET",
                //    url: url,
                //    dataType: "html",
                //    success: function (result) {
                //        $("#mainpanel").html(result);

                //        createAjaxForm(url,actionname);
                //    },
                //    error: function () {
                //        fail(actionname);
                //    }
                //});
            },
            complete: function () {
            },
            resetForm: true,
            target: '#mainpanel'
        });
        return false;
    });
}

function createAjaxFormWithTable(url) {

    $('#createform').on('submit', function (e) {
        e.preventDefault();
        $(this).ajaxSubmit({
            beforeSend: function () {
                $("#loading").show();
                $("#editoverlay").show();
            },
            success: function () {
                complete();
                $.ajax({
                    type: "GET",
                    url: url,
                    dataType: "html",
                    success: function (result) {
                        $("#list").html(result);
                        $('#table').dataTable({
                            "order": [0, 'desc'],
                            "bPaginate": true,
                            "bLengthChange": true,
                            "bFilter": true,
                            "bSort": true,
                            "bInfo": true,
                            "bAutoWidth": true
                        });
                        $(".fade").removeClass("in");
                        $("#createoverlay").hide();
                        $("#loading").hide();
                        $("#Success").html("<p>مورد با موفقیت ثبت شد.</p>");
                        createAjaxFormWithTable(url);
                    },
                    error: function () {
                        $("#boxlist").html('<p style="margin: 0 auto;">در پردازش اطلاعات مشکلی به وجود آمده، لطفا <a href="#" onclick="reloadlist">دوباره امتحان کنید. </a></p>');
                    }
                });
            },
            complete: function () {
                if (typeof defaultActions == 'function') {
                    defaultActions();
                }
                //status.html(xhr.responseText);
            },
            target: '#createbox'
        });
    });
}

function editAjaxForm(url,actionname) {

    $('#editform').ajaxForm({

        beforeSend: function () {
            
        },
        success: function () {
            complete();
            toastr.success(actionname + " با موفقیت انجام شد.");
            //$.ajax({
            //    type: "GET",
            //    url: url,
            //    dataType: "html",
            //    success: function (result) {
            //        $("#list").html(result);
            //        $("#editoverlay").hide();
            //        $(".fade").removeClass("in");
            //    },
            //    error: function () {
            //        $("#boxlist").html('<p style="margin: 0 auto;">در پردازش اطلاعات مشکلی به وجود آمده، لطفا <a href="#" onclick="reloadlist">دوباره امتحان کنید. </a></p>');
            //    }
            //});
        },
        failure: function () {
            toastr.error(actionname + " با مشکل مواجه شد.");
        },
        complete: function (xhr) {
        },
        target: '#mainpanel'
    });
}

function editAjaxFormWithTable(url) {

    $('#editform').ajaxForm({

        beforeSend: function () {
            $("#loading").show();
            $("#editoverlay").show();
        },
        success: function () {
            $.ajax({
                type: "GET",
                url: url,
                dataType: "html",
                success: function (result) {
                    $("#list").html(result);
                    $('#table').dataTable({
                        "order": [0, 'desc'],
                        "bPaginate": true,
                        "bLengthChange": true,
                        "bFilter": true,
                        "bSort": true,
                        "bInfo": true,
                        "bAutoWidth": true
                    });
                    $("#editoverlay").hide();
                    $(".fade").removeClass("in");
                    $("#loading").hide();
                    $("#Success").html("<p>مورد با موفقیت ویرایش شد.</p>");
                },
                error: function () {
                    $("#boxlist").html('<p style="margin: 0 auto;">در پردازش اطلاعات مشکلی به وجود آمده، لطفا <a href="#" onclick="reloadlist">دوباره امتحان کنید. </a></p>');
                }
            });
        },
        complete: function (xhr) {
            
            if (typeof defaultEditActions == 'function') {
                defaultEditActions();
            }

            //status.html(xhr.responseText);
        }
    });
}

function DeletePanelTrigger() {
    $("#deletemodal").modal('show');
}