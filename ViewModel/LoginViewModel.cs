using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiAppToDo.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiAppToDo.ViewModel
{
    public partial class LoginViewModel : ObservableObject
    {

        //Le context de la base de données
        private readonly Data.AppDbContext _context;

        // Propriétés liées à l'interface utilisateur
        [ObservableProperty]
        private string userName;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private string errorMessage;

        //Commande
        public ICommand LoginCommand { get; }


        // Constructeur
        public LoginViewModel(Data.AppDbContext context)
        {
            _context = context;
            LoginCommand = new AsyncRelayCommand(Login);
        }

        private async Task Login()
        {
            // Validation des champs
            if (string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(Password))
            {
                ErrorMessage = "Veuillez entrer un nom d'utilisateur et un mot de passe.";
                return;
            }

            try
            {
                var user = _context.User
                    .FirstOrDefault(u => u.Username == UserName && u.Password == Password);

                if (user != null)
                {
                    await Shell.Current.GoToAsync("//Tasks");
                }
                else
                {
                    ErrorMessage = "Nom d'utilisateur ou mot de passe incorrect.";
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = "Erreur lors de la connexion à la base de données : " + ex;
            }
        }
    }
}
