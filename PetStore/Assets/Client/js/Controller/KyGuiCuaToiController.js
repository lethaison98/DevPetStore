var donHang = {
    init: function () {
        donHang.RegisterEvents();
    },
    RegisterEvents: function () {
        

        $('.btn-tuChoi').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            var r = confirm("Hủy lịch ký gửi?");
            if (r == true) {
                $.ajax({
                    url: "/Account/HuyKyGui",
                    data: { id: id },
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
            var r = confirm("Xác nhận ký gửi đã hoàn thành?");
            if (r == true) {
                $.ajax({
                    url: "/Account/HoanThanhKyGui",
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