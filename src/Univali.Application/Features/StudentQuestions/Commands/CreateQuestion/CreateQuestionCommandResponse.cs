using Univali.Api.Features.Common;

namespace Univali.Api.Features.Questions.Commands.CreateQuestion;

public class CreateQuestionCommandResponse : BaseResponse
{
    public CreateQuestionDto Question { get; set; } = default!;
}