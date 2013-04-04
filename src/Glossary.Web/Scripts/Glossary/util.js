AjaxDispatcher = function () {
    var self = this;

    self.send = function (settings) {

        if (!settings.dataType)
            settings.dataType = "json";

        settings.cache = settings.cache || true;

        if (settings.data && !(settings.contentType)) {
            settings.contentType = "application/json";
        }

        if (settings.url && settings.url != "") {

            settings.url = settings.url;

            return $.ajax(settings);
        }
        else {
            var rej = $.Deferred();
            rej.reject({ msg: "Not a valid ajax URL.",
                error: "invalid url"
            });
            return rej;
        }
    };
};