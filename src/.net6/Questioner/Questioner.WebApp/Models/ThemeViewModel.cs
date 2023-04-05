using System.Collections.Generic;
using System.ComponentModel;

namespace Questioner.WebApp.Models
{
    public class ThemeViewModel
    {
        public int Id { get; set; }

        [DisplayName("Theme:")]
        public string Name { get; set; }

        public List<QuestionViewModel> Questions { get; set; }
    }
}