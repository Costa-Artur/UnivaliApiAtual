using Univali.Api.Features.Common;
using Univali.Api.Features.Students.Commands.CreateStudent;

namespace Univali.Api.Features.Students.Commands.UpdateStudent;

public class UpdateStudentCommandResponse : BaseResponse
{
    public bool Exist { get; set; }
}