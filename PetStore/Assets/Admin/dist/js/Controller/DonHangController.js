var donHang = {
    init: function () {
        donHang.RegisterEvents();
    },
    RegisterEvents: function () {
        $('.btn-status').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            $.ajax({
                url : "/DonHangManagement/XacNhan",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    console.log(response);
                    if (response.status == false) {
                        btn.text('Chưa xác nhận');
                    }
                    else {
                        btn.text('Đã xác nhận');
                    }
                }
            });
        });
    }
}

donHang.init();