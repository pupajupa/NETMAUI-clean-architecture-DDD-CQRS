    using _253504_Antikhovitch.Application.ParticipantUseCases.Queries.Add;
using _253504_Antikhovitch.Application.TeamUseCases.Queries.Get;
using _253504_Antikhovitch.UI.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace _253504_Antikhovitch.UI.ViewModels
{
    public partial class AddNewParticipantViewModel : ObservableObject
    {
        private readonly IMediator _mediator;

        public AddNewParticipantViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public ObservableCollection<Team> Teams { get; set; } = new();

        [ObservableProperty]
        string name;

        [ObservableProperty]
        DateTime dateOfBirth;

        [ObservableProperty]
        int points;

        ImageSource image;

        public ImageSource Image
        {
            get => image;
            set => SetProperty(ref image, value);
        }
        [ObservableProperty]
        Team? selectedTeam;

        [ObservableProperty]
        int teamId;

        [RelayCommand]
        async Task Enter() => await AddParticipant();

        [RelayCommand]
        async Task UpdateTeamsList() => await GetTeams();

        [RelayCommand]
        async Task SelectFile() => await SelectImage();

        [ObservableProperty]
        byte[] imageByte;

        private async Task AddParticipant()
        {
            if (string.IsNullOrEmpty(Name) || DateOfBirth == default || Points == default || Image == null || SelectedTeam == null)
            {
                await Shell.Current.DisplayAlert("Ошибка", "Вы не заполнили все поля", "Ок");
                return;
            }
            TeamId = SelectedTeam.Id;
            await _mediator.Send(new AddParticipantToTeamRequest(Name, DateOfBirth, Points, ImageByte, TeamId));
            await Shell.Current.GoToAsync("///TeamsPage");
        }

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
                        Image = ImageSource.FromStream(() => new MemoryStream(ImageByte));
                    }
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Ошибка", $"Не удалось загрузить фото: {ex.Message}", "OK");
            }
        }
    }
}
