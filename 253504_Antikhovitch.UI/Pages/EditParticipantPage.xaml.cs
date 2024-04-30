using _253504_Antikhovitch.UI.ViewModels;

namespace _253504_Antikhovitch.UI.Pages;

public partial class EditParticipantPage : ContentPage
{
    private readonly EditParticipantViewModel _viewModel;

    public EditParticipantPage(EditParticipantViewModel viewModel)
	{
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }


}