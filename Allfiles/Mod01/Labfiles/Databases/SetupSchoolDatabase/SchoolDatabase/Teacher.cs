using System.Collections.Generic;

namespace SchoolDatabase
{
    public class Teacher : BindableBase
    {
        private string _firstName = string.Empty;
        private string _lastName = string.Empty;

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

        public string Class { get; set; } = string.Empty;

        public ICollection<Student> Students { get; } = new HashSet<Student>();

    }
}
