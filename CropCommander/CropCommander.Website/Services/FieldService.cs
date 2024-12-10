using System.Net.Http.Json;
using CropCommander.Website.Models;

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
        //var response = await _httpClient.GetAsync($"api/fields?queryText={Uri.EscapeDataString(queryText)}");
        //response.EnsureSuccessStatusCode();
        //return await response.Content.ReadFromJsonAsync<List<Field>?>();

        return
        [
            new Field { CropName = "Corn", FieldName = "Field A", FieldArea = 50, Id = Guid.NewGuid() },
            new Field { CropName = "Wheat", FieldName = "Field B", FieldArea = 80, Id = Guid.NewGuid() },
            new Field { CropName = "Soybeans", FieldName = "Field C", FieldArea = 60, Id = Guid.NewGuid() }
        ];
    }

    public async Task AddFieldAsync(Field field)
    {
        var response = await _httpClient.PostAsJsonAsync("api/fields", field);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Error adding field");
        }
    }
}