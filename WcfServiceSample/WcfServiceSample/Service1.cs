using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfDataContract;
using WcfServiceSample.Workers;

namespace WcfServiceSample
{
    public class Service1 : IService1
    {

        public List<Book> CheckStocks(List<int> isbnNo)
        {
            try
            {
                List<Book> books = new List<Book>();
                using (var dbContext = new BookStoreEntities())
                {
                   
                    foreach (int isbno in isbnNo)
                    {
                        using (GetBookByIsbno getBookByIbno = new GetBookByIsbno(dbContext))
                        {
                          Book book = getBookByIbno.Handle(isbno);
                            books.Add(book);
                        }
                    }
                }
                return books;
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                return null;
            }
        }
        
        public Book CheckStock(int isbnNo)
        {
            try
            {
                using (var dbContext = new BookStoreEntities())
                {
                    Book book;
                    using (GetBookByIsbno getBookByIsbno = new GetBookByIsbno(dbContext))
                    {
                        book = getBookByIsbno.Handle(isbnNo);
                    }
                    return book;
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                return null;
            }
        }

        public List<Author> GetAuthors()
        {
            try
            {
                using (var dbContext = new BookStoreEntities())
                {
                     var authors = dbContext.authors.Select(x => new Author() {
                         Name = x.name,
                         Age = x.age,
                         Surname = x.surname
                     }).ToList();
                    return authors;
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                return null;
            }
        }

        public List<Book> GetAuthorBooks(int authorId)
        {
            try
            {
                using (var dbContext = new BookStoreEntities())
                {
                    List<Book> books;
                    using (GetBookByAuthorId getBookByAuthorId = new GetBookByAuthorId(dbContext))
                    {
                        books = getBookByAuthorId.Handle(authorId);
                    }
                    return books;
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                return null;
            }
        }

        public List<Publisher> GetPublishers()
        {
            try
            {
                using (var dbContext = new BookStoreEntities())
                {
                    var publishers = dbContext.publishers.Select(x => new Publisher()
                    {
                        Name = x.name,
                        Address = x.address,
                        PhoneNumber = x.phoneNumber,
                        Email = x.email
                    }).ToList();
                    return publishers;
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                return null;
            }
        }

        public List<Book> GetPublisherBooks(int publisherId)
        {
            try
            {
                using (var dbContext = new BookStoreEntities())
                {
                    List<Book> books;
                    using (GetBookByPublisherId getBookByPublisherId = new GetBookByPublisherId(dbContext))
                    {
                        books = getBookByPublisherId.Handle(publisherId);
                    }
                    return books;
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                return null;
            }
        }

        public async Task<int> AddBookToStock(AddBook book) 
        {
            try
            {
                using (var dbContext = new BookStoreEntities())
                {
                    int isbno;
                    // Isbno uniqe kontrol
                    using (IsbnoCreate isbnoCreate = new IsbnoCreate(dbContext))
                    {
                        isbno = isbnoCreate.Handle();
                    }
                    var bookEntity = new books()
                    {
                        isbn = isbno,
                        author_id = book.AuthorId,
                        publisher_id = book.PublisherId,
                        version = book.Version,
                        preface = book.Preface,
                        quantityLeft = book.QuantityLeft,
                        warehouse = book.Warehouse,
                        format = book.Format,
                        validIsbn = true,
                        nextStockDate = book.NextStockDate,
                        releaseDate = book.ReleaseDate
                    };
                    dbContext.books.Add(bookEntity);
                    dbContext.SaveChanges();
                    return bookEntity.id;
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                return 0;
            }
        }

        public bool IsValidISBN(int isbno)
        {
            try
            {
                using (var dbContext = new BookStoreEntities())
                {
                    using (IsValidIsbno isValidIsbn = new IsValidIsbno(dbContext))
                    {
                        return isValidIsbn.HandleAsync(isbno);
                    }
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                return false;
            }
        }
    }
}
