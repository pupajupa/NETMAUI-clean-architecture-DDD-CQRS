using _253504_Antikhovitch.Application.ParticipantUseCases.Queries;
using _253504_Antikhovitch.Application.ParticipantUseCases.Queries.Add;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Antikhovitch.Application.ParticipantUseCases.Commands.Add
{
    public class AddParticipantToTeamHandler : IRequestHandler<AddParticipantToTeamRequest, Participant>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddParticipantToTeamHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Participant> Handle(AddParticipantToTeamRequest request, CancellationToken cancellationToken)
        {
            var participant = new Participant(new Participant.Person(request.Name, request.DateOfBirth), request.Image, request.Points);
            participant.AddToTeam(request.TeamId);
            await _unitOfWork.ParticipantRepository.AddAsync(participant, cancellationToken);
            await _unitOfWork.SaveAllAsync();
            return participant;
        }
    }
}
