using MediatR;

namespace CropCommander.Common.Queries.Field;

public class FieldNameExistsQuery : IRequest<bool>
{
    public string FieldName { get; }

    public FieldNameExistsQuery(string fieldName)
    {
        FieldName = fieldName;
    }
}