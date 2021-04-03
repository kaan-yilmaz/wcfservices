using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfDataContract;

namespace WcfServiceSample.Workers
{
    public class GetPublisherById : IDisposable
    {
        BookStoreEntities dbContext;
        public GetPublisherById(BookStoreEntities bookStoreEntitys)
        {
            this.dbContext = bookStoreEntitys;
        }

        public void Dispose()
        {
        }

        public Publisher Handle(int publisherId)
        {
            var pb = dbContext.publishers.Where(x => x.id == publisherId).FirstOrDefault();
            Publisher publisher = new Publisher();
            publisher.Address = pb.address;
            publisher.Email = pb.email;
            publisher.Name = pb.name;
            publisher.PhoneNumber = pb.phoneNumber;
            return publisher;
        }
    }
}
