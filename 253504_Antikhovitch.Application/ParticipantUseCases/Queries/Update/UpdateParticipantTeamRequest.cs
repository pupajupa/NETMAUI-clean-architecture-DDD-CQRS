using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Antikhovitch.Application.ParticipantUseCases.Queries.Update
{
    public sealed record UpdateParticipantTeamRequest(string name,DateTime DateOfBirth,byte[] Image,int Points,int SelectedTaskId,int TeamId):IRequest<Participant>
    {
    }
}
