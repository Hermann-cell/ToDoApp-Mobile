using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

using MauiAppToDo.Data;
using MauiAppToDo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiAppToDo.Data;
using MauiAppToDo.Model;
using ToDoProject.Model;

namespace MauiAppToDo.ViewModel
{
    public partial class WorkspaceViewModel : ObservableObject
    {
        private readonly AppDbContext _context;

        [ObservableProperty]
        private ObservableCollection<Workspace> workspaces;

        [ObservableProperty]
        private Workspace selectedWorkspace;

        [ObservableProperty]
        private string newWorkspaceName;

        [ObservableProperty]
        private string errorMessage;

        public IRelayCommand AddCommand { get; }
        public IRelayCommand EditCommand { get; }
        public IRelayCommand DeleteCommand { get; }
        public IRelayCommand OpenCommand { get; }

        private readonly HomeViewModel _homeViewModel;
        public WorkspaceViewModel(Data.AppDbContext context)
        {
            _context = context;
           
            LoadWorkspaces();
            AddCommand = new RelayCommand(AddWorkspace);
            EditCommand = new RelayCommand(EditWorkspace);
            DeleteCommand = new RelayCommand(DeleteWorkspace);
            OpenCommand = new RelayCommand<Workspace>(OpenWorkspace);
        }

        private void LoadWorkspaces()
        {
            var allWorkspaces = _context.Workspace.ToList();
            Workspaces = new ObservableCollection<Workspace>(allWorkspaces);
        }

        private void AddWorkspace()
        {
            if (string.IsNullOrWhiteSpace(NewWorkspaceName))
            {
                ErrorMessage = "Veuillez remplir tous les champs";
                return;
            }

            try
            {
                var newWorkspace = new Workspace
                {
                    Name = NewWorkspaceName,
                    IdUser = _context.User.FirstOrDefault(u => u.IdUser == 1) // à adapter si nécessaire
                };

                _context.Workspace.Add(newWorkspace);
                _context.SaveChanges();

                Workspaces.Add(newWorkspace);

                // Réinitialisation
                NewWorkspaceName = string.Empty;
                ErrorMessage = string.Empty;
            }
            catch (Exception)
            {
                ErrorMessage = "Échec de l'ajout du workspace.";
            }
        }

        partial void OnSelectedWorkspaceChanged(Workspace value)
        {
            if (value != null)
            {
                NewWorkspaceName = value.Name;
            }
            else
            {
                NewWorkspaceName = string.Empty;
            }
        }

        private void EditWorkspace()
        {
            if (SelectedWorkspace == null)
            {
                ErrorMessage = "Veuillez selectionner un espace de travail";
                return;
            }

            try
            {
                SelectedWorkspace.Name = NewWorkspaceName;

                _context.Workspace.Update(SelectedWorkspace);
                _context.SaveChanges();

                // Optionnel : reset formulaire
                //SelectedWorkspace = null;

                NewWorkspaceName = string.Empty;
            }
            catch (Exception ex)
            {
                ErrorMessage = "Echec de modification";
            }
        }


        private void DeleteWorkspace()
        {
            if (SelectedWorkspace == null)
            {
                ErrorMessage = "Veuillez selectionner un espace de travail";
                return;
            }

            try
            {
                var confirm = MessageBox.Show("Voulez-vous supprimer cet espace de travail ?", "Confirmation", MessageBoxButton.YesNo);
                if (confirm == MessageBoxResult.Yes)
                {
                    _context.Workspace.Remove(SelectedWorkspace);
                    _context.SaveChanges();
                    Workspaces.Remove(SelectedWorkspace);
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = "Echec de suppression";
            }
        }


        private void OpenWorkspace(Workspace workspace)
        {
            if (workspace == null)
                return;

            //  Appelle HomeViewModel pour changer la vue courante
            _homeViewModel.ShowTasksForWorkspace(workspace);
        }
    }
}
