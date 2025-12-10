namespace MauiAppToDo.View;

public partial class StatisticView : ContentPage
{
	public StatisticView(ViewModel.StatisticViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}