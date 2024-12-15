using CropCommander.Common.Models;

namespace CropCommander.Common.DataAccess;

public interface IDataAccess
{
    List<Field> GetFields();
    Field AddField(string fieldName, double fieldArea, string cropName);
    Task<bool> FieldNameExistsAsync(string fieldName);
}