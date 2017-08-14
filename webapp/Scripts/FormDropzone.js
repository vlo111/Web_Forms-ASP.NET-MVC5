Dropzone.options.myDropzone = {
    addRemoveLinks: true,
    init: function () {
        this.on("success", function (file, responseText) {
            // Handle the responseText here. For example, add the text to the preview element:
            file.previewTemplate.appendChild(document.createTextNode(responseText));
        });
    }
};

Dropzone.autoDiscover = false;
$("#ImageDropzone").dropzone({
    maxFiles: 1,
    acceptedFiles: ".png,.jpg,.gif",
    addRemoveLinks: true,
    removedfile: function (file) {
        var name = file.name.substring(0, file.name.length - 4);
        $.ajax({
            type: 'POST',
            url: 'Images/delete',
            data: "name=" + name,
            dataType: 'html'
        });
        var _ref;
        return (_ref = file.previewElement) != null ? _ref.parentNode.removeChild(file.previewElement) : void 0;
    },
    maxFilesize: 2,
    dictDefaultMessage: '<span class="text-center"><span class="font-lg visible-xs-block visible-sm-block visible-lg-block"><span class="font-lg"><i class="fa fa-caret-right text-danger"></i> Drop files <span class="font-xs">to upload</span></span><span>&nbsp&nbsp<h4 class="display-inline"> (Or Click)</h4></span>',
    dictResponseError: 'Error uploading file!'
});

Dropzone.autoDiscover = false;
$("#FileDropzone").dropzone({
    //url: "/file/post",
    acceptedFiles: ".png,.jpg,.gif,.pdf,.txt",
    addRemoveLinks: true,
    removedfile: function (file) {
        var name = file.name.substring(0, file.name.length - 4);

        $.ajax({
            type: 'POST',
            url: 'Files/delete',
            data: "name=" + name,
            dataType: 'html'
        });
        var _ref;
        return (_ref = file.previewElement) != null ? _ref.parentNode.removeChild(file.previewElement) : void 0;
    },
    maxFilesize: 5,
    dictDefaultMessage: '<span class="text-center"><span class="font-lg visible-xs-block visible-sm-block visible-lg-block"><span class="font-lg"><i class="fa fa-caret-right text-danger"></i> Drop files <span class="font-xs">to upload</span></span><span>&nbsp&nbsp<h4 class="display-inline"> (Or Click)</h4></span>',
    dictResponseError: 'Error uploading file!'
});