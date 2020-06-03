using System.ComponentModel.DataAnnotations;

namespace Questioner.Repository.Classes.Entities
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}