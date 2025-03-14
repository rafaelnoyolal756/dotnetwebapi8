using dotnetwebapi8.Model;
using FluentValidation;

namespace dotnetwebapi8.Validator
{
    public class PowerValidator: AbstractValidator<Power>
    {
        public PowerValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
