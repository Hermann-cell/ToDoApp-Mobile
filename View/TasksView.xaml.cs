namespace MauiAppToDo.View;

public partial class TasksView : ContentPage
{
	public TasksView(ViewModel.TasksViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}