using ToDoList.BusinessLogic.models.redef;
using ToDoList.BusinessLogic.services.Interface;
using ToDoList.DataAccess.data;
using ToDoList.DataAccess.models;

namespace ToDoList.BusinessLogic.services.business
{
    public class TaskListService: ITaskListService
    {
        private readonly ToDoListDbContext _dbContext;
        public TaskListService(ToDoListDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TaskListRedef>> FindTasks(CancellationToken cancellationToken)
        {
            List<TaskListRedef>  tasks = (_dbContext.TaskList.Select(t=> new TaskListRedef(){
                Identifiant = t.Identifiant,
                Titre = t.Titre,
                Description = t.Description,
                Statut = t.Statut
            })).ToList();
            return tasks;
        }
        public async Task<TaskListRedef?> FindTaskById(int id, CancellationToken cancellationToken)
        {
            TaskListRedef?  task = _dbContext.TaskList.Where(t=>t.Identifiant == id).Select(t=> new TaskListRedef(){
                Identifiant = t.Identifiant,
                Titre = t.Titre,
                Description = t.Description,
                Statut = t.Statut
            }).FirstOrDefault();
            return task;
        }
        public async Task<Boolean> StoreTask(TaskListRedef data, CancellationToken cancellationToken)
        {
            if(data!=null)
            {
                TaskList task = new TaskList(){
                    Identifiant = data.Identifiant,
                    Titre = data.Titre,
                    Description = data.Description,
                    Statut = data.Statut
                };
                var taskResult = await _dbContext.AddAsync<TaskList>(task);
                if(await _dbContext.SaveChangesAsync(cancellationToken) > 0)
                {
                    return true;
                }
                else{
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public async Task<Boolean> ModifyTask(TaskListRedef data, CancellationToken cancellationToken)
        {
            TaskList? task = await _dbContext.TaskList.FindAsync(data.Identifiant);
            if(task != null)
            {
                task.Identifiant = data.Identifiant;
                task.Titre = data.Titre;
                task.Description = data.Description;
                task.Statut = data.Statut;
                var result = _dbContext.Update<TaskList>(task);
                if(await _dbContext.SaveChangesAsync(cancellationToken) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public async Task<Boolean> DeleteTask(int id, CancellationToken cancellationToken)
        {
            TaskList? result = await _dbContext.TaskList.FindAsync(id);
            if(result!=null)
            {
              var DbRemove = _dbContext.Remove(result);
                if(DbRemove != null)
                {
                    await _dbContext.SaveChangesAsync();
                    return true;
                }else{
                    return false;
                }
            }
            return false;
        }
    }
}