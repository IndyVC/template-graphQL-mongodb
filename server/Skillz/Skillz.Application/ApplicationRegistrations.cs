using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Skillz.Application.Dxos;
using System;
using System.Reflection;
using AutoMapper;
using MediatR;

namespace Skillz.Application
{
    public static class ApplicationRegistrations
    {
        public static void RegisterApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetAssembly(typeof(ApplicationRegistrations)));
            services.AddMediatR(Assembly.GetAssembly(typeof(ApplicationRegistrations)));

            #region Dxos
            services.AddScoped<ICompaniesDxos, CompaniesDxos>();
            services.AddScoped<IConsultantsDxos, ConsultantsDxos>();
            services.AddScoped<IProfilesDxos, ProfilesDxos>();
            services.AddScoped<IEvaluationQuestionsDxos, EvaluationQuestionsDxos>();
            services.AddScoped<IEmployeesDxos, EmployeesDxos>();
            services.AddScoped<IAccountDxos, AccountsDxos>();
            services.AddScoped<ISkillsDxos, SkillsDxos>();
            services.AddScoped<ISkillGroupsDxos, SkillGroupsDxos>();
            #endregion

            //services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
            //services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            //services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestPostProcessorBehavior<,>));

            AssemblyScanner.FindValidatorsInAssemblyContaining<Contracts.RequestBase>().ForEach(pair => {
                services.Add(ServiceDescriptor.Transient(pair.InterfaceType, pair.ValidatorType));
                services.Add(ServiceDescriptor.Transient(pair.ValidatorType, pair.ValidatorType));
            });

        }
    }
}
