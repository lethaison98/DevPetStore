var donHang = {
    init: function () {
        donHang.RegisterEvents();
    },
    RegisterEvents: function () {
        $('.btn-xacNhan').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            var r= confirm("Xác nhận đơn hàng?");
            if (r == true) {
                $.ajax({
                    url : "/DonHangManagement/XacNhan",
                    data: { id: id },
                    dataType: "json",
                    type: "POST",
                    success: function (response) {
                        console.log(response);
                        $("#row_"+id).remove();
                    }
                });
            }

        });

        $('.btn-tuChoi').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            var r = confirm("Hủy đơn hàng?");
            if (r == true) {
                $.ajax({
                    url: "/DonHangManagement/TuChoi",
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
            var r = confirm("Xác nhận hoàn thành đơn hàng?");
            if (r == true) {
                $.ajax({
                    url: "/DonHangManagement/HoanThanh",
                    data: { id: id },
                    dataType: "json",
                    type: "POST",
                    success: function (response) {
                        console.log(response);
                        $("#Update_TrangThai_"+id).load(location.href + " #Update_TrangThai"_)+id;
                        $("#Update_button_"+id).load(location.href + " #Update_button_"+id);

                    }
                });
            }

        });

    }
}

donHang.init();