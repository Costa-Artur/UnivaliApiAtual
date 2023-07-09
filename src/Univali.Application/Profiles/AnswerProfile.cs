using AutoMapper;
using Univali.Api.Entities;
using Univali.Api.Features.Answers.Commands.CreateAnswer;
using Univali.Api.Features.Answers.Commands.UpdateAnswer;
using Univali.Api.Features.Answers.Queries.GetAnswerDetail;
using Univali.Api.Features.Answers.Queries.GetAnswersDetail;
using Univali.Api.Features.AnswersCollection.GetAnswersDetail;
using Univali.Api.Models;

namespace Univali.Api.Profiles;

public class AnswerProfile : Profile
{
    public AnswerProfile()
    {
        CreateMap<Answer, AnswerDto>();
        CreateMap<Answer, GetAnswerDetailDto>();
        CreateMap<Answer, GetAnswersDetailDto>();
        CreateMap<Answer, GetAnswersCollectionDetailDto>();
        CreateMap<Answer, CreateAnswerDto>();
        CreateMap<CreateAnswerCommand, Answer>();
        CreateMap<UpdateAnswerCommand, Answer>();
    }
}