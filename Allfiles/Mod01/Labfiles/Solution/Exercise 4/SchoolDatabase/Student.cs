using System;

namespace SchoolDatabase
{
    public class Student : BindableBase
    {
        private string _firstName = string.Empty;
        private string _lastName = string.Empty;
        private DateTime _dateOfBirth;

        public int Id { get; set; }
        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value);
        }
        public string LastName
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value);
        }
        public DateTime DateOfBirth 
        { 
            get => _dateOfBirth; 
            set => SetProperty(ref _dateOfBirth, value); 
        }

        public int ClassId { get; set; }
        public Teacher Teacher { get; set; } = default!;
    }
}
