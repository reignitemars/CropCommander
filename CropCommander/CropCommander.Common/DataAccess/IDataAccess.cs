using CropCommander.Common.Models;
using Microsoft.VisualBasic.FileIO;

namespace CropCommander.Common.DataAccess;

public interface IDataAccess
{
    List<Field> GetFields();
    Field AddField(string fieldName, double fieldArea, string cropName);
}