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
        private readonly ILogger<TodoController> _logger;
        private readonly ITodoRepository _todoRepo;
        private readonly IMapper _mapper;

        public TodoController(ILogger<TodoController> logger, ITodoRepository todoRepo, IMapper mapper)
        {
            _logger = logger;
            _todoRepo = todoRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetTodoDto>>> GetTodos()
        {
            var todos = await _todoRepo.GetTodosAsync();
            var toDto = _mapper.Map<List<GetTodoDto>>(todos);
            return toDto;

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetTodoDto>> GetTodo(int id)
        {
            var todo = await _todoRepo.GetTodoByIdAsync(id);

            if (todo == null)
            {
                return NotFound();
            }

            var toDto = _mapper.Map<GetTodoDto>(todo);
            return toDto;
        }

        [HttpPost]
        public async Task<ActionResult> CreateTodo(PostPutTodoDto todo)
        {
            var toEntity = _mapper.Map<Todo>(todo);
            var createdTodo = await _todoRepo.CreateTodoAsync(toEntity);
            var toDto = _mapper.Map<GetTodoDto>(createdTodo);
            return CreatedAtAction(nameof(GetTodo), new { id = createdTodo.TodoId }, toDto);
        }
    }
}