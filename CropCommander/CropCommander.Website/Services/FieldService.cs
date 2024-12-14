using System.Net.Http.Json;
using CropCommander.Common.Models;

namespace CropCommander.Website.Services;

public class FieldService
{
    private readonly HttpClient _httpClient;

    public FieldService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Field>?> GetFieldsAsync(string queryText)
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<List<Field>>($"api/field?query={queryText}");
            return response;
        }
        catch (Exception ex)
        {
            return [];
        }
    }

    public async Task AddFieldAsync(Field field)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("api/field", field);
            response.EnsureSuccessStatusCode();
            await response.Content.ReadFromJsonAsync<Field>();
        }
        catch (Exception ex)
        {
            // ignored
        }
    }
}