using CommunityToolkit.Mvvm.ComponentModel;
using MauiAppToDo.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppToDo.Model
{
    public partial class Workspace : ObservableObject
    {
        // Propriétés
        [Key]
        public int IdWorkspace { get; set; }

        [ObservableProperty]
        private string? name;

        //Cle Etrangere
        public User? IdUser { get; set; }

        //Relation 1-N avec Task
        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();

    }
}
