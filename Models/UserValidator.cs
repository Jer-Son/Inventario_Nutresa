using FluentValidation;
namespace Sitio_Web_Core_MVC_CRUD_EF.Models
{
    

    public class UserValidator : AbstractValidator<Usuario>
    {
        public UserValidator()
        {
            RuleFor(user => user.Cedula).NotEmpty().WithMessage("La cedula esta repetida");
        }
    }
}
