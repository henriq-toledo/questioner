// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $(".check-box").each(function () {
        $(this).unbind("click").bind("click", function (event) {          

            let answers = event.target.parentNode.parentNode.getElementsByClassName("check-box");
            let answersChecked = 0;
            let answer;

            for (answer of answers) {
                if (answer.checked) {
                    answersChecked++;
                }
            };

            let howManyChoices = event.target.parentNode.parentNode.parentNode.children[0].children[2].getAttribute("value");

            let disableAnswer = howManyChoices == answersChecked;

            if (disableAnswer) {
                for (answer of answers) {
                    if (!answer.checked) {
                        answer.disabled = true;
                    }
                };
            }
            else {
                for (answer of answers) {
                    if (answer.disabled) {
                        answer.disabled = false;
                    }
                };
            }
        });
    });
});