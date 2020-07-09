using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questioner.Repository.Classes.Entities
{
    [Table("Answers")]
    public class Answer : BaseEntity
    {
        [Required]
        [StringLength(1000)]
        public string AnswerText { get; set; }

        public bool IsCorrect { get; set; }

        public long Question_Id { get; set; }

        public virtual Question Question { get; set; }

        public List<Link> Links { get; set; }
    }
}