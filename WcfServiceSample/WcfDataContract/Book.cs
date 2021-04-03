using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using WcfEnum;

namespace WcfDataContract
{
    [DataContract]
    public class Book
    {
        int isbn;
        int id;
        bool validIsbn;
        Author author;
        Publisher publisher;
        FormatEnum format;
        DateTime releaseDate;
        int version;
        string preface;
        int quantityLeft;
        int warehouse;
        DateTime nextStockDate;

        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public int Isbn
        {
            get { return isbn; }
            set { isbn = value; }
        }

        [DataMember]
        public bool ValidIsbn
        {
            get { return validIsbn; }
            set { validIsbn = value; }
        }

        [DataMember]
        public Author Author
        {
            get { return author; }
            set { author = value; }
        }

        [DataMember]
        public Publisher Publisher
        {
            get { return publisher; }
            set { publisher = value; }
        }
        [DataMember]
        public FormatEnum Format
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
