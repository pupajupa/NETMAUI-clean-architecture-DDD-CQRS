using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Antikhovitch.Persistense.Repository
{
    public abstract class FakeCourseRepository : IRepository<Team>
    {
        List<Team> _teams;
        public FakeCourseRepository()
        {
            _teams = new List<Team>();
            var team = new Team("ATeam", "Football");
            _teams.Add(team);
            team = new Team("BTeam", "Basketball");
            _teams.Add(team);
        }
        public async Task<IReadOnlyList<Team>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return await Task.Run(() => _teams);
        }
        public abstract Task<Team> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<Team, object>>[]? includesProperties);
        public abstract Task<IReadOnlyList<Team>> ListAsync(Expression<Func<Team, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<Team, object>>[]? includesProperties);
        public abstract Task AddAsync(Team entity, CancellationToken cancellationToken = default);
        public abstract Task UpdateAsync(Team entity, CancellationToken cancellationToken = default);
        public abstract Task DeleteAsync(Team entity, CancellationToken cancellationToken = default);
        public abstract Task<Team> FirstOrDefaultAsync(Expression<Func<Team, bool>> filter, CancellationToken cancellationToken = default);
    }
}
