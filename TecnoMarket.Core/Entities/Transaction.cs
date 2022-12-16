using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnoMarket.Core.Entities.SecurityEntities;

namespace TecnoMarket.Core.Entities
{
    public class Transaction : BaseEntity
    {
        public string ApplicationUserId { get; set; }
        public int ProductId { get; set; }
        public Guid TransactionIdentifier { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public Product Product { get; set; }
    }
}
