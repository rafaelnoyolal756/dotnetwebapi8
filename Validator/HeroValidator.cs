using dotnetwebapi8.Model;
using FluentValidation;

namespace dotnetwebapi8.Validator
{
    public class HeroValidator: AbstractValidator<OurHero>
    {
        public HeroValidator()
        {
            RuleFor(h => h.FirstName)
                .NotEmpty()
                .MaximumLength(50);

            RuleForEach(h => h.Powers)
                .SetValidator(new PowerValidator());
        }
    }
}
