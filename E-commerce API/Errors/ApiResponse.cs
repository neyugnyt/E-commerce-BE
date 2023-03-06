using Azure.Core;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.Identity.Client.Extensions.Msal;
using static System.Net.WebRequestMethods;
using System.Threading;
using System;

namespace E_commerce_API.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {   
#pragma warning disable CS8603 // Possible null reference return.
            return statusCode switch
            {
                400 => "Bad Request",
                401 => "You are not Authorized",
                402 => "Payment required",
                403 => "Forbidden",
                404 => "Not found",
                405 => "Method not allowed",
                406 => "Not acceptable",
                407 => ",Proxy authentication required",
                408 => "Request timeout",
                409 => "Conflict",
                410 => "Gone",
                411 => "Length required",
                412 => "Precondition failed",
                413 => "Request entity too large",
                414 => "Request URI too large",
                415 => "Unsupported media type",
                416 => "Request range not satisfiable",
                417 => "Expectation failed",
                422 => "Unprocessable entity",
                423 => "Locked",
                424 => "Failed dependency",
                500 => "Internal server error",
                501 => "Not Implemented",
                502 => "Bad gateway",
                503 => "Service unavailable",
                504 => "Gateway timeout",
                505 => "HTTP version not supported",
                506 => "Variant also negotiates",
                507 => "Insufficient storage",
                510 => "Not exList of HTTP status codes",
                _ => null
            };
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}
