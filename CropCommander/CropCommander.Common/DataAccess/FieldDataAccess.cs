using System.Data;
using CropCommander.Common.Models;

namespace CropCommander.Common.DataAccess;

public class FieldDataAccess : IDataAccess
{
    private List<Field> fields = new();

    public FieldDataAccess()
    {
        fields.AddRange([
            new Field { CropName = "Corn", FieldName = "Field A", FieldArea = 50, Id = Guid.NewGuid() },
            new Field { CropName = "Wheat", FieldName = "Field B", FieldArea = 80, Id = Guid.NewGuid() },
            new Field { CropName = "Soybeans", FieldName = "Field C", FieldArea = 60, Id = Guid.NewGuid() }
        ]);
    }

    public List<Field> GetFields() => fields;
    
    public void AddField(Field field) => fields.Add(field);
}