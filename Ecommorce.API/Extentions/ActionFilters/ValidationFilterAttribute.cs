
using Ecommorce.Application.ILogger;
using Ecommorce.Application.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Ecommorce.API.Extentions.ActionFilters
{
    public class ValidationFilterAttribute : IActionFilter
    {
        private readonly ILoggerManger _logger;
        private readonly IRepositoryManager _repository;

        public ValidationFilterAttribute(ILoggerManger loggerManger, IRepositoryManager repositoryManager)
        {
            _logger = loggerManger;
            _repository = repositoryManager;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

            var action = context.RouteData.Values["action"];
            var controller = context.RouteData.Values["controller"];
            var param = context.ActionArguments.SingleOrDefault(x => x.Value.ToString().Contains("DTO")).Value;
            if (param == null)
            {
                _logger.LogError($"Object sent from client is null. Controller: {controller},   action: {action} ");
                context.Result = new BadRequestObjectResult($"Object is null. Controller: {controller}, action: {action} ");
                return;
            }
            if (!context.ModelState.IsValid)
            {
                _logger.LogError($"Invalid model state for the object. Controller: {controller}, action: {action}");
                context.Result = new UnprocessableEntityObjectResult(context.ModelState);

            }


        }
    }
}