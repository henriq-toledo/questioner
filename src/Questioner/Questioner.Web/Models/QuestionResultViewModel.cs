using Questioner.Web.Enums;
using System.ComponentModel;

namespace Questioner.Web.Models
{
    public class QuestionResultViewModel
    {
        public long Id { get; set; }

        public long TopicId { get; set; }

        [DisplayName("Question")]
        public string QuestionText { get; set; }

        [DisplayName("Correct")]
        public QuestionResult QuestionResult { get; set; }

        public string QuestionResultDescription => QuestionResult.GetDescription();
    }
}