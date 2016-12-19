$(document)
    .ready(function () {

        //  password toggler
        var passwordToggler = function (element, field) {
            this.element = element;
            this.field = field;

            this.toggle();
        };

        passwordToggler.prototype = {
            toggle: function () {
                var self = this;
                self.element.addEventListener("change", function () {
                    if (self.element.checked) {
                        self.field.setAttribute("type", "text");
                    } else {
                        self.field.setAttribute("type", "password");
                    }
                }, false);
            }
        };

        //  scroll to top
        $(window).scroll(function () {
            if ($(this).scrollTop() > 50) {
                $("#back-to-top").fadeIn();
            } else {
                $("#back-to-top").fadeOut();
            }
        });

        $("#back-to-top").click(function () {
            $("body,html").animate({
                scrollTop: 0
            }, 800);
            return false;
        });

        //  reset height of fading alerts
        $(".alert")
            .on("animationend webkitAnimationEnd oAnimationEnd MSAnimationEnd",
                function (e) {
                    $(this).css("display", "none");
                });
    });

function setFormValidation(formId) {

    var form = $(`#${formId}`),
        formData = $.data(form[0]),
        settings = formData.validator.settings,
        oldErrorPlacement = settings.errorPlacement,
        oldSuccess = settings.success;

    settings.errorPlacement = function (label, element) {
        oldErrorPlacement(label, element);

        label.parents(".form-group").addClass("has-error");
        label.addClass("text-danger");
    };

    settings.success = function (label) {
        label.parents(".form-group").removeClass("has-error");

        oldSuccess(label);
    };
}