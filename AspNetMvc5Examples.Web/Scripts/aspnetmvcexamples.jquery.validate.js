(function () {
    "use strict";

    // Override default functionality
    $.validator.methods.number = function (value, element) {
        return this.optional(element) || /^-?(?:\d+|\d{1,3}(?:[\s,]\d{3})+)(?:[\,.]\d+)?$/.test(value);
    };

    $.validator.methods.date = function (value, element) {
        return this.optional(element) ||
            /^\d{1,2}\.\d{1,2}\.\d{4}$/.test(value) ||
            /^\d{1,2}\.\s\d{1,2}\.\s\d{4}$/.test(value) ||
            /^\d{1,2}\/\d{1,2}\/\d{4}$/.test(value);
    };

    // Add customgreaterthan jquery validation
    $.validator.addMethod("greaterthan", function (value, element, params) {
        return parseInt(value) > parseInt($(params).val());
    });

    $.validator.unobtrusive.adapters.add("greaterthan", ["otherpropertyname"], function (options) {
        options.rules["greaterthan"] = "#" + options.params.otherpropertyname;
        options.messages["greaterthan"] = options.message;
    });
})();