using QuickTrivia.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace QuickTrivia.Services
{
    public class ApiService
    {
        HttpClient client;
        private readonly JsonSerializerOptions jsonOptions;

        public ApiService()
        {
            client = new HttpClient();

            jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<List<Question>> GetQuestionsAsync()
        {
            var url = "https://opentdb.com/api.php?amount=10&category=9&difficulty=easy&type=multiple";
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var apiResponse = await response.Content.ReadFromJsonAsync<TriviaApiResponse>(jsonOptions);

                    if (apiResponse != null && apiResponse.Results != null)
                    {
                        return apiResponse.Results;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Deserialization Error: " + ex.Message);
                }

            }

            return new List<Question>();
        }
    }
}
