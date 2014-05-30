﻿
    
    $(document).ready(function () {
        $('a.delete-link').click(OnDeleteClick);
        $('a.got-link').click(OnGotClick);
        $('a.add-link').click(OnAddClick);
    });

function OnDeleteClick(e)
{
    var rowdel = document.getElementById('FullItem{' + e.target.id + '}');
    rowdel.parentNode.removeChild(rowdel);

    $.post("/GroceryList/Items/DeleteItem", { itemID: e.target.id },
          function (result) // success
          {
              alert('success');
          },
          function (result) // error
          {
              alert('error');
          }
         );
    return false; // for the button
}

function OnGotClick(e) {

    var hasItem;
    var itemID = e.target.parentElement.id;
    
    //var id = 'FullItem{' + itemID + '}';

    var div = document.getElementById(itemID);
    div.parentNode.removeChild(div);
    
    
    //need a find a better way
    if (window.location.href.indexOf('showAll=True') < 0)
        hasItem = true;
    else {
        hasItem = false;
    }

    $.post("/GroceryList/Items/GotItem", { itemID: e.target.id, haveItem: hasItem },
          function (result) // success
          {
              alert('tea');
          },
          function (msg) // error
          {
              alert('Error');
          }
         );
    return false; // for the button
}

function OnAddClick(e) {
    var name = $("#Name").val();
    var price = $("#Price").val();
    var storeid = $("#SelectedItemId").val();

    if (storeid.length == 0)
        storeid = 3;

    $.post("/GroceryList/Items/AddItem", { name: name, price: price, StoreID: storeid },
          function (data) { });
    document.getElementById('ItemAdded').innerHTML = name + " was added.";
    document.getElementById('Name').value = "";
    document.getElementById('Price').value = "";
    document.getElementById('SelectedItemId')[1].selected = true;
}