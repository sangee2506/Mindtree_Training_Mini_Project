//this function is triggered on success token varified
$(document).ready(function () {
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
        url: 'https://localhost:44339/api/Cart',
        type: 'GET',
        headers: {
            Authorization: 'Bearer ' + jwtToken
        },
        dataType: 'json',
        success: function (data) {
            WriteResponseForDisplayAllFruits(data);
        },
        error: function (err) {
            alert('You are not authorized...Redirecting to sign in');
            var url = "https://localhost:44350/";

            window.location.href = url;
        }
    });
}
function WriteResponseForDisplayAllFruits(data) {
    $.each(data, function (index, trav) {
        let row = "<tr>   <td>  <img src='/Images/" + trav.fruitImg + ".png' alt='HTML5 Icon' style='width: 128px; height: 128px;'>  </td>    <td> " + trav.fruitName + "</td>   <td> " + trav.fruitPrice + "</td>  <td> " + trav.fruitQty + "</td>    </tr > ";
        $('#list').append(row);//Ability to manipulate DOM using jQuery
    })
}