// See https://aka.ms/new-console-template for more information


using dsl;
using dsl.Models;

namespace entityFramework
{
   public class Program
    {
        public static void Main(string[] args)
        {
            Employee employee = new Employee();
            employee.FirstName = "Abdul";
            employee.LastName = "Samad";
            employee.Age = 30;
            employee.Salary = 50000.0;
            employee.Department = "IT";
               
            Employee employee2 = new Employee();
            employee2.FirstName = "Abdul";
            employee2.LastName = "Rafah";
            employee2.Age = 30;
            employee2.Salary = 50000.0;
            employee2.Department = "IT";


            EmployeeRepository employeeRepository = new EmployeeRepository();
            employeeRepository.AddSingleEmployee(employee);

            List<Employee> employees = new List<Employee>();

            employees=employeeRepository.GetAll();

            foreach(Employee employe in employees)
                
            {
                Console.WriteLine($"Id: {employe.Id}, Name: {employe.FirstName} {employe.LastName}, Age: {employe.Age}, Salary: {employe.Salary}, Department: {employe.Department}");
            }


            Employee employee3 = new Employee();
            employee3.Id = 1;
            employee3.FirstName = "Abdul";
            employee3.LastName = "Haseeb";
            employee3.Age = 30;
            employee3.Salary = 45000;
            employee3.Department = "Networking";
            employeeRepository.updateEmployee(employee3);

            employees = employeeRepository.GetAll();

            foreach (Employee employe in employees)

            {
                Console.WriteLine($"Id: {employe.Id}, Name: {employe.FirstName} {employe.LastName}, Age: {employe.Age}, Salary: {employe.Salary}, Department: {employe.Department}");
            }
        }
    }
}
