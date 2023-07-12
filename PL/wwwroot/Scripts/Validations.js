$(function () {

    // Initialize form validation on the registration form.

    // It has the name attribute "registration"

    $("form[name='registration']").validate({

        // Specify validation rules

        rules: {

            // The key name on the left side is the name attribute

            // of an input field. Validation rules are defined

            // on the right side

            Nombre: "required",


            Contraseña: {

                required: true,

                minlength: 5

            }

        },

        // Specify validation error messages

        messages: {

            Nombre: "Por favor, introduzca su nombre",

            password: {

                required: "Por favor proporcione una contraseña",

                minlength: "Su contraseña debe tener al menos 5 caracteres."

            },

        },

        submitHandler: function (form) {

            form.submit();

        }

    });

});