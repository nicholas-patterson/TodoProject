using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TodoProject.Application.Abstractions;
using TodoProject.Application.Models;
using TodoProject.Domain.Entities;

namespace TodoProject.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;
        private readonly IMapper _mapper;

        public TodoController(ITodoService todoService, IMapper mapper)
        {
            _todoService = todoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetTodoDto>>> GetTodos()
        {
            var todos = await _todoService.GetTodos();
            var toDto = _mapper.Map<List<GetTodoDto>>(todos);
            return toDto;

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GetTodoDto>> GetTodo(int id)
        {
            var todo = await _todoService.GetTodoById(id);

            if (todo == null)
            {
                return NotFound();
            }

            var toDto = _mapper.Map<GetTodoDto>(todo);
            return toDto;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTodo(PostPutTodoDto todo)
        {
            var toEntity = _mapper.Map<Todo>(todo);
            var createdTodo = await _todoService.CreateTodo(toEntity);
            var toDto = _mapper.Map<GetTodoDto>(createdTodo);
            return CreatedAtAction(nameof(GetTodo), new { id = createdTodo.TodoId }, toDto);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateTodo(PostPutTodoDto todo, int id)
        {
            var toEntity = _mapper.Map<Todo>(todo);
            var updatedTodo = await _todoService.UpdateTodo(id, toEntity);

            if (updatedTodo == null)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> RemoveTodo(int id)
        {
            var todo = await _todoService.RemoveTodo(id);

            if (todo == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}