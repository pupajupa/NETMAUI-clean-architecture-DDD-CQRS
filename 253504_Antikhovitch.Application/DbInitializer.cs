using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Antikhovitch.Application
{
    public static class DbInitializer
    {
        public static async Task Initialize(IServiceProvider services)
        {
            var unitOfWork = services.GetRequiredService<IUnitOfWork>();

            await unitOfWork.DeleteDataBaseAsync();
            await unitOfWork.CreateDataBaseAsync();

            await unitOfWork.TeamRepository.AddAsync(new Team("ATeam", "Football"));
            await unitOfWork.TeamRepository.AddAsync(new Team("BTeam", "Basketball"));
            await unitOfWork.TeamRepository.AddAsync(new Team("CTeam", "Hockey"));
            await unitOfWork.SaveAllAsync();

            int i = 1;
            var imageName = "E:\\BSUIR\\2\\NET MAUI\\253504_Antikhovitch\\253504_Antikhovitch.UI\\Resources\\Images\\dotnet_bot.png"; // Assuming dotnet_bot.png is in the same directory
            byte[] imageData = File.ReadAllBytes(imageName);
            for (; i< 10; i++)
            {
                var participant = new Participant(
                    new Participant.Person($"Person {i}", DateTime.Now.AddYears(-Random.Shared.Next(30))),
                    imageData,i);
                participant.AddToTeam(teamId: 1);
                await unitOfWork.ParticipantRepository.AddAsync(participant);
            }

            for (; i < 20; i++)
            {
                var participant = new Participant(
                    new Participant.Person($"Person {i}", DateTime.Now.AddYears(-Random.Shared.Next(30))),
                    imageData, i);
                participant.AddToTeam(teamId: 2);
                await unitOfWork.ParticipantRepository.AddAsync(participant);
            }

            for (; i < 30; i++)
            {
                var participant = new Participant(
                    new Participant.Person($"Person {i}", DateTime.Now.AddYears(-Random.Shared.Next(30))),
                    imageData, i);
                participant.AddToTeam(teamId: 3);
                await unitOfWork.ParticipantRepository.AddAsync(participant);
            }

            await unitOfWork.SaveAllAsync();
        }
    }
}
