﻿using Questioner.Repository.Contexts;

namespace Questioner.WebApi.Services
{
    public interface IContextService
    {
        Context GetContext();
    }
}
