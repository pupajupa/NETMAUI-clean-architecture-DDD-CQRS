using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _253504_Antikhovitch.Application.ParticipantUseCases.Queries.Edit;

namespace _253504_Antikhovitch.Application.ParticipantUseCases.Commands.Edit
{
    public class EditParticipantHandler : IRequestHandler<EditParticipantRequest, Participant>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditParticipantHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Participant> Handle(EditParticipantRequest request, CancellationToken cancellationToken)
        {
            Participant existiningParticipant = await _unitOfWork.ParticipantRepository.GetByIdAsync(request.SelectedTaskId, cancellationToken);

            existiningParticipant.ChangeInfo(new Participant.Person(request.Name, request.DateOfBirth));

            existiningParticipant.ChangePoint(request.Points);

            existiningParticipant.ChangeImage(request.Image);

            await _unitOfWork.ParticipantRepository.UpdateAsync(existiningParticipant, cancellationToken);

            await _unitOfWork.SaveAllAsync();

            return existiningParticipant;
        }
    }
}
