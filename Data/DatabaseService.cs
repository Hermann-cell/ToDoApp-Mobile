using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppToDo.Data
{
    public static class DatabaseService
    {
        public static string GetDatabasePath()
        {
            string localPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string basePath = Path.Combine(localPath, "TodoMauiMobile");
            Directory.CreateDirectory(basePath); // Crée le dossier s’il n’existe pas
            return Path.Combine(basePath, "todoMobile.db");
        }

        // Méthode pour initialiser les données de la base de données
        public static void SeedUser(AppDbContext db)
        {
            // Vérifie si un utilisateur existe déjà
            if (!db.User.Any())
            {
                db.User.Add(new Model.User
                {
                    UserName = "admin",
                    Email = "admin@test.com",
                    Password = "123" // pour un vrai projet, hashe le mot de passe !
                });

                db.SaveChanges();
            }
        }
    }
}
