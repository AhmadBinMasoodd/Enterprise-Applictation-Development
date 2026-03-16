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
                    DepartmentServices departmentService = new DepartmentServices();

                    while (true)
                    {
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

                            teacher.Name = ReadRequiredString("Enter Teacher Name: ");
                            teacher.Email = ReadRequiredString("Enter Email: ");
                            teacher.FkDepartmentId = ReadDepartmentId(departmentService, "Enter Department Id: ");

                            teacherService.AddTeacher(teacher);
                            Console.WriteLine("Teacher added successfully.");
                            break;
                        }

                        if (subChoice == "2")
                        {
                            var teachers = teacherService.GetAllTeachers();

                            foreach (var t in teachers)
                            {
                                Console.WriteLine($"ID: {t.PkTeacherId}  Name: {t.Name}  Email: {t.Email}  DeptId: {t.FkDepartmentId}");
                            }

                            break;
                        }

                        if (subChoice == "3")
                        {
                            int id = ReadInt("Enter Teacher Id to Update: ");
                            Teacher? teacher = teacherService.GetTeacherById(id);

                            if (teacher != null)
                            {
                                teacher.Name = ReadRequiredString("Enter New Name: ");
                                teacher.Email = ReadRequiredString("Enter New Email: ");
                                teacher.FkDepartmentId = ReadDepartmentId(departmentService, "Enter New Department Id: ");

                                teacherService.UpdateTeacher(teacher);
                                Console.WriteLine("Teacher updated successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Teacher not found.");
                            }

                            break;
                        }

                        if (subChoice == "4")
                        {
                            int id = ReadInt("Enter Teacher Id to Delete: ");
                            Teacher? teacher = teacherService.GetTeacherById(id);

                            if (teacher != null)
                            {
                                teacherService.DeleteTeacherById(id);
                                Console.WriteLine("Teacher deleted successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Teacher not found.");
                            }

                            break;
                        }

                        if (subChoice == "5")
                        {
                            int id = ReadDepartmentId(departmentService, "Enter Department Id to View Teachers: ");
                            var teachers = teacherService.GetTeachersByDepartmentId(id);

                            if (teachers != null)
                            {
                                foreach (var teacher in teachers)
                                {
                                    Console.WriteLine($"ID: {teacher.PkTeacherId}  Name: {teacher.Name}  Email: {teacher.Email}  DeptId: {teacher.FkDepartmentId}");
                                }
                            }

                            break;
                        }

                        Console.WriteLine("Invalid Teacher Option");
                    }
                }
                else if (choice == "b")
                {
                    StudentServices studentService = new StudentServices();
                    DepartmentServices departmentService = new DepartmentServices();

                    while (true)
                    {
                        Console.WriteLine("\nStudent Management");
                        Console.WriteLine("1. Add Student");
                        Console.WriteLine("2. View Students");
                        Console.WriteLine("3. Update Student");
                        Console.WriteLine("4. Delete Student");
                        Console.WriteLine("5. View Students By Department Id");

                        string? subChoice = Console.ReadLine();

                        if (subChoice == "1")
                        {
                            Student student = new Student();

                            student.StudentName = ReadRequiredString("Enter Student Name: ");
                            student.Age = ReadInt("Enter Age: ");
                            student.Email = ReadRequiredString("Enter Email: ");
                            student.DepartmentId = ReadDepartmentId(departmentService, "Enter Department Id: ");

                            studentService.CheckStudentAge(student);
                            studentService.AddStudent(student);
                            Console.WriteLine("Student added successfully.");
                            break;
                        }

                        if (subChoice == "2")
                        {
                            var students = studentService.GetAllStudents();

                            foreach (var s in students)
                            {
                                Console.WriteLine($"ID: {s.PkStudentId}  Name: {s.StudentName}  Age: {s.Age}  Email: {s.Email}  DeptId: {s.DepartmentId}");
                            }

                            break;
                        }

                        if (subChoice == "3")
                        {
                            int id = ReadInt("Enter Student Id to Update: ");
                            Student? student = studentService.GetStudentById(id);

                            if (student != null)
                            {
                                student.StudentName = ReadRequiredString("Enter New Name: ");
                                student.Age = ReadInt("Enter New Age: ");
                                student.Email = ReadRequiredString("Enter New Email: ");
                                student.DepartmentId = ReadDepartmentId(departmentService, "Enter New Department Id: ");

                                studentService.CheckStudentAge(student);
                                studentService.UpdateStudent(student);
                                Console.WriteLine("Student updated successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Student not found.");
                            }

                            break;
                        }

                        if (subChoice == "4")
                        {
                            int id = ReadInt("Enter Student Id to Delete: ");
                            Student? student = studentService.GetStudentById(id);

                            if (student != null)
                            {
                                studentService.DeleteStudent(student);
                                Console.WriteLine("Student deleted successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Student not found.");
                            }

                            break;
                        }

                        if (subChoice == "5")
                        {
                            int id = ReadDepartmentId(departmentService, "Enter Department Id to View Students: ");
                            var students = studentService.GetStudentsByDepartmentId(id);

                            if (students != null)
                            {
                                foreach (var student in students)
                                {
                                    Console.WriteLine($"ID: {student.PkStudentId}  Name: {student.StudentName}  Age: {student.Age}  Email: {student.Email}  DeptId: {student.DepartmentId}");
                                }
                            }

                            break;
                        }

                        Console.WriteLine("Invalid Option");
                    }
                }
                else if (choice == "c")
                {
                    DepartmentServices departmentService = new DepartmentServices();

                    while (true)
                    {
                        Console.WriteLine("\nDepartment Management");

                        Console.WriteLine("1. Add Department");
                        Console.WriteLine("2. View Departments");
                        Console.WriteLine("3. Update Department");
                        Console.WriteLine("4. Delete Department");
                        Console.WriteLine("5. View Teacher By Department Id");
                        Console.WriteLine("6. Get Students Of Department");
                        Console.WriteLine("7. Get Courses of Department");
                        Console.WriteLine("8. Department Dashboard:");
                        string? subChoice = Console.ReadLine();

                        if (subChoice == "1")
                        {
                            Department department = new Department();

                            department.DepartmentName = ReadRequiredString("Enter Department Name: ");
                            department.Location = ReadRequiredString("Enter Location: ");

                            departmentService.AddDepartment(department);
                            Console.WriteLine("Department added successfully.");
                            break;
                        }

                        if (subChoice == "2")
                        {
                            var departments = departmentService.GetAllDepartments();

                            foreach (var d in departments)
                            {
                                Console.WriteLine($"ID: {d.PkDepartmentId}  Name: {d.DepartmentName}  Location: {d.Location}  Created: {d.CreatedDate}");
                            }

                            break;
                        }

                        if (subChoice == "3")
                        {
                            int id = ReadInt("Enter Department Id to Update: ");
                            Department? department = departmentService.GetDepartmentById(id);

                            if (department != null)
                            {
                                department.DepartmentName = ReadRequiredString("Enter New Department Name: ");
                                department.Location = ReadRequiredString("Enter New Location: ");

                                departmentService.UpdateDepartment(department);
                                Console.WriteLine("Department updated successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Department not found");
                            }

                            break;
                        }

                        if (subChoice == "4")
                        {
                            int id = ReadInt("Enter Department Id to Delete: ");
                            Department? department = departmentService.GetDepartmentById(id);

                            if (department != null)
                            {
                                departmentService.DeleteDepartment(id);
                                Console.WriteLine("Department deleted successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Department not found");
                            }

                            break;
                        }

                        if (subChoice == "5")
                        {
                            int id = ReadDepartmentId(departmentService, "Enter the department id: ");
                            var teachers = departmentService.GetTeachersOfDepartment(id);

                            foreach (var teacher in teachers)
                            {
                                var department = departmentService.GetDepartmentById(teacher.FkDepartmentId);
                                Console.WriteLine($"ID: {teacher.PkTeacherId}  Name: {teacher.Name}  Email: {teacher.Email}  Department: {department?.DepartmentName}");
                            }

                            break;
                        }

                        if (subChoice == "6")
                        {
                            int id = ReadDepartmentId(departmentService, "Enter the department id: ");
                            var students = departmentService.GetStudentsOfDepartment(id);
                            foreach (var student in students)
                            {
                                var department = departmentService.GetDepartmentById(student.DepartmentId);
                                Console.WriteLine($"ID: {student.PkStudentId}  Name: {student.StudentName}  Age: {student.Age}  Email: {student.Email}  Department: {department?.DepartmentName}");
                            }

                            break;
                        }

                        if (subChoice == "7")
                        {
                            int id = ReadDepartmentId(departmentService, "Enter the department id: ");
                            var courses = departmentService.GetCoursesOfDepartment(id);
                            foreach (var course in courses)
                            {
                                var department = departmentService.GetDepartmentById(course.FkDepartmenId);
                                Console.WriteLine($"ID: {course.PkCourseId}  Name: {course.CourseName}  Credits: {course.Credits}  Department: {department?.DepartmentName}");
                            }

                            break;
                        }

                        if (subChoice == "8")
                        {
                            int id = ReadDepartmentId(departmentService, "Enter the department id: ");
                            departmentService.DepartmentDashboard(id);
                            break;
                        }

                        Console.WriteLine("Invalid Department Option");
                    }
                }
                else if (choice == "d")
                {
                    CourseServices courseService = new CourseServices();
                    DepartmentServices departmentService = new DepartmentServices();

                    while (true)
                    {
                        Console.WriteLine("\nCourse Management");
                        Console.WriteLine("1. Add Course");
                        Console.WriteLine("2. View Courses");
                        Console.WriteLine("3. Update Course");
                        Console.WriteLine("4. Delete Course");

                        string? subChoice = Console.ReadLine();

                        if (subChoice == "1")
                        {
                            Course? course = new Course();

                            course.CourseName = ReadRequiredString("Enter Course Name: ");
                            course.Credits = ReadInt("Enter Credit Hours: ");
                            course.FkDepartmenId = ReadDepartmentId(departmentService, "Enter Department Id: ");

                            courseService.AddCourse(course);
                            Console.WriteLine("Course saved successfully.");
                            break;
                        }

                        if (subChoice == "2")
                        {
                            var courses = courseService.GetAllCourses();

                            foreach (var c in courses)
                            {
                                Console.WriteLine($"ID: {c.PkCourseId}  Name: {c.CourseName}  Credits: {c.Credits}  DepartmentId: {c.FkDepartmenId}");
                            }

                            break;
                        }

                        if (subChoice == "3")
                        {
                            int id = ReadInt("Enter Course Id to Update: ");
                            Course? course = courseService.GetCourseById(id);

                            if (course != null)
                            {
                                course.CourseName = ReadRequiredString("Enter New Course Name: ");
                                course.Credits = ReadInt("Enter New Credit Hours: ");
                                course.FkDepartmenId = ReadDepartmentId(departmentService, "Enter New Department Id: ");

                                courseService.UpdateCourse(course);
                                Console.WriteLine("Course updated successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Course not found");
                            }

                            break;
                        }

                        if (subChoice == "4")
                        {
                            int id = ReadInt("Enter Course Id to Delete: ");
                            Course? course = courseService.GetCourseById(id);

                            if (course != null)
                            {
                                courseService.DeleteCourse(id);
                                Console.WriteLine("Course deleted successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Course not found");
                            }

                            break;
                        }

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

        private static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int value))
                {
                    return value;
                }

                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }

        private static string ReadRequiredString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input.Trim();
                }

                Console.WriteLine("Input cannot be empty.");
            }
        }

        private static int ReadDepartmentId(DepartmentServices departmentService, string prompt)
        {
            while (true)
            {
                int id = ReadInt(prompt);
                if (departmentService.GetDepartmentById(id) != null)
                {
                    return id;
                }

                Console.WriteLine("Department not found. Please enter a valid department id.");
            }
        }
    }
}