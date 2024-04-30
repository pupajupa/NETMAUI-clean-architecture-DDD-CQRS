using _253504_Antikhovitch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Antikhovitch.Domain.Abstractions
{
    public interface IRepository<T> where T : Entity
    {
        /// Поиск сущности по Id
        Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[]? includesProperties);
        /// Получение всего списка сущностей
        Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken = default);
        /// Получение отфильтрованного списка 
        Task<IReadOnlyList<T>> ListAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[]? includesProperties);
        /// Добавление новой сущности
        Task AddAsync(T entity, CancellationToken cancellationToken = default);
        /// Изменение сущности
        Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
        /// Удаление сущности
        Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
        /// Поиск первой сущности, удовлетворяющей условию отбора.
        /// Если сущность не найдена, будет возвращено значение по умолчанию
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);
    }
}
