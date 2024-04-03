namespace TextEditorApp.BLL.Interface
{
    public interface IUnitOfWork
    {
        IDocumentRepository DocumentRepository { get; set; }
        public Task<int> CompleteAsync();
    }
}
