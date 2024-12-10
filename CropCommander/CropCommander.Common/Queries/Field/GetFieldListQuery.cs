using MediatR;

namespace CropCommander.Common.Queries.Field;

public record GetFieldListQuery() : IRequest<List<Models.Field>>;