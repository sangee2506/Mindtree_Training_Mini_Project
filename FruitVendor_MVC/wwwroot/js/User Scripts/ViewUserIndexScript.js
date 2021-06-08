﻿$(document).ready(function () {

    validateAjaxGetAllFruits();
});

function validateAjaxGetAllFruits() {

    let jwtToken = sessionStorage.getItem("jwtToken");
    let userName = sessionStorage.getItem("userName");
    let userId = sessionStorage.getItem("userId");

    console.log(userName);
    console.log(jwtToken);

    $('#userName').html(userName);

    $.ajax({
        url: 'https://localhost:44339/api/Fruit',
        type: 'GET',
        headers: {
            Authorization: 'Bearer ' + jwtToken
        },
        dataType: 'json',
        success: function (data) {
            ResponseForAjaxDisplayAllFruits(data);
        },
        error: function (request, message, errorThrown) {
            alert('You are not authorized...Redirecting to sign in');
            var msg = "";
            msg += "Code: " + request.status + "\n";
            msg += "Text: " + request.statusText + "\n";
            if (request.responseJSON != null) {
                msg += "Message" + request.responseJSON.Message + "\n";
            }
            alert(msg);
            var url = "https://localhost:44350/";

            window.location.href = url;
        }
        /* error: function (err) {
             alert('You are not authorized...Redirecting to sign in');
             var url = "https://localhost:44350/";
 
             window.location.href = url;
         }*/
    });
}

function ResponseForAjaxDisplayAllFruits(data) {
    $('#process').hide();
    console.log("single fruit name=" + data[0].fruitName);
    console.log("size of data=" + data.length);

    var products = "";

    for (var item = 0; item < data.length; item++) {
        console.log("loop fruit name=" + data[item].fruitName);
        /////////////  prod 1 //////////////////////
        products = products + "<div class='row'>";
        products = products + "<div class='col-xl-4'>";
        products = products + "<center>";
        products = products + "<img src='/Images/" + data[item].fruitImg + ".png' alt='HTML5 Icon' style='width: 128px; height: 128px;'>";
        products = products + "<p>" + data[item].fruitName + "</p>";
        products = products + "<p> <span>Price:<b>" + data[item].fruitPrice + "</b></span>   <span>Qty:<b>" + data[item].fruitQty + "</b></span> </p>";
        products = products + "<button class='btn-info' onclick='addToCart(" + data[item].fruitId + ")' >Add To Cart</button>";
        products = products + "<center>";
        products = products + "</div>";

        /////////////  prod 2 //////////////////////
        if (item != data.length - 1) { item = item + 1; }
        if (item >= data.length - 1) { break; }

        products = products + "<div class='col-xl-4'>";
        products = products + "<center>";
        products = products + "<img src='/Images/" + data[item].fruitImg + ".png' alt='HTML5 Icon' style='width: 128px; height: 128px;'>";
        products = products + "<p>" + data[item].fruitName + "</p>";
        products = products + "<p> <span>Price:<b>" + data[item].fruitPrice + "</b></span>   <span>Qty:<b>" + data[item].fruitQty + "</b></span> </p>";
        products = products + "<button class='btn-info' onclick='addToCart(" + data[item].fruitId + ")' >Add To Cart</button>";
        products = products + "<center>";
        products = products + "</div>";

        /////////////  prod 3 //////////////////////
        if (item != data.length - 1) { item = item + 1; }

        if (item >= data.length - 1) { break; }
        products = products + "<div class='col-xl-4'>";
        products = products + "<center>";
        products = products + "<img src='/Images/" + data[item].fruitImg + ".png' alt='HTML5 Icon' style='width: 128px; height: 128px;'>";
        products = products + "<p>" + data[item].fruitName + "</p>";
        products = products + "<p> <span>Price:<b>" + data[item].fruitPrice + "</b></span>   <span>Qty:<b>" + data[item].fruitQty + "</b></span> </p>";
        products = products + "<button class='btn-info' onclick='addToCart(" + data[item].fruitId + ")' >Add To Cart</button>";
        products = products + "<center>";
        products = products + "</div>";

        products = products + "</div>";//row

        products = products + "<br>";
        products = products + "<br>";

    }//for
    $('#getProd').append(products);
}//   ResponseForAjaxDisplayAllFruits

function addToCart(data) {
    //  https://localhost:44363/Home/UserCartDetails/?fruitId=121&fruitName=bob
    console.log(data);
    var url = "/Home/UserCartDetails/?fruitId=" + data;

    window.location.href = url;
}