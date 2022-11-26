using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnoMarket.Core.Entities
{
    public class ProductPicture: Picture
    {
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
