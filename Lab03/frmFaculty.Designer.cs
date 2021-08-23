
namespace Lab03
{
    partial class frmFaculty
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFaculty));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTotalPro = new System.Windows.Forms.TextBox();
            this.txtFacultyName = new System.Windows.Forms.TextBox();
            this.txtFacultyID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvFaculty = new System.Windows.Forms.DataGridView();
            this.dgvFacultyID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvFacultyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvToTalProfessor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnUpdateFaculty = new System.Windows.Forms.Button();
            this.btnDelFaculty = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaculty)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTotalPro);
            this.groupBox1.Controls.Add(this.txtFacultyName);
            this.groupBox1.Controls.Add(this.txtFacultyID);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(402, 225);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Khoa";
            // 
            // txtTotalPro
            // 
            this.txtTotalPro.Location = new System.Drawing.Point(143, 153);
            this.txtTotalPro.Name = "txtTotalPro";
            this.txtTotalPro.Size = new System.Drawing.Size(156, 26);
            this.txtTotalPro.TabIndex = 5;
            // 
            // txtFacultyName
            // 
            this.txtFacultyName.Location = new System.Drawing.Point(143, 98);
            this.txtFacultyName.Name = "txtFacultyName";
            this.txtFacultyName.Size = new System.Drawing.Size(250, 26);
            this.txtFacultyName.TabIndex = 4;
            // 
            // txtFacultyID
            // 
            this.txtFacultyID.Location = new System.Drawing.Point(143, 41);
            this.txtFacultyID.Name = "txtFacultyID";
            this.txtFacultyID.Size = new System.Drawing.Size(207, 26);
            this.txtFacultyID.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tổng số GS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên Khoa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Khoa";
            // 
            // dgvFaculty
            // 
            this.dgvFaculty.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFaculty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFaculty.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvFacultyID,
            this.dgvFacultyName,
            this.dgvToTalProfessor});
            this.dgvFaculty.Location = new System.Drawing.Point(420, 46);
            this.dgvFaculty.Name = "dgvFaculty";
            this.dgvFaculty.RowHeadersWidth = 51;
            this.dgvFaculty.RowTemplate.Height = 24;
            this.dgvFaculty.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFaculty.Size = new System.Drawing.Size(555, 280);
            this.dgvFaculty.TabIndex = 1;
            this.dgvFaculty.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFaculty_CellClick);
            // 
            // dgvFacultyID
            // 
            this.dgvFacultyID.HeaderText = "Mã Khoa";
            this.dgvFacultyID.MinimumWidth = 6;
            this.dgvFacultyID.Name = "dgvFacultyID";
            // 
            // dgvFacultyName
            // 
            this.dgvFacultyName.HeaderText = "Tên Khoa";
            this.dgvFacultyName.MinimumWidth = 6;
            this.dgvFacultyName.Name = "dgvFacultyName";
            // 
            // dgvToTalProfessor
            // 
            this.dgvToTalProfessor.HeaderText = "Tổng số GS";
            this.dgvToTalProfessor.MinimumWidth = 6;
            this.dgvToTalProfessor.Name = "dgvToTalProfessor";
            // 
            // btnUpdateFaculty
            // 
            this.btnUpdateFaculty.Location = new System.Drawing.Point(196, 293);
            this.btnUpdateFaculty.Name = "btnUpdateFaculty";
            this.btnUpdateFaculty.Size = new System.Drawing.Size(99, 33);
            this.btnUpdateFaculty.TabIndex = 2;
            this.btnUpdateFaculty.Text = "Thêm / Sửa";
            this.btnUpdateFaculty.UseVisualStyleBackColor = true;
            this.btnUpdateFaculty.Click += new System.EventHandler(this.btnUpdateFaculty_Click);
            // 
            // btnDelFaculty
            // 
            this.btnDelFaculty.Location = new System.Drawing.Point(328, 293);
            this.btnDelFaculty.Name = "btnDelFaculty";
            this.btnDelFaculty.Size = new System.Drawing.Size(86, 33);
            this.btnDelFaculty.TabIndex = 3;
            this.btnDelFaculty.Text = "Xoá";
            this.btnDelFaculty.UseVisualStyleBackColor = true;
            this.btnDelFaculty.Click += new System.EventHandler(this.btnDelFaculty_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(876, 332);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(99, 33);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmFaculty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 401);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelFaculty);
            this.Controls.Add(this.btnUpdateFaculty);
            this.Controls.Add(this.dgvFaculty);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmFaculty";
            this.Text = "Quản Lý Khoa Viện";
            this.Load += new System.EventHandler(this.frmFaculty_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaculty)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTotalPro;
        private System.Windows.Forms.TextBox txtFacultyName;
        private System.Windows.Forms.TextBox txtFacultyID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvFaculty;
        private System.Windows.Forms.Button btnUpdateFaculty;
        private System.Windows.Forms.Button btnDelFaculty;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvFacultyID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvFacultyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvToTalProfessor;
        private System.Windows.Forms.Button btnClose;
    }
}