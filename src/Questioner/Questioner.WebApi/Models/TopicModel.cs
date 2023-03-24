using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Questioner.WebApi.Models
{
    public class TopicModel
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public byte Percentage { get; set; }

        public virtual List<QuestionModel> Questions { get; set; }
    }
}