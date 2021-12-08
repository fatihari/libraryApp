using System.Text.Json;
using LibraryApp.Business.Abstract.Dtos;
using Microsoft.AspNetCore.Diagnostics;

namespace LibraryApp.WebAPI.Extensions
{
    //  Extension method: These are the methods that are written extra on the objects that exist on the NetFramework side.
    public static class UseCustomExceptionHandler // class is static since this method extension
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>{
                    context.Response.StatusCode = 500; 
                    context.Response.ContentType = "application/json";
                    var error = context.Features.Get<IExceptionHandlerFeature>();
                    if(error!=null)
                    {
                        var ex = error.Error;
                        ErrorDto errorDto = new ErrorDto();
                        errorDto.Status = 500;
                        errorDto.Errors.Add(ex.Message);
                        await context.Response.WriteAsync(JsonSerializer.Serialize(errorDto)); // converting
                    }
                });
            });

        }
    }
}