using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questioner.Repository.Classes.Entities
{
    [Table("Themes")]
    public class Theme : BaseEntity
    {
        [Required]
        [StringLength(100)]
        [JsonProperty(Order = 2)]
        public string Name { get; set; }

        [JsonProperty(Order = 3)]
        public byte PassRate { get; set; }

        [JsonProperty(Order = 4)]
        public virtual List<Topic> Topics { get; set; }
    }
}