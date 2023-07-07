using System.Data;
using FluentValidation;

namespace Univali.Api.Features.Authors.Commands.UpdateAuthor;

public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
{
    public UpdateAuthorCommandValidator()
    {
        RuleFor(a => a.Name)
            .NotEmpty()
            .WithMessage("You should fill out a Name")
            .MaximumLength(80)
            .WithMessage("The Name shouldn't have more than 80 characteres");

        RuleFor(a => a.CPF)
            .NotEmpty()
            .WithMessage("You sould fill out a CPF")
            .Length(11)
            .WithMessage("The CPF should have 11 characters")
            .Must(ValidateCPF)
            .When(a => a.CPF != null, ApplyConditionTo.CurrentValidator)
            .WithMessage("The CPf should be valid number");
    }

    private bool ValidateCPF(string cpf)
    {
        // Remove non-numeric characters
        cpf = cpf.Replace(".", "").Replace("-", "");

        // Check if it has 11 digits
        if (cpf.Length != 11)
        {
            return false;
        }

        // Check if all digits are the same
        bool allDigitsEqual = true;
        for (int i = 1; i < cpf.Length; i++)
        {
            if (cpf[i] != cpf[0])
            {
                allDigitsEqual = false;
                break;
            }
        }
        if (allDigitsEqual)
        {
            return false;
        }

        // Check first verification digit
        int sum = 0;
        for (int i = 0; i < 9; i++)
        {
            sum += int.Parse(cpf[i].ToString()) * (10 - i);
        }
        int remainder = sum % 11;
        int verificationDigit1 = remainder < 2 ? 0 : 11 - remainder;
        if (int.Parse(cpf[9].ToString()) != verificationDigit1)
        {
            return false;
        }

        // Check second verification digit
        sum = 0;
        for (int i = 0; i < 10; i++)
        {
            sum += int.Parse(cpf[i].ToString()) * (11 - i);
        }
        remainder = sum % 11;
        int verificationDigit2 = remainder < 2 ? 0 : 11 - remainder;
        if (int.Parse(cpf[10].ToString()) != verificationDigit2)
        {
            return false;
        }

        return true;
    }
}