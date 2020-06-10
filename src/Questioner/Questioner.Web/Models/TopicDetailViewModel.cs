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
    }
}