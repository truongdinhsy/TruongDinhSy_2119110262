using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cau1.DAL;
using Cau1.BUS;
using Cau1.DAO;


namespace Cau1
{
    public partial class EmployeeGUI : Form
    {
        EmployeeBUS empBUS = new EmployeeBUS();
        DepartmentBUS depBUS = new DepartmentBUS();
        public EmployeeGUI()
        {
            InitializeComponent();
        }

        private void EmployeeGUI_Load(object sender, EventArgs e)
        {
            List<EmployeeDAO> lstEmp = empBUS.ReadEmployee();
            foreach (EmployeeDAO emp in lstEmp)
            {
                dgvEmployee.Rows.Add(emp.IdEmployee, emp.Name, emp.PlaceBirth, emp.DateBirth, emp.Gender, emp.NameDepartment);
            }
            List<DepartmentDAO> lstDepartment = depBUS.ReadDepartmentList();
            foreach (DepartmentDAO dep in lstDepartment)
            {
                cbDepartment.Items.Add(dep);
            }
            cbDepartment.DisplayMember = "Name";
        }

        private void dgvEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            DataGridViewRow row = dgvEmployee.Rows[idx];
            if (row.Cells[0].Value != null)
            {
                tbID.Text = row.Cells[0].Value.ToString();
                tbName.Text = row.Cells[1].Value.ToString();
                tbPlaceBirth.Text = row.Cells[2].Value.ToString();
                dtDateBirth.Text = row.Cells[3].Value.ToString();
                int gioitinh = int.Parse(row.Cells[4].Value.ToString());
                if (gioitinh == 1)
                {
                    chbGender.Checked = true;
                }
                else
                {
                    chbGender.Checked = false;
                }
                cbDepartment.Text = row.Cells[5].Value.ToString();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            EmployeeDAO emp = new EmployeeDAO();

            if (tbID.Text.Equals("") || tbName.Text.Equals("") || tbPlaceBirth.Equals(""))
            {
                MessageBox.Show("Không được bỏ trống!", "THÔNG BÁO");
            }
            else
            {
                emp.IdEmployee = tbID.Text;
                emp.Name = tbName.Text;
                emp.PlaceBirth = tbPlaceBirth.Text;
                emp.Department = (DepartmentDAO)cbDepartment.SelectedItem;
                emp.DateBirth = dtDateBirth.Value;
                if (chbGender.Checked)
                {
                    emp.Gender = 1;
                }
                else
                {
                    emp.Gender = 0;
                }
                empBUS.NewEmployee(emp);
                dgvEmployee.Rows.Add(emp.IdEmployee, emp.Name, emp.PlaceBirth, emp.DateBirth, emp.Gender, emp.NameDepartment);
            }


        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            EmployeeDAO emp = new EmployeeDAO();

            if (tbID.Text.Equals("") || tbName.Text.Equals("") || tbPlaceBirth.Equals(""))
            {
                MessageBox.Show("Không được bỏ trống!", "THÔNG BÁO");
            }
            else
            {
                emp.IdEmployee = tbID.Text;
                emp.Name = tbName.Text;
                emp.PlaceBirth = tbPlaceBirth.Text;
                emp.Department = (DepartmentDAO)cbDepartment.SelectedItem;
                emp.DateBirth = dtDateBirth.Value;
                if (chbGender.Checked)
                {
                    emp.Gender = 1;
                }
                else
                {
                    emp.Gender = 0;
                }
                empBUS.EditEmployee(emp);
                using DataGridViewRow row = dgvEmployee.CurrentRow;
                row.Cells[0].Value = emp.IdEmployee;
                row.Cells[1].Value = emp.Name;
                row.Cells[2].Value = emp.PlaceBirth;
                row.Cells[3].Value = emp.DateBirth;
                row.Cells[4].Value = emp.Gender;
                row.Cells[5].Value = emp.NameDepartment;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có muốn xoá", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            EmployeeDAO emp = new EmployeeDAO();

            if (tbID.Text.Equals("") || tbName.Text.Equals("") || tbPlaceBirth.Equals(""))
            {
                MessageBox.Show("Không được bỏ trống!", "THÔNG BÁO");
            }
            else if (dlr == DialogResult.Yes)
            {
                emp.IdEmployee = tbID.Text;
                emp.Name = tbName.Text;
                emp.PlaceBirth = tbPlaceBirth.Text;
                emp.Department = (DepartmentDAO)cbDepartment.SelectedItem;
                emp.DateBirth = dtDateBirth.Value;
                if (chbGender.Checked)
                {
                    emp.Gender = 1;
                }
                else
                {
                    emp.Gender = 0;
                }
                empBUS.DeleteEmployee(emp);
                int idx = dgvEmployee.CurrentCell.RowIndex;
                dgvEmployee.Rows.RemoveAt(idx);
            }
           
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

            DialogResult dlr = MessageBox.Show("Bạn muốn thoát? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                Application.Exit();
            }

        }
    }
}
