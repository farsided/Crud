using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crud.Areas.Contacts.Models
{
    public class NetworkType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int EncBy { get; set; }
        public DateTime EncDate { get; set; }
    }
}