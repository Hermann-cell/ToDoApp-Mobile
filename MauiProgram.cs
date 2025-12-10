using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using MauiAppToDo.Data;

namespace MauiAppToDo
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            //return builder.Build();

            //Configurer le contexte de la base de données
            string dbPath = DatabaseService.GetDatabasePath();
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite($"Filename={dbPath}"));

            //Enregitrer les viewmodels pour l'injection de dépendances
            builder.Services.AddTransient<ViewModel.LoginViewModel>();
            builder.Services.AddTransient<ViewModel.TasksViewModel>();


            var app = builder.Build();
            //Créer la base si elle n'existe pas (IMPORTANT)
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                db.Database.EnsureCreated();

                // Initialisation des donnnees dans la base de donnees
                DatabaseService.SeedUser(db);
            }

            return app;
        }
    }
}
