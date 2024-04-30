using _253504_Antikhovitch.UI.Pages;

namespace _253504_Antikhovitch.UI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(TeamsPage), typeof(TeamsPage));
            Routing.RegisterRoute(nameof(ParticipantDetailsPage), typeof(ParticipantDetailsPage));
            Routing.RegisterRoute(nameof(AddNewTeamPage), typeof(AddNewTeamPage));
            Routing.RegisterRoute(nameof(AddNewParticipantPage), typeof(AddNewParticipantPage));
            Routing.RegisterRoute(nameof(EditParticipantPage), typeof(EditParticipantPage));
        }
    }
}
