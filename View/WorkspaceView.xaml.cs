namespace MauiAppToDo.View;

public partial class WorkspaceView : ContentPage
{
	public WorkspaceView(ViewModel.WorkspaceViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}