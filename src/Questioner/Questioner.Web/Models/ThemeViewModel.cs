using System.ComponentModel;

namespace Questioner.Web.Models
{
    public class ThemeViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }

        [DisplayName("Topics")]
        public int TopicsQuantity { get; set; }
        
        [DisplayName("Questions")]
        public int QuestionsQuantity { get; set; }
    }
}