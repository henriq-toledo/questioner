using System.ComponentModel.DataAnnotations.Schema;

namespace Questioner.Repository.Classes.Entities
{
    [Table("Links")]
    public class Link : BaseEntity
    {
        public string Name { get; set; }
        public string PageLink { get; set; }
    }
}