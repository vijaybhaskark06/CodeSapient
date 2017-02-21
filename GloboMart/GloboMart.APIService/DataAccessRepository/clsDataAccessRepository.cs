using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GloboMart.APIService.Models;
using Microsoft.Practices.Unity;


namespace GloboMart.APIService.DataAccessRepository
{
    public class clsDataAccessRepository : IDataAccessRepository<Product, int>
    {
        //The dendency for the DbContext specified the current class. 
        [Dependency]
        public GloboMartEntities ctx { get; set; }

        //Get all Employees
        public IEnumerable<Product> Get()
        {
            return ctx.Products.ToList();
        }
        //Get Specific Employee based on Id
        public Product Get(int id)
        {
            return ctx.Products.Find(id);
        }

        //Create a new Employee
        public void Post(Product entity)
        {
            ctx.Products.Add(entity);
            ctx.SaveChanges();
        }
        //Update Exisitng Employee
        public void Put(int id, Product entity)
        {
            var Prod = ctx.Products.Find(id);
            if (Prod != null)
            {
                Prod.Name = entity.Name;
                Prod.Category = entity.Category;
                Prod.Price = entity.Price;                
                ctx.SaveChanges();
            }
        }
        //Delete an Employee based on Id
        public void Delete(int id)
        {
            var Prod = ctx.Products.Find(id);
            if (Prod != null)
            {
                ctx.Products.Remove(Prod);
                ctx.SaveChanges();
            }
        }
    }

}