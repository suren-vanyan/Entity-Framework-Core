using System;
using System.Collections.Generic;

namespace ExistingDb.Models.Scaffold
{
    public partial class Shoes
    {
        public Shoes()
        {
            ShoeCategoryJunction = new HashSet<ShoeCategoryJunction>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long ColorId { get; set; }
        public decimal Price { get; set; }
        public long? FittingId { get; set; }

        public virtual Colors Color { get; set; }
        public virtual Fittings Fitting { get; set; }
        public virtual SalesCampaigns SalesCampaigns { get; set; }
        public virtual ICollection<ShoeCategoryJunction> ShoeCategoryJunction { get; set; }
    }
}
