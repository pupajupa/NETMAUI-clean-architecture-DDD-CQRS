using _253504_Antikhovitch.Application.TeamUseCases.Queries.Edit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Antikhovitch.Application.TeamUseCases.Commands.Edit
{
    public class EditTeamHandler:IRequestHandler<EditTeamRequest,Team>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditTeamHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Team> Handle(EditTeamRequest request, CancellationToken cancellationToken)
        {
            Team existingTeam = await _unitOfWork.TeamRepository.GetByIdAsync(request.SelectedTeamId);

            existingTeam.ChangeName(request.Name);

            existingTeam.ChangeSport(request.Sport);

            existingTeam.Id = request.SelectedTeamId;

            await _unitOfWork.TeamRepository.UpdateAsync(existingTeam, cancellationToken    );

            await _unitOfWork.SaveAllAsync();

            return existingTeam;
        }
    }
}
