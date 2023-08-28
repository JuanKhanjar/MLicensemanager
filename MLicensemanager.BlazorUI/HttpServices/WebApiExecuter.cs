using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text;
using MLicensemanager.BusinessCore.Entities;

namespace MLicensemanager.BlazorUI.HttpServices
{
    public class WebApiExecuter : IWebApiExecuter
    {
        private const string apiname = "Group";
        private readonly IHttpClientFactory _httpClientFactory;

        public WebApiExecuter(IHttpClientFactory httpClientFactory)
        {
            this._httpClientFactory = httpClientFactory;
        }
        public async Task<T?> InvokeGet<T>(string relativUrl)
        {
            var httpClient = _httpClientFactory.CreateClient(apiname);
            return await httpClient.GetFromJsonAsync<T>(relativUrl);
        }

        //public async Task<string> InvokeUpdate(string relativeUrl, string data)
        //{
        //    var httpClient = _httpClientFactory.CreateClient(apiname);

        //    var jsonOptions = new JsonSerializerOptions
        //    {
        //        ReferenceHandler = ReferenceHandler.Preserve,
        //        WriteIndented = true // Optional: Makes the serialized JSON more readable for debugging
        //    };

        //    var json = JsonSerializer.Serialize(data, jsonOptions);
        //    var content = new StringContent(json, Encoding.UTF8, "application/json");

        //    var response = await httpClient.PutAsJsonAsync(relativeUrl, content);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var responseJson = await response.Content.ReadAsStringAsync();
        //        var updatedData = JsonSerializer.Deserialize<string>(responseJson, jsonOptions);
        //        return updatedData;
        //    }
        //    else
        //    {
        //        // Handle error
        //        return data;
        //    }
        //}


        //public async Task<string> InvokeUpdate(string relativeUrl, string newName)
        //{
        //    var httpClient = _httpClientFactory.CreateClient(apiname);
        //    var response = await httpClient.PutAsJsonAsync(relativeUrl, newName);
        //    response.EnsureSuccessStatusCode();
        //    string? v = await response.Content.ReadFromJsonAsync<string>();
        //    return v;
        //}
        public async Task<string?> InvokeUpdate(string relativeUrl, string newGroupName)
        {
            var httpClient = _httpClientFactory.CreateClient(apiname);

            try
            {
                var response = await httpClient.PutAsJsonAsync(relativeUrl, newGroupName);
                response.EnsureSuccessStatusCode(); // This will throw an exception for non-success status codes

                // If response status code is successful, parse and return the content
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                // Handle HTTP request exception
                // You can log the exception here if needed
                Console.WriteLine($"HTTP request exception: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                // You can log the exception here if needed
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

    }
}
