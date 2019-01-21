using System.Data;
using System.Windows.Forms;
using WindowsFormsApp1.DataAccess;
using WindowsFormsApp1.Models;
using WindowsFormsApp1.Enums;
using System.Collections.Generic;
using System;

namespace WindowsFormsApp1
{
    public partial class EmployeeGrid : Form
    {
        List<Employee> _employeeList = new List<Employee>();
       
        internal EmployeeGrid(Employee employee)
        {
            InitializeComponent();
            _employeeList.Add(employee);
            SetDataIntoGrid(_employeeList);
        }

        private DataTable GenerateTable(List<Employee> employeeList)
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Surname", typeof(string));
            dataTable.Columns.Add("Birthday", typeof(string));
            dataTable.Columns.Add("SSN", typeof(string));
            dataTable.Columns.Add("Gender", typeof(string));
            dataTable.Columns.Add("Email", typeof(string));
            dataTable.Columns.Add("Phone", typeof(string));
            dataTable.Columns.Add("Country", typeof(string));
            dataTable.Columns.Add("City", typeof(string));
            dataTable.Columns.Add("Street", typeof(string));
            dataTable.Columns.Add("ZipCode", typeof(string));
            dataTable.Columns.Add("Full Address", typeof(string));

            foreach (var employee in employeeList)
            {
                dataTable.Rows.Add(
                employee.CommonInfo.Name,
                employee.CommonInfo.Surname,
                employee.CommonInfo.Birthday,
                employee.CommonInfo.Ssn,
                employee.CommonInfo.Gender,
                employee.ContactInfo.Email,
                employee.ContactInfo.Phone,                
                employee.ContactInfo.Country,
                employee.ContactInfo.City,
                employee.ContactInfo.Street,
                employee.ContactInfo.ZipCode,
                employee.ContactInfo.FullAddress
                );
            }

            return dataTable;
        }

        private void btnSaveToDatabase_Click(object sender, EventArgs e)
        {
            var employeeList = new List<Employee>();


            Employee employee = new Employee
            {
                CommonInfo = new CommonInfo
                {
                    Name = dgwEmployee.Rows[0].Cells[0].Value.ToString(),
                    Surname = dgwEmployee.Rows[0].Cells[1].Value.ToString(),
                    Birthday = string.IsNullOrEmpty(dgwEmployee.Rows[0].Cells[2].Value.ToString()) ? (DateTime?)null : DateTime.Parse(dgwEmployee.Rows[0].Cells[2].Value.ToString()),
                    Ssn = dgwEmployee.Rows[0].Cells[3].Value.ToString(),
                    Gender = (GenderEnum)Enum.Parse(typeof(GenderEnum), dgwEmployee.Rows[0].Cells[4].Value.ToString(), true)
                },

                ContactInfo = new ContactInfo
                {
                    Email = dgwEmployee.Rows[0].Cells[5].Value.ToString(),
                    Phone = dgwEmployee.Rows[0].Cells[6].Value.ToString(),
                    Country = (CountryEnum)Enum.Parse(typeof(CountryEnum),dgwEmployee.Rows[0].Cells[7].Value.ToString(), true),
                    City = dgwEmployee.Rows[0].Cells[8].Value.ToString(),
                    Street = dgwEmployee.Rows[0].Cells[9].Value.ToString(),
                    ZipCode = dgwEmployee.Rows[0].Cells[10].Value.ToString(),
                    FullAddress = dgwEmployee.Rows[0].Cells[11].Value.ToString()
                }

            };


            if (employee.IsValid())
            {
                employeeList.Add(employee);

                var message = DataBase.SaveEmployeeDataToDataBase(employeeList);

                MessageBox.Show(message);
            }
            else
            {
                MessageBox.Show("Please enter valid Employee information!");
            }

            //TODO: Implement Save functionality      
        }

        private void btnGetFromDatabase_Click(object sender, EventArgs e)
        {
            var employee = DataBase.GetDataFromDatabase();
            SetDataIntoGrid(employee);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchName.Text))
            {
                MessageBox.Show("Please enter search criteria");
            }
            else
            {

                (dgwEmployee.DataSource as DataTable).DefaultView.RowFilter = string.Format("Name LIKE '{0}%'", txtSearchName.Text);
                //TODO: Implement Search functionality    
            }
        }

        private void SetDataIntoGrid(List<Employee> employeeList)
        {
            dgwEmployee.DataSource = null;
            dgwEmployee.Refresh();
            dgwEmployee.DataSource = GenerateTable(employeeList);
        }       
    }
}
