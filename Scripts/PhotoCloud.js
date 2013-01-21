/// <reference path="jquery-1.9.0-vsdoc.js">
$(function () {
    // create the signalR hub
    var picHub = $.connection.picHub;
    picHub.addImage = function (url) {
        $("#pics :nth-child(6)").remove();
        $("#pics").prepend("<img src='" + url + "'>");
    }
    $.connection.hub.start();    

    $("body").on('drop', function (evt) {
        evt.stopPropagation();
        evt.preventDefault();
        var files = evt.originalEvent.dataTransfer.files;
        if (files.length > 0) {
            var data = new FormData();
            for (i = 0; i < files.length; i++) {
                data.append("items[]", files[i]);
            }
            console.log('uploading file to server....');
            $.ajax({
                type: "POST",
                url: window.location.href,
                contentType: false,
                processData: false,
                data: data,
                success: function (res) {
                    console.log(res);
                    picHub.update(res);
                }
            });
        }
    }).on('dragover', function (e) {
        return false;
    }).on('dragend', function (e) {
        return false;
    });
})