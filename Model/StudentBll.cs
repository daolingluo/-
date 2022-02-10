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
        /// <summary>
        /// 获取所有的学生信息
        /// </summary>
        /// <returns></returns>
        public List<Student> GetStudents()
        {
            return dal.GetStudents();
        }

        /// <summary>
        /// 多条件查询学生信息
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public List<Student> GetQueryStudents(Student student)
        {
            return dal.GetQueryStudents(student);
        }

        /// <summary>
        /// 添加学生
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public int Add(Student student)
        {
            return dal.Add(student);
        }

        /// <summary>
        /// 根据id获取学生实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Student GetStudentById(int id)
        {
            return dal.GetStudentById(id);
        }

        /// <summary>
        /// 删除学生信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteStudent(int id)
        {
            return dal.DeleteStudent(id);
        }
    }
}
