using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TecnoMarket.Core.ViewModels
{
    public class UserRegistrationViewModel
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

        [Required(ErrorMessage = "{0} es requerido")]
        [DisplayName("Confirmar Contraseña")]
        [Compare(nameof(Password), ErrorMessage ="Las Contraseñas no coinciden")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "El  {0} es requerido")]
        [DisplayName("Nombre Completo")]
        public string FullName { get; set; }

        [DisplayName("Telefono")]
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }

    }
}
