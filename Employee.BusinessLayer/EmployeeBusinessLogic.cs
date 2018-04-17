using Employee.Core.BusinessLayer;
using Employee.Core.DataAccess;

namespace Employee.BusinessLayer
{
    public class EmployeeBusinessLogic : BusinessLogic<Data.Employee, int>, IEmployeeBusinessLogic
    {
        public EmployeeBusinessLogic(IRepository<Data.Employee, int> employeeRepository) : base(employeeRepository) { }

        public int GetSalary(int id)
        {
            var employee = FindById(id);
            return employee.EmployeeType.Salary;
        }
    }
}