using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using _253504_Antikhovitch.Application.ParticipantUseCases.Queries;
using _253504_Antikhovitch.Application.TeamUseCases.Queries.Get;

namespace _253504_Antikhovitch.Application.TeamUseCases.Commands.Get
{
    internal class GetAllTeamsHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllTeamsRequest, IEnumerable<Team>>
    {
        public async Task<IEnumerable<Team>> Handle(GetAllTeamsRequest request, CancellationToken cancellationToken)
        {
            return await unitOfWork.TeamRepository.ListAllAsync(cancellationToken);
        }
    }
}
