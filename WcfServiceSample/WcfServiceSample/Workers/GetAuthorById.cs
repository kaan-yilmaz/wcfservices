using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfDataContract;

namespace WcfServiceSample.Workers
{
    public class GetAuthorById : IDisposable
    {
        BookStoreEntities dbContext;
        public GetAuthorById(BookStoreEntities bookStoreEntitys) {
            this.dbContext = bookStoreEntitys;
        }

        public void Dispose()
        {
           
        }

        public Author Handle(int authorId)
        {
            var au = dbContext.authors.Where(x => x.id==authorId).FirstOrDefault();
            Author author = new Author();
            author.Age = au.age;
            author.Id = au.id;
            author.Name = au.name;
            author.Surname = au.surname;
            return author;
        }
    }
}
