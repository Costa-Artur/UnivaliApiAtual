using AutoMapper;
using Univali.Api.Entities;
using Univali.Api.Features.Students.Commands.CreateStudent;


namespace Univali.Api.Profiles;

public class StudentProfile : Profile
{
    public StudentProfile()
    {
        CreateMap<Student, Features.Students.Queries.GetStudentsDetails.GetStudentsDetailsDto>();
        CreateMap<Student, Features.Students.Queries.GetStudentDetails.GetStudentDetailsDto>();
        CreateMap<Student, Features.Students.Queries.GetStudentCollectionDetails.GetStudentCollectionDetailsDto>();
        CreateMap<Student, Features.Students.Commands.CreateStudent.CreateStudentCommand>().ReverseMap();
        CreateMap<Features.Students.Commands.CreateStudent.CreateStudentDto, Student>();
        CreateMap<Features.Students.Commands.UpdateStudent.UpdateStudentCommand, Student>();
        CreateMap<Student, CreateStudentDto>();

    }
}