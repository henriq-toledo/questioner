using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questioner.Repository.Classes.Entities
{
    [Table("Themes")]
    public class Theme : BaseEntity
    {
        [StringLength(100)]
        public string Name { get; set; }

        public virtual List<Topic> Topics {get;set;}
    }
}