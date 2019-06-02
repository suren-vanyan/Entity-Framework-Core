using System;
using System.Collections.Generic;

namespace ExistingDb.Models.Scaffold
{
    public partial class ShoeCategoryJunction
    {
        public long Id { get; set; }
        public long? ShoeId { get; set; }
        public long? CategoryId { get; set; }

        public virtual Categories Category { get; set; }
        public virtual Shoes Shoe { get; set; }
    }
}
