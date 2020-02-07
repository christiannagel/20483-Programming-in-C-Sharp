using Grades.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradesPrototype.Services
{

    // Global context for operations performed by MainWindow
    public class SessionContext
    {
        public static SchoolGradesContext DBContext = new SchoolGradesContext();

        public static Guid UserID;
        public static string UserName;
       
        public static Role UserRole;
        public static Student CurrentStudent;
        public static Teacher CurrentTeacher;

        public static void Save()
        {
            DBContext.SaveChanges();
        }
    }
}
