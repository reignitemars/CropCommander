using System.ComponentModel.DataAnnotations;

namespace CropCommander.Website.Models.Field;

public class Field
{
    public Guid Id { get; set; } // Primary Key
    
    [Required(ErrorMessage = "Field Name is required")]
    public string FieldName { get; set; } // Unique Name of the Field
    
    [Required(ErrorMessage = "Field Area is required")]
    public double FieldArea { get; set; } // Area in hectares
    
    [Required(ErrorMessage = "Crop Name is required")]
    public string CropName { get; set; } // Name of the Crop
}