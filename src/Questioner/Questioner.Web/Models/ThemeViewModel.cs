using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Questioner.Repository.Classes.Entities;

namespace Questioner.Web.Models
{
    public class ThemeViewModel
    {
        public long Id { get; set; }

        [DisplayName("Theme:")]
        public string Name { get; set; }

        public List<QuestionViewModel> Questions { get; set; }

        public ThemeViewModel()
        {            
        }

        public ThemeViewModel(Theme theme)
        {   
            Id = theme.Id;
            Name = theme.Name;

            Questions = new List<QuestionViewModel>();

            foreach (var question in theme.Topics.SelectMany(topic => topic.Questions))
            {
                Questions.Add(new QuestionViewModel(question));
            }
        }
    }
}