using EntityFrameworkCore_Tutorial_C35.Models;

using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkCore_Tutorial_C35 {

    class Program {

        static void Main(string[] args) {
            ///////////////////////////////////////////////////////////////////////////////////////////////
            //// Create an instance of our class - AppDbContext
            AppDbContext context = new AppDbContext();
            ///////////////////////////////////////////////////////////////////////////////////////////////

            ///////////////////////////////////////////////////////////////////////////////////////////////
            // Delete a customer
            var amazon = context.Customers.SingleOrDefault(c => c.Name == "Amazon");

            // If don't find Amazon
            if(amazon != null) {
                context.Customers.Remove(amazon);
                context.SaveChanges();
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////

            ///////////////////////////////////////////////////////////////////////////////////////////////
            //// Updating a customer
            //// Read the customer want to update
            //var max = context.Customers.Find(1);
            //// Change any of the propteries that want to change, excluding the primary key
            //// Adding $5000
            //max.Sales += 5000;
            //// Tell Entity Framework to Save Changes
            //context.SaveChanges();
            ///////////////////////////////////////////////////////////////////////////////////////////////

            ///////////////////////////////////////////////////////////////////////////////////////////////
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

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            //// Entity Framework adds some new functions to Linq
            //// Read all customers by Primary Key
            //var customer = context.Customers.Find(2);
            //Console.WriteLine($"{customer.Name} {customer.Sales:c}");
            ////////////////////////////////////////////////////////////////////////////////////////////////////

            ///////////////////////////////////////////////////////////////////////////////////////////////
            //// Query syntax in Linq - Can't use aggregate functions
            //// Read all customers
            var customers = from cust in context.Customers
                            //where cust.Sales < 100000
                            select cust;

            //// Method Syntax
            //List<Customer> customers = context.Customers
            //                                .Where(cust => cust.Sales < 100000)
            //                                .ToList();
            ///////////////////////////////////////////////////////////////////////////////////////////////

            ///////////////////////////////////////////////////////////////////////////////////////////////
            //// Foreach same for the Query & Method Syntax above
            foreach (var customer in customers) {
                Console.WriteLine($"{customer.Name,-20} {customer.Sales,10:c}");
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////
        }
    }
}
