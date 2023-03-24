using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Questioner.WebApi.Models
{
    public class QuestionModel
    {
        [Required]
        [StringLength(1500)]
        public string QuestionText { get; set; }

        public virtual List<AnswerModel> Answers { get; set; }
    }
}