using System.Collections.Generic;

namespace Questioner.WebApp.Models
{
    public class QuestionViewModel
    {
        public long Id { get; set; }

        public string QuestionText { get; set; }

        public byte HowManyChoices { get; set; }

        public List<AnswerViewModel> Answers { get; set; }
    }
}