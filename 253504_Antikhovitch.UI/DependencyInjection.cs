using _253504_Antikhovitch.UI.Pages;
using _253504_Antikhovitch.UI.ViewModels;

namespace _253504_Antikhovitch.UI
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterPages(this IServiceCollection services)
        {
            services
                .AddTransient<TeamsPage>()
                .AddTransient<ParticipantDetailsPage>()
                .AddTransient<AddNewTeamPage>()
                .AddTransient<AddNewParticipantPage>()
                .AddTransient<EditParticipantPage>();

            return services;
        }

        public static IServiceCollection RegisterViewModels(this IServiceCollection services)
        {
            services
                .AddTransient<TeamsViewModel>()
                .AddTransient<ParticipantDetailsViewModel>()
                .AddTransient<AddNewParticipantViewModel>()
                .AddTransient<AddNewTeamViewModel>()
                .AddTransient<EditParticipantViewModel>();
                

            return services;
        }
    }
}
