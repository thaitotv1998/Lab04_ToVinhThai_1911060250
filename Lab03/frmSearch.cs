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
            
            if(txtHoTen.Text =="" && txtMaSoSV.Text==""&&cmbKhoa.Text=="")
            {
                BindGrid(students);
            }
            else if (txtMaSoSV.Text == "" && txtHoTen.Text == "") 
            {
                List<Student> seacrh = (from s in students where s.Faculty.FacultyName == cmbKhoa.Text select s).ToList();
                BindGrid(seacrh);
            }
            else
            {
                if (txtMaSoSV.Text != null && txtHoTen.Text != null)
                {
                    List<Student> search = (from s in students where (s.FullName.Contains(txtHoTen.Text) && s.StudentID == txtMaSoSV.Text && s.Faculty.FacultyName == cmbKhoa.Text) select s).ToList();
                    BindGrid(search);
                }
                else
                {

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
