using UMS.BusinessLogic;
using UMS.DataAccess;

namespace UMS.ConsoleApp
{
    public class Controller
    {
        public void AdminFunctionality()
        {
            Console.WriteLine("Welcome To Admin Panel");

            while (true)
            {
                Console.WriteLine("\nSelect Option:");
                Console.WriteLine("a. Manage Teachers");
                Console.WriteLine("b. Manage Students");
                Console.WriteLine("c. Manage Departments");
                Console.WriteLine("d. Manage Courses");
                Console.WriteLine("e. Exit");
                Console.Write("Your Choice: ");

                string? choice = Console.ReadLine();

                if (choice == "a")
                {
                    Console.WriteLine("\nTeacher Management");
                    Console.WriteLine("1. Add Teacher");
                    Console.WriteLine("2. View Teachers");
                    Console.WriteLine("3. Update Teacher");
                    Console.WriteLine("4. Delete Teacher");

                    string? subChoice = Console.ReadLine();

                    if (subChoice == "1")
                    {

                    }
                        

                    else if (subChoice == "2")
                        Console.WriteLine("Displaying Teachers");
                    else if (subChoice == "3")
                        Console.WriteLine("Teacher Updated Successfully");
                    else if (subChoice == "4")
                        Console.WriteLine("Teacher Deleted Successfully");
                    else
                        Console.WriteLine("Invalid Teacher Option");
                }
                else if (choice == "b")
                {
                    Console.WriteLine("\nStudent Management");
                    Console.WriteLine("1. Add Student");
                    Console.WriteLine("2. View Students");
                    Console.WriteLine("3. Update Student");
                    Console.WriteLine("4. Delete Student");

                    string? subChoice = Console.ReadLine();

                    if (subChoice == "1")
                        Console.WriteLine("Student Added Successfully");
                    else if (subChoice == "2")
                        Console.WriteLine("Displaying Students");
                    else if (subChoice == "3")
                        Console.WriteLine("Student Updated Successfully");
                    else if (subChoice == "4")
                        Console.WriteLine("Student Deleted Successfully");
                    else
                        Console.WriteLine("Invalid Student Option");
                }
                else if (choice == "c")
                {
                    DepartmentServices departmentService = new DepartmentServices();

                    Console.WriteLine("\nDepartment Management");
                    Console.WriteLine("1. Add Department");
                    Console.WriteLine("2. View Departments");
                    Console.WriteLine("3. Update Department");
                    Console.WriteLine("4. Delete Department");

                    string? subChoice = Console.ReadLine();

                    if (subChoice == "1")
                    {
                        Department department = new Department();

                        Console.Write("Enter Department Name: ");
                        department.DepartmentName = Console.ReadLine();

                        Console.Write("Enter Location: ");
                        department.Location = Console.ReadLine();

                        // CreatedDate will be set in Service layer automatically
                        departmentService.AddDepartment(department);
                    }

                    else if (subChoice == "2")
                    {
                        var departments = departmentService.GetAllDepartments();

                        foreach (var d in departments)
                        {
                            Console.WriteLine($"ID: {d.PkDepartmentId}  Name: {d.DepartmentName}  Location: {d.Location}  Created: {d.CreatedDate}");
                        }
                    }

                    else if (subChoice == "3")
                    {
                        Console.Write("Enter Department Id to Update: ");
                        int id = int.Parse(Console.ReadLine());

                        Department? department = departmentService.GetDepartmentById(id);

                        if (department != null)
                        {
                            Console.Write("Enter New Department Name: ");
                            department.DepartmentName = Console.ReadLine();

                            Console.Write("Enter New Location: ");
                            department.Location = Console.ReadLine();

                            // Do NOT modify CreatedDate
                            departmentService.UpdateDepartment(department);
                        }
                        else
                        {
                            Console.WriteLine("Department not found");
                        }
                    }

                    else if (subChoice == "4")
                    {
                        Console.Write("Enter Department Id to Delete: ");
                        int id = int.Parse(Console.ReadLine());

                        departmentService.DeleteDepartment(id);
                    }

                    else
                    {
                        Console.WriteLine("Invalid Department Option");
                    }
                }
                else if (choice == "d")
                {
                    CourseServices courseService = new CourseServices();

                    Console.WriteLine("\nCourse Management");
                    Console.WriteLine("1. Add Course");
                    Console.WriteLine("2. View Courses");
                    Console.WriteLine("3. Update Course");
                    Console.WriteLine("4. Delete Course");

                    string? subChoice = Console.ReadLine();

                    if (subChoice == "1")
                    {
                        Course? course = new Course();

                        Console.Write("Enter Course Name: ");
                        course.CourseName = Console.ReadLine();

                        Console.Write("Enter Credit Hours: ");
                        course.Credits = int.Parse(Console.ReadLine());

                        Console.Write("Enter Department Id: ");
                        course.FkDepartmenId = int.Parse(Console.ReadLine());

                        courseService.AddCourse(course);
                    }

                    else if (subChoice == "2")
                    {
                        var courses = courseService.GetAllCourses();

                        foreach (var c in courses)
                        {
                            Console.WriteLine($"ID: {c.PkCourseId}  Name: {c.CourseName}  Credits: {c.Credits}  DepartmentId: {c.FkDepartmenId}");
                        }
                    }

                    else if (subChoice == "3")
                    {
                        Console.Write("Enter Course Id to Update: ");
                        int id = int.Parse(Console.ReadLine());

                        Course? course = courseService.GetCourseById(id);

                        if (course != null)
                        {
                            Console.Write("Enter New Course Name: ");
                            course.CourseName = Console.ReadLine();

                            Console.Write("Enter New Credit Hours: ");
                            course.Credits = int.Parse(Console.ReadLine());

                            Console.Write("Enter New Department Id: ");
                            course.FkDepartmenId = int.Parse(Console.ReadLine());

                            courseService.UpdateCourse(course);
                        }
                        else
                        {
                            Console.WriteLine("Course not found");
                        }
                    }

                    else if (subChoice == "4")
                    {
                        Console.Write("Enter Course Id to Delete: ");
                        int id = int.Parse(Console.ReadLine());

                        courseService.DeleteCourse(id);
                    }

                    else
                    {
                        Console.WriteLine("Invalid Course Option");
                    }
                }
                else if (choice == "e")
                {
                    Console.WriteLine("Exiting Admin Panel...");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Choice. Please try again.");
                }
            }
        }
    }
}