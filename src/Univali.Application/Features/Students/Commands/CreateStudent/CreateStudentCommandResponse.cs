using Univali.Api.Features.Common;

namespace Univali.Api.Features.Students.Commands.CreateStudent;

public class CreateStudentCommandResponse : BaseResponse
{
    public CreateStudentDto Student {get; set;} = default!;
}