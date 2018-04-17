using Employee.Core.DataAccess;

namespace Employee.BusinessLayer
{
    public class EmployeeBusinessLogic : BusinessLogic<DataAccess.Employee, int>, IEmployeeBusinessLogic
    {
        public EmployeeBusinessLogic(IRepository<DataAccess.Employee, int> employeeRepository) : base(employeeRepository) { }

        public int GetSalary(int id)
        {
            var employee = FindById(id);
            return employee.EmployeeType.Salary;
        }
    }
}