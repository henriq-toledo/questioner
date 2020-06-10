using System.ComponentModel;

namespace Questioner.Web.Models
{
    public class TopicViewModel
    {
        public string Name { get; set; }

        [DisplayName("Questions")]
        public int QuestionsQuantity { get; set; }
    }
}