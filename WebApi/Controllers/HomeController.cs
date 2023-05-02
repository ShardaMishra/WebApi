using Microsoft.AspNetCore.Mvc;
using WebApi.Entity;
using WebApi.Service;

namespace WebApi.Controllers
{
    [ApiController]

    [Route("[controller]")]
    public class HomeController : ControllerBase

    {
        private  ICustomerService customerService;

        public HomeController(ICustomerService _customerService)
        {
            this.customerService = _customerService;

        }
        [HttpPost ("savecustomer")]
        
        public async Task<ActionResult> AddConstomer(Customer customer)
        {
            var Customercreated = await customerService.CreateCustomer(customer);
                await customerService.SaveAsync();
            return Ok();

        }

        [HttpGet ("getallcustomers")]
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await customerService.GetAll();
        }

        [HttpGet ("{id}")]
        public async Task<Customer>GetCustomerById(int id)
        {
            return await customerService.GetById(id);
        }
        [HttpDelete ("{id}")]
        public void DeleteCustomerById(int id)
        {
            customerService.Delete(id);
        }

        [HttpPut ("{id}")]
        public void PutCustomer(int id ,Customer customer)
        {
            customerService.Update(id, customer);

        }
        
    
    }
}


