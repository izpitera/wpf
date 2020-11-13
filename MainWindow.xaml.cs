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

namespace wpf
{
    // Konstantin Konovalov
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
            emps.Add(new Employee() {  Id = 1, 
                                        nameFirst = "Иван", 
                                        nameLast = "Сидоров", 
                                        Age = 22, 
                                        Salary = 3000 });
            emps.Add(new Employee() {  Id = 2, 
                                        nameFirst = "Пётр", 
                                        nameLast = "Иванов", 
                                        Age = 25, 
                                        Salary = 6000 });
            emps.Add(new Employee() {  Id = 3, 
                                        nameFirst = "Авас", 
                                        nameLast = "Горидзе", 
                                        Age = 23, 
                                        Salary = 8000 });
            lbEmployee.ItemsSource = emps;
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
        }
        private void lbEmployee_Selected(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(e.Source.ToString());
        }

        private void lbEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show(e.AddedItems[0].ToString());
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            emps.Add(new Employee()
            {
                Id = 4,
                nameFirst = "Сергей",
                nameLast = "Шлюп",
                Age = 26,
                Salary = 7000
            });
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string nameFirst { get; set; }
        public string nameLast { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }
        public override string ToString()
        {
            return $"{Id,-3} {nameFirst,20} {nameLast,-20} {Age,-10} {Salary,-10}";
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

