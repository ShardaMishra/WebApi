using Microsoft.AspNetCore.Mvc;
using WebApi.Entity;

namespace WebApi.Service
{
    public interface ICustomerService
    {
       Task<IEnumerable<Customer>> GetAll();
        Task<Customer> CreateCustomer(Customer customer);
        Task<int> SaveAsync();
        Task<Customer> GetById(int id);
        Task Delete(int id);
        void Update(int id, Customer customer);
            

    }
}
