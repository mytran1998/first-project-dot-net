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
    public partial class frmTinhToanCoBan : Form
    {
        public frmTinhToanCoBan()
        {
            InitializeComponent();
        }

        private void btnTinhToan_Click(object sender, EventArgs e)
        {
            try
            {
                #region Xử lý dữ liệu đầu vào
                float temp = 0;
                // TryParse : có thể ép kiểu không
                if (!float.TryParse(txtNumber1.Text, out temp))
                {
                    //MessageBox.Show("Vui lòng nhập lại số thứ nhất!");
                    errorProvider.SetError(txtNumber1, "Vui lòng nhập lại số thứ nhất!");
                    txtNumber1.Focus(); // Đặt con trỏ chuột vào ô
                    return;
                }
                if (!float.TryParse(txtNumber2.Text, out temp))
                {
                    //MessageBox.Show("Vui lòng nhập lại số thứ hai!");
                    errorProvider.SetError(txtNumber2, "Vui lòng nhập lại số thứ hai!");
                    txtNumber2.Focus(); 
                    return;
                }
                var n1 = float.Parse(txtNumber1.Text);
                var n2 = float.Parse(txtNumber2.Text);
                #endregion

                #region Kiểm tra toán tử 
                string sign = "";
                float result = 0;
                if (rdCong.Checked)
                {
                    result = n1 + n2;
                    sign = "+";
                }
                else if (rdTru.Checked)
                {
                    result = n1 - n2;
                    sign = "-";
                }
                else if (rdNhan.Checked)
                {
                    result = n1 * n2;
                    sign = "*";
                }
                else
                {
                    result = n1 / n2;
                    sign = "/";
                }
                #endregion
                var showResult = string.Format("Kết quả của {0} {1} {2}  = {3}", n1, sign, n2, result);
                MessageBox.Show(showResult, "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex )
            {
                MessageBox.Show("Error : " + ex.Message, "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtNumber2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)  // Enter key 
            {
                btnTinhToan.PerformClick();
            }
        }

        private void txtNumber1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) // Enter key 
            {
                btnTinhToan.PerformClick();
            }
        }
    }
}
