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
        public StudentManagerViewModel()
        {
            bll = new StudentBll();
            //Student = new Student();
            StudentList = FormatUtil<Student>.GetObservableCollection(bll.GetStudents());
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
    }
}
