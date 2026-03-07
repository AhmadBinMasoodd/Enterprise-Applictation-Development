using dsl.Models;
namespace dsl
{
    public class EmployeeRepository
    {
        private readonly EnterpriseManagementDbContext _db;

        public EmployeeRepository()
        {
            _db = new EnterpriseManagementDbContext();
        }

        public void AddSingleEmployee(Employee employee)
        {
            // Implementation to add an employee to the repository        
            _db.Employees.Add(employee);
            _db.SaveChanges();

        }
        public void AddMultipleEmployees(List<Employee> employees)
        {
            _db.Employees.AddRange(employees);
            _db.SaveChanges();

        }
        public List<Employee> GetAll()
        {
            List<Employee> employees = _db.Employees.ToList();

            return employees;
        }

        public List<Employee> GetEmployeesByDepartment(string department)
        {
            List<Employee> employees = _db.Employees.Where(e => e.Department == department).ToList();
            return employees;
        }

        public void DeleteEmployeeById(int id)
        {
            Employee? employee = _db.Employees.Find(id);
            if (employee != null)
            {
                _db.Employees.Remove(employee);
                _db.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Employee with ID {id} not found.");
            }
        }

        public void updateEmployee(Employee employee)
        {
            Employee? existingEmployee = _db.Employees.Find(employee.Id);
            if (existingEmployee != null)
            {
                existingEmployee.FirstName = employee.FirstName;
                existingEmployee.LastName = employee.LastName;
                existingEmployee.Age = employee.Age;
                existingEmployee.Salary = employee.Salary;
                existingEmployee.Department = employee.Department;
                _db.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Employee with ID {employee.Id} not found.");
            }
        }
    }
}
