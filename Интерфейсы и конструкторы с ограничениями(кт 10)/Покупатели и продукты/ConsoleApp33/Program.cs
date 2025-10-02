using ConsoleApp33;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp33
{
    public interface IEntity
    {
        int id { get; set; }
    }
    public interface IRepository<T> where T : IEntity
    {
        void Add(T item);
        void Delete(T item);
        T FindById(int id);
        IEnumerable<T> GetAll();
    }
    public class Product: IEntity
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
    public class Customer: IEntity
    {
        public int id { get; set; } 
        public string Name { get; set; }
        public string Address { get; set; }
    }
    public class ProductRepository: IRepository<Product>
    {
        List<Product> Products = new List<Product>();
        public void Add(Product item)
        {
            Products.Add(item);
        }
        public void Delete(Product item)
        {
            Products.Remove(item);
        }
        public Product FindById(int id)
        {
            return Products.FirstOrDefault(p => p.id == id);
        }
        public IEnumerable<Product> GetAll()
        {
            return Products;
        }
    }
    public class CustomerRepository: IRepository<Customer>
    {
        List<Customer> Customers = new List<Customer>();
        public void Add(Customer item)
        {
            Customers.Add(item);
        }
        public void Delete(Customer item)
        {
            Customers.Remove(item);
        }
        public Customer FindById(int id)
        {
            return Customers.FirstOrDefault(p => p.id == id);
        }
        public IEnumerable<Customer> GetAll()
        {
            return Customers;
        }
    }
}
    internal class Program
    {
        
        static void Main(string[] args)
        {
            var customers = new CustomerRepository();
            var products = new ProductRepository();
            var potato = new Product { id = 1, Name = "Картошка", Price = 30 };
            var apple = new Product { id = 2, Name = "Яблоко", Price = 20 };
            products.Add(apple);
            products.Add(potato);
            var customer1 = new Customer { id = 1, Name = "Александр", Address = "ул. Крылова" };
            var customer2 = new Customer { id = 2, Name = "Валентина", Address = "ул. Петрова" };
            customers.Add(customer1);
            customers.Add(customer2);
            foreach (var customer in customers.GetAll())
            {
                Console.WriteLine($"{customer.id}: {customer.Name} - {customer.Address}");
            }
            foreach (var product in products.GetAll())
            {
                Console.WriteLine($"{product.id}: {product.Name} - {product.Price}");
            }
            var customerFind = customers.FindById(1);
            var productFInd = products.FindById(1);
            Console.WriteLine("Покупатель с 1 id: "  + customerFind.Name);
            Console.WriteLine("Продукт с 1 id: " + productFInd.Name);

    }
}

