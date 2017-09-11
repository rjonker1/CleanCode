using System;
using CleanCode.SwitchStatements;

namespace CleanCode.UnitTests.SwitchStatements
{
    public class PayAsYouGoCustomer : Customer
    {
        public PayAsYouGoCustomer()
        {
        }

        public override MonthlyStatement GenerateStatement(MonthlyUsage monthlyUsage)
        {
            var statement = new MonthlyStatement
            {
                CallCost = 0.12f * monthlyUsage.CallMinutes,
                SmsCost = 0.12f * monthlyUsage.SmsCount
            };
            statement.TotalCost = statement.CallCost + statement.SmsCost;
            return statement;
        }
    }
}