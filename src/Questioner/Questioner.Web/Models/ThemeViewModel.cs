using Questioner.Repository.Classes.Entities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Questioner.Web.Models
{
    public class ThemeViewModel
    {
        public int Id { get; set; }

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