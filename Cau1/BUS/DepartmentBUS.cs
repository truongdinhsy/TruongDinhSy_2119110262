using System;
using System.Collections.Generic;
using System.Text;
using Cau1.DAL;
using Cau1.DAO;
namespace Cau1.BUS
{
    class DepartmentBUS
    {
        DepartmentDAL dal = new DepartmentDAL();
        public List<DepartmentDAO> ReadDepartmentList()
        {
            List<DepartmentDAO> lstDepartment = dal.ReadDepartmentList();
            return lstDepartment;
        }
    }
}
