using Microsoft.EntityFrameworkCore;
using Taxi_Backend.Data;
using Taxi_Backend.Models;
using Taxi_Backend.Models.DBModels;
using Taxi_Backend.Models.DTO;
using Taxi_Backend.Models.Enums;

namespace Taxi_Backend.Managers
{
    public class CustomerManager
    {
        private readonly TaxiDBContext ctx;

        public CustomerManager(TaxiDBContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<(bool success, object response)> CreateCustomer(Customer customer)
        {
            try
            {
                await ctx.Customer.AddAsync(customer);
                await ctx.SaveChangesAsync();
                return (true, customer);
            }
            catch (Exception ex)
            {
                return (false, $"Error creating customer: {ex.Message}");
            }
        }

        public async Task<(bool success, object response)> UpdateCustomer(Customer customer)
        {
            try
            {
                var existingCustomer = await ctx.Customer
                    .FirstOrDefaultAsync(c => c.CustomerId == customer.CustomerId);

                if (existingCustomer == null)
                    return (false, "Customer not found");

                existingCustomer.PhoneNumber = customer.PhoneNumber;

                ctx.Customer.Update(existingCustomer);
                await ctx.SaveChangesAsync();
                return (true, existingCustomer);
            }
            catch (Exception ex)
            {
                return (false, $"Error updating customer: {ex.Message}");
            }
        }

        public async Task<(bool success, object response)> DeleteCustomer(long customerId)
        {
            try
            {
                var customer = await ctx.Customer.FindAsync(customerId);
                if (customer == null)
                    return (false, "Customer not found");

                ctx.Customer.Remove(customer);
                await ctx.SaveChangesAsync();
                return (true, "Customer deleted successfully");
            }
            catch (Exception ex)
            {
                return (false, $"Error deleting customer: {ex.Message}");
            }
        }

        public async Task<(bool success, object response)> GetCustomerById(long customerId)
        {
            try
            {
                var customer = await ctx.Customer
                    .Include(c => c.CustomerQueues)
                    .Include(c => c.Trips)
                    .FirstOrDefaultAsync(c => c.CustomerId == customerId);

                if (customer == null)
                    return (false, "Customer not found");

                return (true, customer);
            }
            catch (Exception ex)
            {
                return (false, $"Error retrieving customer: {ex.Message}");
            }
        }

        public async Task<(int count, List<Customer> items)> GetCustomers(Page page)
        {
            try
            {
                var query = ctx.Customer
                    .Include(c => c.CustomerQueues)
                    .Include(c => c.Trips);

                return await page.Get(query);
            }
            catch (Exception)
            {
                return (0, new List<Customer>());
            }
        }

        public async Task<(bool success, object response)> CreateCustomerQueue(CustomerQueue customerQueue)
        {
            try
            {
                var existingQueue = await ctx.CustomerQueue
                    .FirstOrDefaultAsync(q => q.CustomerId == customerQueue.CustomerId &&
                                            q.QueueStatus == EnumQueueStatus.WAITING);

                if (existingQueue != null)
                    return (false, "Customer already has an active queue");

                await ctx.CustomerQueue.AddAsync(customerQueue);
                await ctx.SaveChangesAsync();

                var queueWithDetails = await ctx.CustomerQueue
                    .Include(q => q.Customer)
                    .Include(q => q.Trip)
                    .FirstOrDefaultAsync(q => q.CustomerQueueId == customerQueue.CustomerQueueId);

                return (true, queueWithDetails);
            }
            catch (Exception ex)
            {
                return (false, $"Error creating customer queue: {ex.Message}");
            }
        }

        public async Task<(bool success, object response)> UpdateCustomerQueue(CustomerQueue customerQueue)
        {
            try
            {
                var existingQueue = await ctx.CustomerQueue
                    .Include(q => q.Customer)
                    .Include(q => q.Trip)
                    .FirstOrDefaultAsync(q => q.CustomerQueueId == customerQueue.CustomerQueueId);

                if (existingQueue == null)
                    return (false, "Customer queue not found");

                existingQueue.QueueStatus = customerQueue.QueueStatus;
                existingQueue.TripId = customerQueue.TripId;

                ctx.CustomerQueue.Update(existingQueue);
                await ctx.SaveChangesAsync();

                return (true, existingQueue);
            }
            catch (Exception ex)
            {
                return (false, $"Error updating customer queue: {ex.Message}");
            }
        }

        public async Task<(bool success, object response)> DeleteCustomerQueue(long customerQueueId)
        {
            try
            {
                var customerQueue = await ctx.CustomerQueue.Include(x => x.Trip).Where(x => x.CustomerQueueId == customerQueueId).FirstOrDefaultAsync();
                if (customerQueue == null)
                    return (false, "Customer queue not found");

                ctx.Trip.Remove(customerQueue.Trip);

                ctx.CustomerQueue.Remove(customerQueue);
                await ctx.SaveChangesAsync();
                return (true, "Customer queue deleted successfully");
            }
            catch (Exception ex)
            {
                return (false, $"Error deleting customer queue: {ex.Message}");
            }
        }

        public async Task<(bool success, object response)> GetCustomerQueueById(long customerQueueId)
        {
            try
            {
                var customerQueue = await ctx.CustomerQueue
                    .Include(q => q.Customer)
                    .Include(q => q.Trip)
                    .FirstOrDefaultAsync(q => q.CustomerQueueId == customerQueueId);

                if (customerQueue == null)
                    return (false, "Customer queue not found");

                return (true, customerQueue);
            }
            catch (Exception ex)
            {
                return (false, $"Error retrieving customer queue: {ex.Message}");
            }
        }

        public async Task<CustomerQueue?> GetCustomerQueueByCustomerId(long customerId)
        {
            return await ctx.CustomerQueue
                .Include(q => q.Customer)
                .Include(q => q.Trip)
                .FirstOrDefaultAsync(x => x.CustomerId == customerId &&
                                        x.QueueStatus == EnumQueueStatus.WAITING);
        }

        public async Task<(int count, List<CustomerQueue> items)> GetCustomerQueues(Page page, long companyId)
        {
            try
            {
                var query = ctx.CustomerQueue
                    .Include(q => q.Customer)
                    .Include(q => q.Trip)
                    .Where(q => q.CompanyId == companyId);

                return await page.Get(query);
            }
            catch (Exception)
            {
                return (0, new List<CustomerQueue>());
            }
        }

        // Add this method to the existing CustomerManager class
        public async Task<(bool success, object response)> CreateCustomerRequest(CustomerRequestDTO request)
        {
            try
            {
                // If no customer ID is provided, try to find or create customer by phone number
                if (request.CustomerId == 0 && !string.IsNullOrEmpty(request.CustomerPhoneNumber))
                {
                    var customer = await ctx.Customer
                        .FirstOrDefaultAsync(c => c.PhoneNumber == request.CustomerPhoneNumber);

                    if (customer == null)
                    {
                        // Create new customer
                        customer = new Customer
                        {
                            PhoneNumber = request.CustomerPhoneNumber,
                            CreatedDateTime = DateTime.UtcNow
                        };
                        await ctx.Customer.AddAsync(customer);
                        await ctx.SaveChangesAsync();
                    }

                    request.CustomerId = customer.CustomerId;
                }

                if (request.CustomerId == 0)
                    return (false, "Customer ID or phone number is required");

                // Check for existing active queue
                var existingQueue = await ctx.CustomerQueue
                    .FirstOrDefaultAsync(q => q.CustomerId == request.CustomerId &&
                                            q.QueueStatus == EnumQueueStatus.WAITING);

                if (existingQueue != null)
                    return (false, "Customer already has an active queue");

                // Create new trip
                var trip = new Trip
                {
                    CustomerId = request.CustomerId,
                    CompanyId = request.CompanyId,
                    PickupAddress = request.PickupAddress,
                    DropoffAddress = request.DropoffAddress,
                    CalledTaxiSize = request.CalledTaxiSize,
                    Notes = request.Notes,
                    TripStatus = EnumTripStatus.CREATED,
                    CreatedDateTime = DateTime.UtcNow
                };

                await ctx.Trip.AddAsync(trip);
                await ctx.SaveChangesAsync();

                // Create customer queue
                var customerQueue = new CustomerQueue
                {
                    CustomerId = request.CustomerId,
                    CompanyId = request.CompanyId,
                    TripId = trip.TripId,
                    QueueStatus = EnumQueueStatus.WAITING,
                    CreatedDateTime = DateTime.UtcNow
                };

                await ctx.CustomerQueue.AddAsync(customerQueue);
                await ctx.SaveChangesAsync();

                // Get complete queue details with related data
                var queueWithDetails = await ctx.CustomerQueue
                    .Include(q => q.Customer)
                    .Include(q => q.Trip)
                    .FirstOrDefaultAsync(q => q.CustomerQueueId == customerQueue.CustomerQueueId);

                return (true, queueWithDetails);
            }
            catch (Exception ex)
            {
                return (false, $"Error creating customer request: {ex.Message}");
            }
        }
    }
}