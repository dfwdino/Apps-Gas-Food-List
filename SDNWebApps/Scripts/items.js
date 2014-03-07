
    
    $(document).ready(function () {
        $('a.delete-link').click(OnDeleteClick);
        $('a.got-link').click(OnGotClick);
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
    var rowdel = document.getElementById('FullItem{' + e.target.id + '}');
    rowdel.parentNode.removeChild(rowdel);
    var hasItem;

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
