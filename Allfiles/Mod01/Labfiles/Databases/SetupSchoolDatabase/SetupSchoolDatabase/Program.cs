using SchoolDatabase;

namespace CreateShoolDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new SchoolContext();
            context.Database.EnsureCreated();
        }
    }
}
