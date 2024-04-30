using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Antikhovitch.Persistense.Repository
{
    public abstract class FakeParticipantRepository : IRepository<Participant>
    {
        List<Participant> _list = new List<Participant>();
        public FakeParticipantRepository()
        {
            var imageName = "E:\\BSUIR\\2\\NET MAUI\\253504_Antikhovitch\\253504_Antikhovitch.UI\\Resources\\Images\\dotnet_bot.png"; // Assuming dotnet_bot.png is in the same directory
            byte[] imageData = File.ReadAllBytes(imageName);
            for (int i = 1; i <= 2; i++)
            {
                for (int j = 0; j < 10; j++)
                {// Read image file into byte array
                    var participant = new Participant(
                        new Participant.Person($"Participant {i * j + 1}", DateTime.Now.AddYears(-Random.Shared.Next(30))),
                        imageData, // Pass byte array instead of string
                        Random.Shared.Next() * 4);

                    _list.Add(participant);
                }
            }
        }
        public async Task<IReadOnlyList<Participant>> ListAsync(Expression<Func<Participant, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<Participant, object>>[]? includesProperties)
        {
            var data = _list.AsQueryable();
            return data.Where(filter).ToList();
        }
        public abstract Task<IReadOnlyList<Participant>> ListAllAsync(CancellationToken cancellationToken = default);

        public abstract Task<Participant> GetByIdAsync(int id, CancellationToken cancellationToken = default,
           params Expression<Func<Participant, object>>[]? includesProperties);
        public abstract Task AddAsync(Participant entity, CancellationToken cancellationToken = default);
        public abstract Task UpdateAsync(Participant entity, CancellationToken cancellationToken = default);
        public abstract Task DeleteAsync(Participant entity, CancellationToken cancellationToken = default);
        public abstract Task<Participant> FirstOrDefaultAsync(Expression<Func<Participant, bool>> filter, CancellationToken cancellationToken = default);
    } 
}
