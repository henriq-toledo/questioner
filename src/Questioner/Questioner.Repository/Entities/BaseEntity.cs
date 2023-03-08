using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Questioner.Repository.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        [JsonProperty(Order = 1)]
        public int Id { get; set; }

        [Timestamp]
        [JsonIgnore]
        public byte[] RowVersion { get; set; }
    }
}