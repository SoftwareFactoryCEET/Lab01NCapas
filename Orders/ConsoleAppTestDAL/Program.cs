// See https://aka.ms/new-console-template for more information
using DAL;
using Entities.Models;
using System.Linq.Expressions;

//CreateAsync().GetAwaiter().GetResult();
RetreiveAsync().GetAwaiter().GetResult();

//Crear un objeto
static async Task CreateAsync()
{

    //Add Customer
    Customer customer =new Customer() { 
        FirstName = "Vladimir",
        LastName = "Cortés",
        City = "Bogotá",
        Country = "Colombia",
        Phone = "3144427602"
    };

    using(var repository = RepositoryFactory.CreateRepository())
    {
        try
        {
            var createdCustomer = await repository.CreateAsync(customer);
            Console.WriteLine($"Added Customer: {createdCustomer.LastName} {createdCustomer.FirstName}");
        }
        catch (Exception ex)
        {

            Console.WriteLine($"Error: {ex.Message}");
        }

    }
}

static async Task RetreiveAsync()
{
    using (var repository = RepositoryFactory.CreateRepository())
    {
        try
        {
            Expression<Func<Customer, bool>> criteria = c => c.FirstName == "Vladimir" && c.LastName == "Cortés";
            var customer = await repository.RetreiveAsync(criteria);
            if (customer != null)
            {
                Console.WriteLine($"Retrived customer: {customer.FirstName} \t{customer.LastName} \t City: {customer.City}\t Country: {customer.Country}");
            }
            else
            {
                Console.WriteLine("Costomer not exist");
            }
            
        }
        catch (Exception ex)
        {

            Console.WriteLine($"Error: {ex.Message}");
        }

    }
}