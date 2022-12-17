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
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "La clave deberia tener al menos 8 caracteres y contener 3 de 4 de los siguientes: mayusculas (A-Z), minusculas (a-z), numeros (0-9) y un caracter especial (e.g. !@#$%^&*)")]
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
