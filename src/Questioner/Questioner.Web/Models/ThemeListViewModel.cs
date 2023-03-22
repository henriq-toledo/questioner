using System.ComponentModel;

namespace Questioner.Web.Models
{
    public class ThemeListViewModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        [DisplayName("Pass Rate")]
        public byte PassRate { get; set; }

        [DisplayName("Topics")]
        public int TopicsQuantity { get; set; }
        
        [DisplayName("Questions")]
        public int QuestionsQuantity { get; set; }
    }
}