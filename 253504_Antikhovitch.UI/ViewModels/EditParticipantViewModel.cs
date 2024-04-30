using _253504_Antikhovitch.Application.ParticipantUseCases.Queries.Edit;
using _253504_Antikhovitch.Application.ParticipantUseCases.Queries.Update;
using _253504_Antikhovitch.Application.TeamUseCases.Queries.Get;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace _253504_Antikhovitch.UI.ViewModels
{
    [QueryProperty(nameof(Participant), "Participant")]
    public partial class EditParticipantViewModel:ObservableObject
    {
        private readonly IMediator _mediator;

        public EditParticipantViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        public ObservableCollection<Team> Teams{ get; set; } = new();

        [ObservableProperty]
        Participant participant;

        [ObservableProperty]
        string name;

        [ObservableProperty]
        int points;

        [ObservableProperty]
        DateTime dateOfBirth;

        [ObservableProperty]
        byte[] imageByte;

        [ObservableProperty]
        int? teamId;

        [ObservableProperty]
        Team? selectedTeam;

        [ObservableProperty]
        int participantId;

        [RelayCommand]
        async Task Enter() => await EditParticipant();

        [RelayCommand]
        async Task SelectFile() => await SelectImage();

        [RelayCommand]
        async Task UpdateTeams() => await GetTeams();

        private async Task EditParticipant()
        {
            if (string.IsNullOrEmpty(Name) || DateOfBirth == default || Points == default || ImageByte == null || SelectedTeam == null)
            {
                await Shell.Current.DisplayAlert("Ошибка", "Вы не заполнили все поля", "Ок");
                return;
            }
            await _mediator.Send(new EditParticipantRequest(Name, DateOfBirth, ImageByte, Points, ParticipantId));
            var movedBook = await _mediator.Send(
                new UpdateParticipantTeamRequest(Name, DateOfBirth, ImageByte, Points, Participant.Id, SelectedTeam.Id));
            await Shell.Current.GoToAsync("///TeamsPage");
        }

        private async Task SelectImage()
        {
            try
            {
                // Запрос на выбор фото из галереи
                var photo = await MediaPicker.PickPhotoAsync();

                if (photo != null)
                {
                    // Получение потока данных из выбранного фото
                    using (var stream = await photo.OpenReadAsync())
                    {
                        // Преобразование потока в массив байтов
                        byte[] imageData;
                        using (var memoryStream = new MemoryStream())
                        {
                            await stream.CopyToAsync(memoryStream);
                            imageData = memoryStream.ToArray();
                        }
                        ImageByte = imageData;
                        // Установка изображения
                    }
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Ошибка", $"Не удалось загрузить фото: {ex.Message}", "OK");
            }
        }
        private async Task GetTeams()
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

            Name = Participant.PersonalData.Name;
            OnPropertyChanged(nameof(Name));

            DateOfBirth = (DateTime)Participant.PersonalData.DateOfBirth;
            OnPropertyChanged(nameof(DateOfBirth));

            ImageByte = Participant.Image;
            OnPropertyChanged(nameof(ImageByte));

            Points = Participant.Points;
            OnPropertyChanged(nameof(Points));

            ParticipantId = Participant.Id;
            OnPropertyChanged(nameof(ParticipantId));

            TeamId = Participant.TeamId;
            OnPropertyChanged(nameof(TeamId));
            foreach (var item in Teams)
            {
                if (item.Id == TeamId)
                {
                    SelectedTeam = item;
                }
            }
        }

    }
}
