using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Customer
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public int currency { get; private set; }

        public Customer(string name, string email)
        {
            Name = name;
            Email = email;
            currency = 0;
        }
        public void ChangeEmail(string email)
        {
            Email = email;
        }
        public void ChangeName(string name)
        {
            Name=name;
        }
        public void UpdateCurrency(int x)
        {
            currency += x;
        }
    }
    public record Information
    {
        public int X { get; init; }
        public int Y { get; init; }
        public int Z { get; init; }
        public float Rating { get; init; }
    }
    public class Product
    {
        public int UnitsInStock { get; private set; }
        public int Id { get; init; }
        public string Name { get; init; }
        public decimal Price { get; private set; }
        public Information info { get; init; }

        public Product(Information info, string name, decimal price, int units)
        {
            Name = name;
            Price = price;
            UnitsInStock = units;
            this.info = info;
        }
        public void Buy(int x)
        {
            UnitsInStock += x;
        }
        public void Restock(int x)
        {
            UnitsInStock -= x;
        }
    }
    public class Sender
    {
        public int ID { get; init; }
        public string Name { get; init; }
        public float Rating { get; private set; }
        public string Carname { get; private set; }
        public bool IsFree { get; private set; }
        public Sender(int id, string name, string carname)
        {
            ID = id;
            Name = name;
            Carname = carname;
            IsFree = true;
            Rating = 0;
        }
        public void StartWork()
        {
            IsFree = false;
        }
        public void EndWork()
        {
            IsFree=true;
        }
    }
}
