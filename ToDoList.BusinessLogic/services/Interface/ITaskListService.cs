using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.BusinessLogic.models.redef;

namespace ToDoList.BusinessLogic.services.Interface
{
    public interface ITaskListService
    {
        Task<IEnumerable<TaskListRedef>> FindTasks(CancellationToken cancellationToken);
        Task<TaskListRedef?> FindTaskById(int id, CancellationToken cancellationToken);
        Task<Boolean> StoreTask(TaskListRedef data, CancellationToken cancellationToken);
        Task<Boolean> ModifyTask(TaskListRedef data, CancellationToken cancellationToken);
        Task<Boolean> DeleteTask(int id, CancellationToken cancellationToken);
    }
}