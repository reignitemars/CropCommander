using System.Windows.Input;
using CropCommander.Common.Models;
using MediatR;

namespace CropCommander.Common.Commands;

public record AddFieldCommand(string FieldName, double FieldArea, string CropName) : IRequest<Field>
{
    
}