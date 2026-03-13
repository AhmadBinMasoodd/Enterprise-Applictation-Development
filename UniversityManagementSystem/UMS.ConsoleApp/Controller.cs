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
                    TeacherServices teacherService = new TeacherServices();

                    Console.WriteLine("\nTeacher Management");
                    Console.WriteLine("1. Add Teacher");
                    Console.WriteLine("2. View ALL Teachers");
                    Console.WriteLine("3. Update Teacher");
                    Console.WriteLine("4. Delete Teacher");
                    Console.WriteLine("5. View Teachers By Department");

                    string? subChoice = Console.ReadLine();

                    if (subChoice == "1")
                    {
                        Teacher teacher = new Teacher();

                        Console.Write("Enter Teacher Name: ");
                        teacher.Name = Console.ReadLine()!;

                        Console.Write("Enter Email: ");
                        teacher.Email = Console.ReadLine()!;

                        Console.Write("Enter Department Id: ");
                        teacher.FkDepartmentId = int.Parse(Console.ReadLine()!);

                        teacherService.AddTeacher(teacher);
                    }

                    else if (subChoice == "2")
                    {
                        var teachers = teacherService.GetAllTeachers();

                        foreach (var t in teachers)
                        {
                            Console.WriteLine($"ID: {t.PkTeacherId}  Name: {t.Name}  Email: {t.Email}  DeptId: {t.FkDepartmentId}");
                        }
                    }

                    else if (subChoice == "3")
                    {
                        Console.Write("Enter Teacher Id to Update: ");
                        int id = int.Parse(Console.ReadLine()!);

                        Teacher? teacher = teacherService.GetTeacherById(id);

                        if (teacher != null)
                        {
                            Console.Write("Enter New Name: ");
                            teacher.Name = Console.ReadLine()!;

                            Console.Write("Enter New Email: ");
                            teacher.Email = Console.ReadLine()!;

                            Console.Write("Enter New Department Id: ");
                            teacher.FkDepartmentId = int.Parse(Console.ReadLine()!);

                            teacherService.UpdateTeacher(teacher);
                        }
                        else
                        {
                            Console.WriteLine("Teacher not found.");
                        }
                    }

                    else if (subChoice == "4")
                    {
                        Console.Write("Enter Teacher Id to Delete: ");
                        int id = int.Parse(Console.ReadLine()!);

                        teacherService.DeleteTeacherById(id);
                    }
                    else if (subChoice == "5")
                    {
                        Console.Write("Enter Department Id to View Teachers: ");
                        int id= int.Parse(Console.ReadLine()!);

                        var teachers=teacherService.GetTeachersByDepartmentId(id);
                        if(teachers != null)
                        {
                            foreach(var teacher in teachers)
                            {
                                Console.WriteLine($"ID: {teacher.PkTeacherId}  Name: {teacher.Name}  Email: {teacher.Email}  DeptId: {teacher.FkDepartmentId}");

                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Teacher Option");
                    }
                }
                else if (choice == "b")
                {
                    StudentServices studentService = new StudentServices();

                    Console.WriteLine("\nStudent Management");
                    Console.WriteLine("1. Add Student");
                    Console.WriteLine("2. View Students");
                    Console.WriteLine("3. Update Student");
                    Console.WriteLine("4. Delete Student");

                    string? subChoice = Console.ReadLine();

                    if (subChoice == "1")
                    {
                        Student student = new Student();

                        Console.Write("Enter Student Name: ");
                        student.StudentName = Console.ReadLine()!;

                        Console.Write("Enter Age: ");
                        student.Age = int.Parse(Console.ReadLine()!);

                        Console.Write("Enter Email: ");
                        student.Email = Console.ReadLine()!;

                        Console.Write("Enter Department Id: ");
                        student.DepartmentId = int.Parse(Console.ReadLine()!);

                        studentService.CheckStudentAge(student);
                        studentService.AddStudent(student);
                    }

                    else if (subChoice == "2")
                    {
                        var students = studentService.GetAllStudents();

                        foreach (var s in students)
                        {
                            Console.WriteLine($"ID: {s.PkStudentId}  Name: {s.StudentName}  Age: {s.Age}  Email: {s.Email}  DeptId: {s.DepartmentId}");
                        }
                    }

                    else if (subChoice == "3")
                    {
                        Console.Write("Enter Student Id to Update: ");
                        int id = int.Parse(Console.ReadLine()!);

                        Student? student = studentService.GetStudentById(id);

                        if (student != null)
                        {
                            Console.Write("Enter New Name: ");
                            student.StudentName = Console.ReadLine()!;

                            Console.Write("Enter New Age: ");
                            student.Age = int.Parse(Console.ReadLine()!);

                            Console.Write("Enter New Email: ");
                            student.Email = Console.ReadLine()!;

                            Console.Write("Enter New Department Id: ");
                            student.DepartmentId = int.Parse(Console.ReadLine()!);

                            studentService.CheckStudentAge(student);
                            studentService.UpdateStudent(student);
                        }
                        else
                        {
                            Console.WriteLine("Student not found.");
                        }
                    }

                    else if (subChoice == "4")
                    {
                        Console.Write("Enter Student Id to Delete: ");
                        int id = int.Parse(Console.ReadLine()!);

                        Student student = new Student();
                        student.PkStudentId = id;

                        studentService.DeleteStudent(student);
                    }

                    else
                    {
                        Console.WriteLine("Invalid Option");
                    }
                }
                else if (choice == "c")
                {
                    DepartmentServices departmentService = new DepartmentServices();

                    Console.WriteLine("\nDepartment Management");
                    Console.WriteLine("1. Add Department");
                    Console.WriteLine("2. View Departments");
                    Console.WriteLine("3. Update Department");
                    Console.WriteLine("4. Delete Department");
                    Console.WriteLine("5. View Teacher By Department Id");
                    string? subChoice = Console.ReadLine();

                    if (subChoice == "1")
                    {
                        Department department = new Department();

                        Console.Write("Enter Department Name: ");
                        department.DepartmentName = Console.ReadLine()!;

                        Console.Write("Enter Location: ");
                        department.Location = Console.ReadLine()!;

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
                        int id = int.Parse(Console.ReadLine()!);

                        Department? department = departmentService.GetDepartmentById(id);

                        if (department != null)
                        {
                            Console.Write("Enter New Department Name: ");
                            department.DepartmentName = Console.ReadLine()!;

                            Console.Write("Enter New Location: ");
                            department.Location = Console.ReadLine()!;

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
                        int id = int.Parse(Console.ReadLine()!);

                        departmentService.DeleteDepartment(id);
                    }
                    else if (subChoice == "5")
                    {
                        Console.WriteLine("Enter the department id: ");
                        int id=int.Parse(Console.ReadLine()!);
                        var teachers=departmentService.GetTeachersOfDepartment(id);

                        foreach(var teacher in teachers)
                        {
                            Console.WriteLine($"ID: {teacher.PkTeacherId}  Name: {teacher.Name}  Email: {teacher.Email}  DeptId: {teacher.FkDepartmentId}");

                        }
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
                        course.CourseName = Console.ReadLine()!;

                        Console.Write("Enter Credit Hours: ");
                        course.Credits = int.Parse(Console.ReadLine()!);

                        Console.Write("Enter Department Id: ");
                        course.FkDepartmenId = int.Parse(Console.ReadLine()!);

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
                        int id = int.Parse(Console.ReadLine()!);

                        Course? course = courseService.GetCourseById(id);

                        if (course != null)
                        {
                            Console.Write("Enter New Course Name: ");
                            course.CourseName = Console.ReadLine()!;

                            Console.Write("Enter New Credit Hours: ");
                            course.Credits = int.Parse(Console.ReadLine()!);

                            Console.Write("Enter New Department Id: ");
                            course.FkDepartmenId = int.Parse(Console.ReadLine()!);

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
                        int id = int.Parse(Console.ReadLine()!);

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