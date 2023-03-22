using AutoMapper;
using Questioner.Repository.Entities;
using Questioner.Web.Models;
using System.Linq;

namespace Questioner.Web.Mappers
{
    public class QuestionerMapper : Profile
    {
        public QuestionerMapper()
        {
            CreateMap<Answer, AnswerViewModel>();

            CreateMap<Question, QuestionViewModel>()
                .ForMember(m => m.Answers, opt => opt.MapFrom(src => src.Answers))
                .ForMember(m => m.HowManyChoices, opt => opt.MapFrom(src => (byte)src.Answers.Count(src => src.IsCorrect)));

            CreateMap<Topic, TopicResultViewModel>();

            CreateMap<Topic, TopicDetailViewModel>()
                .ForMember(m => m.QuestionsQuantity, opt => opt.MapFrom(src => src.Questions.Count));

            CreateMap<Theme, ThemeViewModel>()
                .ForMember(m => m.Questions, opt => opt.MapFrom(src => src.Topics.SelectMany(topic => topic.Questions)));

            CreateMap<Theme, ThemeDetailViewModel>()
                .ForMember(m => m.Topics, opt => opt.MapFrom(src => src.Topics));

            CreateMap<Theme, ThemeListViewModel>()
                .ForMember(m => m.TopicsQuantity, opt => opt.MapFrom(src => src.Topics.Count))
                .ForMember(m => m.QuestionsQuantity, opt => opt.MapFrom(src => src.Topics.Sum(topic => topic.Questions.Count)));
        }
    }
}
