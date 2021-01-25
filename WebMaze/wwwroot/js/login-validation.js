//Будет выполняться ещё до того как загрузилась страница
console.log('1');

$(document).ready(function () {
    //Выполняется только ПОСЛЕ того как загрузилась вся страница
    console.log('2');

    $('input[type=submit]').attr('disabled', 'disabled');

    $('#Login').keyup(function () {
        validateForm();
    });

    $('#Password').keyup(function () {
        validateForm();
    });

    function validateForm() {
        var loginCorrect = $('#Login').val().length > 0;
        var passwordCorrect = $('#Password').val().length > 0;
        if (loginCorrect && passwordCorrect) {
            $('input[type=submit]').removeAttr('disabled');
        } else {
            $('input[type=submit]').attr('disabled', 'disabled');
        }
    }

    
});


//Будет выполняться ещё до того как загрузилась страница
console.log('3');