namespace SpecFlowZdt.Support
{
    public class ApiHelper
    {
        private readonly HttpClient _httpClient;
        private readonly string _api;

        public ApiHelper()
        {
            _httpClient = new HttpClient();
            _api = "https://localhost:7205/api";
        }

        public async Task<HttpResponseMessage> GetAsync(string endpoint)
        {
            return await _httpClient.GetAsync(endpoint);
        }

        public async Task<HttpResponseMessage> PostAsync(string endpoint, HttpContent content)
        {
            return await _httpClient.PostAsync(endpoint, content);
        }

        public string GetApi()
        {
            return _api;
        }
    }
}
