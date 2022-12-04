
using DemoApplication.ViewModels.Admin.SubNavbar;
using FluentValidation;

namespace DemoApplication.Validators.Admin.SubNavbar
{
    public class AddViewModelValidator :AbstractValidator<SubAddViewModel>
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

            RuleFor(n=>n.Title)
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
