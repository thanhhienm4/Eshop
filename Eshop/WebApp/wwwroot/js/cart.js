var CartController = function () {
    this.initialize = function () {
        RegisterEvent();
        loadCart();
    }
    function loadCart() {
        const culture = $('#culture').val();
        $.ajax({
            type: "GET",
            url: "/" + culture + '/Cart/GetListCart',
            data: {
                languageId: culture
            },
            success: function (res) {
                console.log(res);
                var html = "";
                var total = 0;
                $.each(res, function (i, item) {
                    html += "<tr>\r\n<td><img width =\"60\" src=" + item.image + " /><\/td>\r\n"
                        + "<td>" + item.description + "<\/td>\r\n"
                        + "<td>\r\n\t<div class=\"input-append\">\r\n\t\t<input id=\"input-quantity-" + item.productId + "\" class=\"input-quantity\" data-id=\""+item.productId+ "\" pattern=\"[0-9]{0,}\" style =\"max-width:34px\" placeholder=\"1\" value=\"" + item.quantity + "\" size =\"16\" type=\"number\">\r\n\t\t"
                        + "<button class=\"btn btn-minus-quantity\" type=\"button\" data-id=" +item.productId +"  id=\"btn btn-minus-"+item.productId+"\">\r\n\t\t\t<i class=\"icon-minus\"><\/i>\r\n\t\t<\/button>\r\n\t\t"
                        + "<button class=\"btn btn-add-quantity\" type=\"button\" data-id=" +item.productId +"  id=\"btn btn-add-"+item.productId+"\">\r\n\t\t\t<i class=\"icon-plus\"><\/i>\r\n\t\t<\/button>\r\n\t\t" 
                        + "<button class=\"btn btn-danger\" type=\"button\"data-id="+  item.productId +" id=\"btn btn-remove-"+item.productId+"\">\r\n\t\t\t<i class=\"icon-remove icon-white\"><\/i>\r\n\t\t<\/button>\r\n\t<\/div>\r\n<\/td>"
                        + "<td>" + numberWithCommas(item.price) + "<\/td>\r\n"
                        + "< td > $25.00 <\/td>\r\n"
                        + "<td>$15.00<\/td>\r\n"
                        + "<td>" + numberWithCommas(item.price * item.quantity) + "<\/td>\r\n<\/tr>";
                    total += item.price * item.quantity;
                });
                $("#cart-body").html(html);
                $("#total-price").text(numberWithCommas(total).toString());
                $("#number-items-cart").text(res.length);
                $("#number-items").text(res.length);
              




            }
        });
    }
    function UpdateQuantity(id, quantity) {
        var culture = $('#culture').val();
        $.ajax({
            type: "POST",
            url: '/' + culture + '/Cart/UpdateCart',
            data: {
                id: id,
                quantity: quantity
            },
            success: function (res) {
                $("#number-items").text(res.length);
                loadCart();
            }

        });
    }
    function RegisterEvent() {
       
        $('body').on('change', '.input-quantity', function (e) {
            e.preventDefault();
            var id = $(this).data("id");
            var quantity = $(this).val();
            UpdateQuantity(id, quantity);
            
        });
        $('body').on('click', '.btn-add-quantity', function (e) {
            e.preventDefault();
            var id = $(this).data("id");
            var quantity = parseInt($("#input-quantity-"+id).val()) + 1;
            UpdateQuantity(id, quantity);

        });
        $('body').on('click', '.btn-minus-quantity', function (e) {
            e.preventDefault();
            var id = $(this).data("id");
            var quantity = parseInt($("#input-quantity-" + id).val()) - 1;
            UpdateQuantity(id, quantity);

        });
        $('body').on('click', '.btn-danger', function (e) {
            e.preventDefault();
            var id = $(this).data("id");
            var quantity = 0;
            UpdateQuantity(id, quantity);

        });

    }
}