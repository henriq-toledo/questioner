namespace Questioner.Web.Models
{
    public class AnswerViewModel
    {
        public long Id { get; set; }
        
        public short OrderId { get; set; }

        public string AnswerText { get; set; }

        public bool IsCorrect { get; set; }

        public bool Selected { get; set; }
    }
}