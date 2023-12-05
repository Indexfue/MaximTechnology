namespace Task1.Utility.Networking
{
    public sealed class RandomGenerator
    {
        private readonly HttpClient _client = new HttpClient();
        private readonly Random _random = new Random();

        private readonly string _requestUri = "https://www.randomnumberapi.com/api/v1.0/random?min=0&";

        public async Task<int> GetRandomNumber(int maxValue)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(_requestUri + $"max={maxValue}&count=1");
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    return ConvertToInt(result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Response error: {ex.Message}");
            }
            return _random.Next(0, maxValue);
        }

        private int ConvertToInt(string response)
        {
            List<char> responseList = response.ToCharArray().ToList();
            responseList = responseList.FindAll(Char.IsDigit);
            
            response = String.Join("", responseList);
            
            return Int32.Parse(response);
        }
    }
}