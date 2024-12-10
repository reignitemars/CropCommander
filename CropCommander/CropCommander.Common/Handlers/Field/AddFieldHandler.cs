using CropCommander.Common.Commands;
using CropCommander.Common.DataAccess;
using MediatR;

namespace CropCommander.Common.Handlers.Field;

public class AddFieldHandler(IDataAccess dataAccess) : IRequestHandler<AddFieldCommand, Models.Field>
{
    public Task<Models.Field> Handle(AddFieldCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(dataAccess.AddField(request.FieldName, request.FieldArea, request.CropName));
    }
}