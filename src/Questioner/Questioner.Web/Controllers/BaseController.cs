using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Questioner.Repository.Interfaces;

namespace Questioner.Web.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IContext context;
        private readonly ILogger<BaseController> logger;

        public BaseController(ILogger<BaseController> logger, IContext context)
        {
            this.context = context;
            this.logger = logger;
        }
    }
}