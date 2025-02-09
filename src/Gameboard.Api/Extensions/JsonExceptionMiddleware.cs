// Copyright 2021 Carnegie Mellon University. All Rights Reserved.
// Released under a MIT (SEI)-style license. See LICENSE.md in the project root for license information.

using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Gameboard.Api;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Gameboard.Api
{
    public class JsonExceptionMiddleware
    {
        public JsonExceptionMiddleware(
            RequestDelegate next,
            ILogger<JsonExceptionMiddleware> logger
        )
        {
            _next = next;
            _logger = logger;
        }
        private readonly RequestDelegate _next;
        private readonly ILogger<JsonExceptionMiddleware> _logger;

        public async Task Invoke(HttpContext context)
        {
            try {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "error");

                if (!context.Response.HasStarted)
                {
                    context.Response.StatusCode = 500;
                    string message = "Error";
                    Type type = ex.GetType();

                    if (ex.GetType().Name.EndsWith("ApiException"))
                    {
                        context.Response.StatusCode = 400;
                        message = ex.Message;
                    }

                    if (
                        ex is System.InvalidOperationException
                        || type.Namespace.StartsWith("Gameboard")
                    ) {
                        context.Response.StatusCode = 400;
                        // message = ex.Message;
                        message = type.Name
                            .Split('.')
                            .Last()
                            .Replace("Exception", "");

                        // message += $" {ex.Message}";
                    }

                    await context.Response.WriteAsync(JsonSerializer.Serialize(new { message = message }));
                }
            }

        }
    }
}

namespace Microsoft.AspNetCore.Builder
{
    public static class JsonExceptionStartupExtensions
    {
        public static IApplicationBuilder UseJsonExceptions (
            this IApplicationBuilder builder
        )
        {
            return builder.UseMiddleware<JsonExceptionMiddleware>();
        }
    }
}
