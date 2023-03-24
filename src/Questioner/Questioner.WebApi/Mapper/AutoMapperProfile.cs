using AutoMapper;
using Questioner.Repository.Entities;
using Questioner.WebApi.Defaults;
using Questioner.WebApi.Extensions;
using Questioner.WebApi.Models;
using System.Linq;

namespace Questioner.WebApi.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AnswerModel, Answer>();

            CreateMap<QuestionModel, Question>()
                .ForMember(
                    dest => dest.Answers,
                    opt => opt.MapFrom(src => src.Answers.IsNullOrEmpty() ? AnswerModelDefault.NoYes.ToList() : src.Answers));

            CreateMap<TopicModel, Topic>()
                .ForMember(dest => dest.Questions, opt => opt.MapFrom(src => src.Questions));

            CreateMap<ThemeModel, Theme>()
                .ForMember(dest => dest.Topics, opt => opt.MapFrom(src => src.Topics));
        }
    }
}
