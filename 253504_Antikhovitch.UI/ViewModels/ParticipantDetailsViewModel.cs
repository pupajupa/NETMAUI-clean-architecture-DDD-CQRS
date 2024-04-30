using _253504_Antikhovitch.Application.ParticipantUseCases.Queries.Delete;
using _253504_Antikhovitch.Application.TeamUseCases.Queries.Get;
using _253504_Antikhovitch.UI.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace _253504_Antikhovitch.UI.ViewModels
{
    [QueryProperty(nameof(Participant), "Participant")]
    public partial class ParticipantDetailsViewModel:ObservableObject
    {
        private readonly IMediator _mediator;

        public ParticipantDetailsViewModel(IMediator mediator)
        {
            _mediator = mediator;

        }

        [ObservableProperty]
        Participant participant;

        [RelayCommand]
        async Task EditParticipant() => await GoToEditParticipantPage();

        [RelayCommand]
        async Task DeleteParticipant() => await DeleteParticipantItem();

        private async Task GoToEditParticipantPage()
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"Participant", Participant }
            };

            await Shell.Current.GoToAsync("///EditParticipantPage", parameters);
        }

        private async Task DeleteParticipantItem()
        {
            var deleteQuery = new DeleteParticipantRequest(Participant);
            await _mediator.Send(deleteQuery);
            await Shell.Current.GoToAsync("//TeamsPage");
        }
    }
}
