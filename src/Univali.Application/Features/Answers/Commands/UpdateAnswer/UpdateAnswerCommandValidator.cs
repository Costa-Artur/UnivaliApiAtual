using FluentValidation;

namespace Univali.Api.Features.Answers.Commands.UpdateAnswer;

public class UpdateAnswerCommandValidator : AbstractValidator<UpdateAnswerCommand>
{
    public UpdateAnswerCommandValidator()
    {
        RuleFor(a => a.AnswerId)
        .NotEmpty()
        .WithMessage("You should fill out an AnswerId");

        RuleFor(a => a.Body)
        .NotEmpty()
        .WithMessage("You should fill out a Body");

        RuleFor(a => a.AuthorId)
        .NotEmpty()
        .WithMessage("You should fill out an AuthorId");
    }
}