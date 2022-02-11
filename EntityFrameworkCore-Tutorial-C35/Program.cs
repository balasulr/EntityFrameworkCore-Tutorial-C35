using EntityFrameworkCore_Tutorial_C35.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkCore_Tutorial_C35 {

    class Program {

        static void Main(string[] args) {
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //// Create an instance of our class - AppDbContext
            AppDbContext context = new AppDbContext();
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // List of all the items & display them in a foreach loop with a ConsoleWriteLine
            var items = context.Items.ToList();

            // Adding 10% to the price
            foreach(var i in items) {
                i.Price = i.Price * (1 + 0.1m);
            }

            context.SaveChanges(); // Save the changes after all changes are done

            items = context.Items.ToList(); // To update the items

            foreach (var item in items) {
                Console.WriteLine($"{item.Id,-5} {item.Code,-10} {item.Name,-15} {item.Price,10:c}");
            }
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////


            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //// Add a new Order for Kroger
            //var kroger = context.Customers.SingleOrDefault(c => c.Name.StartsWith("Krog"));
            //var order = new Order() {
            //    Id = 0, Description = "3rd Order", Total = 2500, CustomerId = kroger.Id
            //};

            //context.Orders.Add(order);
            //context.SaveChanges();

            //// Read all orders
            //var orders = context.Orders.Include(x => x.Customer).ToList();

            //foreach ( var o in orders) {
            //    Console.WriteLine($"{o.Id,-5}{o.Description,-10}{o.Total,10:c} {o.Customer.Name}");
            //}

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////


            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //// Delete a customer
            //var amazon = context.Customers.SingleOrDefault(c => c.Name == "Amazon");

            //// If don't find Amazon
            //if(amazon != null) {
            //    context.Customers.Remove(amazon);
            //    context.SaveChanges();
            //}
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////


            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //// Updating a customer
            //// Read the customer want to update
            //var max = context.Customers.Find(1);
            //// Change any of the propteries that want to change, excluding the primary key
            //// Adding $5000
            //max.Sales += 5000;
            //// Tell Entity Framework to Save Changes
            //context.SaveChanges();
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////


            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //// Adding a New Customer
            //// Create a instance of our customer
            //var newCustomer = new Customer() {
            //    Id = 0, Name = "Kroger", Active = true,
            //    Sales = 3000000, Updated = new DateTime(2022,2,11)
            //};

            //// Puts in the Entity Framework collection which is in memory
            //context.Customers.Add(newCustomer);
            //context.SaveChanges(); // Will add new instance to the database
            ///////////////////////////////////////////////////////////////////////////////////////////////


            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //// Entity Framework adds some new functions to Linq
            //// Read all customers by Primary Key
            //var customer = context.Customers.Find(2);
            //Console.WriteLine($"{customer.Name} {customer.Sales:c}");
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////


            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //// Query syntax in Linq - Can't use aggregate functions
            //// Read all customers
            //var customers = from cust in context.Customers
            //                //where cust.Sales < 100000
            //                select cust;

            //// Method Syntax
            //List<Customer> customers = context.Customers
            //                                .Where(cust => cust.Sales < 100000)
            //                                .ToList();
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////


            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //// Foreach same for the Query & Method Syntax above
            //foreach (var customer in customers) {
            //    Console.WriteLine($"{customer.Name,-20} {customer.Sales,10:c}");
            //}
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }
    }
}
