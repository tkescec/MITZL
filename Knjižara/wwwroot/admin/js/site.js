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
                if (!window.File && !window.FileList && !window.FileReader) {
                    alert("You need a browser with file reader support, to use this form properly.");
                    return;
                }

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
        },
        books: {
            delete: function (options) {
                // Options + Defaults
                const settings = $.extend({
                    controller: "Books",
                    action: "Delete",
                    delete_btn: ".delete-btn",
                    show_alert: true,
                    alert_title: "Jesi li siguran?",
                    alert_text: "Nakon što izbrišeš knjigu ista neće biti dostupna. Ako je poželiš obnoviti to možeš na stranici izbrisane knjige!",
                    alert_icon: "error",
                    panel_class: "panel",
                    loading_class: "panel-loading",
                    body_class: "panel-body",
                    loader_class: "panel-loader",
                    loader_html: '<span class="spinner spinner- sm"></span>'
                }, options);

                $(settings.delete_btn).off("click");
                $(settings.delete_btn).on("click", function (e) {
                    e.preventDefault();

                    //Get book Id
                    const bookId = $(this).data("bookId");

                    // Fire panel loader
                    const target = $(this).closest('.' + settings.panel_class);
                    if (!$(target).hasClass(settings.loading_class)) {
                        const targetBody = $(target).find('.' + settings.body_class);
                        const spinnerHtml = '<div class="' + settings.loader_class + '">' + settings.loader_html + '</div>';
                        $(target).addClass(settings.loading_class);
                        $(targetBody).prepend(spinnerHtml);
                    }

                    // Check if Alert box is required
                    if (!settings.show_alert) {
                        // Add code for trigger delete book without warning
                        return false;
                    }

                    createSwal(settings.alert_title, settings.alert_text, settings.alert_icon)
                        .then(function (result) {
                            if (result) {
                                $.ajax({
                                    url: `/Admin/${settings.controller}/${settings.action}`,
                                    data: {
                                        "id": bookId
                                    },
                                    cache: false,
                                    type: "DELETE",
                                    beforeSend: function () {

                                    },
                                    success: function (response) {
                                        if (response.success) {
                                            window.location.assign(response.returnUrl);
                                        }
                                    },
                                    error: function (xhr) {

                                    },
                                    complete: function () {
                                        setTimeout(function () {
                                            $(target).removeClass(settings.loading_class);
                                            $(target).find('.' + settings.loader_class).remove();
                                        }, 2000);
                                    }
                                });
                            } else {
                                $(target).removeClass(settings.loading_class);
                                $(target).find('.' + settings.loader_class).remove();
                            }
                        });
                })
            },
            restore: function (options) {
                // Options + Defaults
                const settings = $.extend({
                    controller: "Books",
                    action: "Restore",
                    restore_btn: ".restore-btn",
                    show_alert: true,
                    alert_title: "Jesi li siguran?",
                    alert_text: "Nakon što obnoviš knjigu ista će biti dostupna!",
                    alert_icon: "error",
                    panel_class: "panel",
                    loading_class: "panel-loading",
                    body_class: "panel-body",
                    loader_class: "panel-loader",
                    loader_html: '<span class="spinner spinner- sm"></span>'
                }, options);

                $(settings.restore_btn).off("click");
                $(settings.restore_btn).on("click", function (e) {
                    e.preventDefault();

                    //Get book Id
                    const bookId = $(this).data("bookId");

                    // Fire panel loader
                    const target = $(this).closest('.' + settings.panel_class);
                    if (!$(target).hasClass(settings.loading_class)) {
                        const targetBody = $(target).find('.' + settings.body_class);
                        const spinnerHtml = '<div class="' + settings.loader_class + '">' + settings.loader_html + '</div>';
                        $(target).addClass(settings.loading_class);
                        $(targetBody).prepend(spinnerHtml);
                    }

                    // Check if Alert box is required
                    if (!settings.show_alert) {
                        // Add code for trigger delete book without warning
                        return false;
                    }

                    createSwal(settings.alert_title, settings.alert_text, settings.alert_icon)
                        .then(function (result) {
                            if (result) {
                                $.ajax({
                                    url: `/Admin/${settings.controller}/${settings.action}`,
                                    data: {
                                        "id": bookId
                                    },
                                    cache: false,
                                    type: "PUT",
                                    beforeSend: function () {

                                    },
                                    success: function (response) {
                                        if (response.success) {
                                            window.location.assign(response.returnUrl);
                                        }
                                    },
                                    error: function (xhr) {

                                    },
                                    complete: function () {
                                        setTimeout(function () {
                                            $(target).removeClass(settings.loading_class);
                                            $(target).find('.' + settings.loader_class).remove();
                                        }, 2000);
                                    }
                                });
                            } else {
                                $(target).removeClass(settings.loading_class);
                                $(target).find('.' + settings.loader_class).remove();
                            }
                        });
                })
            },
            return: function (options) {
                // Options + Defaults
                const settings = $.extend({
                    controller: "Books",
                    action: "Return",
                    return_btn: ".return-btn",
                    show_alert: true,
                    alert_title: "Vraćanje posuđene knjige!",
                    alert_text: "Zakasnina za posuđenu knjigu iznosi:",
                    alert_icon: "info",
                    panel_class: "panel",
                    loading_class: "panel-loading",
                    body_class: "panel-body",
                    loader_class: "panel-loader",
                    loader_html: '<span class="spinner spinner- sm"></span>',
                    returnUrl: ""
                }, options);

                $(settings.return_btn).off("click");
                $(settings.return_btn).on("click", function (e) {
                    e.preventDefault();

                    //Get posudba Id
                    const posudbaId = $(this).data("posudbaId");
                    const zakasnina = $(this).data("zakasnina");
                    const alertText = `${settings.alert_text} ${zakasnina},00 kn`;

                    // Fire panel loader
                    const target = $(this).closest('.' + settings.panel_class);
                    if (!$(target).hasClass(settings.loading_class)) {
                        const targetBody = $(target).find('.' + settings.body_class);
                        const spinnerHtml = '<div class="' + settings.loader_class + '">' + settings.loader_html + '</div>';
                        $(target).addClass(settings.loading_class);
                        $(targetBody).prepend(spinnerHtml);
                    }

                    // Check if Alert box is required
                    if (!settings.show_alert) {
                        // Add code for trigger delete book without warning
                        return false;
                    }

                    createSwal(settings.alert_title, alertText, settings.alert_icon)
                        .then(function (result) {
                            if (result) {
                                $.ajax({
                                    url: `/Admin/${settings.controller}/${settings.action}`,
                                    data: {
                                        "id": posudbaId
                                    },
                                    cache: false,
                                    type: "PUT",
                                    beforeSend: function () {

                                    },
                                    success: function (response) {
                                        if (response.success) {
                                            window.location.assign(settings.returnUrl);
                                        }
                                    },
                                    error: function (xhr) {

                                    },
                                    complete: function () {
                                        setTimeout(function () {
                                            $(target).removeClass(settings.loading_class);
                                            $(target).find('.' + settings.loader_class).remove();
                                        }, 2000);
                                    }
                                });
                            } else {
                                $(target).removeClass(settings.loading_class);
                                $(target).find('.' + settings.loader_class).remove();
                            }
                        });
                })
            }
        }
    });

    function createSwal(alert_title, alert_text, alert_icon) {
        return swal({
            title: alert_title,
            text: alert_text,
            icon: alert_icon,
            buttons: {
                cancel: {
                    text: 'Odustani',
                    value: null,
                    visible: true,
                    className: 'btn btn-default',
                    closeModal: true,
                },
                confirm: {
                    text: 'Da, siguran sam!',
                    value: true,
                    visible: true,
                    className: 'btn btn-danger',
                    closeModal: true
                }
            }
        })
    }
})(jQuery);