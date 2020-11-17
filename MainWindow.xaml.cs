using System;
using System.Collections.Generic;
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
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace wpf
{
    // Konstantin Konovalov
    // изменение данных сотрудников пока не реализовано 
    public partial class MainWindow : Window
    {
        ObservableCollection<Employee> emps = new ObservableCollection<Employee>();
        ObservableCollection<Department> deps = new ObservableCollection<Department>();
        public MainWindow()
        {
            InitializeComponent();
            FillListEmployee();
            FillComboDepartment();
        }
        void FillListEmployee()
        {
            emps.Add(new Employee()
            {
                FirstName = "Иван",
                LastName = "Сидоров",
                Age = 22,
                Salary = 3000,
                Department = "ИТ"
            });
            emps.Add(new Employee() {
                FirstName = "Пётр",
                LastName = "Иванов",
                Age = 25,
                Salary = 6000,
                Department = "Отдел Кадров" 
            });
            emps.Add(new Employee()
            {
                FirstName = "Авас",
                LastName = "Горидзе",
                Age = 23,
                Salary = 8000,
                Department = "Бухгалтерия"
            });
            lvEmployee.ItemsSource = emps;
        }
        void FillComboDepartment()
        {
            deps.Add(new Department()
            {
                Name = "Отдел Кадров"
            });
            deps.Add(new Department()
            {
                Name = "Бухгалтерия"
            });
            deps.Add(new Department()
            {
                Name = "ИТ"
            });
            cbDepartment.ItemsSource = deps;
            cbDepartment.SelectedIndex = 0;
            CbDepartmentEmployee.ItemsSource = deps;
            CbDepartmentEmployee.SelectedIndex = 0;
        }
        private void lbEmployee_Selected(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(e.Source.ToString());
        }

        private void lbEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show(e.AddedItems[0].ToString());
        }
        private void cbDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show(e.AddedItems[0].ToString());
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            deps.Add(new Department() { Name = tbDepartment.Text });
        }
        private void DelButton_Click(object sender, RoutedEventArgs e)
        {
            deps.RemoveAt(cbDepartment.Items.IndexOf(cbDepartment.SelectedItem));
        }
        private void BtnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            emps.Add(new Employee()
            {

                FirstName = TbFirstName.Text,
                LastName = TbLastName.Text,
                Age = Convert.ToInt32(TbAge.Text),
                Salary = Convert.ToDouble(TbSalary.Text),
                Department = CbDepartmentEmployee.SelectedItem.ToString()
            });
        }
        private void BtnDeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (lvEmployee.SelectedItem != null)
                emps.Remove(lvEmployee.SelectedItem as Employee);
        }
        private void btnChangeUser_Click(object sender, RoutedEventArgs e)
        {
            if (lvEmployee.SelectedItem != null)
                (lvEmployee.SelectedItem as Employee).FirstName = "Иван";
        }


    }

    public class Employee : INotifyPropertyChanged
    {
        private string _nameFirst;
        private string _nameLast;
        private int _age;
        private double _salary;
        private string _department;
        public string FirstName
        {
            get { return _nameFirst; }
            set
            {
                if (_nameFirst != value)
                {
                    _nameFirst = value;
                    NotifyPropertyChanged("FirstName");
                }
            }
        }
        public string LastName
        {
            get { return _nameLast; }
            set
            {
                if (_nameLast != value)
                {
                    _nameLast = value;
                    NotifyPropertyChanged("LastName");
                }
            }
        }
        public int Age
        {
            get { return _age; }
            set
            {
                if (_age != value)
                {
                    _age = value;
                    NotifyPropertyChanged("Age");
                }
            }
        }
        public double Salary
        {
            get { return _salary; }
            set
            {
                if (_salary != value)
                {
                    _salary = value;
                    NotifyPropertyChanged("Salary");
                }
            }
        }
        public string Department
        {
            get { return _department; }
            set
            {
                if (_department != value)
                {
                    _department = value;
                    NotifyPropertyChanged("Department");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public override string ToString()
        {
            return $"{_nameFirst} {_nameLast} {_age} {_salary} {_department}";
        }
    }
    public class Department
    {
        public string Name { get; set; }
        public override string ToString()
        {
            return $"{Name}";
        }
    }

}

