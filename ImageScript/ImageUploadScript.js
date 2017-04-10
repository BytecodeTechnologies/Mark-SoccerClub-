$(document).ready(function () {

})

function ClosePopup() {
    document.getElementById('light').style.display = 'none';
    document.getElementById('fade').style.display = 'none';

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
function openPopup() {
    document.getElementById('light').style.display = 'block';
    document.getElementById('fade').style.display = 'block';
}
