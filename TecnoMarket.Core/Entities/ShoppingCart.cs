using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnoMarket.Core.Entities.SecurityEntities;

namespace TecnoMarket.Core.Entities
{
    public class ShoppingCart : BaseEntity
    {
        public string ApplicationUserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public Product Product { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
