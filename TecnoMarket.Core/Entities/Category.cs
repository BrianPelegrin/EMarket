using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnoMarket.Core.Entities
{
    public class Category:BaseEntity
    {
        public string Description { get; set; }

        public Statu Statu { get;set; }

        public virtual ICollection<Product> Products { get; set; } = null!;
    }
}
