using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TecnoMarket.Core.ViewModels
{
    public class ProductViewModel : BaseEntityViewModel
    {
        [Required(ErrorMessage = "La {0} es requerido")]
        [DisplayName("Nombre")]

        public string Name { get; set; }
        [Required(ErrorMessage = "La {0} es requerida")]
        [DisplayName("Descripcion")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessage = "La {0} es requerida")]
        [DisplayName("Precio")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Por favor indroduzca un {0} valido")]
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

        public virtual ICollection<ProductPictureViewModel>? Pictures { get; set; }
        public virtual StatuViewModel? Statu { get; set; }
        public virtual CategoryViewModel? Category { get; set; }
    }
}
