﻿using Catalog.API.Entities;
using Catalog.API.Repositories.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using Catalog.API.Data;
using Catalog.API.Data.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Catalog.API.Repositories
{
    public class BookRepository :  IBookRepository
    {
        private readonly ICatalogContext _context;
        private readonly IMemoryCache _cache;

        public BookRepository(IMemoryCache cache, ICatalogContext context)
        {
            _cache = cache;
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Book>> GetBooks()
        {
            string cacheKey = "AllBooks";
            if (!_cache.TryGetValue(cacheKey, out IEnumerable<Book> cachedBooks))
            {
                cachedBooks = await _context.Books.Find(new BsonDocument()).ToListAsync();

                if (cachedBooks != null)
                {
                    _cache.Set(cacheKey, cachedBooks, new MemoryCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10), // Термін дії кешу
                    });
                }
            }
            return cachedBooks;
        }

        public async Task<Book> GetBookByTitle(string title)
        {
            return await _context.Books
                          .Find(p => p.Title == title)
                          .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksByAuthor(string authorName)
        {
            return await _context.Books
                          .Find(p => p.AuthorName == authorName)
                          .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksByGenre(string genre)
        {
            return await _context.Books
                          .Find(p => p.Genre == genre)
                          .ToListAsync();
        }

        public async Task<Book> GetBookById(string id)
        {
            return await _context.Books
                           .Find(p => p.Id == id)
                           .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksByPublisher(string publisherName)
        {
            return await _context.Books
                          .Find(p => p.PublisherName == publisherName)
                          .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksByLanguage(string languageName)
        {
            return await _context.Books
                          .Find(p => p.LanguageName == languageName)
                          .ToListAsync();
        }

        public async Task CreateBook(Book book)
        {
            await _context.Books.InsertOneAsync(book);
        }

        public async Task<bool> UpdateBook(Book book)
        {
            var updateResult = await _context
                                        .Books
                                        .ReplaceOneAsync(filter: g => g.Id == book.Id, replacement: book);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteBook(string id)
        {
            FilterDefinition<Book> filter = Builders<Book>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _context
                                                .Books
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }
    }
}