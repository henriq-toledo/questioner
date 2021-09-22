using Questioner.Web.Enums;
using System.Collections.Generic;
using System.ComponentModel;

namespace Questioner.Web.Models
{
    public class ResultViewModel
    {
        public long ThemeId { get; set; }

        [DisplayName("Theme:")]
        public string ThemeName { get; set; }

        [DisplayName("Percentage:")]
        public byte Percentage { get; set; }

        [DisplayName("Result:")]
        public ExamResult ExamResult { get; set; }

        public List<TopicResultViewModel> Topics { get; set; }

        public List<QuestionResultViewModel> Questions { get; set; }
    }
}