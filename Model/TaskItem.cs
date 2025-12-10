using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiAppToDo.Data;
using MauiAppToDo.Model;

namespace MauiAppToDo.Model
{
    public partial class TaskItem : ObservableObject
    {
        // Propriétés
        [Key]
        public int IdTask { get; set; }
        [ObservableProperty]
        public string? title;
        [ObservableProperty]
        public string? description;
        [ObservableProperty]
        public Enums.Status status = Enums.Status.ToDo;
        [ObservableProperty]
        public Enums.Priority priority = Enums.Priority.Low;
        [ObservableProperty]
        public DateTime deadLine;



        //Cle Etrangere
        public User? IdUser { get; set; }
        public Workspace? IdWorkspace { get; set; }
    }
}
