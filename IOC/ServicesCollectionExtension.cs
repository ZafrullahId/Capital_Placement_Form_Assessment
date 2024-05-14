using Application.Abstractions;
using Application.Exceptions;
using Application.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Persistence.Auth.Jwt;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC
{
    public static class ServicesCollectionExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped<IChoiceRepository, ChoiceRepository>()
                .AddScoped<IQuestionRepository, QuestionRepository>()
                .AddScoped<ISubmissionRepository, SubmissionRepository>()
                .AddScoped<IFormWindowRepository, FormWindowRepository>()
                .AddScoped<IQuestionTypeRepository, QuestionTypeRepository>()
                .AddScoped<IApplicationProgramRepository, ApplicationProgramRepository>();
        }
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddScoped<IChoiceService, ChoiceService>()
                .AddScoped<IQuestionService, QuestionService>()
                .AddScoped<ISubmissionService, SubmissionService>()
                .AddScoped<IQuestionTypeService, QuestionTypeService>()
                .AddScoped<IApplicationProgramService, ApplicationProgramService>();
        }
        public static IServiceCollection AddJWTAuth(this IServiceCollection services)
        {
            services.AddSingleton<IConfigureOptions<JwtBearerOptions>, ConfigureJwtBearerOptions>();

            return services
                .AddAuthentication(authentication =>
                {
                    authentication.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    authentication.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, null!)
                .Services;
        }
        public static IApplicationBuilder UseGlobalException(this IApplicationBuilder app)
        {
            return app.UseMiddleware<GlobalExceptionMiddleware>();
        }
    }
}
