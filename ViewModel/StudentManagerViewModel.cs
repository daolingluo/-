using demo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using demo.Common;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using demo.View;

namespace demo.ViewModel
{
    public class StudentManagerViewModel : NotiticationObject
    {
        StudentBll bll = null;
        public StudentManagerViewModel()
        {
            bll = new StudentBll();
            Student = new Student();
            QueryStudent = new Student();
            StudentList = FormatUtil<Student>.GetObservableCollection(bll.GetStudents());
            this.QueryTeamList = new List<Student>()
            {
                new Student { Team = "", Id = -1 },
                new Student { Team = "高三1班", Id = 1 },
                new Student { Team = "高三2班", Id = 2 },
                new Student { Team = "高三3班", Id = 3 },
            };
        }

        private ObservableCollection<Student> studentList;
        public ObservableCollection<Student> StudentList
        {
            get
            {
                return studentList;
            }
            set
            {
                studentList = value;
                this.RaisePropertyChanged("StudentList");
            }
        }



        private List<Student> queryTeamList;
        public List<Student> QueryTeamList
        {
            get
            {
                return queryTeamList;
            }

            set
            {
                queryTeamList = value;
                this.RaisePropertyChanged("QueryTeamList");
            }
        }


        private Student queryStudent;
        public Student QueryStudent
        {
            get
            {
                return queryStudent;
            }

            set
            {
                queryStudent = value;
                this.RaisePropertyChanged("QueryStudent");
            }
        }


        private Student student;
        public Student Student
        {
            get
            {
                return student;
            }

            set
            {
                student = value;
                this.RaisePropertyChanged("Student");
            }
        }



        private ICommand queryCommand;

        public ICommand QueryCommand
        {
            get
            {
                return new RelayCommand(() => QueryStudentList());
            }

            set
            {
                queryCommand = value;
            }
        }



        private BaseCommand addCommand;
        /// <summary>
        /// 显示学生添加的窗口
        /// </summary>
        public BaseCommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new BaseCommand(new Action<object>(o =>
                    {
                        AddStudent add = new AddStudent(StudentList);            
                        //AddStudent add = new AddStudent();
                        add.Show();
                    }));
                }
                return addCommand;
            }
        }



        private ICommand saveCommand;

        public ICommand SaveCommand
        {
            get
            {
                return new RelayCommand<AddStudent>((AddST) => AddStudents(AddST));
            }

            set
            {
                saveCommand = value;
            }
        }


        private void AddStudents(AddStudent view)
        {
            if (ValidationFields(view))
            {
                Student.Name = view.Student_Name.Text;
                Student.Age = int.Parse(view.Student_Age.Text);
                Student.Gender = view.Student_Gender.Text;
                Student.Team = view.Student_Team.Text;
                var responseId = bll.Add(Student);
                if (responseId > 0)
                {
                    var students = bll.GetStudentById(responseId);
                    StudentList.Add(students);
                    MessageBox.Show("添加成功");
                    view.Close();
                }
                else
                {
                    MessageBox.Show("添加失败");
                }
            }
        }

        private bool ValidationFields(AddStudent win)
        {
            if (string.IsNullOrWhiteSpace(win.Student_Name.Text))
            {
                MessageBox.Show("学生姓名不能为空！");
                return false;
            }
            if (string.IsNullOrWhiteSpace(win.Student_Age.Text))
            {
                MessageBox.Show("学生年龄不能为空！");
                return false;
            }
            if (string.IsNullOrWhiteSpace(win.Student_Gender.Text))
            {
                MessageBox.Show("学生性别不能为空！");
                return false;
            }
            if (string.IsNullOrWhiteSpace(win.Student_Team.Text))
            {
                MessageBox.Show("学生班级不能为空！");
                return false;
            }
            return true;
        }

        private RelayCommand<Student> deleteCommand;
        /// <summary>
        /// 删除学生的命令
        /// </summary>
        public RelayCommand<Student> DeleteCommand
        {
            get
            {
                if (null == deleteCommand)
                {
                    deleteCommand = new RelayCommand<Student>((student) => DeleteStudents(student));
                }
                return deleteCommand;
            }
        }

        private void DeleteStudents(Student student)
        {
            {
                MessageBoxResult confirmToDel = MessageBox.Show("确定要删除所选行吗？", "提示",
                    MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (confirmToDel == MessageBoxResult.Yes)
                {
                    var response = bll.DeleteStudent(student.Id);
                    if (response > 0)
                    {
                        MessageBox.Show("删除成功！");
                        StudentList = FormatUtil<Student>.GetObservableCollection(bll.GetStudents());
                    }
                }
            }
        }

        private void QueryStudentList()
        {
            StudentList = FormatUtil<Student>.GetObservableCollection(bll.GetQueryStudents(QueryStudent));
        }
    }
}
