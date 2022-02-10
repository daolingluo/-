using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.Model
{
    public class StudentBll
    {
        StudentDal dal = new StudentDal();
        public List<Student> GetStudents()
        {
            return dal.GetStudents();
        }
    }
}
