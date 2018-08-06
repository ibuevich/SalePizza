    //$(function () {
    //    $.ajaxSetup({ cache: false });
    //    $(".CartItem").click(function (e) {

    //        e.preventDefault();
    //        $.get(this.href, function (data) {
    //            $('#dialogContent').html(data);
    //            $('#modDialog').modal('show');
    //        });
    //    });
    //})

    $(document).on('click', '#purchase', function () {
        $('#modal-content').modal('show');
    });