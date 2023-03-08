using AutoMapper;
using Contracts;
using Entities.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;

namespace PurchasePointCalcAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public UserController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }        
        [HttpPost("ApiKey")]
        public IActionResult CreateApiKey(Guid userId)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("User object sent from the client is Invalid.");
                return BadRequest("User object sent from the client is Invalid.");
            }
            var user = _repository.User.GetUserById(userId);
            //var user = await _userManager.FindByNameAsync(userObj.UserName);

            if (user is null)
            {
                return BadRequest("Unregistered user.");
            }

            var token = _repository.UserApiKey.CreateApiKey(user);
            
            return Ok(token);
        }
    }
}
