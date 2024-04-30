using _253504_Antikhovitch.Application.ParticipantUseCases.Queries;
using _253504_Antikhovitch.Application.ParticipantUseCases.Queries.Get;
using _253504_Antikhovitch.Application.TeamUseCases.Queries;
using _253504_Antikhovitch.Application.TeamUseCases.Queries.Get;
using _253504_Antikhovitch.UI.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using static System.Reflection.Metadata.BlobBuilder;

namespace _253504_Antikhovitch.UI.ViewModels;

public partial class TeamsViewModel : ObservableObject
{
    private readonly IMediator _mediator;

    public TeamsViewModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    public ObservableCollection<Team> Teams { get; set; } = new();

    public ObservableCollection<Participant> Participants { get; set; } = new();

    [ObservableProperty]
    Participant selectedParticipant;

    [ObservableProperty]
    Team selectedTeam;

    [RelayCommand]
    async Task UpdateTeamList() =>  await GetTeams();

    [RelayCommand]
    async Task UpdateParticipantsList() => await GetParticipants();

    [RelayCommand]
    async Task ShowDetails(Participant participant) => await GotoDetailsPage(participant);

    [RelayCommand]
    async Task AddNewTeam() => await AddTeam();

    [RelayCommand]
    async Task AddNewParticipant() => await AddParticipant();


    public async Task GetTeams()
    {
        var teams = await _mediator.Send(new GetAllTeamsRequest());

        await MainThread.InvokeOnMainThreadAsync(() =>
        {
            Teams.Clear();

            foreach (var team in teams)
            {
                Teams.Add(team);
            }
        });
    }

    public async Task GetParticipants()
    {
        if (SelectedTeam != null)
        {
            var participants = await _mediator.Send(new GetParticipantsByTeamRequest(SelectedTeam.Id));

            if (participants != null)
            {

                await MainThread.InvokeOnMainThreadAsync(() =>
                {
                    Participants.Clear();

                    foreach (var participant in participants)
                    {
                        Participants.Add(participant);
                    }
                });
            }
        }
        else
        {
            Participants.Clear();
        }
    }

    private async Task GotoDetailsPage(Participant participant)
    {
        IDictionary<string, object> parameters = new Dictionary<string, object>()
        {
            { "Participant", participant }
        };
        await Shell.Current.GoToAsync(nameof(ParticipantDetailsPage), parameters);
    }

    public async Task AddTeam()
    {
        await Shell.Current.GoToAsync(nameof(AddNewTeamPage));
    }

    public async Task AddParticipant()
    {
        await Shell.Current.GoToAsync(nameof(AddNewParticipantPage)); ;
    }


}