using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueuePrior
{
    class Program
    {
        class Customer
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Priority { get; set; }

            public override string ToString()
            {
                //return String.Format("[{0}] {1}", Priority, Name);
                return $"[{Priority}] {Name}";
            }

        }

        class QueuePrior
        {
            private List<Customer> customers = new List<Customer>();

            //public int Size { get { customers.Count(); }; }
            public int Size { get { return customers.Count; }  }

            public void Enqueue(Customer customer)
            {
                customer.Id = Size + 1;

                customers.Add(customer);
            }

            public Customer Dequeue1()
            {

                int foundIndex = -1; int maxPrior = -1;

                for (int i = 0; i < customers.Count; i++)
                {
                    if (customers[i].Priority > maxPrior)
                    {
                        maxPrior = customers[i].Priority;
                        foundIndex = i;
                    }
                }

                if (foundIndex == -1)
                    return null;

                Customer foundCustomer = customers[foundIndex];
                customers.RemoveAt(foundIndex);
                return foundCustomer;

                ///return null;
            }


            public Customer Dequeue2()
            {

                
                //LINQ
                Customer c = customers.OrderByDescending(x => x.Priority).ThenBy(x => x.Id).First();

                customers.RemoveAt(0);// c.Id - 1);
                //if (c != null)
                //    customers.Remove(c);

                return c;


                ///return null;
            }




        }
        static void Main(string[] args)
        {

            QueuePrior qp = new QueuePrior();
            int size = 10000;

            for (int i = 0; i < size; i++)
            {
                qp.Enqueue(new Customer() { Name = "Jan Kowalski", Priority = 1 });
                qp.Enqueue(new Customer() { Name = "Sasin 70mln", Priority = 5 });
                qp.Enqueue(new Customer() { Name = "Marian Kowalski", Priority = 1 });
                qp.Enqueue(new Customer() { Name = "Jan Rokita", Priority = 3 });
                qp.Enqueue(new Customer() { Name = "Nelly Rokita", Priority = 2 });
            }

            Stopwatch sw = new Stopwatch();
            sw.Start();

        //qp.Dequeue();
        int qs = qp.Size;
            for (int i = 0; i < qs; i++)
            {
                Customer currCustomer = qp.Dequeue1();
                ///Console.WriteLine(currCustomer);
            }

            sw.Stop();
            Console.WriteLine($" total = {sw.ElapsedMilliseconds}");


            for (int i = 0; i < size; i++)
            {
                qp.Enqueue(new Customer() { Name = "Jan Kowalski", Priority = 1 });
                qp.Enqueue(new Customer() { Name = "Sasin 70mln", Priority = 5 });
                qp.Enqueue(new Customer() { Name = "Marian Kowalski", Priority = 1 });
                qp.Enqueue(new Customer() { Name = "Jan Rokita", Priority = 3 });
                qp.Enqueue(new Customer() { Name = "Nelly Rokita", Priority = 2 });

            }
            
            sw.Restart();

            //qp.Dequeue();
            qs = qp.Size;
            for (int i = 0; i < qs; i++)
            {
                Customer currCustomer = qp.Dequeue2();
                //Console.WriteLine(currCustomer);
            }

            sw.Stop();
            Console.WriteLine($" total LINQ = {sw.ElapsedMilliseconds}");






            Console.ReadKey();
        }
    }
}
