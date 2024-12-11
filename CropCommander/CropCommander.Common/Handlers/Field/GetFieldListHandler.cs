using CropCommander.Common.DataAccess;
using CropCommander.Common.Queries.Field;
using MediatR;

namespace CropCommander.Common.Handlers.Field;

public class GetFieldListHandler(IDataAccess dataAccess) : IRequestHandler<GetFieldListQuery, List<Models.Field>>
{
    public Task<List<Models.Field>> Handle(GetFieldListQuery request, CancellationToken cancellationToken)
    {
        var fields = dataAccess.GetFields();

        if (string.IsNullOrWhiteSpace(request.Query)) return Task.FromResult(fields);
        var query = request.Query.ToLower();

        fields = fields.Where(f =>
            (f.FieldName?.ToLower().EndsWith(query) ?? false) ||
            (f.CropName?.ToLower().EndsWith(query) ?? false)).ToList();

        return Task.FromResult(fields);
    }
}