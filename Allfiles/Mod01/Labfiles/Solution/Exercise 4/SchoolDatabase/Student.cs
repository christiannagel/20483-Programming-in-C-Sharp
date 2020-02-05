using System;

namespace ShoolDatabase
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }

        public int ClassId { get; set; }
        public Teacher Teacher { get; set; } = default!;
    }
}
