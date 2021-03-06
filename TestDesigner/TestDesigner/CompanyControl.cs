﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestDesigner
{
    public partial class CompanyControl : UserControl
    {
        public string txtcode;
        public string txtname;
        public string tentable;
        public int ID;
        public int ParentID;
        bool hienthi = false;//Quy dinh cac chuc nang sua va xoa co hien thi hay ko
        public CompanyControl()
        {
            InitializeComponent();
            txtName.GotFocus += txtName_GotFocus;
            txtCode.GotFocus += txtCode_GotFocus;
            this.Leave += CompanyControl_MouseLeave;
        }

        void CompanyControl_MouseLeave(object sender, EventArgs e)
        {
            if (txtName.ReadOnly == false)
            { UpdateCompany(); }
        }

        void txtCode_GotFocus(object sender, EventArgs e)
        {
            panelControl1.Visible = false;
            hienthi = false;
        }

        void txtName_GotFocus(object sender, EventArgs e)
        {
            panelControl1.Visible = false;
            hienthi = false;
        }

        private void CompanyControl_Load(object sender, EventArgs e)
        {
            txtCode.Text = txtcode;
            txtName.Text = txtname;
            txtCode.ReadOnly = true;
            txtName.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelControl1.Visible = true;
            hienthi = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtCode.ReadOnly == true)
            {
                txtCode.ReadOnly = false;
                txtName.ReadOnly = false;
                txtCode.Focus();
            }
            else
            {
                UpdateCompany();

            }

        }
        void UpdateCompany()
        {
            if (txtName.Text != "" && txtCode.Text != "" && (txtName.Text != txtname || txtCode.Text != txtcode))
            {

                string ma = tentable.Substring(3);
                DataTable dttemp = Khoidau.DBEngine.execReturnDataTable(String.Format("Select * from {0} where {1}Code ='{2}' and {1}ID<>{3}", tentable, ma, txtCode.Text, ID));
                if (dttemp.Rows.Count <= 0)
                {
                    DialogResult r;
                    r = MessageBox.Show("Dữ liệu đã thay đổi. Bạn có muốn cập nhật?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (r == DialogResult.Yes)
                    {
                        Khoidau.DBEngine.exec(String.Format("Update {0} set {1}Code ='{2}',{1}Name=N'{3}' where {1}ID= {4}", tentable, ma, txtCode.Text, txtName.Text, ID));
                        MessageBox.Show("Lưu thành công");
                        panelControl1.Visible = false;
                        txtCode.ReadOnly = true;
                        txtName.ReadOnly = true;
                    }
                }
                else
                {
                    MessageBox.Show("Code đã tồn tại");
                    txtCode.Focus();
                }
            }
        }
        public void btnDel_Click(object sender, EventArgs e)
        {
            string ma = tentable.Substring(3);
            DataTable dttemp = Khoidau.DBEngine.execReturnDataTable(String.Format("Select * from {0} where {1}Code ='{2}'", tentable, ma, txtCode.Text));
            if (dttemp.Rows.Count > 0)
            {
                DialogResult r;
                r = MessageBox.Show("Bạn chắc chắn muốn xóa", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (r == DialogResult.Yes)
                {
                    Khoidau.DBEngine.exec(String.Format("Delete from {0} where {1}ID= {2}", tentable, ma, this.ID));
                    this.Enabled = false;//Tin hieu cho FormLoadCompanyTree load lai tree
                }
            }

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            panelControl1.Visible = true;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            panelControl1.Visible = hienthi;
        }
    }
}
