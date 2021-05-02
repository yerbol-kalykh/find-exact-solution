(function () {
    window.QuillFunctions = {
        createQuill: function (quillElement) {
            var options = {
                modules: {
                    toolbar: '#toolbar'
                },
                placeholder: 'Compose a question...',
                readOnly: false,
                theme: 'snow'
            };
            new Quill(quillElement, options);
        },
        getQuillHTML: function (quillControl) {
            return quillControl.__quill.root.innerHTML;
        },
        loadQuillHTMLContent: function (quillElement, quillHTMLContent) {
            return quillElement.__quill.root.innerHTML = quillHTMLContent;
        }
    };
})();