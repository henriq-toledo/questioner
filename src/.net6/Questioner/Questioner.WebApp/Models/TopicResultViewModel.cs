using System.ComponentModel;

namespace Questioner.WebApp.Models
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
    }
}