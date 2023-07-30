namespace BlogAppMVC.Contracts
{
    public interface IRepositoryManager
    {
        IBlogRepository Blog { get; }
        IPostRepository Post { get; }

        Task Save();
    }
}