using HueOnlineTicketFestival.Models;

public interface ICustomerService
{
    Task<IEnumerable<Customer>> GetAllCustomersAsync();
    Task<Customer> GetCustomerByIdAsync(int id);
    Task<int> AddCustomerAsync(Customer customer);
    Task UpdateCustomerAsync(int id, Customer customer);
    Task DeleteCustomerAsync(int id);
}
