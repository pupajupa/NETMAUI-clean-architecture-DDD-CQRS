using _253504_Antikhovitch.Application.TeamUseCases.Queries.Add;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Antikhovitch.Application.TeamUseCases.Commands.Add
{
    public class AddTeamHandler : IRequestHandler<AddTeamRequest,Team>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddTeamHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Team> Handle(AddTeamRequest request, CancellationToken cancellationToken)
        {
            Team newTeam = new(request.Name, request.Sport);

            await _unitOfWork.TeamRepository.AddAsync(newTeam,cancellationToken);

            await _unitOfWork.SaveAllAsync();

            return newTeam;
        }
    }
}
