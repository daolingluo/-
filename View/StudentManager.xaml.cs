using demo.Model;
using demo.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace demo.View
{
    /// <summary>
    /// StudentManager.xaml 的交互逻辑
    /// </summary>
    public partial class StudentManager : Page
    {
        public StudentManager()
        {
            InitializeComponent();
            this.DataContext = new StudentManagerViewModel();

            //测试数据
            //ObservableCollection<Student> students = new ObservableCollection<Student>();
            //students.Add(new Student()
            //{
            //    Id = 1,
            //    Name = "张三1",
            //    Age = 20,
            //    Gender = "男",
            //    Team = "高三2班"
            //});
            //students.Add(new Student()
            //{
            //    Id = 2,
            //    Name = "张三2",
            //    Age = 20,
            //    Gender = "男",
            //    Team = "高三2班"
            //});
            //students.Add(new Student()
            //{
            //    Id = 3,
            //    Name = "张三3",
            //    Age = 20,
            //    Gender = "男",
            //    Team = "高三2班"
            //});
            ////绑定datagrid的来源
            //studentList.ItemsSource = students;
        }

        /// <summary>
        /// 每增加一行，自动+1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }
    }
}
