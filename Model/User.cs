using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiAppToDo.Model;

namespace MauiAppToDo.Model
{
    public partial class User
    {
        // Propriétés
        [Key]
        public int IdUser { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }

        //Relation 1-N avec Task
        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();

        //Relation 1-N avec Workspace
        public ICollection<Workspace> Workspaces { get; set; } = new List<Workspace>();
    }
}
