using _253504_Antikhovitch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Antikhovitch.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        IRepository<Team> TeamRepository { get; }
        IRepository<Participant> ParticipantRepository { get; }
        public Task SaveAllAsync();
        public Task DeleteDataBaseAsync();
        public Task CreateDataBaseAsync();
    }
}
