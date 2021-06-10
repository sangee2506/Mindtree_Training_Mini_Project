$(document).ready(function () {
    let role = sessionStorage.getItem("role");
    if (role == "admin") {
        $('#navbarSupportedContent').append(adminNavbar());
    }
    else if (role == "user") {
        $('#navbarSupportedContent').append(userNavbar());
    }
    else {
        $('#navbarSupportedContent').append(homeNavbar());
    }
});

function userNavbar() {
    let navbar =
        "<ul class='navbar-nav ml-auto topnav'>" +
        "<li class='nav-item active'>" +
        "<a class='nav-link text-white' href='/home/homepage'>" + "Home" + "</a>" +
        "</li>" +
        "<li class='nav-item active'>" +
        "<a class='nav-link text-white' href='/home/userIndex'>" + "Fruits" + "</a>" +
        "</li>" +
        "<li class='nav-item'>" +
        "<a class='nav-link text-white' href='/home/userFeedback'>" + "Your Feedback" + "</a>" +
        "</li>" +
        "<li class='nav-item'>" +
        "<a class='nav-link text-white' href='/home/userOrder'>" + "Your Orders" + "</a>" +
        "</li>" +
        "<li class='nav-item'>" +
        "<a class='nav-link text-white' href='/home/userProfile'>" + "Profile" + "</a>" +
        "</li>" +
        "<li class='nav-item' >" +
        "<a class='nav-link text-white' href='/home/userCart'>" +
        "<i class='fas fa-shopping-cart' style='color:white'></i>" + "Cart" + "</a>" +
        "</li>" +
        "<li class='nav-item'>" +
        "<a class='nav-link btn btn-danger btn-sm text-white' type='button' href='/home/homepage' onclick='logOut()'>" +
        "<i class='fas fa-sign-out-alt' style='color:white'></i>" + "Logout" + "</a>" +
        "</li>" +

        "</ul>";
    return navbar;

}


function adminNavbar() {
    let navbar =
        "<ul class='navbar-nav ml-auto topnav'>" +
        "<li class='nav-item active'>" +
        "<a class='nav-link text-white' href='/home/homepage'>" + "Home" + "</a>" +
        "</li>" +
        "<li class='nav-item'>" +
        "<a class='nav-link text-white' href='/admin/AdminFruit'>" + "Add New Fruit" + "</a>" +
        "</li>" +
        "<li class='nav-item'>" +
        "<a class='nav-link text-white' href='/admin/AdminIndex'>" + "View Fruits" + "</a>" +
        "</li>" +
        "<li class='nav-item'>" +
        "<a class='nav-link text-white' href='/admin/AdminOrders'>" + "View Orders" + "</a>" +
        "</li>" +
        "<li class='nav-item' >" +
        "<a class='nav-link text-white' href='/admin/AdminFeedbacks'>" + "View Feedbacks" + "</a>" +
        "</li>" +
        "<li class='nav-item'>" +
        "<a class='nav-link btn btn-danger btn-sm text-white' type='button' href='/home/homepage' onclick='logOut()'>" +
        "<i class='fas fa-sign-out-alt' style='color:white'></i>" + "Logout" + "</a>" +
        "</li>" +

        "</ul>";
    return navbar;

}
function homeNavbar() {
    let navbar =
        "<ul class='navbar-nav ml-auto topnav'>" +
        "<li class='nav-item active'>" +
        "<a class='nav-link text-white' href='/home/homepage'>" + "Home" + "</a>" +
        "</li>" +
        "<li class='nav-item'>" +
        "<a class='nav-link text-white' href='#features'>" + "Features" + "</a>" +
        "</li>" +
        "<li class='nav-item'>" +
        "<a class='nav-link text-white' href='#contact'>" + "Contact" + "</a>" +
        "</li>" + 
        "<li class='nav-item'>" +
        "<a class='nav-link btn btn-info btn-sm text-white' type='button' href='/home/usersignUp'>" +
        "<i class='fas fa-user' style='color:white'></i>" + "Sign Up" + "</a>" +
        "</li>" + " &nbsp;&nbsp;" +
        "<li class='nav-item'>" +
        "<a class='nav-link btn btn-success btn-sm  text-white' type='button' href='/home/usersignIn'>" +
        "<i class='fas fa-user-shield' style='color:white'></i>" + "Sign In" + "</a>" +
        "</li>" +


        "</ul>";
    return navbar;

}