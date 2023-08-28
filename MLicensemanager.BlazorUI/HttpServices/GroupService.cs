using Microsoft.Net.Http.Headers;
using MLicensemanager.BusinessCore.Entities;
using System.Text;
using System.Text.Json;

namespace MLicensemanager.BlazorUI.HttpServicesServices
{
    public class GroupService : IGroupService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GroupService(IHttpClientFactory httpClient)
        {
            _httpClientFactory = httpClient;
        }

        public async Task<Group> UpdateGroupNameAsync(Group updatedGroup)
        {
            var httpClient = _httpClientFactory.CreateClient("Group");

            var json = JsonSerializer.Serialize(updatedGroup);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var httpResponseMessage = await httpClient.PutAsync(
                $"api/Customer/{updatedGroup.GroupId}", content); // Replace with your API endpoint

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                // Update was successful, so return the updated group
                var responseContent = await httpResponseMessage.Content.ReadAsStringAsync();
                var updatedGroupResult = JsonSerializer.Deserialize<Group>(responseContent);
                return updatedGroupResult;
            }
            else
            {
                // Handle error and return null or throw an exception
                return null;
            }
        }
    }
}
