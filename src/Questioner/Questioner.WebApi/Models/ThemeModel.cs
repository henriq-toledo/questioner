using System.ComponentModel.DataAnnotations;

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
    }
}