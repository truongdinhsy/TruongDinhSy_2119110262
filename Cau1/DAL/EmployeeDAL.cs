using System;
using System.Collections.Generic;
using System.Text;
using Cau1.DAO;
using System.Data.SqlClient;

namespace Cau1.DAL
{
    class EmployeeDAL:DBConnection
    {
        public EmployeeDAL() : base()
        {

        }
        public List<EmployeeDAO> ReadEmployee()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Employee_2119110262", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<EmployeeDAO> lstEmp = new List<EmployeeDAO>();
            DepartmentDAL dep = new DepartmentDAL();
            while (reader.Read())
            {
                EmployeeDAO emp = new EmployeeDAO();
                emp.IdEmployee = reader["IdEmployee"].ToString();
                emp.Name = reader["Name"].ToString();
                emp.Department = dep.ReadDepartment(reader["IdDepartment"].ToString());
                emp.PlaceBirth = reader["PlaceBirth"].ToString();
                emp.DateBirth = Convert.ToDateTime(reader["DateBirth"].ToString());
                emp.Gender = int.Parse(reader["Gender"].ToString());
                lstEmp.Add(emp);
            }
            conn.Close();
            return lstEmp;
        }

        public void DeleteEmployee(EmployeeDAO emp)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from Employee_2119110262 where IdEmployee = @IdEmployee", conn);
            cmd.Parameters.Add(new SqlParameter("@IdEmployee", emp.IdEmployee));
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void NewEmployee(EmployeeDAO emp)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(
                "insert into Employee_2119110262(IdEmployee,Name,IdDepartment,PlaceBirth,DateBirth,Gender) values(@IdEmployee,@Name,@IdDepartment,@PlaceBirth,@DateBirth,@Gender)", conn);
            cmd.Parameters.Add(new SqlParameter("@Name", emp.Name));
            cmd.Parameters.Add(new SqlParameter("@IdDepartment", emp.Department.IdDepartment));
            cmd.Parameters.Add(new SqlParameter("@PlaceBirth", emp.PlaceBirth));
            cmd.Parameters.Add(new SqlParameter("@DateBirth", emp.DateBirth));
            cmd.Parameters.Add(new SqlParameter("@Gender", emp.Gender));
            cmd.Parameters.Add(new SqlParameter("@IdEmployee", emp.IdEmployee));
            cmd.ExecuteNonQuery();
            conn.Close();
        }


        public void EditEmployee(EmployeeDAO emp)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(
                "update Employee_2119110262 set Name = @Name, IdEmployee = @IdEmployee," +
                "IdDepartment=@IdDepartment, PlaceBirth=@PlaceBirth," +
                "DateBirth=@DateBirth, Gender=@Gender where @IdEmployee = IdEmployee", conn);
            cmd.Parameters.Add(new SqlParameter("@IdEmployee", emp.IdEmployee));
            cmd.Parameters.Add(new SqlParameter("@Name", emp.Name));
            cmd.Parameters.Add(new SqlParameter("@IdDepartment", emp.Department.IdDepartment));
            cmd.Parameters.Add(new SqlParameter("@PlaceBirth", emp.PlaceBirth));
            cmd.Parameters.Add(new SqlParameter("@DateBirth", emp.DateBirth));
            cmd.Parameters.Add(new SqlParameter("@Gender", emp.Gender));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
