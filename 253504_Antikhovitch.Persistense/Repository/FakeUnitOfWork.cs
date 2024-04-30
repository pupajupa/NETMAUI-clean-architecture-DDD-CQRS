using _253504_Antikhovitch.Persistense.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Antikhovitch.Persistense.Repository
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly Lazy<IRepository<Team>> _teamRepository;
        private readonly Lazy<IRepository<Participant>> _participantRepository;

        public FakeUnitOfWork(AppDbContext context)
        {
            _context = context;
            _teamRepository = new Lazy<IRepository<Team>>(() => new EfRepository<Team>(context));
            _participantRepository = new Lazy<IRepository<Participant>>(() => new EfRepository<Participant>(context));
        }
        public IRepository<Team> TeamRepository => _teamRepository.Value;
        public IRepository<Participant> ParticipantRepository => _participantRepository.Value;
        public async Task CreateDataBaseAsync() => await _context.Database.EnsureCreatedAsync();
        public async Task DeleteDataBaseAsync() => await _context.Database.EnsureDeletedAsync();
        public async Task SaveAllAsync() => await _context.SaveChangesAsync();
    }
}
