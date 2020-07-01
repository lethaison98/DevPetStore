var donHang = {
    init: function () {
        donHang.RegisterEvents();
    },
    RegisterEvents: function () {
        $('.btn-xacNhan').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            var r= confirm("Xác nhận lịch ký gửi?");
            if (r == true) {
                $.ajax({
                    url: "/Admin/KyGuiManagement/XacNhan",
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
            var r = confirm("Từ chối lịch ký gửi?");
            if (r == true) {
                $.ajax({
                    url: "/Admin/KyGuiManagement/TuChoi",
                    data: { id: id },
                    dataType: "json",
                    type: "POST",
                    success: function (response) {
                        console.log(response);
                        $("#row_" + id).remove();
                    }
                });
            }
        });
        $('.btn-dangkygui').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            var r = confirm("Cập nhật trạng thái đang ký gửi?");
            if (r == true) {
                $.ajax({
                    url: "/Admin/KyGuiManagement/DangKyGui",
                    data: { id: id },
                    dataType: "json",
                    type: "POST",
                    success: function (response) {
                        console.log(response);
                        $("#row_" + id).remove();
                    }
                });
            }

        });
        $('.btn-hoanThanh').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            var r = confirm("Xác nhận hoàn thành ký gửi?");
            if (r == true) {
                $.ajax({
                    url: "/Admin/KyGuiManagement/HoanThanh",
                    data: { id: id },
                    dataType: "json",
                    type: "POST",
                    success: function (response) {
                        console.log(response);
                        $("#row_" + id).remove();
                    }
                });
            }

        });

    }
}

donHang.init();