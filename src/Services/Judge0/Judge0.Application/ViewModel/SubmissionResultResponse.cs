namespace Judge0.Application.ViewModel
{
    public class SubmissionResultResponse
    {
        public int Language_id { get; set; }
        public string Source_code { get; set; } = string.Empty;
        public string Stdin { get; set; } = string.Empty;
        public string Expected_output { get; set; } = string.Empty;
        public string Stdout { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public string Compile_output { get; set; } = string.Empty;

    }
}
