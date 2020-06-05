using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questioner.Repository.Classes.Entities
{
    [Table("Links")]
    public class Link : BaseEntity
    {
        [StringLength(100)]
        public string Name { get; set; }
        
        [StringLength(300)]
        public string PageLink { get; set; }
    }
}