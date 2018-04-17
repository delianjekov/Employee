using System;
using Employee.BusinessLayer;
using Unity;
using Microsoft.Practices.Unity.Configuration;

namespace Employee
{
    public class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();
            container.LoadConfiguration();
            var bl = container.Resolve<IEmployeeBusinessLogic>();
            var salary = bl.GetSalary(1);
            Console.WriteLine("Employee 1 has salary {0}", salary);
        }
    }
}