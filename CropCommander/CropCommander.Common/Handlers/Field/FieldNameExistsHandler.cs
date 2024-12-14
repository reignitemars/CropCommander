using CropCommander.Common.DataAccess;
using CropCommander.Common.Queries.Field;
using MediatR;

namespace CropCommander.Common.Handlers.Field;

public class FieldNameExistsHandler : IRequestHandler<FieldNameExistsQuery, bool>
{
    private readonly IDataAccess _dataAccess;

    public FieldNameExistsHandler(IDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public async Task<bool> Handle(FieldNameExistsQuery request, CancellationToken cancellationToken)
    {
        return await _dataAccess.FieldNameExistsAsync(request.FieldName);
    }
}