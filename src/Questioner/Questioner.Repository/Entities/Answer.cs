using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questioner.Repository.Entities
{
    [Table("Answers")]
    public class Answer : BaseEntity
    {
        [Required]
        [StringLength(1000)]
        [JsonProperty(Order = 2)]
        public string AnswerText { get; set; }

        [JsonProperty(Order = 3)]
        public bool IsCorrect { get; set; }

        [JsonIgnore]
        public int QuestionId { get; set; }

        [JsonIgnore]
        public virtual Question Question { get; set; }

        [JsonIgnore]
        public virtual List<Link> Links { get; set; }
    }
}