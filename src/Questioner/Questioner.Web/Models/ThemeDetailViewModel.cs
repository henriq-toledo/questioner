using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Questioner.Web.Models
{
    public class ThemeDetailViewModel
    {
        public long Id { get; set; }

        [DisplayName("Theme:")]
        public string Name { get; set; }

        public List<TopicDetailViewModel> Topics { get; set; }
    }
}