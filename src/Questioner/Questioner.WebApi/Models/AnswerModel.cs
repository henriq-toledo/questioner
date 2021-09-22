using Questioner.Repository.Classes.Entities;
using System.ComponentModel.DataAnnotations;

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