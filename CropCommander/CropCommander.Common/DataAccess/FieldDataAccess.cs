using System.Data;
using CropCommander.Common.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CropCommander.Common.DataAccess;

public class FieldDataAccess : IDataAccess
{
    private readonly ApplicationDbContext _context;

    public FieldDataAccess(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public List<Field> GetFields() 
        => _context.Fields.ToList();

    public Field AddField(string fieldName, double fieldArea, string cropName)
    {
        try
        {
            var field = new Field { CropName = cropName, FieldName = fieldName, FieldArea = fieldArea };
            
            _context.Fields.Add(field);
            _context.SaveChanges();

            return field;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Error adding the field to the database.", ex);
        }
    }
    
    public async Task<bool> FieldNameExistsAsync(string fieldName)
        => await _context.Fields.AnyAsync(f => f.FieldName.ToLower() == fieldName.ToLower());
}
