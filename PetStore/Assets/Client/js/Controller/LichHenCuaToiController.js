var donHang = {
    init: function () {
        donHang.RegisterEvents();
    },
    RegisterEvents: function () {

        $('.btn-tuChoi').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            var text = $('#txtarea_' + id).val();
            var r = confirm("Hủy lịch hẹn đã đặt?");
            if (r == true) {
                $.ajax({
                    url: "/Account/HuyLichHen",
                    data: { id: id , lydo: text},
                    dataType: "json",
                    type: "POST",
                    success: function (response) {
                        console.log(response);
                        $("#Update_TrangThai_"+id).load(location.href + " #Update_TrangThai_"+id);
                        $("#Update_button_"+id).load(location.href + " #Update_button_"+id);

                    }
                });
            }
        });
        $('.btn-hoanThanh').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            var r = confirm("Xác nhận lịch chăm sóc đã hoàn tất?");
            if (r == true) {
                $.ajax({
                    url: "/Account/HoanThanhLichHen",
                    data: { id: id },
                    dataType: "json",
                    type: "POST",
                    success: function (response) {
                        console.log(response);
                        $("#Update_TrangThai_" + id).load(location.href + " #Update_TrangThai_" + id);
                        $("#Update_button_"+id).load(location.href + " #Update_button_"+id);
                    }
                });
            }
        });
    }
}

donHang.init();