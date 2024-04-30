using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Antikhovitch.Application.TeamUseCases.Queries.Add
{
    public sealed record AddTeamRequest(string Name, string Sport) : IRequest<Team>
    {
    }
}
