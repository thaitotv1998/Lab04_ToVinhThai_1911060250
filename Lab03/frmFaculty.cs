using Lab03.Model;
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

namespace Lab03
{
    public partial class frmFaculty : Form
    {
        StudentContextDB contextDB;
        public frmFaculty()
        {
            InitializeComponent();
            contextDB = new StudentContextDB();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmFaculty_Load(object sender, EventArgs e)
        {
            List<Faculty> listFacultys = contextDB.Faculties.ToList();
            BindGrid(listFacultys);
        }

        private void BindGrid(List<Faculty> listFacultys)
        {
            dgvFaculty.Rows.Clear();
            foreach (var item in listFacultys)
            {
                int index = dgvFaculty.Rows.Add();
                dgvFaculty.Rows[index].Cells[0].Value = item.FacultyID;
                dgvFaculty.Rows[index].Cells[1].Value = item.FacultyName;
                dgvFaculty.Rows[index].Cells[2].Value = item.TotalProfessor;
            }
        }

        private void dgvFaculty_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvFaculty.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    dgvFaculty.CurrentRow.Selected = true;
                    txtFacultyID.Text = dgvFaculty.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                    txtFacultyName.Text = dgvFaculty.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                    txtTotalPro.Text = dgvFaculty.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Có vẻ bạn chọn sai", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnUpdateFaculty_Click(object sender, EventArgs e)
        {
            if (KiemTraDuLieu())
            {
                if (CheckIDFaculty(txtFacultyID.Text) == -1)
                {
                    Faculty faculty = new Faculty();

                    faculty.FacultyID = Convert.ToInt32(txtFacultyID.Text);
                    faculty.FacultyName = txtFacultyName.Text;
                    faculty.TotalProfessor = Convert.ToInt32(txtTotalPro.Text);

                    contextDB.Faculties.AddOrUpdate(faculty);
                    contextDB.SaveChanges();

                    ReloadDGV();
                    ResetForm();

                    MessageBox.Show("Thêm mới dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    Faculty updateFaculty = contextDB.Faculties.FirstOrDefault(p => p.FacultyID.ToString() == txtFacultyID.Text);
                    if (updateFaculty != null)
                    {
                        updateFaculty.FacultyName = txtFacultyName.Text;
                        updateFaculty.TotalProfessor = Convert.ToInt32(txtTotalPro.Text);

                        contextDB.Faculties.AddOrUpdate(updateFaculty);
                        contextDB.SaveChanges();

                        ReloadDGV();
                        ResetForm();

                        MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm tháy khoa cần sửa.","Thông báo", MessageBoxButtons.OK);
                    }
                }
            }  
        }

        private void ResetForm()
        {
            txtFacultyID.Clear();
            txtFacultyName.Clear();
            txtTotalPro.Clear();
        }

        private void ReloadDGV()
        {
            List<Faculty> faculties = contextDB.Faculties.ToList();
            BindGrid(faculties);
        }

        private int CheckIDFaculty(string facultyID)
        {
            for (int i = 0; i < dgvFaculty.Rows.Count; i++)
            {
                if (dgvFaculty.Rows[i].Cells[0].Value != null)
                {
                    if (dgvFaculty.Rows[i].Cells[0].Value.ToString() == facultyID)
                    {
                        return 1;
                    }
                }
            }
            return -1;
        }

        private bool KiemTraDuLieu()
        {
            if (txtFacultyID.Text == "" || txtFacultyName.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                int ketQua = 0;
                bool Result = int.TryParse(txtFacultyID.Text, out ketQua);
                if (Result == false)
                {
                    MessageBox.Show("Bạn nhập sai!", "Thông báo", MessageBoxButtons.OK);
                    return false;
                }
                else
                {
                    Result = int.TryParse(txtTotalPro.Text, out ketQua);
                    if(Result == false)
                    {
                        MessageBox.Show("Nhập sai số lượng giáo sư!", "Thông báo", MessageBoxButtons.OK);
                    }
                    else
                    {
                        ketQua = int.Parse(txtTotalPro.Text);
                        if(ketQua<0)
                        {
                            MessageBox.Show("Số lượng giáo sư phải lớn hơn 0", "Thông báo", MessageBoxButtons.OK);
                        }
                    }
                }
            }
            return true;
        }

        private void btnDelFaculty_Click(object sender, EventArgs e)
        {
            Faculty FacultyDel = contextDB.Faculties.FirstOrDefault(p => p.FacultyID.ToString() == txtFacultyID.Text);
            if (FacultyDel != null)
            {
                DialogResult result = MessageBox.Show($"Bạn có đồng ý xoá khoa {FacultyDel.FacultyName} không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    contextDB.Faculties.Remove(FacultyDel);
                    contextDB.SaveChanges();

                    ReloadDGV();
                    ResetForm();

                    MessageBox.Show("Xoá sinh khoa thành công!", "Thông báo", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy khoa cần xoá.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
