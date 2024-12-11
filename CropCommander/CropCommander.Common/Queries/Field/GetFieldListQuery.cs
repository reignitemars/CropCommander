using MediatR;

namespace CropCommander.Common.Queries.Field;

public record GetFieldListQuery(string? Query) : IRequest<List<Models.Field>>;