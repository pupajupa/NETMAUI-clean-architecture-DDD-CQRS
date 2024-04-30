using _253504_Antikhovitch.Application.TeamUseCases.Queries.Delete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Antikhovitch.Application.TeamUseCases.Commands.Delete
{
    public class DeleteTeamHandler : IRequestHandler<DeleteTeamRequest, Team>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTeamHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Team> Handle(DeleteTeamRequest request, CancellationToken cancellationToken)
        {
            Team TeamToDelete = await _unitOfWork.TeamRepository.GetByIdAsync(request.TeamId,cancellationToken);

            await _unitOfWork.TeamRepository.DeleteAsync(TeamToDelete);

            var teamParticipants = await _unitOfWork.ParticipantRepository.ListAsync(p => p.TeamId.Equals(request.TeamId));

            foreach(var teamParticipant in teamParticipants)
            {
                await _unitOfWork.ParticipantRepository.DeleteAsync(teamParticipant);
            }

            await _unitOfWork.SaveAllAsync();

            return TeamToDelete;
        }
    }
}
