using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questioner.Repository.Entities
{
    [Table("Questions")]
    public class Question : BaseEntity
    {
        [Required]
        [StringLength(1500)]
        [JsonProperty(Order = 2)]
        public string QuestionText { get; set; }

        [JsonIgnore]
        public int TopicId { get; set; }

        [JsonIgnore]
        public virtual Topic Topic { get; set; }

        [JsonIgnore]
        public virtual List<Link> Links { get; set; }

        [JsonProperty(Order = 3)]
        public virtual List<Answer> Answers { get; set; }
    }
}