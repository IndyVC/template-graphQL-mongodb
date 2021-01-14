using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Skillz.Models.Companies;
using Skillz.Models.Consultants;
using Skillz.Models.Entities.Accounts;
using Skillz.Models.Entities.Evaluations;
using Skillz.Models.Entities.People;
using Skillz.Models.Entities.Profiles;
using Skillz.Models.Entities.Skills;
using Skillz.Models.Evaluations;
using Skillz.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skillz.Api
{
    public static class StartupExtensions
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            #region Repositories
            services.AddScoped(typeof(IRepository<Company>), typeof(Repository<Company>));
            services.AddScoped(typeof(IRepository<Consultant>), typeof(Repository<Consultant>));
            services.AddScoped(typeof(IRepository<Profile>), typeof(Repository<Profile>));
            services.AddScoped(typeof(IRepository<EvaluationQuestion>), typeof(Repository<EvaluationQuestion>));
            services.AddScoped(typeof(IRepository<EvaluationQuestionGroup>), typeof(Repository<EvaluationQuestionGroup>));
            services.AddScoped(typeof(IRepository<EvaluationQuestionCategory>), typeof(Repository<EvaluationQuestionCategory>));
            services.AddScoped(typeof(IRepository<Account>), typeof(Repository<Account>));
            services.AddScoped(typeof(IRepository<Employee>), typeof(Repository<Employee>));


            services.AddScoped(typeof(IRepository<Skill>), typeof(Repository<Skill>));
            services.AddScoped(typeof(IRepository<SkillProfile>), typeof(Repository<SkillProfile>));
            services.AddScoped(typeof(IRepository<SkillGroup>), typeof(Repository<SkillGroup>));
            #endregion
        }

        public static void RegisterSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo() { Title = "Skillz Api", Version = "v1" });
                c.DescribeAllParametersInCamelCase();
            });
        }

        public static void ConfigureCors(this IApplicationBuilder app)
        {

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

        }

        public static void RegisterAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:ServerSecret"]));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(config => {
                config.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = signingKey,
                    ValidAudience = configuration["JWT:Audience"],
                    ValidIssuer = configuration["JWT:Issuer"]
                };

                config.SaveToken = true;
            });
        }
    }
}
