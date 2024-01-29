namespace AssessmentPortal.Infrastructure.Data
{
    public class SkillAssessmentDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public SkillAssessmentDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("Assessment")!;
        }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
