using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.Model
{
    public class StudentDal
    {
        LoginEntity entity = new LoginEntity();

        public List<Student> GetStudents()
        {
            var Students = from u in entity.Student
                           select u;
            //AsNoTracking() 无变动跟踪，提高EF查询性能
            //只能用于查询，不能用于其他赋值的操作，只做查询 ，不用做修改时可以用
            return Students.ToList();
        }     
    }
}
