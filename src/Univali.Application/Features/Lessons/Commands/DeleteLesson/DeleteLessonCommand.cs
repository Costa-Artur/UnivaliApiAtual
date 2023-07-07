using System.ComponentModel.DataAnnotations;
using MediatR;
using Univali.Api.ValidationAttributes;

namespace Univali.Api.Features.Lessons.Commands.DeleteLesson;

public class DeleteLessonCommand : IRequest<bool>
{
    public int LessonId {get; set;}
}