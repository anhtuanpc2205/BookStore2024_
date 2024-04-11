
if (document.readyState == "loading") {
    document.addEventListener("DOMContentLoaded", ready)
} else {
    ready()
}

function ready() {
    //2 nút chỉnh số lượng
    var quantitiesItems = document.getElementsByClassName("product-quantity")
    //console.log(document.getElementsByClassName("product-quantity"))
    for (var i = 0; i < quantitiesItems.length; i++) {
        var buttons = quantitiesItems[i].getElementsByClassName("input-group-btn")

        var buttonPlus = buttons[1]
        var buttonMinus = buttons[0]

        buttonPlus.addEventListener('click', quantityButtonClick)
        buttonMinus.addEventListener('click', quantityButtonClick)

    }
    // nút xóa
    var removeCartItemButtons = document.getElementsByClassName("btn-danger")
    //console.log(removeCartItemButtons)
    for (var i = 0; i < removeCartItemButtons.length; i++) {
        var button = removeCartItemButtons[i]
        button.addEventListener('click', removeCartRowEvent)
    }
    // nút add to cart
    var buttonAddToCarts = document.getElementsByClassName("btn-add-tocart")
    for (var i = 0; i < buttonAddToCarts.length; i++) {
        buttonAddToCarts[i].addEventListener('click', addToCartClick)
    }
    updateCart()
}


////////////////////////////////////////////////
function quantityButtonClick(event) {
    var numberInput = event.target.parentElement.parentElement.getElementsByClassName("product-quantity-value")[0]
    var currentValue = parseInt(numberInput.value)

    if (isNaN(currentValue) || currentValue < 1) {
        numberInput.value = 1
        //console.log("x")
        return
    }
    switch (event.target.classList.contains('glyphicon-plus')) {
        case true: //console.log("button plus clicked")
            numberInput.value = currentValue + 1
            break
        case false: //console.log("button minus clicked")
            if (currentValue > 1) {
                numberInput.value = currentValue - 1
            }
            else { }
            break
        default: console.log("button clicked is: " + event.target)
    }
    updateCart()
}
//////////////////////////////////////////////// skien xoa
function removeCartRowEvent(event) {
    var buttonClicked = event.target
    buttonClicked.parentElement.parentElement.remove()
    updateCart()
    // console.log('---------a cart-item has been delete-----------------')
}
////////////////////////////////////////////////
function updateCart() {
    var total = 0
    var subTotal = 0
    var shippingFee = parseFloat(document.getElementsByClassName("shippingFee")[0].innerText.replace('$', ''))
    var cartRows = document.getElementsByClassName("cart-row")
    for (var i = 0; i < cartRows.length; i++) {
        var row = cartRows[i]
        var price = parseFloat(row.getElementsByClassName("product-price")[0].getElementsByClassName("product-price-value")[0].innerText.replace('$', ''))
        var quantity = parseFloat(row.getElementsByClassName("product-quantity")[0].getElementsByClassName("input-group")[0].getElementsByClassName("product-quantity-value")[0].value)
        var rowAmountElement = row.getElementsByClassName("row-amount")[0].getElementsByClassName("row-amount-value")[0]
        var rowAmountValue = parseFloat(rowAmountElement.innerText.replace('$', ''))
        var rowAmountValue = price * quantity
        subTotal += rowAmountValue

        rowAmountElement.innerText = '$' + rowAmountValue.toFixed(2)
        // console.log('price is:'+price)
        // console.log('quantity is:' +quantity)
        // console.log('row amount is:' +rowAmountValue)
        // console.log('---------------------------------------------------------------------')
    }
    total = subTotal + shippingFee
    document.getElementsByClassName("subTotal-value")[0].innerText = '$' + subTotal.toFixed(2)
    document.getElementsByClassName("total")[0].innerText = '$' + total.toFixed(2)
    // console.log('--------------subtotal is: '+subTotal+'-------------------')
    // console.log('---------------------------------------------------------------------')
}
function addToCartClick() {
    alert("added to cart!")
    
}

//function addToCartClick() {
//    $.ajax({
//        url: '@Url.Action("Index", "Products")',
//        data: {
//            minicart: document.getElementsByClassName(tg-minicartdropdown").checked
//        },
//        success: function (data) {
//            $("#minicart").html(data);
//        }
//    })
//} 
