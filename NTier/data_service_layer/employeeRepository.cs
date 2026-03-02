using Entity;
using Microsoft.Data.SqlClient;
namespace data_service_layer
{
    public class EmployeeRepository
    {
        public EmployeeRepository() { }
        public void SaveEmployee(Employee employee)
        {
            String connection_string = @"Data Source=(localdb)\ProjectModels;Initial Catalog=EnterpriseManagementDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";
            SqlConnection connection = new SqlConnection(connection_string);
            string query = "INSERT INTO Employees (firstName, lastName, age, salary, department) VALUES (@FirstName, @LastName, @Age, @Salary, @Department)";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                command.Parameters.AddWithValue("@LastName", employee.LastName);
                command.Parameters.AddWithValue("@Age", employee.Age);
                command.Parameters.AddWithValue("@Salary", employee.Salary);
                command.Parameters.AddWithValue("@Department", employee.Department);
                

                command.ExecuteNonQuery();
                Console.WriteLine("Employee is added successfully");

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while connecting to the database: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            String connection_string = @"Data Source=(localdb)\ProjectModels;Initial Catalog=EnterpriseManagementDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";
            SqlConnection connection = new SqlConnection(connection_string);
            string query = "SELECT id, firstName, lastName, age, salary, department FROM Employees";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Employee employee = new Employee
                    {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Age = reader.GetInt32(3),
                        Salary = reader.GetDouble(4),
                        Department = reader.GetString(5)
                    };
                    employees.Add(employee);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while fetching employees: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return employees;
        }

        public Employee GetEmployeeById(int id)
        {
            Employee employee = null;
            String connection_string = @"Data Source=(localdb)\ProjectModels;Initial Catalog=EnterpriseManagementDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";
            SqlConnection connection = new SqlConnection(connection_string);
            string query = "SELECT id, firstName, lastName, age, salary, department FROM Employees WHERE id = @Id";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    employee = new Employee
                    {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Age = reader.GetInt32(3),
                        Salary = reader.GetDouble(4),
                        Department = reader.GetString(5)
                    };
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while fetching employee: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return employee;
        }

        public void UpdateEmployee(Employee employee)
        {
            String connection_string = @"Data Source=(localdb)\ProjectModels;Initial Catalog=EnterpriseManagementDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";
            SqlConnection connection = new SqlConnection(connection_string);
            string query = "UPDATE Employees SET firstName = @FirstName, lastName = @LastName, age = @Age, salary = @Salary, department = @Department WHERE id = @Id";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", employee.Id);
                command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                command.Parameters.AddWithValue("@LastName", employee.LastName);
                command.Parameters.AddWithValue("@Age", employee.Age);
                command.Parameters.AddWithValue("@Salary", employee.Salary);
                command.Parameters.AddWithValue("@Department", employee.Department);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Employee updated successfully");
                }
                else
                {
                    Console.WriteLine("No employee found with the given ID");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating employee: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void DeleteEmployee(int id)
        {
            String connection_string = @"Data Source=(localdb)\ProjectModels;Initial Catalog=EnterpriseManagementDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";
            SqlConnection connection = new SqlConnection(connection_string);
            string query = "DELETE FROM Employees WHERE id = @Id";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Employee deleted successfully");
                }
                else
                {
                    Console.WriteLine("No employee found with the given ID");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while deleting employee: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
