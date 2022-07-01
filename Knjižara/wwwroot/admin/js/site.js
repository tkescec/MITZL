(function ($) {
    $.extend({
        images: {
            preview: function (options) {
                // Options + Defaults
                const settings = $.extend({
                    input_field: ".image-input",
                    input_base: ".image-base",
                    input_original: ".image-original",
                    preview_box: ".image-preview",
                    delete_field: ".image-delete",
                    label_field: ".image-label",
                    button_field: ".image-btn",
                    error_field: ".image-error",
                    label_default: "Choose File",
                    label_selected: '<i class="fas fa-redo-alt"></i>zamjeni sliku',
                    no_label: false,
                    success_callback: null,
                }, options);

                // Check if FileReader is available
                if (window.File && window.FileList && window.FileReader) {
                    $(settings.input_field).off("change");
                    $(settings.input_field).on("change", function () {
                        const files = this.files;

                        if (files.length > 0) {
                            const file = files[0];
                            const reader = new FileReader();

                            // Load file
                            reader.addEventListener("load", function (e) {
                                const loadedFile = e.target;

                                // Check format
                                if (file.type.match('image')) {
                                    // Image
                                    $(settings.preview_box).attr('src', loadedFile.result);
                                    $(settings.input_base).val(loadedFile.result);
                                }
                            });

                            // Read the file
                            reader.readAsDataURL(file);
                        }
                    });
                }
                else {
                    alert("You need a browser with file reader support, to use this form properly.");
                    return false;
                }

            }
        }
    });
})(jQuery);