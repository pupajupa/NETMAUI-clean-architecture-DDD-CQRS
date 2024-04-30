using _253504_Antikhovitch.UI.ViewModels;

namespace _253504_Antikhovitch.UI.Pages;

public partial class ParticipantDetailsPage : ContentPage
{
    private readonly ParticipantDetailsViewModel _viewModel;
    public ParticipantDetailsPage(ParticipantDetailsViewModel viewModel)
	{
		InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
	}
}