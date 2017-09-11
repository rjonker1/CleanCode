using CleanCode.Comments;
using System;
using System.Collections.Generic;

namespace CleanCode.OutputParameters
{
    public class GetCustomerResult
    {
        public GetCustomerResult(int totalCount, IEnumerable<Customer> customers)
        {
            TotalCount = totalCount;
            Customers = customers;
        }

        public int TotalCount { get; private set; }
        public IEnumerable<Customer> Customers { get; private set; }
    }

    public class OutputParameters
    {
        public void DisplayCustomers()
        {
            var getCustomerResult = GetCustomers(1);
            var result = getCustomerResult;

            Console.WriteLine("Total customers: " + result.TotalCount);
            foreach (var c in result.Customers)
                Console.WriteLine(c);
        }

        public GetCustomerResult GetCustomers(int pageIndex)
        {
            var totalCount = 100;
            return new GetCustomerResult(totalCount, new List<Customer>());
        }
    }
}
