using CropCommander.Common.Commands;
using CropCommander.Common.Models;
using CropCommander.Common.Queries.Field;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CropCommander.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FieldController(IMediator mediator) : ControllerBase
{
    // GET: api/<FieldController>
    [HttpGet]
    public async Task<List<Field>> Get([FromQuery] string? query)
        => await mediator.Send(new GetFieldListQuery(query));
        
    // POST api/<FieldController>
    [HttpPost]
    public async Task<Field> Post([FromBody] Field value) 
        => await mediator.Send(new AddFieldCommand(value.FieldName, value.FieldArea, value.CropName));
        
    [HttpGet("exists")]
    public async Task<bool> FieldNameExistsAsync([FromQuery] string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException("Field name cannot be null or empty.", nameof(name));
        }

        return await mediator.Send(new FieldNameExistsQuery(name));
    }
}