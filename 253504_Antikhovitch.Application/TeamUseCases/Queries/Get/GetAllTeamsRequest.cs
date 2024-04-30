using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Antikhovitch.Application.TeamUseCases.Queries.Get
{
    public sealed record class GetAllTeamsRequest() : IRequest<IEnumerable<Team>>
    {
    }
}
