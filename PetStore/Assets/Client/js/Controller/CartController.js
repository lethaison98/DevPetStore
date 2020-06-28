var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        $('#btnPayment').off('click').on('click', function () {
            window.location.href = "GioHang/ThanhToan";
        });
        $('#btnUpdate').off('click').on('click', function () {
            var listProduct = $('.txtQuantity');
            var cartList = [];
            $.each(listProduct, function (i, item) {
                cartList.push({
                    SoLuong: $(item).val(),
                    Pet: {
                        ID_Item: $(item).data('id')
                    }
                });
            });

            $.ajax({
                url: '/GioHang/Update',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "GioHang";
                    }
                }
            })
        });

        $('#btnDeleteAll').off('click').on('click', function () {
            $.ajax({
                url: '/GioHang/DeleteAll',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "GioHang";
                    }
                }
            })
        });

        $('.btn-delete').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            var r = confirm("Bỏ sản phẩm?");
            if (r == true) {
                $.ajax({
                    data: { id: id },
                    url: '/GioHang/Delete',
                    dataType: 'json',
                    type: 'POST',
                    success: function (response) {
                        console.log(response);
                        if (response.status == true) {
                            btn.text('Kích hoạt');
                            $("#row_" + id).remove();
                            $("#Update_GioHang").load(location.href + " #Update_GioHang");
                            $("#Count").load(location.href + " #Count");

                        }

                    }
                })
            }
            
        });
        $('.value-plus').off('click').on('click', function (e) {
            var divUpd = $(this).parent().find('.value'), newVal = parseInt(divUpd.text(), 10) + 1;
            divUpd.text(newVal);
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            $.ajax({
                data: { id: id },
                url: '/GioHang/Increase',
                dataType: 'json',
                type: 'POST',
                success: function (response) {
                    console.log(response);
                    if (response.status == true) {
                        $("#ThanhTien_" + id).load(location.href + " #ThanhTien_" + id);
                        $("#Update_GioHang").load(location.href + " #Update_GioHang");
                        $("#Count").load(location.href + " #Count");

                    }

                }
            })
        });

        $('.value-minus').off('click').on('click', function (e) {
            var divUpd = $(this).parent().find('.value'), newVal = parseInt(divUpd.text(), 10) - 1;
            if (newVal >= 1) {
                divUpd.text(newVal);
                e.preventDefault();
                var btn = $(this);
                var id = btn.data('id');
                $.ajax({
                    data: { id: id },
                    url: '/GioHang/Decrease',
                    dataType: 'json',
                    type: 'POST',
                    success: function (response) {
                        console.log(response);
                        if (response.status == true) {
                            $("#ThanhTien_" + id).load(location.href + " #ThanhTien_" + id);
                            $("#Update_GioHang").load(location.href + " #Update_GioHang");
                            $("#Count").load(location.href + " #Count");

                        }

                    }
                })
            } else {
                e.preventDefault();
                var btn = $(this);
                var id = btn.data('id');
                var r = confirm("Bỏ sản phẩm?");
                if (r == true) {
                    $.ajax({
                        data: { id: id },
                        url: '/GioHang/Delete',
                        dataType: 'json',
                        type: 'POST',
                        success: function (response) {
                            console.log(response);
                            if (response.status == true) {
                                btn.text('Kích hoạt');
                                $("#row_" + id).remove();
                                $("#Update_GioHang").load(location.href + " #Update_GioHang");
                                $("#Count").load(location.href + " #Count");

                            }

                        }
                    })
                }
            }
           
        });
    }
}
cart.init();