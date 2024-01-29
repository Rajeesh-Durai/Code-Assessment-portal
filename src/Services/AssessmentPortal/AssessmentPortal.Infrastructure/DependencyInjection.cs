using AssessmentPortal.Domain.Repositories;
using AssessmentPortal.Infrastructure.Repositories;

namespace AssessmentPortal.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<SkillAssessmentDbContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserAssessmentRepository, UserAssessmentRepository>();
            services.AddScoped<IResultRepository, ResultRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IAssessmentQuestionRepository, AssessmentQuestionRepository>();
            services.AddHealthChecks()
               .AddCheck<DatabaseCheck>("Checking the health status of the database");
        }
    }
}
