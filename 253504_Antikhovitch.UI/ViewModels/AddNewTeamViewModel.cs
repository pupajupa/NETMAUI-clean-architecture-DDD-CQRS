using _253504_Antikhovitch.Application.TeamUseCases.Commands.Add;
using _253504_Antikhovitch.Application.TeamUseCases.Queries.Add;
using _253504_Antikhovitch.Application.TeamUseCases.Queries.Get;
using _253504_Antikhovitch.UI.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Antikhovitch.UI.ViewModels
{
    public partial class AddNewTeamViewModel : ObservableObject
    {
        private readonly IMediator _mediator;

        public AddNewTeamViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ObservableProperty]
        string name;

        [ObservableProperty]
        string sport;

        [RelayCommand]
        async Task Enter() => await AddTeamToDb();

        private async Task AddTeamToDb()
        {
            Name ??= string.Empty;
            Sport ??= string.Empty;

            await _mediator.Send(new AddTeamRequest(Name.Trim(), Sport.Trim()));

            await Shell.Current.GoToAsync("///TeamsPage");
        }
    }

}
