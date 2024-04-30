using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _253504_Antikhovitch.Application.ParticipantUseCases.Queries.Get;

namespace _253504_Antikhovitch.Application.ParticipantUseCases.Commands.Get
{
    internal class GetParticipantsByTeamHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetParticipantsByTeamRequest, IEnumerable<Participant>>
    {
        public async Task<IEnumerable<Participant>> Handle(GetParticipantsByTeamRequest request, CancellationToken cancellationToken)
        {
            return await unitOfWork.ParticipantRepository.ListAsync(t => t.TeamId.Equals(request.Id), cancellationToken);
        }
    }
}
