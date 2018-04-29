$(function () {
    $('#ajaxsend').click(function (e) {
        e.preventDefault();

        $.ajax({
            type: "POST",
            url: "/Home/SendDate",
            data: "{'date':'" + $('#datepicker').val() + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json"

        }).done(function (data) {
            //Successfully pass to server and get response
            if (data.result = "OK") {
                alert("Date submitted successfully.");
            }
        }).fail(function (response) {
            if (response.status != 0) {
                alert(response.status + " " + response.statusText);
            }
        });
    });

});