using Questioner.Repository.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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

        internal Topic ToEntity()
        {
            return new Topic()
            {
                Name = Name,
                Percentage = Percentage,
                Questions = Questions.Select(question => question.ToEntity()).ToList()
            };
        }
    }
}