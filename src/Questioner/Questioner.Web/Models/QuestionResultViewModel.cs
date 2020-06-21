using System.ComponentModel;

namespace Questioner.Web.Models
{
    public class QuestionResultViewModel
    {
        public long Id { get; set; }
        
        [DisplayName("Question")]
        public string QuestionText { get; set; }
        
        [DisplayName("Correct")]
        public bool IsCorrect { get; set; }
    }
}