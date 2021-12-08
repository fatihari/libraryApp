using LibraryApp.Business.Abstract;
using LibraryApp.Business.Abstract.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LibraryApp.WebAPI.Filters
{
    public class NotFoundFilter : ActionFilterAttribute
    {
        private readonly IBookService _bookService;
        public NotFoundFilter(IBookService bookService)
        {
            _bookService = bookService;
        }       
        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault(); // It takes the value from the id. 

            var book = await _bookService.GetByIdAsync(id); 

            if (book != null) // enters the incoming request / goes to the next step. 
            {
                await next();
            }
            else
            {
                ErrorDto errorDto = new ErrorDto();
                errorDto.Status = 404;
                errorDto.Errors.Add($"Book with id {id} not found in database");
                context.Result = new NotFoundObjectResult(errorDto);
                //context.Result = new RedirectToActionResult("Error", "Home", errorDto);
            }
        }
    }
}