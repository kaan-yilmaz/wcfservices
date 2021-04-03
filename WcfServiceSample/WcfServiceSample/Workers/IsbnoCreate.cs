using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfDataContract;

namespace WcfServiceSample.Workers
{
    public class IsbnoCreate : IDisposable
    {
        BookStoreEntities dbContext;
        public IsbnoCreate(BookStoreEntities bookStoreEntitys) {
            this.dbContext = bookStoreEntitys;
        }

        public void Dispose()
        {
           
        }

        public int Handle()
        {
            bool resultIsValidIsbnNo = false;
            int isbnNo;
            do
            {
                Random random = new Random();
                isbnNo = random.Next(1000, 100000);
                using (IsValidIsbno IsValidIsbno = new IsValidIsbno(dbContext))
                {
                    resultIsValidIsbnNo = IsValidIsbno.HandleAsync(isbnNo);
                }
            } while (!resultIsValidIsbnNo);
            return isbnNo;
        }
    }
}
