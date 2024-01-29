namespace Judge0.Domain.Model
{
    public class SubmissionResult
    {
        public int? status_id { get; set; }
        public string stdout { get; set; } = string.Empty;
        public string compile_output { get; set; } = string.Empty;
    }
}
