using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using WebApi.Data;
using WebApi.Entity;

namespace WebApi.Service
{

    public class CustomerService:ICustomerService
    {
        public readonly CustomerDBContext dBContext;

        public CustomerService(CustomerDBContext dBContext)
        {
            this.dBContext = dBContext;

        }


        public async Task<Customer> CreateCustomer(Customer customer)
        {
            var result = await dBContext.Customers.AddAsync(customer);

            return result.Entity;
        }

        public Task Delete(int id)
        {
            var result = dBContext.Customers.FirstOrDefault(x => x.Id == id);
            if (result != null)
            {
                dBContext.Customers.Remove(result);
                dBContext.SaveChanges();
            }
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            var result = await dBContext.Customers.ToListAsync();

            return result;
        }

        public async Task<Customer> GetById(int id)
        {
           var result = await dBContext.Customers.FindAsync(id);
            return result;
        }

        public async Task<int> SaveAsync()
        {
            return await dBContext.SaveChangesAsync();
        }

        public void Update(int id, Customer customer)
        {
            var result = dBContext.Customers.FirstOrDefault(x => x.Id == id);
            if (result != null)
            {
             //   result.Id = customer.Id;
                result.Name = customer.Name;
                result.Email = customer.Email;
                result.Address = customer.Address;

                dBContext.SaveChanges();
            }
        }
    }
}

