using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Cau1.DAO;

namespace Cau1.DAL
{
    class DepartmentDAL : DBConnection
    {

        public List<DepartmentDAO> ReadDepartmentList()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Department_2119110262", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<DepartmentDAO> lstDep = new List<DepartmentDAO>();
            while (reader.Read())
            {
                DepartmentDAO dep = new DepartmentDAO();
                dep.IdDepartment = reader["IdDepartment"].ToString();
                dep.Name = reader["Name"].ToString();
                lstDep.Add(dep);
            }
            conn.Close();
            return lstDep;
        }


        public DepartmentDAO ReadDepartment(string id)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(
                "select * from Department_2119110262 where IdDepartment = '" + id + "'", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            DepartmentDAO dep = new DepartmentDAO();
            if (reader.HasRows && reader.Read())
            {
                dep.IdDepartment = reader["IdDepartment"].ToString();
                dep.Name = reader["Name"].ToString();
            }
            conn.Close();
            return dep;
        }
    }
}
