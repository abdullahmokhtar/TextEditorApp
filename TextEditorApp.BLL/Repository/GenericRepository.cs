using Microsoft.EntityFrameworkCore;
using TextEditorApp.BLL.Interface;
using TextEditorApp.DAL.Context;

namespace TextEditorApp.BLL.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext context;

        public GenericRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(T entity) => await context.Set<T>().AddAsync(entity);

        public void Delete(T entity) => context.Set<T>().Remove(entity);

        public async Task<IReadOnlyList<T>> GetAllAsync() => await context.Set<T>().ToListAsync();

        public async Task<T> GetByIdAsync(int? id) => await context.Set<T>().FindAsync(id);

        public void Update(T entity) => context.Set<T>().Update(entity);
    }
}
