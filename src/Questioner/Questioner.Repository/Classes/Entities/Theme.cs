using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questioner.Repository.Classes.Entities
{
    [Table("Themes")]
    public class Theme : BaseEntity
    {
        public string Name { get; set; }

        public virtual List<Topic> Topics {get;set;}
    }
}