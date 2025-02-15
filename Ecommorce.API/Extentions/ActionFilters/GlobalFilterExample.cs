using Ecommorce.Application.ILogger;
using Ecommorce.Application.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NuGet.Protocol.Core.Types;
using System;

namespace Ecommorce.API.Extentions.ActionFilters
{
    public  class GlobalFilterExample : Attribute, IFilterMetadata, IActionFilter, IAsyncActionFilter
    //IAsyncActionFilter
    //, , IOrderedFilter  IResultFilter

    {
        private readonly ILoggerManger _logger;
        private readonly IRepositoryManager _repository;

        public GlobalFilterExample(ILoggerManger logger, IRepositoryManager repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var action = context.RouteData.Values["action"];
            var controller = context.RouteData.Values["controller"];
            var trackChanges = context.HttpContext.Request.Method.Equals("GET");
            if (controller == null)
            {
                _logger.LogError($"Object sent from client is null. Controller: {controller},  action: {action} ");
            }
            if (!context.ModelState.IsValid)
            {
                _logger.LogError($"Invalid model state for the object. Controller:   {controller}, action: {action}");
                context.Result = new UnprocessableEntityObjectResult(context.ModelState);
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var action = context.RouteData.Values["action"];
            var controller = context.RouteData.Values["controller"];
            var param = context.ActionArguments.SingleOrDefault(x => x.Value.ToString().Contains("All")).Value;
            if (controller == null)
            {
                _logger.LogError($"Object sent from client is null. Controller: {controller},  action: { action} ");
            context.Result = new BadRequestObjectResult($"Object is null. Controller: { controller }, action: { action} ");
            return;
            }
            if (!context.ModelState.IsValid)
            {
                _logger.LogError($"Invalid model state for the object. Controller:   { controller}, action: { action}");
            context.Result = new UnprocessableEntityObjectResult(context.ModelState);
            }
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var trackChanges = context.HttpContext.Request.Method.Equals("PUT");
            var id = (int)context.ActionArguments["id"];
            var company = await _repository.ProductBrand.GetByIdAsync(id);
            if (company == null)
            {
                _logger.LogInfo($"Company with id: {id} doesn't exist in the database.");
                context.Result = new NotFoundResult();
            }
            else
            {
                context.HttpContext.Items.Add("company", company);
                await next();
            }
        }

    }

}
