using _253504_Antikhovitch.Application.ParticipantUseCases.Queries.Delete;

namespace _253504_Antikhovitch.Application.ParticipantUseCases.Commands.Delete
{
    public class DeleteParticipantHandler : IRequestHandler<DeleteParticipantRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteParticipantHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteParticipantRequest request, CancellationToken cancellationToken)
        {
            await _unitOfWork.ParticipantRepository.DeleteAsync(request.Participant, cancellationToken);
            
            await _unitOfWork.SaveAllAsync();
        }
    }
}
