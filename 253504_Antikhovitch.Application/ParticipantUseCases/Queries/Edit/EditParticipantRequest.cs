using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Antikhovitch.Application.ParticipantUseCases.Queries.Edit
{
    public sealed record EditParticipantRequest(string Name, DateTime DateOfBirth,byte[] Image, int Points, int SelectedTaskId) : IRequest<Participant>
    {
    }
}
