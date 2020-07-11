// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $(".check-box").each(function () {
        $(this).unbind("click").bind("click", function (event) {          

            var answers = event.target.parentNode.parentNode.getElementsByClassName("check-box");
            var answersChecked = 0;            

            for (var i = 0; i < answers.length; i++) {
                var answer = answers[i];

                if (answer.checked) {
                    answersChecked++;
                }
            };

            var howManyChoices = event.target.parentNode.parentNode.parentNode.children[0].children[2].getAttribute("value");

            var disableAnswer = howManyChoices == answersChecked;

            if (disableAnswer) {
                for (var i = 0; i < answers.length; i++) {
                    var answer = answers[i];

                    if (answer.checked == false) {
                        answer.disabled = true;
                    }
                };
            }
            else {
                for (var i = 0; i < answers.length; i++) {
                    var answer = answers[i];

                    if (answer.disabled == true) {
                        answer.disabled = false;
                    }
                };
            }
        });
    });
});