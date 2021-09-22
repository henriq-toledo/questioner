using Questioner.Repository.Classes.Entities;
using System.Collections.Generic;
using System.ComponentModel;

namespace Questioner.Web.Models
{
    public class ThemeDetailViewModel
    {
        public long Id { get; set; }

        [DisplayName("Theme:")]
        public string Name { get; set; }

        public List<TopicDetailViewModel> Topics { get; set; }

        public ThemeDetailViewModel()
        {   
        }

        public ThemeDetailViewModel(Theme theme)
        {
            Id = theme.Id;
            Name = theme.Name;

            Topics = new List<TopicDetailViewModel>();

            foreach (var topic in theme.Topics)
            {
                Topics.Add(new TopicDetailViewModel(topic));
            }
        }
    }
}