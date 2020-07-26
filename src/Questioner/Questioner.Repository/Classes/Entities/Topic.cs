using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Questioner.Repository.Classes.Entities
{
    [Table("Topics")]
    public class Topic : BaseEntity
    {
        [Required]
        [StringLength(100)]
        [JsonProperty(Order = 2)]
        public string Name { get; set; }

        [JsonIgnore]
        public long ThemeId { get; set; }

        [JsonProperty(Order = 3)]
        public byte Percentage { get; set; }

        [JsonIgnore]
        public virtual Theme Theme { get; set; }

        [JsonProperty(Order = 4)]
        public virtual List<Question> Questions { get; set; }
    }
}