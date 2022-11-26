using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnoMarket.Core.ViewModels
{
    public class PictureViewModel: BaseEntityViewModel
    {
        public string Image { get; set; }
        public virtual StatuViewModel Statu { get; set; }
    }
}
