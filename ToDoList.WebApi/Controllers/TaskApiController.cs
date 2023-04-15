using Microsoft.AspNetCore.Mvc;
using ToDoList.BusinessLogic.models.redef;
using ToDoList.BusinessLogic.services.Interface;

namespace ToDoList.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskApiController : ControllerBase
    {
        private readonly ITaskListService _iTaskListService;
        public TaskApiController(ITaskListService taskListService)
        {
            _iTaskListService = taskListService;
        }

        [HttpGet, Route("/api/tasks")]
        public async Task<IEnumerable<TaskListRedef>> get(CancellationToken cancellationToken)
        {
            return await _iTaskListService.FindTasksAsync(cancellationToken);
        }

        [HttpGet, Route("/api/tasks/{pageNumber}/{pageSize}")]
        public async Task<IActionResult> getPagination(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            var data = await _iTaskListService.FindTaskPaginationAsync(pageNumber, pageSize, cancellationToken);
            var allData = await _iTaskListService.FindTasksAsync(cancellationToken);
            var response = new {
                Data = data,
                CurrentPage = pageNumber,
                TotalPages = (int)Math.Ceiling((double)allData.Count() / pageSize),
                TotalRecords = allData.Count()
            };
            return Ok(response);
        }

        [HttpPost, Route("/api/task")]
        public async Task<IActionResult> post([FromBody] TaskListRedef data, CancellationToken cancellationToken)
        {
            return Ok(await _iTaskListService.StoreTaskAsync(data, cancellationToken));
        }

        [HttpPut, Route("/api/task")]
        public async Task<IActionResult> put([FromBody] TaskListRedef data, CancellationToken cancellationToken)
        {
            return Ok(await _iTaskListService.ModifyTaskAsync(data, cancellationToken));
        }

        [HttpDelete, Route("/api/task/{id}")]
        public async Task<IActionResult> delete(int id, CancellationToken cancellationToken)
        {
            return Ok(await _iTaskListService.DeleteTaskAsync(id, cancellationToken));
        }
    }
}