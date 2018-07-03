$(document).ready(function () {
    //$("#myCarousel").carousel('pause');
    $('#viewL').click(function () {
        $("#myCarousel").carousel(1);

    });
    $('#addL').click(function () {
        $("#myCarousel").carousel(0);

    });
});
function jQueryAjaxPost(form, viewDiv, addDiv, carosl) {
    $.validator.unobtrusive.parse(form);
    if ($(form).valid()) {
        var ajaxConfig = {
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            success: function (response) {
                //$('#viewRecords').html(response);
                $(viewDiv).html(response);
                refreshAddNew($(form).attr('data-resetUrl'), addDiv, carosl, 0)
            }
        }
        if ($(form).attr('enctype') == "multipart/form-data") {
            ajaxConfig["contentType"] = false;
            ajaxConfig["processData"] = false;
        }
         $.ajax(ajaxConfig);
    }   
    return false;
}
function refreshAddNew(resetUrl, addDiv, carsl, slideIndex) {
    $.ajax({
        type: 'GET',
        url: resetUrl,
        success: function (response) {
            //$("#addRecord").html(response);
            $(addDiv).html(response);
            $(carsl).carousel(slideIndex);
            $(carsl).carousel('pause')
        }
    });
}
function Edit(url, addDiv, carosl) {
    $.ajax({
        type: 'GET',
        url: url,
        success: function (response) {            
            $(addDiv).html(response);
            $(carosl).carousel(1);
            $(carosl).carousel('pause')
        }
    });
}

function Delete(url, viewDiv) {
    if (confirm('Delete this from the List ?') == true, "Confirm") {
        $.ajax({
            type: 'POST',
            url: url,
            success: function (response) {
                $(viewDiv).html(response);
            }
        });
    }
}


