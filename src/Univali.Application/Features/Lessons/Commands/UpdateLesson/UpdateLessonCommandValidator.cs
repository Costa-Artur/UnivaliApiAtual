using FluentValidation;

namespace Univali.Api.Features.Lessons.Commands.UpdateLesson;

public class UpdateLessonCommandValidator : AbstractValidator<UpdateLessonCommand>
{
    public UpdateLessonCommandValidator()
    {
        RuleFor(c => c.LessonId)
            .NotEmpty()
            .WithMessage("You should fill out a Id");

        RuleFor(c => c.Title)
            .NotEmpty()
            .WithMessage("You should fill out Title")
            .MaximumLength(30)
            .WithMessage("The property Title shouldn't have more than 30 characters");

        RuleFor(c => c.ModuleId)
            .NotEmpty()
            .WithMessage("You should fill out ModuleId")
            .GreaterThan(0)
            .WithMessage("ModuleId should be greater than 0");
    }
}