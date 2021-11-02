using Employees.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Employees.Models.DataManager
{
    public class EmployeeManager : IDataRepository<Employee>
    {
        readonly EmployeeContext _employeeContext;

        public EmployeeManager(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }
        public IEnumerable<Employee> GetAll()
        {
            return _employeeContext.Employees.ToList();
        }

        public Employee Get(int id)
        {
            Employee employee = _employeeContext.Employees.FirstOrDefault(e => e.Id == id);
            return employee;
        }

        public void Post(Employee entity)
        {
            _employeeContext.Employees.Add(entity);
            _employeeContext.SaveChanges();
        }

        public void Put(Employee dbEntity, Employee entity)
        {
            dbEntity.Id = entity.Id;
            dbEntity.FirstName = entity.FirstName;
            dbEntity.LastName = entity.LastName;
            dbEntity.Salary = entity.Salary;

            _employeeContext.SaveChanges();
        }

        public void Delete(Employee entity)
        {
            _employeeContext.Employees.Remove(entity);
            _employeeContext.SaveChanges();
        }
    }
}
