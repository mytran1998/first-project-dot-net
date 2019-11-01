using Helloworld.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Helloworld
{
    public partial class frmQuaTrinhHocTap : Form
    {
        QuaTrinhHocTap quaTrinhHocTap;
        string maSV;
        string pathDataQTHT = @"E:\Net Framework\Learn\Helloworld\Helloworld\DATA\dataqtht.txt";
        private frmSinhVien fSinhVien;

        public frmQuaTrinhHocTap(frmSinhVien fSinhVien,string maSinhVien, QuaTrinhHocTap quaTrinhHocTap = null)
        {
            InitializeComponent();
            this.quaTrinhHocTap = quaTrinhHocTap;
            this.maSV = maSinhVien;
            this.fSinhVien = fSinhVien;
            if (quaTrinhHocTap == null)
            {
                this.Text = "Thêm mới quá trình học tập"; 
            }
            else
            {
                this.Text = "Chỉnh sửa quá trình học tập";
                nmFromYear.Value = quaTrinhHocTap.TuNam;
                nmToYear.Value = quaTrinhHocTap.DenNam;
                txtHocTai.Text = quaTrinhHocTap.HocTai;
            }
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            // Refresh 
            int tuNam = (int)nmFromYear.Value;
            int denNam = (int)nmToYear.Value;
            string hocTai = txtHocTai.Text;
            if (quaTrinhHocTap != null)
            {
                QuaTrinhHocTap.updateQTHT(pathDataQTHT, maSV, quaTrinhHocTap.maQuaTrinhHocTap, tuNam, denNam, hocTai);
                MessageBox.Show("Cập nhật thành công!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                QuaTrinhHocTap.addQTHT(pathDataQTHT, maSV, tuNam, denNam, hocTai);
                MessageBox.Show("Thêm quá trình học tập thành công!",
                 "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); 
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void frmQuaTrinhHocTap_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.fSinhVien.refreshDataGridView();
        }
    }
}
