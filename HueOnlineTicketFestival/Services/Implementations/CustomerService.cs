using Microsoft.EntityFrameworkCore;
using HueOnlineTicketFestival.Models;

public class CustomerService : ICustomerService
{
    private readonly FestivalTicketContext _context;
    public CustomerService(FestivalTicketContext context)
    {
        this._context = context;
    }

    public async Task<int> AddCustomerAsync(Customer customer)
    {
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();
        return customer.CustomerId;
    }

    public async Task DeleteCustomerAsync(int id)
    {
        var deleteBook = _context.Customers!.SingleOrDefault(b => b.CustomerId == id);
        if (deleteBook != null)
        {
            _context.Customers!.Remove(deleteBook);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
    {
        var Customers = await _context.Customers!.ToListAsync();
        return Customers;
    }

    public async Task<Customer> GetCustomerByIdAsync(int id)
    {
        var customer = await _context.Customers!.FindAsync(id);
        return customer == null ? null : customer;
    }

    public async Task UpdateCustomerAsync(int id, Customer customer)
    {
        if (id == customer.CustomerId)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }
    }
}
