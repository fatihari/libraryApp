using LibraryApp.Business.Abstract.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LibraryApp.WebAPI.Filters
{
    public class ValidationFilter : ActionFilterAttribute
    {
        // I want to intervene when a request comes to the relevant action. 
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if(!context.ModelState.IsValid) // name, title vs yazılmadıysa
            {
                ErrorDto errorDto = new ErrorDto();
                errorDto.Status = 400;
                IEnumerable<ModelError> modelErrors = context.ModelState.Values.SelectMany(v=>v.Errors);

                modelErrors.ToList().ForEach(x => 
                {
                    errorDto.Errors.Add(x.ErrorMessage);
                });      
                context.Result = new BadRequestObjectResult(errorDto);
            }
        }
    }
}