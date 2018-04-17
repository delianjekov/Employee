namespace Employee.Core.BusinessLayer
{
    public interface IEmployeeBusinessLogic : IBusinessLogic<Data.Employee, int>
    {
        int GetSalary(int id);
    }
}