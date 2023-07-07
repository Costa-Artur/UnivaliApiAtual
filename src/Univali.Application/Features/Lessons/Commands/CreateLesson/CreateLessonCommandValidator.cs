using FluentValidation;

namespace Univali.Api.Features.Lessons.Commands.CreateLesson;

public class CreateLessonCommandValidator : AbstractValidator<CreateLessonCommand>
{
    public CreateLessonCommandValidator()
    {
        RuleFor(c => c.Title)
            .NotEmpty()
            .WithMessage("You should fill out Title")
            .MaximumLength(30)
            .WithMessage("The property Title shouldn't have more than 30 characters");

        RuleFor(c => c.Description);
        
        RuleFor(c => c.ModuleId)
            .NotNull()
            .WithMessage("You should fill out ModuleId")
            .GreaterThan(0)
            .WithMessage("ModuleId should be greater than 0");
    }
}