using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Univali.Api.DbContexts;
using Univali.Api.Features.Addresses.Commands.CreateAddress;
using Univali.Api.Features.Addresses.Commands.UpdateAddress;
using Univali.Api.Features.Answers.Commands.CreateAnswer;
using Univali.Api.Features.Answers.Commands.UpdateAnswer;
using Univali.Api.Features.Authors.Commands.CreateAuthor;
using Univali.Api.Features.Authors.Commands.UpdateAuthor;
using Univali.Api.Features.Lessons.Commands.CreateLesson;
using Univali.Api.Features.Lessons.Commands.UpdateLesson;
using Univali.Api.Features.Courses.Commands.CreateCourse;
using Univali.Api.Features.Courses.Commands.UpdateCourse;
using Univali.Api.Features.Customers.Commands.CreateCustomer;
using Univali.Api.Features.Customers.Commands.CreateCustomerWithAddresses;
using Univali.Api.Features.Customers.Commands.UpdateCustomer;
using Univali.Api.Features.Customers.Commands.UpdateCustomerWithAddresses;
using Univali.Api.Features.Publishers.Commands.CreatePublisher;
using Univali.Api.Features.Publishers.Commands.UpdatePublisher;
using Univali.Api.Features.Questions.Commands.CreateQuestion;
// using Univali.Api.Features.Questions.Commands.PartiallyUpdateQuestion;
using Univali.Api.Features.Questions.Commands.UpdateQuestion;
using Univali.Api.Features.Students.Commands.CreateStudent;
using Univali.Api.Features.Students.Commands.UpdateStudent;


namespace Univali.Api.Extensions;

internal static class StartupHelperExtensions
{
    public static async Task ResetDatabaseAsync(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            try
            {
                var customerContext = scope.ServiceProvider.GetService<CustomerContext>();
                if (customerContext != null)
                {
                    await customerContext.Database.EnsureDeletedAsync();
                    await customerContext.Database.MigrateAsync();
                }
                
                var PublisherContext = scope.ServiceProvider.GetService<PublisherContext>();
                if (PublisherContext != null)
                {
                    await PublisherContext.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = scope.ServiceProvider.GetRequiredService<ILogger>();
                logger.LogError(ex, "An error occurred while migrating the database.");
            }
        }
    }

    public static void AddFluentValidationServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IValidator<CreateCustomerCommand>, CreateCustomerCommandValidator>();
        builder.Services.AddScoped<IValidator<CreateAddressCommand>, CreateAddressCommandValidator>();
        builder.Services.AddScoped<IValidator<UpdateAddressCommand>, UpdateAddressCommandValidator>();
        builder.Services.AddScoped<IValidator<CreatePublisherCommand>, CreatePublisherCommandValidator>();
        builder.Services.AddScoped<IValidator<UpdatePublisherCommand>, UpdatePublisherCommandValidator>();
        builder.Services.AddScoped<IValidator<UpdateCourseCommand>, UpdateCourseCommandValidator>();
        builder.Services.AddScoped<IValidator<CreateCourseCommand>, CreateCourseCommandValidator>();
        builder.Services.AddScoped<IValidator<UpdateAuthorCommand>, UpdateAuthorCommandValidator>();
        builder.Services.AddScoped<IValidator<CreateAuthorCommand>, CreateAuthorCommandValidator>();
        builder.Services.AddScoped<IValidator<CreateCustomerWithAddressesCommand>, CreateCustomerWithAddressesCommandValidator>();
        builder.Services.AddScoped<IValidator<UpdateCustomerCommand>, UpdateCustomerCommandValidator>();
        builder.Services.AddScoped<IValidator<UpdateCustomerWithAddressesCommand>, UpdateCustomerWithAddressesCommandValidator>();
        builder.Services.AddScoped<IValidator<CreateQuestionCommand>, CreateQuestionCommandValidator>();
        builder.Services.AddScoped<IValidator<UpdateQuestionCommand>, UpdateQuestionCommandValidator>();
        // builder.Services.AddScoped<IValidator<QuestionForUpdateDto>, PartiallyUpdateQuestionCommandValidator>();
        builder.Services.AddScoped<IValidator<CreateLessonCommand>, CreateLessonCommandValidator>();
        builder.Services.AddScoped<IValidator<UpdateLessonCommand>, UpdateLessonCommandValidator>();
        builder.Services.AddScoped<IValidator<CreateStudentCommand>, CreateStudentCommandValidator>();
        builder.Services.AddScoped<IValidator<UpdateStudentCommand>, UpdateStudentCommandValidator>();
        builder.Services.AddScoped<IValidator<CreateAnswerCommand>, CreateAnswerCommandValidator>();
        builder.Services.AddScoped<IValidator<UpdateAnswerCommand>, UpdateAnswerCommandValidator>();
    }
}
