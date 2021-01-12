using Skillz.Contracts;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;


namespace Skillz.Api
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
        private readonly IMediator _mediator;
        protected IActionResult InternalServerError() => StatusCode((int)HttpStatusCode.InternalServerError);
        protected IActionResult StatusWithMessages(HttpStatusCode statusCode, string message) => StatusCodeWithMessages(statusCode, new[] { message });
        protected IActionResult StatusCodeWithMessages(HttpStatusCode statusCode, IEnumerable<string> messages)
        {
            //TODO: ErrorMessageDto
            //var dto = new ErrorMessageDto(statusCode, messages);
            //return StatusCode(dto.StatusCode, dto);

            return StatusCode(200);
        }
        public ApiControllerBase(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException();
        }

        protected async Task<IActionResult> ExecuteRequest<T>(IRequest<T> request)
        {
            try
            {
                var reqBase = request as RequestBase;
                //if (reqBase != null) reqBase.PrincipalEmail = User.FindFirst("email").Value;
                var result = await _mediator.Send(request);
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return StatusCodeWithMessages(HttpStatusCode.BadRequest, ex.Errors.Select(x => x.ErrorMessage));
            }
            //catch (UnauthorizedException ex)
            //{
            //    return StatusWithMessages(HttpStatusCode.Forbidden, ex.Message);
            //}
            //catch (DomainException ex)
            //{
            //    return StatusWithMessages(HttpStatusCode.BadRequest, ex.Message);
            //}
            catch (Exception ex)
            {
                string m = ex.Message;
                //TODO: Log exception details with Microsoft.Extensions.Logging.AzureAppServices or Application Insights?
                return StatusWithMessages(HttpStatusCode.InternalServerError, "An error has occurred. Please try again, and if the problem persists, contact the Travelorama team.");
            }
        }

        protected async Task<IActionResult> ExecuteRequest(IRequest request)
        {
            try
            {
                await _mediator.Send(request);
                return NoContent();
            }
            catch (ValidationException ex)
            {
                return StatusCodeWithMessages(HttpStatusCode.BadRequest, ex.Errors.Select(x => x.ErrorMessage));
            }
            //catch (UnauthorizedException ex)
            //{
            //    return StatusWithMessages(HttpStatusCode.Forbidden, ex.Message);
            //}
            //catch (DomainException ex)
            //{
            //    return StatusWithMessages(HttpStatusCode.BadRequest, ex.Message);
            //}
            catch (Exception)
            {
                //TODO: Log exception details with Microsoft.Extensions.Logging.AzureAppServices or Application Insights?
                return StatusWithMessages(HttpStatusCode.InternalServerError, "An error has occurred. Please try again, and if the problem persists, contact the Travelorama team.");
            }
        }
    }
}
