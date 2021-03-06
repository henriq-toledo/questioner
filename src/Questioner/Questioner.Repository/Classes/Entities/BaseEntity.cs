﻿using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Questioner.Repository.Classes.Entities
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