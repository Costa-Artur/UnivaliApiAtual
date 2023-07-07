using Univali.Api.Features.Common;

namespace Univali.Api.Features.Answers.Commands.UpdateAnswer;

public class UpdateAnswerCommandResponse : BaseResponse
{
    public bool Exists {get; set;}

    public UpdateAnswerCommandResponse()
    {
        Exists = false;
    }
}