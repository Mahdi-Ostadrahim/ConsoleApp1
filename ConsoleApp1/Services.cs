using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Order
    {
        public int Id { get; init; }
        public Product Product { get; init; }
        public int count { get; private set; }
        public Order(Product product, int id, int cnt=1)
        {
            Product = product;
            Id = id;
            count = Math.Min(cnt,Product.UnitsInStock);
            Product.Buy(count);
        }
        public Order Update(int x)
        {
            if (Product.UnitsInStock < x)
                return this;
            Product.Buy(x - count);
            return this;
        }
    }
    public class Basket
    {
        public int ID { get; init; }
        public Customer customer { get; init; }
        public List<Order> total { get; private set; }
        public Basket(Customer customer, Order order, int id)
        {
            this.customer = customer;
            total = new List<Order>();
            total.Add(order);
            this.ID = id;
        }
        public void Add(Order ord)
        {
            total.Add(ord);
        }
        public void Delete(Order ord)
        {
            for (int i = 0; i < total.Count; i++)
            {
                if (total[i] == ord)
                {
                    total.RemoveAt(i);
                    return;
                }
            }
        }
        public void Update(Order order, int count)
        {
            if (count == 0)
            {
                Delete(order);
                return;
            }
            for (int i = 0; i < total.Count; i++)
                if (total[i] == order)
                    total[i] = total[i].Update(count);
            order.Update(count);
            Add(order);
        }
    }
    public class Send
    {
        public int ID { get; init; }
        public Order order { get; init; }
        public Sender sender { get; init; }
        public string destination { get; init; }
        public string currentLocation { get; private set; }
        public DateTime starttime { get; init; }
        public DateTime estimatedDeliveryTime { get; init; }
        public Send(Order ord, Sender send, int id, string des, DateTime deliver)
        {
            sender = send;
            sender.StartWork();
            order = ord;
            ID = id;
            destination = des;
            currentLocation = "";
            starttime = DateTime.Now;
            estimatedDeliveryTime = deliver;
        }
        public void UpdateLocation(string loc)
        {
            currentLocation = loc;
        }
        public string GetLocation()
        {
            return currentLocation;
        }
        public double RemainingPercent()
        {
            return ((DateTime.Now - starttime).TotalSeconds * 100) / ((estimatedDeliveryTime - starttime).TotalSeconds);
        }
    }
}
