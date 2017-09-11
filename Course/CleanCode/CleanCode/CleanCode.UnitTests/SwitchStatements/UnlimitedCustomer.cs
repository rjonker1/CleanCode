using CleanCode.SwitchStatements;

namespace CleanCode.UnitTests.SwitchStatements
{
    public class UnlimitedCustomer : Customer
    {
        public UnlimitedCustomer()
        {
        }

        public override MonthlyStatement GenerateStatement(MonthlyUsage monthlyUsage)
        {
            var statement = new MonthlyStatement {TotalCost = 54.90f};
            return statement;
        }
    }
}