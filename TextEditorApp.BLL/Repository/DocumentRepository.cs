using TextEditorApp.BLL.Interface;
using TextEditorApp.DAL.Context;
using TextEditorApp.DAL.Entities;

namespace TextEditorApp.BLL.Repository
{
    public class DocumentRepository : GenericRepository<Document>, IDocumentRepository
    {
        private readonly AppDbContext context;

        public DocumentRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public IReadOnlyList<Document> GetAllUserDocuments(string? id)
        {
            return context.Documents.Where(d => d.UserId == id).ToList();
        }
    }
}
