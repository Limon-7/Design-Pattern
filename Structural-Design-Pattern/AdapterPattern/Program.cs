using System;
using Microsoft.Extensions.Logging;


namespace AdapterPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] employeesArray = new string[5, 4]
            {
                {"101","John","SE","10000"},
                {"102","Smith","SE","20000"},
                {"103","Dev","SSE","30000"},
                {"104","Pam","SE","40000"},
                {"105","Sara","SSE","50000"}
            };
            ITarget target = new EmployeeAdapter();
            target.ProcessCompanySalary(employeesArray);

            var logger = new FileLoggerAdapter<Program>("Log.txt");
            logger.LogDebug("New Debug Message");
        }
    }
}
