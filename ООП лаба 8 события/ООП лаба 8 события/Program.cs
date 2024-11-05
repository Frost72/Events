using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП_лаба_8_события
{
    public class OnlineStore
    {
        
        public event EventHandler<ProductEventArgs> ProductArrived;

       
        public void AddProduct(string productName)
        {
            Console.WriteLine($"Товар {productName} поступил на склад");
            OnProductArrived(new ProductEventArgs(productName));
        }

        protected virtual void OnProductArrived(ProductEventArgs e)
        {
            ProductArrived?.Invoke(this, e);
        }
    }
   
    public class ProductEventArgs : EventArgs
    {
        public string ProductName { get; }

        public ProductEventArgs(string productName)
        {
            ProductName = productName;
        }
    }
   
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    
    public class Client
    {
        public string Name { get; }
        public string Surename { get;  }

        public Client(string name, string surename)
        {
            Name = name;
            Surename = surename;
        }

        
        public void OnProductArrived(object sender, ProductEventArgs e)
        {
            Console.WriteLine($"{Name} {Surename} получил уведомление о поступлении товара: {e.ProductName}");
            
        }
    }
        internal class Program
    {
        static void Main(string[] args)
        {
                
                OnlineStore store = new OnlineStore();
                Client client1 = new Client("Иван", "Иванов");
                Client client2 = new Client("Мария", "Петрова");

                store.ProductArrived += client1.OnProductArrived;
                store.ProductArrived += client2.OnProductArrived;

                
                store.AddProduct("Ноутбук");

                Console.ReadLine();
            }
    }
}
