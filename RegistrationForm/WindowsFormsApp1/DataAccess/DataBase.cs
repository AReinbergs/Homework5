using WindowsFormsApp1.Models;
using WindowsFormsApp1.Enums;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace WindowsFormsApp1.DataAccess
{
    public static class DataBase
    {
        public static List<Employee> GetDataFromDatabase()
        {
            var employeeList = new List<Employee>();
            var connectionString = GetConnectionString();

            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandText = "" +
                        $@"SELECT  emp.Name as Name 
                                  ,emp.Surname as Surname 
                                  ,emp.Birthdate as Birthdate 
                                  ,emp.SSN as SSN
                                  ,emp.Gender as Gender
                                  ,emp.Email as Email
                                  ,emp.Phone as Phone
                                  ,emp.City as City
                                  ,emp.Country as Country
                                  ,emp.Street as Street
                                  ,emp.ZipCode as ZipCode
                                  ,emp.FullAddress as FullAddress
                             FROM dbo.Employee emp";

                connection.Open();
                    
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Employee employee = new Employee
                        {
                            CommonInfo = new CommonInfo
                            {
                                Name = !reader.IsDBNull(reader.GetOrdinal("Name"))
                                        ? reader.GetString(reader.GetOrdinal("Name"))
                                        : null,
                                Surname = !reader.IsDBNull(reader.GetOrdinal("Surname"))
                                        ? reader.GetString(reader.GetOrdinal("Surname"))
                                        : null,
                                Birthday = !reader.IsDBNull(reader.GetOrdinal("Birthdate"))
                                        ? reader.GetDateTime(reader.GetOrdinal("Birthdate"))
                                        : (DateTime?)null,
                                Ssn = !reader.IsDBNull(reader.GetOrdinal("SSN"))
                                        ? reader.GetString(reader.GetOrdinal("SSN"))
                                        : null,
                                Gender = !reader.IsDBNull(reader.GetOrdinal("Gender"))
                                        ? (GenderEnum)Enum.Parse(typeof(GenderEnum), reader.GetString(reader.GetOrdinal("Gender")))
                                        : GenderEnum.None

                            }
                            ,

                            ContactInfo = new ContactInfo
                            {
                                Email = !reader.IsDBNull(reader.GetOrdinal("Email"))
                                        ? reader.GetString(reader.GetOrdinal("Email"))
                                        : null,
                                Phone = !reader.IsDBNull(reader.GetOrdinal("Phone"))
                                        ? reader.GetString(reader.GetOrdinal("Phone"))
                                        : null,
                                City = !reader.IsDBNull(reader.GetOrdinal("City"))
                                        ? reader.GetString(reader.GetOrdinal("City"))
                                        : null,
                                Country = !reader.IsDBNull(reader.GetOrdinal("Country"))
                                            ? (CountryEnum)Enum.Parse(typeof(CountryEnum), reader.GetString(reader.GetOrdinal("Country")))
                                            : CountryEnum.None,
                                Street = !reader.IsDBNull(reader.GetOrdinal("Street"))
                                            ? reader.GetString(reader.GetOrdinal("Street"))
                                            : null,
                                ZipCode = !reader.IsDBNull(reader.GetOrdinal("ZipCode"))
                                            ? reader.GetString(reader.GetOrdinal("ZipCode"))
                                            : null,
                                FullAddress = !reader.IsDBNull(reader.GetOrdinal("FullAddress"))
                                            ? reader.GetString(reader.GetOrdinal("FullAddress"))
                                            : null
                            }
                        };

                        employeeList.Add(employee);
                    }
                }            
            }

            return employeeList;          
        }

        public static string SaveEmployeeDataToDataBase(List<Employee> employeeList)
        {
            var connectionString = GetConnectionString();
            
           

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    var commandInsertEmployee = connection.CreateCommand();

                    connection.Open();

                    foreach (var employee in employeeList)
                    {
                        
                        commandInsertEmployee.CommandText += $"" +
                            $@"INSERT INTO dbo.Employee(Name, Surname, Birthdate, SSN, Gender, Email, Phone, City, Country, Street, ZipCode, FullAddress)
                                VALUES('{ employee.CommonInfo.Name}',
                                       '{employee.CommonInfo.Surname}', 
                                       '{employee.CommonInfo.Birthday}',
                                       '{employee.CommonInfo.Ssn}',
                                       '{employee.CommonInfo.Gender}',
                                        '{employee.ContactInfo.Email}',
                                        '{employee.ContactInfo.Phone}',
                                        '{employee.ContactInfo.City}',
                                        '{employee.ContactInfo.Country}',
                                        '{employee.ContactInfo.Street}',
                                        '{employee.ContactInfo.ZipCode}',
                                        '{employee.ContactInfo.FullAddress}') ";
                   }

                    commandInsertEmployee.ExecuteReader();

                    return "Data was successfully saved to database";
                }
                catch (Exception ex)
                {
                    return $"Data wasn't save to database due to error: {ex.Message}";
                }            
            }
        }

        private static string GetConnectionString()
        {
            //return "Integrated Security=SSPI;Initial Catalog=test;Data Source=localhost\\SQLEXPRESS;";
            return "Server=WSP2971B; Database=OrsXml; Trusted_Connection=True;";  

        }
    }
}