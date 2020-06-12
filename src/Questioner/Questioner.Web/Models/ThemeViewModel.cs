using System.Collections.Generic;
using System.ComponentModel;

namespace Questioner.Web.Models
{
    public class ThemeViewModel
    {
        public long Id { get; set; }

        [DisplayName("Theme:")]
        public string Name { get; set; }

        public List<QuestionViewModel> Questions { get; set; }
    }
}