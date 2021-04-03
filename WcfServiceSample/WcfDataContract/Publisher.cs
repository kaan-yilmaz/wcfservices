using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WcfDataContract
{
    [DataContract]
    public class Publisher
    {
        int id;
        string name;
        string address;
        string phoneNumber;
        string email;

        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public string Name
        {
            get { return name;  }
            set { name = value; }
        }

        [DataMember]
        public string Address
        {
            get { return address; }
            set { address = value;  }
        }

        [DataMember]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        [DataMember]
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
    }
}
