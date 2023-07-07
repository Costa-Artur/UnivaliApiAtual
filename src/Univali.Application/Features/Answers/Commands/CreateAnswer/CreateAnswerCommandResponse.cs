using Univali.Api.Features.Common;

namespace Univali.Api.Features.Answers.Commands.CreateAnswer;

public class CreateAnswerCommandResponse : BaseResponse
{
    public CreateAnswerDto Answer { get; set;} = default!;
}