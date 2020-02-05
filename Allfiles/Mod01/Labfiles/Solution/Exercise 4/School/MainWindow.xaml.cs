using Microsoft.EntityFrameworkCore;
using SchoolDatabase;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace School
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Connection to the School database
        private SchoolContext _schoolContext = null;

        // Field for tracking the currently selected teacher
        private Teacher _currentTeacher = null;

        // List for tracking the students assigned to the teacher's class
        // private IList studentsInfo = null;

        private ObservableCollection<Teacher> _teachers;
        private ObservableCollection<Student> _students;

        #region Predefined code

        public MainWindow()
        {
            InitializeComponent();
        }



        // Connect to the database and display the list of teachers when the window appears
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this._schoolContext = new SchoolContext();
            this._schoolContext.Teachers.Load();
            _teachers = this._schoolContext.Teachers.Local.ToObservableCollection();
            teachersList.DataContext = _teachers;
            this._schoolContext.Students.Load();
            _students = this._schoolContext.Students.Local.ToObservableCollection();
            studentsList.DataContext = _students;
        }

        // When the user selects a different teacher, fetch and display the students for that teacher
        private void teachersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //// Find the teacher that has been selected
            this._currentTeacher = teachersList.SelectedItem as Teacher;
            //this.schoolContext.Entry<Teacher>(teacher).Collection(t => t.Students).Load();

            //// Find the students for this teacher
            //this.studentsInfo = teacher.Students.ToList();

            //// Use databinding to display these students
            //studentsList.DataContext = this.studentsInfo;

            CollectionViewSource.GetDefaultView(this._students).Filter = student => (student as Student).ClassId == _currentTeacher.Id;
        }

        #endregion

        // When the user presses a key, determine whether to add a new student to a class, remove a student from a class, or modify the details of a student
        private void studentsList_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                // If the user pressed Enter, edit the details for the currently selected student
                case Key.Enter: Student student = this.studentsList.SelectedItem as Student;

                    // Use the StudentsForm to display and edit the details of the student
                    StudentForm sf = new StudentForm();

                    // Set the title of the form and populate the fields on the form with the details of the student           
                    sf.Title = "Edit Student Details";
                    sf.firstName.Text = student.FirstName;
                    sf.lastName.Text = student.LastName;
                    sf.dateOfBirth.Text = student.DateOfBirth.ToString("d"); // Format the date to omit the time element

                    // Display the form
                    if (sf.ShowDialog().Value)
                    {
                        // When the user closes the form, copy the details back to the student
                        student.FirstName = sf.firstName.Text;
                        student.LastName = sf.lastName.Text;
                        // student.DateOfBirth = DateTime.Parse(sf.dateOfBirth.Text, CultureInfo.InvariantCulture);
                        student.DateOfBirth = DateTime.Parse(sf.dateOfBirth.Text);

                        // Enable saving (changes are not made permanent until they are written back to the database)
                        saveChanges.IsEnabled = true;
                    }
                    break;

                // If the user pressed Insert, add a new student
                case Key.Insert:

                    // Use the StudentsForm to get the details of the student from the user
                    sf = new StudentForm();

                    // Set the title of the form to indicate which class the student will be added to (the class for the currently selected teacher)
                    sf.Title = "New Student for Class " + _currentTeacher.Class;

                    // Display the form and get the details of the new student
                    if (sf.ShowDialog().Value)
                    {
                        // When the user closes the form, retrieve the details of the student from the form
                        // and use them to create a new Student object
                        Student newStudent = new Student();
                        newStudent.FirstName = sf.firstName.Text;
                        newStudent.LastName = sf.lastName.Text;
                        newStudent.DateOfBirth = DateTime.Parse(sf.dateOfBirth.Text, CultureInfo.InvariantCulture);
                        newStudent.ClassId = _currentTeacher.Id;
                        // Assign the new student to the current teacher
                        this._currentTeacher.Students.Add(newStudent);

                        // Add the student to the list displayed on the form
                        this._students.Add(newStudent);

                        // Enable saving (changes are not made permanent until they are written back to the database)
                        saveChanges.IsEnabled = true;
                    }
                    break;

                // If the user pressed Delete, remove the currently selected student
                case Key.Delete: student = this.studentsList.SelectedItem as Student;

                    // Prompt the user to confirm that the student should be removed
                    MessageBoxResult response = MessageBox.Show(
                        String.Format("Remove {0}", student.FirstName + " " + student.LastName),
                        "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question,
                        MessageBoxResult.No);

                    // If the user clicked Yes, remove the student from the database
                    if (response == MessageBoxResult.Yes)
                    {
                        this._schoolContext.Students.Local.Remove(student);
                       

                        // Enable saving (changes are not made permanent until they are written back to the database)
                        saveChanges.IsEnabled = true;
                    }
                    break;
            }
        }

        #region Predefined code

        private void studentsList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
 
        }

        // Save changes back to the database and make them permanent
        private void saveChanges_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion
    }

    [ValueConversion(typeof(string), typeof(Decimal))]
    class AgeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
                              System.Globalization.CultureInfo culture)
        {
            // Convert the date of birth provided in the value parameter and convert to the age of the student in years
            // Check that the value provided is not null. If it is, return an empty string
            if (value != null)
            {
                // Convert the value provided into a DateTime value
                DateTime studentDateOfBirth = (DateTime)value;

                // Work out the difference between the current date and the value provided
                TimeSpan difference = DateTime.Now.Subtract(studentDateOfBirth);

                // Convert this result into a number of years
                int ageInYears = (int)(difference.Days / 365.25);

                // Convert the number of years into a string and return it
                return ageInYears.ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        #region Predefined code

        public object ConvertBack(object value, Type targetType, object parameter,
                                  System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
