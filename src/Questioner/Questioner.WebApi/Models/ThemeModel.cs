using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Questioner.Repository.Classes.Entities;

namespace Questioner.WebApi.Models
{
    public class ThemeModel
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public virtual List<TopicModel> Topics {get;set;}

        internal Theme ToEntity()
        {
            return new Theme()
            {
                Name = Name,
                Topics = Topics.Select(topic => topic.ToEntity()).ToList()
            };
        }
    }
}