using Catalog.API.Entities;

namespace Catalog.API.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooks();
        Task<Book> GetBookById(string id);
        Task<IEnumerable<Book>> GetBooksByAuthor(string authorName);
        Task<IEnumerable<Book>> GetBooksByPublisher(string publisherName);
        Task<IEnumerable<Book>> GetBooksByGenre(string genre);
        Task<IEnumerable<Book>> GetBooksByLanguage(string languageName);
        Task<Book> GetBookByTitle(string title);
    }
}
