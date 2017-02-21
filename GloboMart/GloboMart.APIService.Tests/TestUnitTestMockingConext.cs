using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GloboMart.APIService.Models;
using System.Data.Entity;

namespace GloboMart.APIService.Tests
{
    class TestUnitTestMockingConext : GloboMartEntities
    {

        public TestUnitTestMockingConext()
        {

            this.Items = new TestItemDbSet();

        }

        public DbSet<Product> Items { get; set; }

        public int SaveChanges()
        {

            return 0;

        }

        public void MarkAsModified(Product item) { }

        public void Dispose() { }

    }

}
