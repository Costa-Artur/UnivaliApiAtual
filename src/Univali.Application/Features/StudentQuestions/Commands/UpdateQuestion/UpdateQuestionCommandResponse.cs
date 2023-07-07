using Univali.Api.Features.Common;

namespace Univali.Api.Features.Questions.Commands.UpdateQuestion;

public class UpdateQuestionCommandResponse : BaseResponse
{
    public bool Exist { get; set; }
}