using System.ComponentModel;
using Questioner.Repository.Classes.Entities;
using Questioner.Web.Enums;

namespace Questioner.Web.Models
{
    public class QuestionResultViewModel
    {
        public long Id { get; set; }

        public long TopicId { get; set; }

        [DisplayName("Question")]
        public string QuestionText { get; set; }

        [DisplayName("Correct")]
        public QuestionResultEnum QuestionResult { get; set; }

        public string QuestionResultDescription => QuestionResult.GetDescription();
    }
}