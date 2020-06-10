using System.Collections.Generic;

namespace Questioner.Web.Models
{
    public class ThemeViewModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public List<TopicViewModel> Topics { get; set; }
    }
}