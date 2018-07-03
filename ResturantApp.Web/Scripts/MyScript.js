$(document).ready(function () {
    //$("#myCarousel").carousel('pause');
    $('#viewL').click(function () {
        $("#myCarousel").carousel(1);

    });
    $('#addL').click(function () {
        $("#myCarousel").carousel(0);

    });
});
function jQueryAjaxPost(form, viewDiv, addDiv) {
    $.validator.unobtrusive.parse(form);
    if ($(form).valid()) {
        var ajaxConfig = {
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            success: function (response) {
                //$('#viewRecords').html(response);
                $(viewDiv).html(response);
                refreshAddNew($(form).attr('data-resetUrl'), addDiv, 0)
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
function refreshAddNew(resetUrl, addDiv, slideIndex) {
    $.ajax({
        type: 'GET',
        url: resetUrl,
        success: function (response) {
            //$("#addRecord").html(response);
            $(addDiv).html(response);
            $("#myCarousel").carousel(slideIndex);
            $("#myCarousel").carousel('pause')
        }
    });
}
function Edit(url, addDiv) {
    $.ajax({
        type: 'GET',
        url: url,
        success: function (response) {            
            $(addDiv).html(response);
            $("#myCarousel").carousel(1);
            $("#myCarousel").carousel('pause')
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


