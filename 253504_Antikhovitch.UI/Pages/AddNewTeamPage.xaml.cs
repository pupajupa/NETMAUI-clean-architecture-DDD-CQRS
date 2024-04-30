using _253504_Antikhovitch.UI.ViewModels;

namespace _253504_Antikhovitch.UI.Pages;

public partial class AddNewTeamPage : ContentPage
{
    private readonly AddNewTeamViewModel _viewModel;

    public AddNewTeamPage(AddNewTeamViewModel viewModel)
	{
		InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }
}