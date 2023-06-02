using E_commerce_API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce_API.Controllers
{
    public class ErrorHandlingController : BaseApiController
    {
        private readonly DataContext _context;

        public ErrorHandlingController(DataContext context) 
        {
            _context = context;
        }
        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            var thing = _context.Products.Find(42);
            if(thing == null) 
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok();
        }
        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var thing = _context.Products.Find(42); 
            var thingToReturn = thing.ToString();

            return Ok();
        }
        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }


        [HttpGet("testauth")]
        [Authorize]
        public ActionResult<string> GetToken()
        {
            return "Secret Token";
        }

        [HttpGet("badrequest/product/{id}")]
        public ActionResult GetNotFoundRequest(int id)
        {

            return Ok(new ApiResponse(400));
        }
    }
}
