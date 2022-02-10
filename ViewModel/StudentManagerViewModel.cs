using demo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using demo.Common;

namespace demo.ViewModel
{
    public class StudentManagerViewModel : NotiticationObject
    {
        StudentBll bll = null;
        StudentDal dal=new StudentDal();
        public StudentManagerViewModel()
        {
            bll = new StudentBll();
            //Student = new Student();
            StudentList = FormatUtil<Student>.GetObservableCollection(bll.GetStudents());
            //直接列出下拉列表的数据
            this.QueryTeamList = new List<Student>()
            {
                new Student { Team = "", Id = -1 },
                new Student { Team = "高三1班", Id = 1 },
                new Student { Team = "高三2班", Id = 2 },
                new Student { Team = "高三3班", Id = 3 },
            };
            ////根据数据库sql得到数据(不会啊)
            //this.QueryTeamList = dal.GetTeam();

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
    }
}
