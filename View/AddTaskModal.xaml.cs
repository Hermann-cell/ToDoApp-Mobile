namespace MauiAppToDo.View;

public partial class AddTaskModal : ContentPage
{
    public  AddTaskModal(ViewModel.AddTaskModalViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}