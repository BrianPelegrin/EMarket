using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnoMarket.Core.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string UserCreator { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int StatuId { get; set; }

    }
}
