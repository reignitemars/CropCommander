using CropCommander.Common.Models;

namespace CropCommander.Common.DataAccess;

public interface IDataAccess
{
    List<Field> GetFields();
    void AddField(Field field);
}