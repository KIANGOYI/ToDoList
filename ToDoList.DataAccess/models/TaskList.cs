
namespace ToDoList.DataAccess.models
{
    public class TaskList
    {
        public int Identifiant {set; get;}
        public string? Titre {set; get;}
        public string? Description {set; get;}
        public string? Statut {set; get;}
        // identifiant, titre, description et statut (à faire, en cours, terminé).
    }
}