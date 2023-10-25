using Application.Core.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Code.Challenge.Web.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// Method to validate if the model contains data within what is expected
        /// </summary>
        /// <param name="model">Generic object</param>
        /// <exception cref="ValidationException"></exception>
        protected void ValidateModel(object model)
        {
            if (model == null)
                throw new RequestException("No data has been sent.");

            if (!ModelState.IsValid)
            {
                var result = new List<string>();

                var errorMessages = ModelState.Values.Select(x => x.Errors.Select(y => new { y.ErrorMessage }));

                foreach (var x in errorMessages)
                    foreach (var y in x)
                        result.Add(y.ErrorMessage ?? "");

                result.RemoveAll(string.IsNullOrEmpty);

                var message = string.Join(" ", result.ToArray());

                throw new RequestException(message);
            }
        }

        /// <summary>
        /// Method to validate if an access token was sent, and get the access token received
        /// </summary>
        /// <returns>token</returns>
        /// <exception cref="AccessException"></exception>
        protected string GetAuthorizationToken()
        {
            if (!Request.Headers.TryGetValue("Authorization", out var hValues))
                throw new AccessException("A session token is required for this operation.");

            var token = hValues.First()?.Trim();
            token = token.Replace("Basic", "");
            token = token.Replace("Bearer", "");
            token = token.TrimStart();

            return token;
        }

        /// <summary>
        /// Asynchronous method to handle  and determine HTTP error code
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <param name="requestData">Request</param>
        /// <returns>Task -> ObjectResult</returns>
        protected async Task<ObjectResult> ErrorResponseAsync(Exception ex, object requestData)
        {
            var logId = default(string);

            int code;
            string message;

            switch (ex)
            {
                case AccessException accessEx:
                    code = StatusCodes.Status401Unauthorized;
                    message = accessEx.Message;
                    break;

                case AuthException authEx:
                    code = StatusCodes.Status403Forbidden;
                    message = authEx.Message;
                    break;

                case ValidationException validationEx:
                    code = StatusCodes.Status400BadRequest;
                    message = validationEx.Message;
                    break;

                case CustomGenericException customEx:
                    code = StatusCodes.Status500InternalServerError;
                    message = customEx.Message;
                    break;

                default:
                    code = StatusCodes.Status500InternalServerError;
                    message = "An error occurred. Please try again.";
                    break;
            }

            var result = default(ObjectResult);
            result = new ObjectResult(new
            {
                Message = message
            });
            result.StatusCode = code;
            return result;
        }

        public void PostMessage(FlashMessage Message)
        {
            if (TempData["FlashMessages"] == null)
                TempData["FlashMessages"] = new List<FlashMessage>();

            ((List<FlashMessage>)TempData["FlashMessages"]).Add(Message);
        }

        public void PostMessage(MessageType Type)
        {
            String Body = "";

            switch (Type)
            {
                case MessageType.Error: Body = "An error occurred while processing the request."; break;
                case MessageType.Info: Body = ""; break;
                case MessageType.Success: Body = "The data was saved successfully."; break;
                case MessageType.Warning: Body = ""; break;
            }
            PostMessage(Type, Body);
        }

        public void PostMessage(MessageType Type, String Title, String Body)
        {
            PostMessage(new FlashMessage { Title = Title, Body = Body, Type = Type });
        }

        public void PostMessage(MessageType Type, String Body)
        {
            String Title = "";

            switch (Type)
            {
                case MessageType.Error: Title = "Error"; break;
                case MessageType.Info: Title = "Info"; break;
                case MessageType.Success: Title = "Success!"; break;
                case MessageType.Warning: Title = "Attention!"; break;
            }

            PostMessage(new FlashMessage { Title = Title, Body = Body, Type = Type });
        }
    }
}
