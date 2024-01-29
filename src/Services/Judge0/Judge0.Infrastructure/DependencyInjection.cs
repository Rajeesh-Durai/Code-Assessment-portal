
namespace Judge0.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SubmissionApiSettings>(options =>
            {
                configuration.GetSection("SubmissionApi").Bind(options);
            });
            services.AddScoped<ISubmissionService, SubmissionService>();

        }
    }
}
