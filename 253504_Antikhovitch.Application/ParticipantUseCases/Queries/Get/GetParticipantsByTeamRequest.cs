using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Antikhovitch.Application.ParticipantUseCases.Queries.Get
{
    public sealed record class GetParticipantsByTeamRequest(int Id) : IRequest<IEnumerable<Participant>>
    {
    }
}
