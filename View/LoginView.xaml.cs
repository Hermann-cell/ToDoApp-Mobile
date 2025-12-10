namespace MauiAppToDo.View;

public partial class LoginView : ContentPage
{
	public LoginView(ViewModel.LoginViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}