using FluentValidation;

namespace Univali.Api.Features.Answers.Commands.CreateAnswer;

public class CreateAnswerCommandValidator : AbstractValidator<CreateAnswerCommand>
{
    public CreateAnswerCommandValidator()
    {
        RuleFor(a => a.Body)
        .NotEmpty()
        .WithMessage("You should fill out a Body");

        RuleFor(a => a.QuestionId)
        .NotEmpty()
        .WithMessage("You should fill out a QuestionId");

        RuleFor(a => a.AuthorId)
        .NotEmpty()
        .WithMessage("You should fill out an AuthorId");
    }
}