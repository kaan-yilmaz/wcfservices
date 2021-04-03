using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WcfDataContract
{
    [DataContract]
    public class AddBook
    {
        int author_id;
        int publisher_id;
        int format;
        DateTime releaseDate;
        int version;
        string preface;
        int quantityLeft;
        int warehouse;
        DateTime nextStockDate;
        
        [DataMember]
        public int AuthorId
        {
            get { return author_id; }
            set { author_id = value; }
        }

        [DataMember]
        public int PublisherId
        {
            get { return publisher_id; }
            set { publisher_id = value; }
        }
        [DataMember]
        public int Format
        {
            get { return format; }
            set { format = value; }
        }

        [DataMember]
        public DateTime ReleaseDate
        {
            get { return releaseDate; }
            set { releaseDate = value; }
        }

        [DataMember]
        public int Version
        {
            get { return version; }
            set { version = value; }
        }

        [DataMember]
        public string Preface
        {
            get { return preface; }
            set { preface = value; }
        }

        [DataMember]
        public int QuantityLeft
        {
            get { return quantityLeft; }
            set { quantityLeft = value; }
        }

        [DataMember]
        public int Warehouse
        {
            get { return warehouse; }
            set { warehouse = value; }
        }

        [DataMember]
        public DateTime NextStockDate
        {
            get { return nextStockDate; }
            set { nextStockDate = value; }
        }
    }
    }
