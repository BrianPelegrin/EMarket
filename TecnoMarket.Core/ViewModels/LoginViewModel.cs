using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnoMarket.Core.ViewModels
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "El  {0} es requerido")]
        [DisplayName("Correo")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "El Correo no es Valido.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "La {0} es requerida")]
        [DisplayName("Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
