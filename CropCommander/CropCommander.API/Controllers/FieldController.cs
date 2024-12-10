using CropCommander.Common.Commands;
using CropCommander.Common.Models;
using CropCommander.Common.Queries.Field;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CropCommander.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FieldController(IMediator mediator) : ControllerBase
    {
        // GET: api/<FieldController>
        [HttpGet]
        public async Task<List<Field>> Get() 
            => await mediator.Send(new GetFieldListQuery());

        // GET api/<FieldController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FieldController>
        [HttpPost]
        public async Task<Field> Post([FromBody] Field value) 
            => await mediator.Send(new AddFieldCommand(value.FieldName, value.FieldArea, value.CropName));
    }
}
