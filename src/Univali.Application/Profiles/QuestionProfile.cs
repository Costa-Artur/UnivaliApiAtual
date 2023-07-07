using AutoMapper;
using Univali.Api.Entities;
using Univali.Api.Features.Questions.Commands.CreateQuestion;
using Univali.Api.Features.Questions.Commands.UpdateQuestion;
using Univali.Api.Features.Questions.Queries.GetLessonQuestion;
using Univali.Api.Features.Questions.Queries.GetLessonQuestions;
using Univali.Api.Features.Questions.Queries.GetLessonQuestionWithAnswers;
using Univali.Api.Features.Questions.Queries.GetQuestion;
using Univali.Api.Features.Questions.Queries.GetQuestions;
using Univali.Api.Features.Questions.Queries.GetQuestionWithAnswers;
using Univali.Api.Features.QuestionsCollection.Queries.GetQuestionsCollection;

namespace Univali.Api.Profiles;

public class QuestionProfile : Profile
{
    public QuestionProfile()
    {
        CreateMap<Question, GetQuestionDto>();
        CreateMap<Question, GetLessonQuestionDto>();
        CreateMap<Question, GetQuestionsDto>();
        CreateMap<Question, GetQuestionsCollectionDto>().ReverseMap();
        CreateMap<Question, GetLessonQuestionsDto>();
        CreateMap<Question, GetQuestionWithAnswersDto>();
        CreateMap<Question, GetLessonQuestionWithAnswersDto>();
        CreateMap<Question, CreateQuestionDto>();
        CreateMap<CreateQuestionCommand, Question>();
        CreateMap<UpdateQuestionCommand, Question>();
    }
}