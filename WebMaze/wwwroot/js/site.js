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

$(document).ready(
    async function () {
        let item = $(".violations-list-container .violation-list-item");
        if (item != null) {
            const respone = await fetch("/api/violation",
                {
                    method: "GET",
                    headers: { "Accept": "application/json" }
                });

            if (respone.ok === true) {
                const viols = await respone.json();

                let sample = item.clone();
                let parent = $(".violations-list-container");

                for (const viol of viols) {
                    let clone = sample.clone().appendTo(parent);
                    AddViolationItem(viol, clone);
                };

                item.remove();
            }
        }
    });

function AddViolationItem(item, sample) {
    sample.find(".violation-user-field").text(item.userName);
    sample.find(".violation-policeman-field").text(item.policemanName);
    sample.find(".violation-date-field").text(new Date(item.date).toLocaleDateString());
    sample.find(".violation-link").attr("href", "/Police/Criminal/" + item.id);
    $('.violation-clickable').toggleClass('violation-clickable').click(function () {
        window.location = '/Police/Criminal/' + item.id;
    });
};