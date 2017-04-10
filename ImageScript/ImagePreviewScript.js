$(document).ready(function () {
});
function ShowImagePreview(input) {
    alert("ded");
    if (input.files.length > 5) {
        alert("You cannot choose more than 5 images.");
        var fileUpload = $("[id*=UploadImage]");
        var id = fileUpload.attr("id");
        var name = fileUpload.attr("name");
        var newFileUpload = $("<input type = 'file' Multiple='multiple' runat='server' onchange='ShowImagePreview(this);' style='margin-bottom:10px;color:black;'/>");
        fileUpload.after(newFileUpload);
        fileUpload.remove();
        newFileUpload.attr("id", id);
        newFileUpload.attr("name", name);
        $("#ImgPreView").empty();
        return false;
    }
    else {
        if (input.files && input.files[0]) {
            alert("wds");
            $("#ImgPreView").empty();
            for (var i = 0; i < input.files.length; i++) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    //$("#ImgPreView").empty();
                    $("#ImgPreView").append("<img src='" + e.target.result + "' height='120px';width='120px' />")
                };
                reader.readAsDataURL(input.files[i]);
            }
        }
    }
};