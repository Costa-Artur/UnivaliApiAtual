using FluentValidation;

namespace Univali.Api.Features.Questions.Commands.CreateQuestion;

public class CreateQuestionCommandValidator : AbstractValidator<CreateQuestionCommand>
{
    public CreateQuestionCommandValidator()
    { 
        RuleFor(q => q.Questioning)
            .NotEmpty()
            .WithMessage("You should fill out a Questioning");

        RuleFor(q => q.Category)
            .NotEmpty()
            .WithMessage("You should fill out a Category");
        
        RuleFor(q => q.LessonId)
            .NotEmpty()
            .WithMessage("You should fill out a LessonId");
        
        RuleFor(q => q.StudentId)
            .NotEmpty()
            .WithMessage("You should fill out a StudentId");
    }
}