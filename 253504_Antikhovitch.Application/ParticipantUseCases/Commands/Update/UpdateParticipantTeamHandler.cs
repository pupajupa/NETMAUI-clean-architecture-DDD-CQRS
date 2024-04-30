using _253504_Antikhovitch.Application.ParticipantUseCases.Queries.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Antikhovitch.Application.ParticipantUseCases.Commands.Update
{
    public class UpdateParticipantTeamHandler : IRequestHandler<UpdateParticipantTeamRequest, Participant>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateParticipantTeamHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Participant> Handle(UpdateParticipantTeamRequest request, CancellationToken cancellationToken)
        {
            Participant existingTask = await _unitOfWork.ParticipantRepository.GetByIdAsync(request.SelectedTaskId,cancellationToken);

            existingTask.AddToTeam(request.TeamId);

            await _unitOfWork.ParticipantRepository.UpdateAsync(existingTask);

            await _unitOfWork.SaveAllAsync();

            return existingTask;
        }
    }
}
