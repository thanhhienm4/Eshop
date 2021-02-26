 function paint(dot) {
    var id = $(dot).attr("data-id");
    var status = $("#status-" + id).val();
    switch (status) {
        case "0":
            dot.style.backgroundColor = "#ffc107";
            break;
        case "1":
            dot.style.backgroundColor = "#fd7e14";
            break;
        case "2":
            dot.style.backgroundColor = "#007bff";
            break;
        case "3":
            dot.style.backgroundColor = "#28a745";
            break;
        case "4":
            dot.style.backgroundColor = "#dc3545";
            break;
        

    }

}

function updateStatus(item) {
    var orderId = $(item).attr("data-id");
    var status = $(item).val();
    var dot = document.getElementById("dot-"+ orderId);
    //paint(dot);
    $.ajax({
        type: "POST",
        url: "/Order/UpdateStatus",
        data: { orderId: orderId, status: status },
        success: function () {
            //location.reload();
            paint(dot);
        }
    })
}
function initPaint() {
    var listDot = document.getElementsByClassName("dot");
    for ( item of listDot) {
        paint(item);
    }
}