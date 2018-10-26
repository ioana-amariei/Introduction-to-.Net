using FluentValidation;

namespace Employees
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.PhoneNumber).NotNull().Matches("(00|\\+)40\\d{10}");
            RuleFor(c => c.Email).NotNull().Matches("[a-zA-Z0-9_.-]+@[a-z]+.[a-z]+");
        }
    }
}
