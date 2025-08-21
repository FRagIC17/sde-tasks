using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dependency_injection
{
    internal interface IProductRepository
    {
        List<string> GetAllProducts();
        void AddProduct(string name);
    }

    public class InMemoryProductRepository : IProductRepository
    {
        private List<string> _products = new List<string>();
        public List<string> GetAllProducts()
        {
            return _products;
        }
        public void AddProduct(string name)
        {
            _products.Add(name);
        }
    }
    public class SqlProductRepository : IProductRepository
    {
        private List<string> _products = new List<string>();
        
        public List<string> GetAllProducts()
        {
            foreach (var product in _products)
            {
                Console.WriteLine(product);
            }
            return _products;
        }

        public void AddProduct(string name)
        {
            _products.Add(name);
            Console.WriteLine($"Product {name} added to SQL database.");
        }
    }

}
