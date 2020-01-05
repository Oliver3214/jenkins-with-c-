using SeleniumTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestsFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerService mts = new CustomerService();

            mts.SetupTest();

            mts.TheCustomerServiceTest();

            mts.TeardownTest();

        }
    }
}
