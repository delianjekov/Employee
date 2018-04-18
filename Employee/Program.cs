using System;
using Employee.Core.BusinessLayer;
using Employee.Core.DataAccess;
using Unity;
using Microsoft.Practices.Unity.Configuration;

namespace Employee
{
    public class Program
    {
        static void Main()
        {
            var container = new UnityContainer();
            container.LoadConfiguration();
            var unitOfWorkFactory = container.Resolve<IUnitOfWorkFactory>();
            var businessLayerFactory = container.Resolve<IBusinessLogicFactory>();

            using (var unitOfWork = unitOfWorkFactory.ReadOnly)
            {
                var employeeBusinessLogic = businessLayerFactory.CreateSpecific<Data.Employee, IEmployeeBusinessLogic>(unitOfWork);
                var employees = employeeBusinessLogic.GetAll();
                foreach (var employee in employees)
                {
                    Console.WriteLine("{0} {1} at the age of {2} has salary {3}", employee.Name, employee.Surname,
                        employee.Age, employee.EmployeeType.Salary);
                }
            }
        }
    }
}