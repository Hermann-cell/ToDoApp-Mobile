using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiAppToDo.Model;

namespace MauiAppToDo.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<Model.User> User { get; set; }
        public DbSet<Model.TaskItem> Task { get; set; }
        public DbSet<Model.Workspace> Workspace { get; set; }

        // Constructeur compatible avec l'injection de dépendances
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
