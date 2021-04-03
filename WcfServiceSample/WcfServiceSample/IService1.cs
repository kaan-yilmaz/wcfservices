using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfDataContract;

namespace WcfServiceSample
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        Book CheckStock(int isbnNo);

        [OperationContract]
        List<Book> CheckStocks(List<int> isbnNo);
        
        [OperationContract]
        List<Author> GetAuthors();

        [OperationContract]
        List<Book> GetAuthorBooks(int authorId);
        
        [OperationContract]
        List<Publisher> GetPublishers();

        [OperationContract]
        List<Book> GetPublisherBooks(int publisherId);

        [OperationContract]
        Task<int> AddBookToStock(AddBook book);

        [OperationContract]
        bool IsValidISBN(int isbno);
    }
}
