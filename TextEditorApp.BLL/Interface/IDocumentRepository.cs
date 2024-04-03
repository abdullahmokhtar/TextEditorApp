using TextEditorApp.DAL.Entities;

namespace TextEditorApp.BLL.Interface
{
    public interface IDocumentRepository : IGenericRepository<Document>
    {
        IReadOnlyList<Document> GetAllUserDocuments(string? id);
    }
}
