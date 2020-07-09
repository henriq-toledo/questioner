using System.Collections.Generic;
using System.Linq;
using Questioner.Repository.Classes.Entities;

namespace Questioner.Web.Models
{
    public class QuestionViewModel
    {
        public long Id { get; set; }

        public string QuestionText { get; set; }

        public byte HowManyChoices { get; set; }

        public List<AnswerViewModel> Answers { get; set; }

        public QuestionViewModel()
        {
        }

        public QuestionViewModel(Question question)
        {
            Id = question.Id;
            QuestionText = question.QuestionText;
            HowManyChoices = (byte)question.Answers.Count(a => a.IsCorrect);

            Answers = new List<AnswerViewModel>();

            foreach (var answer in question.Answers)
            {
                Answers.Add(new AnswerViewModel(answer));
            }
        }
    }
}