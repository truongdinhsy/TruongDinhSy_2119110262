﻿using System;
using System.Collections.Generic;
using System.Text;
using Cau1.DAL;
using Cau1.DAO;


namespace Cau1.BUS
{
    class EmployeeBUS
    {
        EmployeeDAL dal = new EmployeeDAL();
        public List<EmployeeDAO> ReadEmployee()
        {
            List<EmployeeDAO> lstEmp = dal.ReadEmployee();
            return lstEmp;
        }
        public void NewEmployee(EmployeeDAO emp)
        {
            dal.NewEmployee(emp);
        }
        public void DeleteEmployee(EmployeeDAO emp)
        {
            dal.DeleteEmployee(emp);
        }
        public void EditEmployee(EmployeeDAO emp)
        {
            dal.EditEmployee(emp);
        }
    }
}

