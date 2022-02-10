using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        /// <summary>
        /// 多条件查询学生信息
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public List<Student> GetQueryStudents(Student student)
        {
            IQueryable<Student> students;
            //同时查询学生姓名和班级
            if (!string.IsNullOrEmpty(student.Name) && !string.IsNullOrEmpty(student.Team))
            {
                students = from u in entity.Student
                           where u.Name == student.Name && u.Team == student.Team
                           select u;
                return students.AsNoTracking().ToList();
            }
            //查询学生的姓名
            else if (!string.IsNullOrEmpty(student.Name))
            {
                students = from u in entity.Student
                           where u.Name == student.Name
                           select u;
                return students.AsNoTracking().ToList();
            }
            //查询学生的班级
            else if (!string.IsNullOrEmpty(student.Team))
            {
                students = from u in entity.Student
                           where u.Team == student.Team
                           select u;
                return students.AsNoTracking().ToList();
            }
            //查询所有的学生信息
            else
            {
                students = from u in entity.Student
                           select u;
                return students.AsNoTracking().ToList();
            }
        }

        /// <summary>
        /// 添加学生
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public int Add(Student student)
        {
            entity.Student.Add(student);
            if (entity.SaveChanges() > 0)
                return student.Id;
            else
                return 0;
        }

        /// <summary>
        /// 根据id获取学生实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Student GetStudentById(int id)
        {
            var student = from u in entity.Student
                          where u.Id == id
                          select u;
            return student.AsNoTracking().FirstOrDefault();
        }


        /// <summary>
        /// 删除学生信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteStudent(int id)
        {
            Student s = entity.Student.Find(id);
            entity.Student.Remove(s);
            return entity.SaveChanges();
        }
    }
}
