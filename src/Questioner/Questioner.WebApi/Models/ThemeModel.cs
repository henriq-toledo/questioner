using Questioner.Repository.Classes.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Questioner.WebApi.Models
{
    public class ThemeModel
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public byte PassRate { get; set; }

        public virtual List<TopicModel> Topics {get;set;}

        internal Theme ToEntity()
        {
            return new Theme()
            {
                Name = Name,
                PassRate = PassRate,
                Topics = Topics.Select(topic => topic.ToEntity()).ToList()
            };
        }
    }
}