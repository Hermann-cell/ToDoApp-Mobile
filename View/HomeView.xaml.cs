
namespace MauiAppToDo.View;

public partial class HomeView : ContentPage
{
    public  HomeView(ViewModel.HomeViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;

    }
}