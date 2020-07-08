using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questioner.Repository.Classes.Entities
{
    [Table("Questions")]
    public class Question : BaseEntity
    {
        [Required]
        [StringLength(1500)]
        public string QuestionText { get; set; }

        public long TopicId { get; set; }

        public virtual Topic Topic { get; set; }

        public List<Link> Links { get; set; }

        public virtual List<Answer> Answers { get; set; }
    }
}