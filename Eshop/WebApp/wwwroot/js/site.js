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
                $("#number-items").text(res.length);

               
              
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
                url:'/'+ $('#culture').val() + '/Cart/AddToCart',
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