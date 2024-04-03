using TextEditorApp.BLL.Interface;
using TextEditorApp.DAL.Context;

namespace TextEditorApp.BLL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;

        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
            DocumentRepository = new DocumentRepository(context);
        }
        public IDocumentRepository DocumentRepository { get; set; }

        public async Task<int> CompleteAsync() => await context.SaveChangesAsync();
    }
}
