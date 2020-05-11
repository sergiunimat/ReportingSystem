$(function () {
    
    $('#imgInp').on("change", function() {
        var fileSrc = $('#imgInp').val().split("\\").pop();
        console.log(fileSrc);
        $(this).next('#inpPicText').html(fileSrc);

    });
});