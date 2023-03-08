using AutoMapper;
using Contracts;
using Entities.DTO;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace PurchasePointCalcAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = $"ApiKey")]
    public class CustomerController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        //private IPurchasePointsService _purchasePointsService;

        public CustomerController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]        
        public IActionResult GetAllCustomers()
        {
            try
            {
                var customers = _repository.Customer.GetAllCustomers();
                _logger.LogInfo($"Returned all owners from database.");

                var customersResult = _mapper.Map<IEnumerable<CustomerDto>>(customers);
                return Ok(customers);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Exception occured inside GetAllCustomers action : {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{id}", Name = "CustomerById")]
        public IActionResult GetCustomerById(Guid id)
        {
            try
            {
                var customer = _repository.Customer.GetCustomerById(id);
                if (customer is null)
                {
                    _logger.LogError($"Customer with id {id} not found in the db.");
                    return NotFound();
                }
                else
                {
                    var customerResult = _mapper.Map<CustomerDto>(customer);
                    return Ok(customerResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occured inside GetCustomerById action : {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/purchase", Name = "CustomerWithPurchaseDetails")]
        public IActionResult GetCustomerWithDetails(Guid id)
        {
            try
            {
                var customer = _repository.Customer.GetCustomerWithDetails(id);
                if (customer is null)
                {
                    _logger.LogInfo($"Customer with id {id} not found in the db.");
                    return NotFound();
                }
                else
                {
                    var customerResult = _mapper.Map<CustomerPurchaseDto>(customer);
                    return Ok(customerResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occured inside GetCustomerWithDetails action : {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromBody] CustomerForCreationDto customer)
        {
            try
            {
                if (customer is null) {
                    _logger.LogError("Customer object sent from the client is null.");
                    return BadRequest("Customer object sent in the request is null.");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Customer object sent from the client is Invalid.");
                    return BadRequest("Customer object sent from the client is Invalid.");
                }

                var customerEntity = _mapper.Map<Customer>(customer);               
                _repository.Customer.CreateCustomer(customerEntity);
                _repository.Save();

                var createdCustomer = _mapper.Map<CustomerDto>(customerEntity);
                return CreatedAtRoute("CustomerById", new { id = createdCustomer.IdCustomer }, createdCustomer);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Exception occured inside CreateCustomer action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(Guid id, [FromBody] CustomerForCreationDto customer)
        {
            try
            {
                if (customer is null)
                {
                    _logger.LogError("Customer object sent from the client is null.");
                    return BadRequest("Customer object sent in the request is null.");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Customer object sent from the client is Invalid.");
                    return BadRequest("Customer object sent from the client is Invalid.");
                }

                var customerEntity = _repository.Customer.GetCustomerById(id);
                if (customerEntity is null)
                {
                    _logger.LogError($"Customer with id {id} has not been found in the database.");
                    return NotFound();
                }
                _mapper.Map(customer, customerEntity);
                _repository.Customer.UpdateCustomer(customerEntity);
                _repository.Save();

                var createdCustomer = _mapper.Map<CustomerDto>(customerEntity);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occured inside UpdateCustomer action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(Guid id)
        {
            try
            {
                if (_repository.Purchase.PurchasesByCustomer(id).Any()) {
                    _logger.LogError($@"Cannot delete customer. Customer with id {id} has the purchase entries in the purchase table.
                         Purchase entries belong to this id should be deleted first.");
                    return BadRequest($@"Cannot delete customer. Customer with id {id} has the purchase entries in the purchase table.
                         Purchase entries belong to this id should be deleted first.");
                }

                var customer = _repository.Customer.GetCustomerById(id);
                if (customer is null)
                {
                    _logger.LogError($"Customer with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Customer.DeleteCustomer(customer);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteCustomer action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("purchasePointDetails", Name = "PurchasePointDetails")]
        public IActionResult GetPurchasePointDetails([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            try
            {                
                var allCustomersPoints = _repository.Customer.GetAllCustomersPurchases(startDate, endDate);
                return Ok(allCustomersPoints);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occured inside GetCustomerWithDetails action : {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
