// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $(".check-box").each(function () {
        $(this).unbind("click").bind("click", function (event) {          

            let answers = event.target.parentNode.parentNode.getElementsByClassName("check-box");

            let answersChecked = getAnsweredNumbers(answers);            

            let howManyChoices = event.target.parentNode.parentNode.parentNode.children[0].children[2].getAttribute("value");

            let disableAnswer = howManyChoices == answersChecked;

            if (howManyChoices > 1) {

                if (disableAnswer) {
                    disableAnswers(answers);
                }
                else {
                    enableAnswers(answers);
                }
            }
            else {

                let currentAnswer = event.currentTarget;

                uncheckAnswers(answers, currentAnswer);
            }
        });
    });
});

function getAnsweredNumbers(answers) {

    let answersChecked = 0;    

    for (let answer of answers) {
        if (answer.checked) {
            answersChecked++;
        }
    };

    return answersChecked;
};

function disableAnswers(answers) {

    for(let answer of answers) {
        if (!answer.checked) {
            answer.disabled = true;
        }
    };
}

function enableAnswers(answers) {

    for (let answer of answers) {
        if (answer.disabled) {
            answer.disabled = false;
        }
    };
}

function uncheckAnswers(answers, currentAnswer) {

    for (answer of answers) {
        if (answer.id != currentAnswer.id) {
            answer.checked = false;
        }
    };
}