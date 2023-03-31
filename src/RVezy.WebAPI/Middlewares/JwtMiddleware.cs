using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace RVezy.WebAPI.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private string _secret;

        public JwtMiddleware(RequestDelegate next, string secret)
        {
            _next = next;
            _secret = secret;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string? token = context.Request.Headers["Authorization"]
                .FirstOrDefault()?.Split(" ")
                .Last();

            if (string.IsNullOrEmpty(_secret))
            {
                await _next(context);
                return;
            }

            if (token != null)
            {
                try
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_secret);
                    tokenHandler.ValidateToken(token, new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ClockSkew = TimeSpan.Zero
                    }, out SecurityToken validatedToken);

                    var jwtToken = (JwtSecurityToken)validatedToken;
                    var identity = new ClaimsIdentity(jwtToken.Claims);
                    context.Items["User"] = new ClaimsPrincipal(identity);
                }
                catch (Exception)
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Invalid token.");
                    return;
                }
            }


            await _next(context);
        }
    }

}

