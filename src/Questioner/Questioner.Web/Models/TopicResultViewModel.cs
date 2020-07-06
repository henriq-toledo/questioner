using System.ComponentModel;
using Questioner.Repository.Classes.Entities;

namespace Questioner.Web.Models
{
    public class TopicResultViewModel
    {
        public long Id { get; set; }

        [DisplayName("Topic")]
        public string Name { get; set; }

        [DisplayName("%")]
        public byte Percentage { get; set; }

        [DisplayName("Result")]
        public byte PercentageAnswered { get; set; }

        public TopicResultViewModel()
        {
        }

        public TopicResultViewModel(Topic topic)
        {
            Id = topic.Id;
            Name = topic.Name;
            Percentage = topic.Percentage;            
        }
    }
}