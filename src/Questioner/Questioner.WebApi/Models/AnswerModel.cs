using System;
using System.ComponentModel.DataAnnotations;
using Questioner.Repository.Classes.Entities;

namespace Questioner.WebApi.Models
{
    public class AnswerModel
    {
        [Required]
        [StringLength(1000)]
        public string AnswerText { get; set; }

        public bool IsCorrect { get; set; }

        internal Answer ToEntity()
        {
            return new Answer()
            {
                AnswerText = AnswerText,
                IsCorrect = IsCorrect
            };
        }
    }
}