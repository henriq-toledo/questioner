using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Questioner.Repository.Classes.Entities;
using Questioner.WebApi.Defaults;

namespace Questioner.WebApi.Models
{
    public class QuestionModel
    {
        [Required]
        [StringLength(1500)]
        public string QuestionText { get; set; }

        public virtual List<AnswerModel> Answers { get; set; }

        internal Question ToEntity()
        {
            return new Question()
            {
                QuestionText = QuestionText,
                Answers = AnswersSetDefaultIfThereIsNo
            };
        }

        private List<Answer> AnswersSetDefaultIfThereIsNo
            => (Answers?.Count).GetValueOrDefault() > 0
                ? Answers.Select(answer => answer.ToEntity()).ToList()
                : AnswerDefault.NoYes.ToList();
    }
}