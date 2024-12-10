using CropCommander.Common.DataAccess;
using CropCommander.Common.Queries.Field;
using MediatR;

namespace CropCommander.Common.Handlers.Field;

public class GetFieldListHandler : IRequestHandler<GetFieldListQuery, List<Models.Field>>
{
    private readonly IDataAccess _dataAccess;
    
    public GetFieldListHandler(IDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }
    
    public Task<List<Models.Field>> Handle(GetFieldListQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_dataAccess.GetFields().ToList());
    }
}