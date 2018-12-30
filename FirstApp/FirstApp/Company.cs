using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstApp
{
    [NotMapped]
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
