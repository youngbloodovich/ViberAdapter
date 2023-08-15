using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;

namespace ViberAdapter
{
    public class ModelStateBindingErrorActionFilter : IActionFilter
    {
        private readonly ILogger<ModelStateBindingErrorActionFilter> _logger;
        private readonly ApiBehaviorOptions _options;
        private readonly Type _apiControllerAttribute;

        public ModelStateBindingErrorActionFilter(ILogger<ModelStateBindingErrorActionFilter> logger, IOptions<ApiBehaviorOptions> options)
        {
            _logger = logger;
            _options = options.Value;
            _apiControllerAttribute = typeof(ApiControllerAttribute);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.Controller.GetType().CustomAttributes.Any(x => x.AttributeType == _apiControllerAttribute))
            {
                if (!context.ModelState.IsValid)
                {
                    _logger.LogWarning("Invalid model state: {@errors}", context.ModelState.Select(x =>
                    new
                    {
                        x.Key,
                        Errors = x.Value?.Errors.Select(x => new
                        {
                            x.ErrorMessage,
                            x.Exception
                        })
                    }));

                    context.Result = _options.InvalidModelStateResponseFactory(context);
                }
            }
        }
    }
}