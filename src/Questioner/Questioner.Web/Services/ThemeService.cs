using Questioner.Repository.Classes.Entities;
using Questioner.Web.Repositories;
using System.Threading.Tasks;

namespace Questioner.Web.Services
{
    public class ThemeService : IThemeService
    {
        private readonly IQuestionerRepository questionerRepository;

        public ThemeService(IQuestionerRepository questionerRepository)
        {
            this.questionerRepository = questionerRepository;
        }

        public async Task<Theme[]> GetAllThemes() => await questionerRepository.GetAllThemes();
    }
}
