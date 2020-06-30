var donHang = {
    init: function () {
        donHang.RegisterEvents();
    },
    RegisterEvents: function () {
        $('.btn-xacNhan').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            var r= confirm("Xác nhận lịch hẹn chăm sóc?");
            if (r == true) {
                $.ajax({
                    url : "/LichHenManagement/XacNhan",
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
            var r = confirm("Từ chối lịch hẹn chăm sóc?");
            if (r == true) {
                $.ajax({
                    url: "/LichHenManagement/TuChoi",
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
            var r = confirm("Xác nhận hoàn thành lịch chăm soc?");
            if (r == true) {
                $.ajax({
                    url: "/LichHenManagement/HoanThanh",
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