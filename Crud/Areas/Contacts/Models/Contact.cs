using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crud.Areas.Contacts.Models
{
    public class Contact
    {
        public int ID { get; set; }
        public int EID { get; set; }
        public string NetworkNo { get; set; }
        public int NetworkTypeID { get; set; }
        public string BinCard { get; set; }
        public string Remarks { get; set; }
        public int EncBy { get; set; }
        public int LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public DateTime EncDate { get; set; }
    }
}

