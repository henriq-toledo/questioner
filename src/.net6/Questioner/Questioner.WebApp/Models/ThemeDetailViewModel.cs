using System.Collections.Generic;
using System.ComponentModel;

namespace Questioner.WebApp.Models
{
    public class ThemeDetailViewModel
    {
        public long Id { get; set; }

        [DisplayName("Theme:")]
        public string Name { get; set; }

        public List<TopicDetailViewModel> Topics { get; set; }
    }
}