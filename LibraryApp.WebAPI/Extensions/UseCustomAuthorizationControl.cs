using System.Text;
using LibraryApp.Business;
using LibraryApp.Business.Abstract;
using LibraryApp.Business.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
//using Microsoft.Identity.Web;

namespace LibraryApp.WebAPI.Extensions
{
    public static class UseCustomAuthorizationControl
    {
        public static void useCustomAuthorization(this WebApplicationBuilder builder)
        {
                        //Authentication 
            var key = Encoding.ASCII.GetBytes(builder.Configuration.GetValue<string>("AppSettings:Secret"));
            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                 .AddJwtBearer(x =>
                 {
                     x.Events = new JwtBearerEvents
                     {
                         OnTokenValidated = context =>
                         {
                             var userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
                             var userId = int.Parse(context.Principal.Identity.Name);
                             var user = userService.GetById(userId);
                             if (user == null)
                             {
                                 // return unauthorized if user no longer exists
                                 context.Fail("Unauthorized");
                             }
                             return Task.CompletedTask;
                         }
                     };
                     x.RequireHttpsMetadata = false;
                     x.SaveToken = true;
                     x.TokenValidationParameters = new TokenValidationParameters
                     {
                         ValidateIssuerSigningKey = true,
                         IssuerSigningKey = new SymmetricSecurityKey(key),
                         ValidateIssuer = false,
                         ValidateAudience = false
                     };
                 });
        }
    
    }
}