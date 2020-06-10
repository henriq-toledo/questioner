using System.Collections.Generic;

namespace Questioner.Web.Models
{
    public class TopicViewModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public byte Percentage { get; set; }

        public List<QuestionViewModel> Questions { get; set; }
    }
}