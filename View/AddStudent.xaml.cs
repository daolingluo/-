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
using System.Windows.Shapes;

namespace demo.View
{
    /// <summary>
    /// AddStudent.xaml 的交互逻辑
    /// </summary>
    public partial class AddStudent : Window
    {
        private ViewModel.StudentManagerViewModel viewModel;
        public AddStudent(ObservableCollection<Student> StudentList)
        {
            InitializeComponent();
            this.DataContext = new StudentManagerViewModel();
            //刷新表格
            viewModel = DataContext as ViewModel.StudentManagerViewModel;
            this.viewModel.StudentList = StudentList;
        }
    }
}

