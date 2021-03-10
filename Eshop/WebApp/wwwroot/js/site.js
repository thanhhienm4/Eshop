var SiteController = function () {
    this.initialize = function () {
        regsiterEvents();
     
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
$(document).ready(function () {
    const culture = $('#culture').val();
    $.ajax({
        type: "GET",
        url: "/" + culture + '/Cart/GetListCart',
        data: {
            languageId: culture
        },
        success: function (res) {
            console.log(res);
            $("#number-items").text(res.length);



        }
    });
});
$(document).ready(function () {
    var priceItems = document.getElementsByClassName("price");
    for (var i = 0; i < priceItems.length; i++) {
        priceItems[i].textContent = numberWithCommas(priceItems[i].textContent);
        priceItems[i].style.textAlign = "right";
    }
});
function numberWithCommas(x) {
    return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
}