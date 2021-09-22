using Questioner.Repository.Classes.Entities;
using System.ComponentModel;

namespace Questioner.Web.Models
{
    public class TopicDetailViewModel
    {
        public string Name { get; set; }

        [DisplayName("Questions")]
        public int QuestionsQuantity { get; set; }

         [DisplayName("%")]
        public byte Percentage { get; set; }

        public TopicDetailViewModel()
        {            
        }

        public TopicDetailViewModel(Topic topic)
        {
            Name = topic.Name;
            QuestionsQuantity = topic.Questions.Count;
            Percentage = topic.Percentage;
        }
    }
}