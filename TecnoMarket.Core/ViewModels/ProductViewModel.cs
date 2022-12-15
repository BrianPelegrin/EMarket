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

        [Required(ErrorMessage = "El {0} es requerido")]
        [DisplayName("Precio")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Por favor indroduzca un {0} valido")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "La {0} es requerida")]
        [DisplayName("Cantidad en Almacen")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Por favor indroduzca una cantidad valida")]
        public int Stock { get; set; }
        public int CategoryId { get; set; }

        public virtual ICollection<ProductPictureViewModel>? Pictures { get; set; }
        public virtual StatuViewModel? Statu { get; set; }
        public virtual CategoryViewModel? Category { get; set; }
    }
}
