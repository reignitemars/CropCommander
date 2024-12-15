using System.Net.Http.Json;
using FluentValidation;
using Field = CropCommander.Common.Models.Field;

namespace CropCommander.Website.Validators;

public class CreateValidator : AbstractValidator<Field>
{
    private readonly HttpClient _httpClient;
    
    public CreateValidator(HttpClient httpClient)
    {
        _httpClient = httpClient;
        
        RuleFor(x => x.FieldName)
            .NotEmpty().WithMessage("Field name is required.");
        
        RuleFor(x => x.FieldName)
            .MustAsync(async (fieldName, _) =>
            {
                var isvalid = !await IsFieldNameExistsAsync(fieldName);
                return isvalid;
            }).WithMessage("Field name must be unique.");

        RuleFor(x => x.CropName)
            .NotEmpty().WithMessage("Crop name is required.");

        RuleFor(x => x.FieldArea)
            .GreaterThan(0).WithMessage("Field area must be greater than 0.");
    }
    
    public Task<bool> ValidateAsync(Field field)
    {
        var validationResult = Validate(field);
        return Task.FromResult(validationResult.IsValid);
    }
    
    private async Task<bool> IsFieldNameExistsAsync(string fieldName)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/field/exists?name={fieldName}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<bool>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while checking field name uniqueness: {ex.Message}");
            return false;  // Treat as not unique if there's an error
        }
    }
    
    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<Field>
            .CreateWithOptions((Field)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };
}