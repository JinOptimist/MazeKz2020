// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

(function () {
    'use strict';
    window.addEventListener('load', function () {
        var forms = document.getElementsByClassName('needs-validation');
        var validation = Array.prototype.filter.call(forms, function (form) {
            form.addEventListener('submit', function (event) {
                if (form.checkValidity() === false) {
                    event.preventDefault();
                    event.stopPropagation();
                }
                form.classList.add('was-validated');
            }, false);
        });
    }, false);
})();

$(document).ready(function () {
    if ($("#form-validation-errors").children().length != 0) {
        $("#form-validation-errors").children().each(function () {
            const attributeName = $(this).attr('data-valmsg-for').toLowerCase();
            const attibuteValue = $(this).text();

            const inputElement = $('.needs-validation .form-control[name="' + attributeName + '"]');
            inputElement.on("input propertychange", function () {
                $("#invalid-feedback-temp-" + attributeName).remove();
            });
            const clone = '<div class="invalid-feedback" id="invalid-feedback-temp-' + attributeName + '">' + attibuteValue + '</div>';
            inputElement.parent().append(clone);
        });

        $(".needs-validation").toggleClass("was-validated");
    }

    $('.prevent-enter').on('keyup keypress', function (e) {
        var keyCode = e.keyCode || e.which;
        if (keyCode === 13) {
            e.preventDefault();
            return false;
        }
    });

    $("#cancel-get-user").hide().click(function () {
        // Cancel
        $("#get-citizen-user-names").removeAttr('readonly').attr('data-mmsg', 'null').val("").parent().toggleClass('col-md-8 col-md-6');
        $(this).hide();
    });

    // НЕ РАБОТАЕТ без скриптов, объявленные в _PoliceLayout.cshtml
    $('#get-citizen-user-names').autocomplete({
        source: function (request, respone) {
            $.ajax({
                type: "GET",
                url: "/api/violation/SearchUsers/" + $('#get-citizen-user-names').val(),
                success: function (data) {
                    respone($.map(data, function (item) {
                        return {
                            value: item.name,
                            label: (item.name + ' (' + item.login + ' )'),
                            login: item.login
                        }
                    }))
                }
            });
        },
        select: function (event, ui) {
            $('#get-citizen-user-names').attr('readonly', 'true').attr('data-mmsg', ui.item.login).parent().toggleClass('col-md-8 col-md-6');
            $("#cancel-get-user").show();
            $('input[name="blamedUserLogin"]').val(ui.item.login);
        }
    });

    $("#searchViolation :input").change(function (e) {
        const form = $(this).closest('form');
        e.preventDefault();

        const jData = SerializeForm(form);

        $.ajax({
            type: "POST",
            url: form.attr("action"),
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            data: jData,
            success: function (data) {
                AddViolationItems(data.violations);
                $("#violation-counter").text("Найдено результатов: " + data.foundCount + " (" + data.foundOnThisPage + " на этой странице)");
                if (data.violations.length == 0) {
                    $("#violation-counter").text("");
                    $(".violation-not-found").show();
                }
            },
            error: function (data) {
                $(".violation-not-found").show();
            }
        });
    });

    if ($(".violations-list-container .violation-list-item").length != 0) {
        $.get('/api/violation/', function (data) {
            AddViolationItems(data);
            if (data.length == 0) {
                $(".violation-not-found").show();
            }
        });
    }

    $('#makeConfirmModalView').click(function (event) {
        const form = $(this).closest('form');
        const input = $('#get-citizen-user-names');
        if (input.attr('data-mmsg') == 'null' || input.attr('data-mmsg') != form.find('input[name="blamedUserLogin"]').val()) {
            input.attr('data-mmsg', 'null').val('');
        }

        if (form[0].checkValidity() === false) {
            event.preventDefault();
            event.stopPropagation();
        }

        form.addClass('was-validated');
    });

    $('#confirm-add-violation').click(function () {
        const form = $('#add-violation');
        const jData = SerializeForm(form);

        $.ajax({
            type: 'POST',
            url: form.attr('action'),
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            data: jData,
            success: function (data) {
                // TO DO: 
                // Перенаправление на другой View
            },
            error: function () {
                alert('Произошла ошибка');
                location.reload();
            }
        });
    });
});

// Заполнение данных Violations к нужным местам
function AddViolationItems(data) {
    let cloneSample = $(".violations-list-container .violation-list-item");
    if (cloneSample.length != 0) {
        const parent = $(".violations-list-container");

        $(".v-temp-item").remove();

        for (const i in data) {
            const item = data[i];
            let clone = cloneSample.clone().toggleClass("violation-list-item v-temp-item").show().appendTo(parent);
            if (clone.hasClass("violation-clickable")) {
                clone.toggleClass("v-temp-onclick");
            }

            clone.find(".violation-user-field").text(item.userName);
            clone.find(".violation-policeman-field").text(item.policemanName);
            clone.find(".violation-date-field").text(new Date(item.date).toLocaleDateString());
            clone.find(".violation-link").attr("href", "/Police/Criminal/" + item.id);
            $('.v-temp-onclick').toggleClass('v-temp-onclick').click(function () {
                window.location = '/Police/Criminal/' + item.id;
            });
        };

        cloneSample.attr("style", "display: none!important;");
    }
};

function SerializeForm(form) {
    var unindexed_array = form.serializeArray();
    var indexed_array = {};
    $.map(unindexed_array, function (n, i) {
        indexed_array[n['name']] = n['value'];
    });

    return JSON.stringify(indexed_array);
};