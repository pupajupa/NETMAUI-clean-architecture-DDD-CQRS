using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Antikhovitch.Application.TeamUseCases.Queries.Edit
{
    public sealed record EditTeamRequest(string Name, string Sport,int SelectedTeamId):IRequest<Team>
    {
    }
}
