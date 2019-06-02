using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreApp.Models
{
    public class Resort
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MailingAddress { get; set; }
        public DateTime OperatingSince { get; set; }
    }
}
