$(document).ready(function() {
   
    $('#add-number').click(function(e) {
        console.log("test");
        e.preventDefault();
        $('<label for="newNumber">To:</label><input type="text" name="formNum" /> <br/>').appendTo('#output');

    });
});