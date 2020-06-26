using Questioner.Repository.Classes.Entities;

namespace Questioner.Web.Models
{
    public class AnswerViewModel
    {
        public long Id { get; set; }

        public string AnswerText { get; set; }

        public bool Selected { get; set; }

        public AnswerViewModel()
        {
        }

        public AnswerViewModel(Answer answer)
        {
            Id = answer.Id;
            AnswerText = answer.AnswerText;
        }
    }
}