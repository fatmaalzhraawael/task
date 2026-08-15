using System;
using System.Collections.Generic;
using System.Linq; 
using System.Text;
using System.Threading.Tasks;


namespace AdvancedCharp
{
   
    public class Employee 
    { 
        public int Id { get; set; } 
        public string Name { get; set; } = ""; 
        public decimal Salary { get; set; }
    }

    public class Client 
    { 
        public int Id { get; set; } 
        public string Name { get; set; } = ""; 
        public string Email { get; set; } = "";
    }
    public class GenericListManager<T>
    {
        private List<T> items = new List<T>();
        private List<string> logs = new List<string>();
        private DateTime? lastCreatedAt;
        private DateTime? lastSearchAt;

    
        public void Add(T item)
        {
            items.Add(item);
            lastCreatedAt = DateTime.Now;
            logs.Add("item added successfully");
        }
        public void Edit(Func<T, bool> predicate, T updatedItem)
        {
            int index = items.FindIndex(x => predicate(x));
            if (index != -1)
            {
                items[index] = updatedItem;
                logs.Add($"Item edited at '{DateTime.Now}'");
            }
        }

        public void Delete(Func<T, bool> predicate)
        {
            int index = items.FindIndex(x => predicate(x));
            if (index != -1)
            {
                items.RemoveAt(index);
                logs.Add($"Item deleted at '{DateTime.Now}'");
            }
        }

       
        public T? Find(Func<T, bool> predicate)
        {
            lastSearchAt = DateTime.Now;
            return items.FirstOrDefault(predicate);
        }
        public List<T> Where(Func<T, bool> predicate)
        {
            lastSearchAt = DateTime.Now;
            return items.Where(predicate).ToList();
        }
        public int GetCount() => items.Count;
        public DateTime? GetLastCreatedAt() => lastCreatedAt;
        public DateTime? GetLastSearchAt() => lastSearchAt;
        public List<string> GetLogs() => logs;
    }
    class program
    {
        static void Main(string[] args)
        {
            var employeeManager = new GenericListManager<Employee>();
            employeeManager.Add(new Employee { Id = 1, Name = "Ahmed", Salary = 8000 });
            employeeManager.Add(new Employee { Id = 2, Name = "Sara", Salary = 12000 });
           
            var clientManager = new GenericListManager<Client>();
            clientManager.Add(new Client { Id = 1, Name = "Noha", Email = "noha@test.com" });

            Console.WriteLine($" Employees Info");
            Console.WriteLine($"Count: {employeeManager.GetCount()}");
            Console.WriteLine($"Last Created At: {employeeManager.GetLastCreatedAt()}");
            
            Console.WriteLine($"\n Clients Info");
            Console.WriteLine($"Count: {clientManager.GetCount()}");
            
            Console.WriteLine("\nTask Done Successfully!");
        }
    }
}