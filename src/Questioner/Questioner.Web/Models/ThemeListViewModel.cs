using System.ComponentModel;
using System.Linq;
using Questioner.Repository.Classes.Entities;

namespace Questioner.Web.Models
{
    public class ThemeListViewModel
    {
        public ThemeListViewModel()
        {            
        }

        public ThemeListViewModel(Theme theme)
        {
            this.Id = theme.Id;
            this.Name = theme.Name;
            this.TopicsQuantity = theme.Topics.Count;
            this.QuestionsQuantity = 0;
        }

        public long Id { get; set; }
        public string Name { get; set; }

        [DisplayName("Topics")]
        public int TopicsQuantity { get; set; }
        
        [DisplayName("Questions")]
        public int QuestionsQuantity { get; set; }
    }
}