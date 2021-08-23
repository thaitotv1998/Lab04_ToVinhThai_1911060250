using Lab03.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03
{
    public partial class frmSearch : Form
    {
        StudentContextDB contextDB;
        public frmSearch()
        {
            InitializeComponent();
            contextDB = new StudentContextDB();
        }

        private void BindGrid(List<Student> listStudent)
        {
            dgvSearch.Rows.Clear();
            foreach (var item in listStudent)
            {
                int index = dgvSearch.Rows.Add();
                dgvSearch.Rows[index].Cells[0].Value = item.StudentID;
                dgvSearch.Rows[index].Cells[1].Value = item.FullName;
                dgvSearch.Rows[index].Cells[2].Value = item.Faculty.FacultyName;
                dgvSearch.Rows[index].Cells[3].Value = item.AverageScore;
            }
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {
            txtMaSoSV.Clear();
            txtHoTen.Clear();
            txtResult.Text = "0";
            cmbKhoa.Text = "";
            dgvSearch.Rows.Clear();
        }

        private void FillFacultyCombobox(List<Faculty> listFacultys)
        {
            this.cmbKhoa.DataSource = listFacultys;
            this.cmbKhoa.DisplayMember = "FacultyName";
            this.cmbKhoa.ValueMember = "FacultyID";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<Student> students = contextDB.Students.ToList();
            if(txtMaSoSV.Text=="" && txtHoTen.Text =="" && cmbKhoa.Text =="")
            {
                MessageBox.Show("Vui lòng nhập dữ liệu cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (txtMaSoSV.Text != "")
            {
                if (txtMaSoSV.TextLength <= 10)
                {
                    if (txtHoTen.Text == "" && cmbKhoa.Text == "")
                    {
                        List<Student> search = (from s in students where s.StudentID.StartsWith(txtMaSoSV.Text) select s).ToList();
                        BindGrid(search);
                    }
                    else
                    {
                        if (txtHoTen.Text != "" && cmbKhoa.Text == "")
                        {
                            List<Student> seacrh1 = (from s in students
                                                     where s.StudentID.StartsWith(txtMaSoSV.Text) && s.FullName.ToLower().Contains(txtHoTen.Text.ToLower())
                                                     select s).ToList();
                            BindGrid(seacrh1);
                        }
                        else
                        {
                            List<Student> seacrh1 = (from s in students 
                                                     where s.Faculty.FacultyName == cmbKhoa.Text && s.StudentID.StartsWith(txtMaSoSV.Text) 
                                                     select s).ToList();
                            BindGrid(seacrh1);
                        }
                    }
                }
                else
                    MessageBox.Show("Mã số SV chỉ tối đa 10 kí tự!", "Thông báo", MessageBoxButtons.OK);
                }
            else
            {
                if (txtHoTen.Text == "" && cmbKhoa.Text != "")
                {
                    List<Student> seacrh1 = (from s in students where s.Faculty.FacultyName == cmbKhoa.Text select s).ToList();
                    BindGrid(seacrh1);
                }
                else
                {
                    if (txtHoTen.Text != "" && cmbKhoa.Text == "")
                    {
                        List<Student> search2 = (from s in students where s.FullName.ToLower().Contains(txtHoTen.Text.ToLower()) select s).ToList();
                        BindGrid(search2);
                    }
                    else
                    {
                        List<Student> search3 = (from s in students
                                                 where s.FullName.ToLower().Contains(txtHoTen.Text.ToLower())
                                                       && s.Faculty.FacultyName == cmbKhoa.Text
                                                select s).ToList();
                        BindGrid(search3);
                    }
                }
            }

            txtResult.Text = dgvSearch.Rows.Count.ToString();
        }

            private void btnBack_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            private void btnXoa_Click(object sender, EventArgs e)
            {
                frmSearch_Load(sender, e);
            }

            private void cmbKhoa_DropDown(object sender, EventArgs e)
            {
                List<Faculty> listFacultys = contextDB.Faculties.ToList();
                FillFacultyCombobox(listFacultys);
            }
        }
    }
