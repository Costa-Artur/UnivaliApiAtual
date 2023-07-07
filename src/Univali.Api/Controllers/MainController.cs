using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;

namespace Univali.Api.Controllers;

[ApiController]
public abstract class MainController : ControllerBase
{
    protected const int maxPageSize = 6;
    public override ActionResult ValidationProblem(
    [ActionResultObjectValue] ModelStateDictionary modelStateDictionary)
    {
        // base.ValidationProblem();
        var options = HttpContext.RequestServices
            .GetRequiredService<IOptions<ApiBehaviorOptions>>();

        return (ActionResult)options.Value
            .InvalidModelStateResponseFactory(ControllerContext);
    }

    public override NotFoundObjectResult NotFound([ActionResultObjectValue] object? value)
    {
        Console.WriteLine(ModelState.ErrorCount);
        Console.WriteLine(ModelState.IsValid);
        Console.WriteLine(ModelState == null);
        Console.WriteLine(Activity.Current?.Id);

        // Cria a fábrica de um objeto de detalhes de problema de validação
        var problemDetailsFactory = HttpContext.RequestServices
            .GetRequiredService<ProblemDetailsFactory>();

        // Cria um objeto de detalhes de problema de validação
        var validationProblemDetails = problemDetailsFactory
            .CreateValidationProblemDetails(
                HttpContext,
                ModelState!);

        // Adiciona informações adicionais não adicionadas por padrão
        validationProblemDetails.Detail =
            "See the errors field for details.";
        validationProblemDetails.Instance =
            HttpContext.Request.Path;

        // Relata respostas do estado de modelo inválido como problemas de validação
        validationProblemDetails.Type =
            "https://courseunivali.com/notfoundproblem";
        validationProblemDetails.Status =
            StatusCodes.Status404NotFound;
        validationProblemDetails.Title =
            "One or more records were not found";
        // validationProblemDetails.Extensions["traceId"] = HttpContext.TraceIdentifier;
        return new NotFoundObjectResult(
            validationProblemDetails)
        {
            ContentTypes = { "application/problem+json" }
        };

    }

    public override UnprocessableEntityObjectResult UnprocessableEntity([
        ActionResultObjectValue] ModelStateDictionary modelState)
    {
        // Cria a fábrica de um objeto de detalhes de problema de validação
        var problemDetailsFactory = HttpContext.RequestServices
            .GetRequiredService<ProblemDetailsFactory>();

        // Cria um objeto de detalhes de problema de validação
        var validationProblemDetails = problemDetailsFactory
            .CreateValidationProblemDetails(
                HttpContext,
                ModelState);

        // Adiciona informações adicionais não adicionadas por padrão
        validationProblemDetails.Detail =
            "See the errors field for details.";
        validationProblemDetails.Instance =
            HttpContext.Request.Path;

        // Relata respostas do estado de modelo inválido como problemas de validação
        validationProblemDetails.Type =
            "https://courseunivali.com/modelvalidationproblem";
        validationProblemDetails.Status =
            StatusCodes.Status422UnprocessableEntity;
        validationProblemDetails.Title =
            "One or more validation errors occurred.";

        return new UnprocessableEntityObjectResult(
            validationProblemDetails)
        {
            ContentTypes = { "application/problem+json" }
        };
    }

    public void ConfigureModelState(Dictionary<string, string[]> errors)
    {
        foreach (var error in errors)
        {
            string key = error.Key;
            string[] values = error.Value;

            foreach (var value in values)
            {
                ModelState.AddModelError(key, value);
            }
        }
    }
}