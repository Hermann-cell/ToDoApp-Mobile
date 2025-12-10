using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using MauiAppToDo.Model;

namespace MauiAppToDo.ViewModel
{
    public partial class HomeViewModel : ObservableObject
    {

        [ObservableProperty]
        private ObservableObject currentViewModel;

        [ObservableProperty] private bool isWorkspaceActive;
        [ObservableProperty] private bool isTasksActive;
        [ObservableProperty] private bool isStatisticActive;
        [ObservableProperty] private bool isProfileActive;
        [ObservableProperty] private bool isLogoutActive;

        public ICommand ShowProfileCommand { get; }
        public ICommand ShowStatisticCommand { get; }
        public ICommand ShowTasksCommand { get; }
        public ICommand ShowWorkspaceCommand { get; }
        public ICommand LogoutCommand { get; }

        public HomeViewModel()
        {
            ActivateSection("Workspace");

            ShowWorkspaceCommand = new RelayCommand(() => ActivateSection("Workspace"));
            ShowTasksCommand = new RelayCommand(() => ActivateSection("Tasks"));
            ShowStatisticCommand = new RelayCommand(() => ActivateSection("Statistic"));
            ShowProfileCommand = new RelayCommand(() => ActivateSection("Profile"));
            LogoutCommand = new RelayCommand(() => ActivateSection("Logout"));
        }

        private void ActivateSection(string section)
        {
            IsWorkspaceActive = false;
            IsTasksActive = false;
            IsStatisticActive = false;
            IsProfileActive = false;
            IsLogoutActive = false;

            switch (section)
            {
                case "Workspace":
                    IsWorkspaceActive = true;
                    CurrentViewModel = new WorkspaceViewModel(this); // ✅ passer HomeViewModel
                    break;
                case "Statistic":
                    IsStatisticActive = true;
                    CurrentViewModel = new StatisticViewModel();
                    break;
                case "Profile":
                    IsProfileActive = true;
                    CurrentViewModel = new ProfileViewModel();
                    break;
                case "Logout":
                    IsLogoutActive = true;
                    System.Windows.Application.Current.Shutdown();
                    break;
            }
        }

        // Nouvelle méthode pour afficher les tâches d’un workspace spécifique
        public void ShowTasksForWorkspace(Workspace workspace)
        {
            IsWorkspaceActive = false;
            IsTasksActive = true;
            CurrentViewModel = new TasksViewModel(workspace);
        }
    }
}
