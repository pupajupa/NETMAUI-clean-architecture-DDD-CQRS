using _253504_Antikhovitch.UI.ViewModels;

namespace _253504_Antikhovitch.UI.Pages;

public partial class AddNewParticipantPage : ContentPage
{
    private readonly AddNewParticipantViewModel _viewModel;

    public AddNewParticipantPage(AddNewParticipantViewModel viewModel)
	{
		InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }
}