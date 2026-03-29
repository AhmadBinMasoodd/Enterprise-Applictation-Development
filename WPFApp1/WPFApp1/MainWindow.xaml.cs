using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFApp1.Models;

namespace WPFApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Student> students;
        private Student? selectedStudent;
        public MainWindow()
        {
            InitializeComponent();
            students = new ObservableCollection<Student>
            {
                new Student { Sname = "Alice", Sage = 20 },
                new Student { Sname = "Bob", Sage = 22 },
                new Student { Sname = "Charlie", Sage = 21 }
            };
            stdGrid.ItemsSource = students;
        }

        private void Clear_Student()
        {
            TbName.Clear();
            TbAge.Clear();
        }
        private void add_Student(object sender, RoutedEventArgs e)
        {
            if(TbName != null && TbAge != null)
            {
                string name = TbName.Text;
                if(int.TryParse(TbAge.Text, out int age))
                {
                    students.Add(new Student { Sname = name, Sage = age });
                    Clear_Student();
                }
                else
                {
                    MessageBox.Show("Please enter a valid age.");
                }
            }
        }

        private void delete_student(object sender, RoutedEventArgs e)
        {
            Student? student=stdGrid.SelectedItem as Student;
            if(student != null)
            {
                students.Remove(student);
            }
            else
            {
                MessageBox.Show("Please select a student to delete.");
            }
        }

        private void edit_student(object sender, RoutedEventArgs e)
        {
            selectedStudent = stdGrid.SelectedItem as Student;
            if(selectedStudent != null)
            {
                TbName.Text = selectedStudent.Sname;
                TbAge.Text = selectedStudent.Sage.ToString();
                

            }
            else
            {
                MessageBox.Show("Please select a student to edit.");
            }
        }

        private void update_student(object sender, RoutedEventArgs e)
        {
            if (selectedStudent != null)
            { 
                selectedStudent.Sname = TbName.Text;
                selectedStudent.Sage = int.TryParse(TbAge.Text, out int age) ? age : selectedStudent.Sage;
                //stdGrid.Items.Refresh();
                Clear_Student();
            }
        }
    }
}