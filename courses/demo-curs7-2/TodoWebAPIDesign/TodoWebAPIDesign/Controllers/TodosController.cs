using System;
using System.Collections.Generic;
using Fii.BusinessLayer;
using Fii.DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace TodoWebAPIDesign.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodoRepository _repository;

        public TodosController(ITodoRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        public ActionResult<IReadOnlyList<Todo>> Get()
        {
            return Ok(this._repository.GetAll());
        }
        
        [HttpGet("{id}", Name = "GetById")]
        public ActionResult<Todo> Get(Guid id)
        {
            return Ok(this._repository.GetById(id));
        }
        
        [HttpPost]
        public ActionResult<Todo> Post([FromBody] Todo  todo)
        {
            if (todo == null)
            {
                return BadRequest();
            }

            this._repository.Create(todo);

            return CreatedAtRoute("GetById", new {id = todo.Id}, todo);
        }
    }
}