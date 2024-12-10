namespace CropCommander.Website.Models;

public class Field
{
    public Guid Id { get; set; } // Primary Key
    public string FieldName { get; set; } // Unique Name of the Field
    public double FieldArea { get; set; } // Area in hectares
    public string CropName { get; set; } // Name of the Crop
}