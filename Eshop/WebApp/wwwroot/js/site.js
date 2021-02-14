var SiteController = function () {
    this.initialize = function () {
        regsiterEvents();
        loadCart();
    }
    function loadCart() {
        const culture = $('#culture').val();
        $.ajax({
            type: "GET",
            url: "/" + culture + '/Cart/GetListCart',
            data: {
                languageId : culture
            },
            success: function (res) {
                console.log(res);
                var html = "";
                var total = 0;
                $.each(res, function (i, item) {
                    html += "<tr>\r\n<td><img width =\"60\" src=" + item.image + " /><\/td>\r\n"
                        + "<td>" + item.description + "<\/td>\r\n"
                        + "<td>\r\n                    <div class=\"input-append\">\r\n                        <input class=\"span1\" style=\"max-width:34px\" placeholder=\"1\" value=\"" + item.quantity +"\" id =\"appendedInputButtons\" size=\"16\" type=\"text\">\r\n                        <button class=\"btn\" type=\"button\"><i class=\"icon-minus\"><\/i><\/button>\r\n                        <button class=\"btn\" type=\"button\"><i class=\"icon-plus\"><\/i><\/button>\r\n                        <button class=\"btn btn-danger\" type=\"button\"><i class=\"icon-remove icon-white\"><\/i><\/button>\r\n                    <\/div>\r\n<\/td>"
                        + "<td>" +numberWithCommas(item.price)+"<\/td>\r\n"
                        + "< td > $25.00 <\/td>\r\n"
                        + "<td>$15.00<\/td>\r\n"
                        + "<td>$110.00<\/td>\r\n"
                        + "<td>" + numberWithCommas(item.price * item.quantity) + "<\/td>\r\n<\/tr>";
                    total += item.price * item.quantity;
                });
                $("#cart-body").html(html);
                $("#total-price").text(numberWithCommas(total).toString());

               
              
            }
        });
    }
    function regsiterEvents() {
        // Write your JavaScript code.
        $('body').on('click', '.btn-add-cart', function (e) {
            e.preventDefault();
            var id = $(this).data("id");
            $.ajax({
                type: "POST",
                url: $('#culture').val() + '/Cart/AddToCart',
                data: {
                    id: id 
                },
                success: function (res) {
                    $("#number-items").text(res.length);
                }

            });
        });
    }
}


function numberWithCommas(x) {
    return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
}