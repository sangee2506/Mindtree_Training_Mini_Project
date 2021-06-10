
$(document).ready(function () {
  
    getOrderDetails();
   
});

function getOrderDetails() {
    
    var jwtToken = sessionStorage.getItem("jwtToken");
    $.ajax({
        type: "GET",
        url: 'https://localhost:44329/api/AdminOrder/'+orderId,
        dataType: 'json',
        headers: {
            Authorization: 'Bearer ' + jwtToken
        },
        success: function (order, status, xhr) {
            $('processing').hide();
            $('#IndexPage').show();
            console.log(order);
            $('#orderId').text("OrderID : #"+order.orderId);
            $('#orderDate').text("Order Placed : " +order.orderDate);
            $('#billAddress').text(order.billingAddress);
            $('#payMethod').text(order.paymentMethod);
            $('#orderQty').text(order.orderQty );
            $('#orderTotal').text(order.orderAmount);
            $('#orderStatus').text(order.status);


            getProductDetails(order.fruit);

            getUserDetails(order.user);
            

        },
        error: function (xhr, status, error) {
            //alert("Error:" + xhr.responseText);
            $("#unAuthorised").show();
        }
    });

    function getProductDetails(fruit) {
        $('#fruitId').text(fruit.fruitId);
        $('#fruitName').text(fruit.fruitName);
        $('#fruitPrice').text(fruit.fruitPrice);
        $('#fruitQty').text(fruit.fruitQty);
        $('#fruitImg').attr('src', '/Images/' + fruit.fruitImg);
    }
    function getUserDetails(user) {
        $('#userId').text(user.userId);
        $('#userName').text(user.userName);
        $('#gender').text(user.gender);
        $('#email').text(user.email);
        $('#mobNo').text(user.mobNum);
    }
}