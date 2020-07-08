using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questioner.Repository.Classes.Entities
{
    [Table("Topics")]
    public class Topic : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public long ThemeId { get; set; }

        public byte Percentage { get; set; }

        public virtual Theme Theme { get; set; }

        public virtual List<Question> Questions { get; set; }
    }
}