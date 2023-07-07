using FluentValidation;

namespace Univali.Api.Features.Questions.Commands.UpdateQuestion;

public class UpdateQuestionCommandValidator : AbstractValidator<UpdateQuestionCommand>
{
    public UpdateQuestionCommandValidator()
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