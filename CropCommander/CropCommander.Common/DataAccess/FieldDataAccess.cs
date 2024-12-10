using System.Data;
using CropCommander.Common.Models;

namespace CropCommander.Common.DataAccess;

public class FieldDataAccess : IDataAccess
{
    private List<Field> _fields = [];

    public FieldDataAccess()
    {
        _fields.AddRange([
            new Field { CropName = "Corn", FieldName = "Field A", FieldArea = 50, Id = Guid.NewGuid() },
            new Field { CropName = "Wheat", FieldName = "Field B", FieldArea = 80, Id = Guid.NewGuid() },
            new Field { CropName = "Soybeans", FieldName = "Field C", FieldArea = 60, Id = Guid.NewGuid() }
        ]);
    }

    public List<Field> GetFields() => _fields;
    
    public Field AddField(string fieldName, double fieldArea, string cropName)
    {
        var field = new Field { CropName = cropName, FieldName = fieldName, FieldArea = fieldArea };
        _fields.Add(field);
        return field;
    }
}