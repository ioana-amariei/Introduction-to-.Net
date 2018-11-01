namespace Authors
{
    public interface IUnitOfWork
    {
        IRepository<Author> AuthorRepository { get; }
        IRepository<Book> BookRepository { get; }
        
//        Commits all changes
        void Commit();
        
//        Discards all changes that has not been committed
        void RejectChanges();

        void Dispose();
    }
}
