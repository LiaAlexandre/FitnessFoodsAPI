using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessFoods.API.Attributes
{
    public class ApiKeyAttribute : Attribute, IAsyncActionFilter
    {
        private const string ApiKeyName = "api_key";
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            IConfiguration configuration = builder.Build();

            string ApiKey = configuration["Settings:ApiKey"];

            var apiKeyRequest = context.HttpContext.Request.Headers[ApiKeyName];
           
            if (String.IsNullOrEmpty(apiKeyRequest))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "ApiKey não encontrada"
                };
                return;
            }

            if (!ApiKey.Equals(apiKeyRequest))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Acesso não autorizado"
                };
                return;
            }

            await next();
        }


    }
}
