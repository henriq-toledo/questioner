using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questioner.Repository.Classes.Entities
{
    [Table("Questions")]
    public class Question : BaseEntity
    {
        public string QuestionText { get; set; }

        public long Topic_Id { get; set; }

        public virtual Topic Topic { get; set; }

        public List<Link> Links { get; set; }

        public virtual List<Answer> Answers { get; set; }
    }
}