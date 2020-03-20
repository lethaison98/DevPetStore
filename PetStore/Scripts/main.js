$(document).ready(function () {
       
    $('#selectImage').click (function () {
        var finder = new CKFinder();

                finder.selectActionFunction = function (url) {
                    $('#linkImage').val(url);
                };
                finder.popup()
            })
        
});

$(document).ready(function () {
    CKEDITOR.replace("noidung");
});