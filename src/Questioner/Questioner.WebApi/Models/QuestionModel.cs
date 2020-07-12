using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Questioner.Repository.Classes.Entities;

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
                Answers = Answers.Select(answer => answer.ToEntity()).ToList()
            };
        }
    }
}