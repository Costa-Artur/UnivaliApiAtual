using System.ComponentModel.DataAnnotations;
using MediatR;
using Univali.Api.ValidationAttributes;

namespace Univali.Api.Features.Lessons.Commands.UpdateLesson;

// IRequest<> transforma a classe em uma Mensagem
// CreatePublisherDto é o tipo que este comando espera receber de volta
public class UpdateLessonCommand : IRequest<UpdateLessonCommandResponse>
{
    public int LessonId {get; set;}
    public string Title {get; set;} = string.Empty;
    public string Description {get; set;} = string.Empty;
    public int ModuleId { get; set; }
}