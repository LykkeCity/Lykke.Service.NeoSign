using JetBrains.Annotations;
using Lykke.Sdk;
using Lykke.Service.NeoSign.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using AsyncFriendlyStackTrace;
using Lykke.Common.Api.Contract.Responses;

namespace Lykke.Service.NeoSign
{
    [UsedImplicitly]
    public class Startup
    {
        private readonly LykkeSwaggerOptions _swaggerOptions = new LykkeSwaggerOptions
        {
            ApiTitle = "NeoSign",
            ApiVersion = "v1"
        };

        [UsedImplicitly]
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            return services.BuildServiceProvider<AppSettings>(options =>
            {
                options.SwaggerOptions = _swaggerOptions;

  
                options.Logs = logs =>
                {
                    logs.UseEmptyLogging();
                };
            });
        }

        [UsedImplicitly]
        public void Configure(IApplicationBuilder app)
        {
            app.UseLykkeConfiguration(options =>
            {
                options.SwaggerOptions = _swaggerOptions;
                options.DefaultErrorHandler = ex => new ErrorResponse { ErrorMessage = ex.ToAsyncString() };
            });
        }
    }
}
