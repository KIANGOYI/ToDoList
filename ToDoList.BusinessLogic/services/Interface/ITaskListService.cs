using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.BusinessLogic.models.redef;
using ToDoList.DataAccess.models;

namespace ToDoList.BusinessLogic.services.Interface
{
    public interface ITaskListService
    {
        Task<IEnumerable<TaskListRedef>> FindTasksAsync(CancellationToken cancellationToken);
        Task<IEnumerable<TaskListRedef>?> FindTaskPaginationAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);
        Task<Boolean> StoreTaskAsync(TaskListRedef data, CancellationToken cancellationToken);
        Task<TaskList?> ModifyTaskAsync(TaskListRedef data, CancellationToken cancellationToken);
        Task<Boolean> DeleteTaskAsync(int id, CancellationToken cancellationToken);
    }
}