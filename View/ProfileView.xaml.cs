namespace MauiAppToDo.View;

public partial class ProfileView : ContentPage
{
	public ProfileView(ViewModel.ProfileViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}