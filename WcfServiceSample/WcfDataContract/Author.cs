using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WcfDataContract
{
    [DataContract]
    public class Author
    {
        string name;
        string surname;
        string age;
        int id;

        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value;  }
        }

        [DataMember]
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        [DataMember]
        public string Age
        {
            get { return age; }
            set { age = value;  }
        }
    }
}
