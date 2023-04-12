using AutoMapper;
using Questioner.Repository.Entities;
using Questioner.WebApp.Models;

namespace Questioner.WebApp.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Answer, AnswerViewModel>();

            CreateMap<Question, QuestionViewModel>()
                .ForMember(dest => dest.Answers, opt => opt.MapFrom(src => src.Answers))
                .ForMember(dest => dest.HowManyChoices, opt => opt.MapFrom(src => (byte)src.Answers.Count(src => src.IsCorrect)));

            CreateMap<Topic, TopicResultViewModel>();

            CreateMap<Topic, TopicDetailViewModel>()
                .ForMember(dest => dest.QuestionsQuantity, opt => opt.MapFrom(src => src.Questions.Count));

            CreateMap<Theme, ThemeViewModel>()
                .ForMember(dest => dest.Questions, opt => opt.MapFrom(src => src.Topics.SelectMany(topic => topic.Questions)));

            CreateMap<Theme, ThemeDetailViewModel>()
                .ForMember(dest => dest.Topics, opt => opt.MapFrom(src => src.Topics));

            CreateMap<Theme, ThemeListViewModel>()
                .ForMember(dest => dest.TopicsQuantity, opt => opt.MapFrom(src => src.Topics.Count))
                .ForMember(dest => dest.QuestionsQuantity, opt => opt.MapFrom(src => src.Topics.Sum(topic => topic.Questions.Count)));
        }
    }
}
