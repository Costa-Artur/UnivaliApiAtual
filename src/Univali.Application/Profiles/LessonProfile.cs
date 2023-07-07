using AutoMapper;
using Univali.Api.Entities;
using Univali.Api.Features.Lessons.Commands.CreateLesson;
using Univali.Api.Features.Lessons.Commands.UpdateLesson;
using Univali.Api.Features.Lessons.Queries.GetLessonDetail;
using Univali.Api.Features.Lessons.Queries.GetLessonsDetail;
using Univali.Api.Models;

namespace Univali.Api.Profiles;

public class LessonProfile : Profile
{
    public LessonProfile()
    {
        //1º arg: objeto de origem
        //2º arg: objeto de destino

        CreateMap<Entities.Lesson, Entities.Lesson>();

        CreateMap<Lesson, GetLessonDetailDto>();

        CreateMap<CreateLessonCommand, Lesson>();
        CreateMap<Lesson, CreateLessonCommandDto>();
        CreateMap<LessonForCreationDto, CreateLessonCommand>().ReverseMap();
        CreateMap<Lesson, GetLessonsDetailDto>().ReverseMap();
        CreateMap<LessonForUpdateDto, UpdateLessonCommand>().ReverseMap();
        CreateMap<UpdateLessonCommand, Lesson>().ReverseMap();
    }
}