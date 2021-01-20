// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

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

    $("#searchViolation").submit(function (e) {
        e.preventDefault();

        var unindexed_array = $(this).serializeArray();
        var indexed_array = {};
        $.map(unindexed_array, function (n, i) {
            indexed_array[n['name']] = n['value'];
        });

        $.ajax({
            type: "POST",
            url: $(this).attr("action"),
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            data: JSON.stringify(indexed_array),
            success: function (data) {
                AddViolationItems(data.violations);
                $("#violation-counter").text("Найдено результатов: " + data.foundCount + " (" + data.foundOnThisPage + " на этой странице)");
            },
            error: function (data) {
                $(".violations-list-container .violation-not-found").show();
            }
        });
    });

    $("#get-citizen-user-names").on("paste input propertychange", function () {
        $(".user-suggest-temp").remove();

        const thisInput = $(this);

        if (thisInput.val().length != 0) {
            $.ajax({
                type: "GET",
                url: "/api/violation/SearchUsers/" + thisInput.val(),
                success: function (data) {
                    const sample = $(".user-suggestions .user-suggest-example-item");
                    const parent = $(".user-suggestions");
                    for (const item in data) {
                        let clone = sample.clone().toggleClass("user-suggest-example-item user-suggest-temp").show().appendTo(parent);
                        clone.text(data[item]);

                        clone.click(function () {
                            $("#get-citizen-user-names").hide();
                            $("#ready-citizen-user-name").show().find("input").val(data[item]);

                            $("#ready-citizen-user-name a").click(function () {
                                // Cancel
                                $("#get-citizen-user-names").show();
                                $("#ready-citizen-user-name").hide();
                                thisInput.val("");
                            });

                            $(".user-suggest-temp").remove();
                        });
                    }
                }
            });
        }
    });
});

$(document).ready(
    async function () {
        if ($(".violations-list-container .violation-list-item") != null) {
            const respone = await fetch("/api/violation",
                {
                    method: "GET",
                    headers: { "Accept": "application/json" }
                });

            if (respone.ok === true) {
                AddViolationItems(await respone.json());
            }
            else {
                $(".violations-list-container .violation-not-found").show();
            }
        }
    });

function AddViolationItems(data) {
    let cloneSample = $(".violations-list-container .violation-list-item");
    if (cloneSample != null) {
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