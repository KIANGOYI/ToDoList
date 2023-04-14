using Microsoft.EntityFrameworkCore;
using ToDoList.DataAccess.models;

namespace ToDoList.DataAccess.data
{
    public class ToDoListDbContext: DbContext
    {
        public virtual DbSet<TaskList>? TaskList { get; set; }
        public ToDoListDbContext()
        { }

        public ToDoListDbContext(DbContextOptions<ToDoListDbContext> options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder _Options)
        {
            if (!_Options.IsConfigured)
            {
                _Options.UseSqlServer(
                    "Server=127.0.0.1;Database=dbToDoList;User Id=sa;Password=1234;Encrypt=False;"
                );
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TaskList>(
                entity=>{
                    entity.HasKey(t=>t.Identifiant);
                }
            );
        }
    }
}