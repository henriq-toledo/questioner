using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Questioner.Repository.Classes.Entities
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