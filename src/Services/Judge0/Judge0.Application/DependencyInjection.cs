using Microsoft.Extensions.DependencyInjection;

namespace Judge0.Application
{
    public static class DependencyInjection
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ISubmissionAppService, SubmissionAppService>();
        }
    }
}
