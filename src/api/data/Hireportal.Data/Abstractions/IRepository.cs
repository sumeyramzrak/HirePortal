﻿namespace Hireportal.Data.Abstractions
{
    public interface IRepository<T> where T : EntityBase
    {
        Task<T> Get(Guid id, CancellationToken cancellationToken);
        Task<T> Get(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
        Task<TDto> Get<TDto>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
        Task<List<T>> GetAll(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
        Task<List<TDto>> GetAll<TDto>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
        Task<List<TDto>> GetAll<TDto>(Expression<Func<T, bool>> predicate, Expression<Func<TDto, object>> order, CancellationToken cancellationToken);
        Task<PagedList<T>> GetPagedList(Expression<Func<T, bool>> predicate, PageRequest pageRequest, CancellationToken cancellationToken);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
