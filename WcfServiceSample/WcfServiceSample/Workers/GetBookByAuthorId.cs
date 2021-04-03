using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfDataContract;

namespace WcfServiceSample.Workers
{
    class GetBookByAuthorId : IDisposable
    {
        public void Dispose()
        {
        }

        BookStoreEntities dbContext;

        public GetBookByAuthorId(BookStoreEntities bookStoreEntitys)
        {
            this.dbContext = bookStoreEntitys;
        }

        public List<Book> Handle(int authorId)
        {
            var books = dbContext.books.Where(item => item.author_id == authorId).ToList();

            List<Book> bookList = new List<Book>();
            foreach (var book in books)
            {
                Book _book = new Book();
                _book.Id = book.id;
                _book.Isbn = Convert.ToInt32(book.isbn);
                _book.NextStockDate = book.nextStockDate != null ? Convert.ToDateTime(book.nextStockDate) : DateTime.Now;
                _book.Preface = book.preface;
                _book.QuantityLeft = book.quantityLeft != null ? Convert.ToInt32(book.quantityLeft) : 0;
                _book.ReleaseDate = book.releaseDate != null ? Convert.ToDateTime(book.releaseDate) : DateTime.Now;
                _book.ValidIsbn = book.validIsbn != null ? Convert.ToBoolean(book.validIsbn) : false;
                _book.Version = book.version != null ? Convert.ToInt32(book.version) : 0;
                _book.Warehouse = book.warehouse != null ? Convert.ToInt32(book.warehouse) : 0;
                using (GetAuthorById getAuthorById = new GetAuthorById(dbContext))
                {
                    _book.Author = getAuthorById.Handle(Convert.ToInt32(book.author_id));
                }
                using (GetPublisherById getPublisherById = new GetPublisherById(dbContext))
                {
                    _book.Publisher = getPublisherById.Handle(Convert.ToInt32(book.publisher_id));
                }

                bookList.Add(_book);
            }

            return bookList;
        }
    }
}
