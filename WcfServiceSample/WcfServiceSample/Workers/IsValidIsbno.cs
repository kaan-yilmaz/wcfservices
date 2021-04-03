using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfDataContract;

namespace WcfServiceSample.Workers
{
    public class IsValidIsbno : IDisposable
    {
        BookStoreEntities dbContext;
        public IsValidIsbno(BookStoreEntities bookStoreEntitys) {
            this.dbContext = bookStoreEntitys;
        }

        public void Dispose()
        {
           
        }

        public bool HandleAsync(int isbno)
        {
            var isbnCount =  dbContext.books.Where(x => x.isbn==isbno).Count();
            return  isbnCount > 0 ? false : true;
        }
    }
}
