using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Text;


namespace Judge0.Infrastructure
{
    public class SubmissionService : ISubmissionService
    {
        public async Task<string> SubmitAsync(Submission submission)
        {
            string apiUrl = "http://192.168.17.49:2358/submissions/?base64_encoded=true&wait=false";

            var postData = submission;

            // Serialize the data to JSON
            string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(postData);

            using (HttpClient client = new HttpClient())
            {
                // Set the content type to JSON
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                // Create the StringContent with JSON data
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                // Send the POST request
                HttpResponseMessage response = client.PostAsync(apiUrl, content).ConfigureAwait(false).GetAwaiter().GetResult();

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as a string
                    string responseContent = Task.Run(() => response.Content.ReadAsStringAsync()).ConfigureAwait(false).GetAwaiter().GetResult();
                    Tokens tokenResponse = JsonConvert.DeserializeObject<Tokens>(responseContent);
                    return tokenResponse.token;
                }
                else
                {
                    throw new Exception("Error submitting the code.");
                }
            }
        }

        public async Task<SubmissionResult> GetResultAsync(string token)
        {
            string apiUrl = $"http://192.168.17.49:2358/submissions/{token}?base64_encoded=true&fields=stdout,status_id,compile_output";

            // Set up HttpClient
            using (HttpClient client = new HttpClient())
            {

                // Send the GET request
                HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as a string
                    string responseContent = response.Content.ReadAsStringAsync().Result;

                    // Deserialize the response content into SubmissionResult
                    SubmissionResult result = JsonConvert.DeserializeObject<SubmissionResult>(responseContent);
                    while (result.status_id == 1|| result.status_id==2)
                    {
                        result =await GetResultAsync(token);
                    }

                    return result;
                }
                else
                {
                    throw new Exception("Error getting submission result.");
                }
            }
        }
    }

}
