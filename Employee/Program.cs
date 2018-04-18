using System;
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
            var factory = container.Resolve<IUnitOfWorkFactory>();

            using (var unitOfWork = factory.ReadOnly)
            {
                var employeeRepository = unitOfWork.GetRepository<Data.Employee>();
                var employees = employeeRepository.GetAll();
                foreach (var employee in employees)
                {
                    Console.WriteLine("{0} {1} at the age of {2} has salary {3}", employee.Name, employee.Surname,
                        employee.Age, employee.EmployeeType.Salary);
                }
            }
        }
    }
}