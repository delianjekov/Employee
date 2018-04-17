using Employee.Core.BusinessLayer;

namespace Employee.BusinessLayer
{
    public interface IEmployeeBusinessLogic : IBusinessLogic<DataAccess.Employee, int>
    {
        int GetSalary(int id);
    }
}