using DemoApplication.ViewModels.Admin.Navbar;
using FluentValidation;

namespace DemoApplication.Validators.Admin.Navbar
{
    public class AddViewModelValidator :AbstractValidator<AddViewModel>
    {
        public AddViewModelValidator()
        {

            RuleFor(n => n.Title)
                .NotNull()
                .WithMessage("Title can't be null")
                .NotEmpty()
                 .MinimumLength(4)
                  .WithMessage("Minimum length should be 5")
                   .MaximumLength(45)
                 .WithMessage("Maximum length should be 45");

            RuleFor(n=>n.Url)
                  .NotNull()
                .WithMessage("Url can't be null")
                .NotEmpty()
                 .MinimumLength(3)
                  .WithMessage("Minimum length should be 5")
                   .MaximumLength(45)
                 .WithMessage("Maximum length should be 45");

            
        }
    }
}
