using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Antikhovitch.Application.ParticipantUseCases.Queries.Add
{
    public sealed record AddParticipantToTeamRequest(string Name, DateTime DateOfBirth, int Points, byte[] Image, int TeamId) : IRequest<Participant>
    {
    }
}
