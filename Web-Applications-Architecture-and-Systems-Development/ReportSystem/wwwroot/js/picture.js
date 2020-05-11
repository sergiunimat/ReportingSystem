$(function() {
    $('#imgInp').on("change", function() {
        var fileSrc = $('#imgInp').val();
        $('#loadTempImg').attr("src", fileSrc);
    });
});