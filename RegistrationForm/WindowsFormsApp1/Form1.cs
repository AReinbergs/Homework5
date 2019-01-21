using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WindowsFormsApp1.Enums;
using WindowsFormsApp1.Helpers;
using WindowsFormsApp1.Models;
using WindowsFormsApp1.DataAccess;

namespace WindowsFormsApp1
{
    public partial class frmRegistrationForm : Form
    {
        


        public frmRegistrationForm()
        {
            InitializeComponent();
        }

        private void frmRegistrationForm_Load(object sender, EventArgs e)
        {
            cmbGender.DataSource = Enum.GetNames(typeof(GenderEnum));
            cmbCountry.DataSource = Enum.GetNames(typeof(CountryEnum));
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (!Validator.ValidateNameOrSurname(txtName.Text))
            {
                erpError.SetError(txtName, "Invalid name! Must not be empty and contain only letters and dash.");
            }
            else
            {
                erpError.SetError(txtName, "");
            }
        }

        private void txtSurname_Validating(object sender, CancelEventArgs e)
        {
            if (!Validator.ValidateNameOrSurname(txtSurname.Text))
            {
                erpError.SetError(txtSurname, "Invalid surname! Must not be empty and contain only letters and dash.");
            }
            else
            {
                erpError.SetError(txtSurname, "");
            }
        }

        private void txtBirthdate_Validating(object sender, CancelEventArgs e)
        {
            if (!Validator.ValidateDate(txtBirthdate.Text))
            {
                erpError.SetError(txtBirthdate, "Invalid date! Must not be empty and be in format 'dd.mm.yyyy'.");
            }
            else
            {
                var date = Generator.GetBirthdate(txtBirthdate.Text);
                if (!Regex.IsMatch(txtSsn.Text, "\\d{6}-\\d{5}$"))
                {
                    txtSsn.Text = Generator.GenerateSsn(date);
                }

                erpError.SetError(txtBirthdate, "");
            }
        }

        private void txtSsn_Validating(object sender, CancelEventArgs e)
        {
            var date = Generator.GetBirthdate(txtBirthdate.Text);
            if (!Validator.ValidateSsn(txtSsn.Text, date))
            {
                erpError.SetError(txtSsn, "Invalid SSN! Must not be empty and be in format 'ddmmyy-xxxxx'.");
            }
            else
            {
                erpError.SetError(txtSsn, "");
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (!Validator.ValidateEmail(txtEmail.Text))
            {
                erpError.SetError(txtEmail, "Invalid Email! Must not be empty and be in format 'xxx.xxx@xxx.xx '.");
            }
            else
            {
                erpError.SetError(txtEmail, "");
            }
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            if (!Validator.ValidateNumber(txtPhone.Text))
            {
                erpError.SetError(txtPhone, "Invalid phone number! Must not be empty and contain only numbers.");
            }
            else
            {
                erpError.SetError(txtPhone, "");
            }
        }
               
        private void cmbGender_Validating(object sender, CancelEventArgs e)
        {
            if (cmbGender.SelectedIndex == 0)
            {
                erpError.SetError(cmbGender, "Please pick a gender.");
            }
            else
            {
                erpError.SetError(cmbGender, "");
            }
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            var employeeList = new List<Employee>();
            var employee = CreateEmployee();

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
        }
        
        private Employee CreateEmployee()
        {
            return new Employee()
            {
                CommonInfo = new CommonInfo
                {
                    Name = txtName.Text,
                    Surname = txtSurname.Text,
                    Birthday = string.IsNullOrEmpty(txtBirthdate.Text) ? (DateTime?)null : Generator.GetBirthdate(txtBirthdate.Text),
                    Ssn = txtSsn.Text,
                    Gender = (GenderEnum)cmbGender.SelectedIndex
                },
                ContactInfo = new ContactInfo
                {
                    Email = txtEmail.Text,
                    Phone = txtPhone.Text,
                    Country = (CountryEnum)cmbCountry.SelectedIndex,
                    City = txtCity.Text,
                    Street = txtStreet.Text,
                    ZipCode = txtZipCode.Text,
                    FullAddress = txtFullAddress.Text

                }
            };
        }
        
        private void btnInsertTestData_Click(object sender, EventArgs e)
        {
            txtName.Text = "John";
            txtSurname.Text = "Doe";
            txtBirthdate.Text = "01.02.2000";
            txtSsn.Text = "010200-12345";
            cmbGender.SelectedIndex = 1;
            txtEmail.Text = "john@doe.com";
            txtPhone.Text = "1234567";
            cmbCountry.SelectedIndex = 2;
            txtCity.Text = "Riga";
            txtStreet.Text = "Riga street 101";
            txtZipCode.Text = "LV-1010";
            txtFullAddress.Text = cmbCountry.Text + ",\r\n" + txtCity.Text + ",\r\n" + txtStreet.Text + ",\r\n" + txtZipCode.Text;

            //debugEmployee = CreateEmployee();

            //TODO: add address fake data
        }

        private void cmbCountry_Validating(object sender, CancelEventArgs e)
        {
            if (cmbCountry.SelectedIndex == 0)
            {
                erpError.SetError(cmbCountry, "Please pick a country.");
            }
            else
            {
                erpError.SetError(cmbCountry, "");
                txtFullAddress.Text = cmbCountry.Text + ",\r\n" + txtCity.Text + ",\r\n" + txtStreet.Text + ",\r\n" + txtZipCode.Text;
            }

        }

        private void txtCity_Validating(object sender, CancelEventArgs e)
        {
            if (!Validator.ValidateCity(txtCity.Text))
            {
                erpError.SetError(txtCity, "Invalid city name! Can't contain any numbers.");
            }
            else
            {
                erpError.SetError(txtCity, "");
                txtFullAddress.Text = cmbCountry.Text + ",\r\n" + txtCity.Text + ",\r\n" + txtStreet.Text + ",\r\n" + txtZipCode.Text;
            }
        }

        private void txtStreet_Validating(object sender, CancelEventArgs e)
        {
            if (!Validator.ValidateStreet(txtStreet.Text))
            {
                erpError.SetError(txtStreet, "Invalid Street! Has to start with capital letter and end with a numbers");
            }
            else
            {
                erpError.SetError(txtStreet, "");
                txtFullAddress.Text = cmbCountry.Text + ",\r\n" + txtCity.Text + ",\r\n" + txtStreet.Text + ",\r\n" + txtZipCode.Text;
            }
        }

        private void txtZipCode_Validating(object sender, CancelEventArgs e)
        {
            if (!Validator.ValidateZipCode(txtZipCode.Text))
            {
                erpError.SetError(txtZipCode, "Invalid Zip Code! Has to have two capital letters and four digits");
            }
            else
            {
                erpError.SetError(txtZipCode, "");
                txtFullAddress.Text = cmbCountry.Text + ",\r\n" + txtCity.Text + ",\r\n" + txtStreet.Text + ",\r\n" + txtZipCode.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmployeeGrid grid = new EmployeeGrid(CreateEmployee());
            grid.ShowDialog();

        }

        

    }
}
