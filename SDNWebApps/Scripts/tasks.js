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

    $.post("/Tasks/Task/DeleteItem", { itemID: e.target.id },
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
    var done;
    var taskID = e.target.parentElement.id;
    document.getElementById('FullItem{' + taskID + '}').innerHTML = "";

    //need a find a better way
    if (window.location.href.indexOf('showAll=True') < 0)
        done = true;
    else {
        done = false;
    }

    $.post("/Tasks/Tasks/GotTask", { taskID: taskID, done: done },
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
    var title = $("#Title").val();
    var duedate = $("#DueDate").val();
    
    //if (storeid.length == 0)
    //    storeid = 3;

    $.post("/Tasks/Tasks/AddTask", { Title: title, DueDate: duedate},
          function (data) { });
    document.getElementById('TaskAdded').innerHTML = title + " was added.";
    document.getElementById('Title').value = "";
    document.getElementById('DueDate').value = "";
    //document.getElementById('SelectedItemId')[1].selected = true;
}