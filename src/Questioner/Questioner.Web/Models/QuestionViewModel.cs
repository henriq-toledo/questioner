using System.Collections.Generic;

namespace Questioner.Web.Models
{
    public class QuestionViewModel
    {
        public long Id { get; set; }

        public short OrderId { get; set; }

        public string QuestionText { get; set; }

        public List<AnswerViewModel> Answers { get; set; }
    }
}