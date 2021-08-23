using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab03.Model;

namespace Lab03
{
    public partial class frmStudentManagement : Form
    {
        StudentContextDB contextDB;
        public frmStudentManagement()
        {
            InitializeComponent();
            contextDB = new StudentContextDB();
        }

        private void frmStudentManagement_Load(object sender, EventArgs e)
        {
            List<Student> listStudent = contextDB.Students.ToList();
            List<Faculty> listFacultys = contextDB.Faculties.ToList();
            FillFacultyCombobox(listFacultys);
            BindGrid(listStudent);
        }

        private void BindGrid(List<Student> listStudent)
        {
            dgvStudent.Rows.Clear();
            foreach (var item in listStudent)
            {
                int index = dgvStudent.Rows.Add();
                dgvStudent.Rows[index].Cells[0].Value = item.StudentID;
                dgvStudent.Rows[index].Cells[1].Value = item.FullName;
                dgvStudent.Rows[index].Cells[2].Value = item.Faculty.FacultyName;
                dgvStudent.Rows[index].Cells[3].Value = item.AverageScore;
            }
        }

        private void FillFacultyCombobox(List<Faculty> listFacultys)
        {
            this.cmbKhoaVien.DataSource = listFacultys;
            this.cmbKhoaVien.DisplayMember = "FacultyName";
            this.cmbKhoaVien.ValueMember = "FacultyID";
        }

        private void dgvStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvStudent.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dgvStudent.CurrentRow.Selected = true;
                    txtMSSV.Text = dgvStudent.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                    txtHoTen.Text = dgvStudent.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                    txtDTB.Text = dgvStudent.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                    cmbKhoaVien.SelectedIndex = cmbKhoaVien.FindString(dgvStudent.Rows[e.RowIndex].Cells[2].FormattedValue.ToString());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Có vẻ bạn chọn sai!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (KiemTraDuLieu())
            {
                if (CheckIDStudent(txtMSSV.Text) == -1)
                {
                    Student student = new Student();

                    student.StudentID = txtMSSV.Text;
                    student.FullName = txtHoTen.Text;
                    float temp = float.Parse(txtDTB.Text);
                    student.AverageScore = temp;
                    student.FacultyID = Convert.ToInt32(cmbKhoaVien.SelectedValue.ToString());

                    contextDB.Students.AddOrUpdate(student);
                    contextDB.SaveChanges();

                    ReloadDGV();
                    ResetForm();

                    MessageBox.Show("Thêm mới dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Sinh viên đã tồn tại, kiểm tra lại thông tin! ", "Thông báo", MessageBoxButtons.OK);
                }
            }
        }

        private void ReloadDGV()
        {
            List<Student> students = contextDB.Students.ToList();
            BindGrid(students);
        }

        private void ResetForm()
        {
            txtMSSV.Clear();
            txtHoTen.Clear();
            txtDTB.Clear();
            cmbKhoaVien.SelectedIndex = 0;
        }

        private int CheckIDStudent(string studentID)
        {
            for (int i = 0; i < dgvStudent.Rows.Count; i++)
            {
                if (dgvStudent.Rows[i].Cells[0].Value != null)
                {
                    if (dgvStudent.Rows[i].Cells[0].Value.ToString() == studentID)
                    {
                        return 1;
                    }
                }
            }
            return -1;
        }

        private bool KiemTraDuLieu()
        {
            if (txtMSSV.Text == "" || txtHoTen.Text == "" || txtDTB.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            else if (txtMSSV.TextLength != 10)
            {
                MessageBox.Show("Mã số sinh viên phải đủ 10 ký tự!", "Thông Báo", MessageBoxButtons.OK);
                return false;
            }
            else
            {
                float ketQua = 0;
                bool Result = float.TryParse(txtDTB.Text, out ketQua);
                if (Result == false)
                {
                    MessageBox.Show("Điểm TB phải là số!", "Thông báo", MessageBoxButtons.OK);
                    return false;
                }
                else
                {
                    ketQua = float.Parse(txtDTB.Text);
                    if (ketQua < 0 || ketQua > 10)
                    {
                        MessageBox.Show("Điểm TB phải từ 0 đến 10!", "Thông báo", MessageBoxButtons.OK);
                        return false;
                    }
                }
                return true;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (KiemTraDuLieu())
            {
                Student updateStudent = contextDB.Students.FirstOrDefault(p => p.StudentID == txtMSSV.Text);
                if (updateStudent != null)
                {
                    updateStudent.FullName = txtHoTen.Text;
                    float temp = float.Parse(txtDTB.Text);
                    updateStudent.AverageScore = temp;
                    updateStudent.FacultyID = Convert.ToInt32(cmbKhoaVien.SelectedValue.ToString());

                    contextDB.Students.AddOrUpdate(updateStudent);
                    contextDB.SaveChanges();

                    ReloadDGV();
                    ResetForm();

                    MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sinh viên cần sửa!", "Thông báo", MessageBoxButtons.OK);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Student delStudent = contextDB.Students.FirstOrDefault(p => p.StudentID == txtMSSV.Text);
            if(delStudent != null)
            {
                DialogResult result = MessageBox.Show($"Bạn có đồng ý xoá sinh viên {delStudent.FullName} không?","Thông báo", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                if(result == DialogResult.Yes)
                {
                    contextDB.Students.Remove(delStudent);
                    contextDB.SaveChanges();

                    ReloadDGV();
                    ResetForm();

                    MessageBox.Show("Xoá sinh viên thành công!", "Thông báo", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy sinh viên cần xoá.", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát ứng dụng không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void quảnLýKhoaViệnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFaculty frm = new frmFaculty();

            frm.ShowDialog();
            List<Faculty> faculties = contextDB.Faculties.ToList();
            FillFacultyCombobox(faculties);
        }

        private void tìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSearch frm = new frmSearch();
            frm.ShowDialog();
        }


        private void thoátToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            btnExit_Click(sender, e);
        }

        private void toolStripBtnQLK_Click(object sender, EventArgs e)
        {
            quảnLýKhoaViệnToolStripMenuItem_Click(sender, e);
        }

        private void toolStripBtnSearch_Click(object sender, EventArgs e)
        {
            tìmKiếmToolStripMenuItem_Click(sender, e);
        }
    }
}
