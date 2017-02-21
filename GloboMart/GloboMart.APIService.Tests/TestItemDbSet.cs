using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GloboMart.APIService.Models;

namespace GloboMart.APIService.Tests
{
    class TestItemDbSet : TestDb<Product>
    {

        public override Product Find(params object[] keyValues)
        {

            return this.SingleOrDefault(item => item.Id == (int)keyValues.Single());

        }

    }

}
