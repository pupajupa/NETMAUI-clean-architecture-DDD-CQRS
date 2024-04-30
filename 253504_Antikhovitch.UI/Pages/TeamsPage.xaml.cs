using _253504_Antikhovitch.UI.ViewModels;

namespace _253504_Antikhovitch.UI.Pages;

public partial class TeamsPage : ContentPage
{
    private readonly TeamsViewModel _viewModel;
    public TeamsPage(TeamsViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }
}