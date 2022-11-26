using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnoMarket.Core.Entities
{
    public class Statu: BaseEntity
    {
        public string Description { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<ProductPicture> ProductsPictures { get; set; }
    }
}
