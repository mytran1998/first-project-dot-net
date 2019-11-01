using Helloworld.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Helloworld
{
    public partial class frmSinhVien : Form
    {
        string pathAvatarFordel = "";
        string pathAvatar = "";
        SinhVien sinhVien;
        string pathData = "";
        string pathDataQTHT = @"E:\Net Framework\Learn\Helloworld\Helloworld\DATA\dataqtht.txt";
        
        public frmSinhVien(string maSinhVien)
        {
            InitializeComponent();
            // CHO PHÉP KÉO THẢ 
            picAvatar.AllowDrop = true;
            pathAvatarFordel = Application.StartupPath + @"\avatar";
            pathAvatar = pathAvatarFordel + @"\avatar.png";
            pathData = Application.StartupPath + @"\DATA\datastudent.txt";
            
            if (File.Exists(pathAvatar))
            {
                showAndSaveImageAva(pathAvatar);
            }

            dgvQuaTrinhHocTap.AutoGenerateColumns = false; // khong cho tu tao
            sinhVien = SinhVien.GetFromFile(pathData, maSinhVien);
            if(sinhVien == null)
            {
                throw new Exception("Sinh vien co ma " + maSinhVien + " khong ton tai!");
            }
            else
            {
                txtMaSinhVien.Text = sinhVien.MaSinhVien;
                txtHo.Text = sinhVien.Ho;
                txtTen.Text = sinhVien.Ten;
                dtpDate.Value = sinhVien.NgaySinh;
                chkNam.Checked = sinhVien.GioiTinh == SEX.Male;
                txtQueQuan.Text = sinhVien.QueQuan;

                //bdsQuaTrinhHocTap.DataSource = sinhVien.listQuaTrinhHocTap;
                //dgvQuaTrinhHocTap.DataSource = bdsQuaTrinhHocTap;

                bdsQuaTrinhHocTap.DataSource = QuaTrinhHocTap.getQthtFromFile(pathDataQTHT, sinhVien.MaSinhVien);
                dgvQuaTrinhHocTap.DataSource = bdsQuaTrinhHocTap;
                //lblTongSoMuc.Text = string.Format("{0} mục", sinhVien.listQuaTrinhHocTap.Count);
            }
        }
        #region Methods
        public List<QuaTrinhHocTap> getDataByFileTXT(string path)
        {
            List<QuaTrinhHocTap> list = new List<QuaTrinhHocTap>();
            string[] data = null;
            if (File.Exists(pathData))
            {
                data = File.ReadAllLines(path);
            }
            foreach(string item in data)
            {
                string[] st = item.Split('|');
                
                QuaTrinhHocTap qtht = new QuaTrinhHocTap {
                    maQuaTrinhHocTap = st[0],
                    tuNam = Int32.Parse(st[1]),
                    denNam = Int32.Parse(st[2]),
                    hocTai = st[3],
                    maSinhVien =st[4]
                };
                list.Add(qtht);
            }
            return list;
        }

        void showAndSaveImageAva(string path, bool saveOption = false)
        {
            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            picAvatar.Image = Image.FromStream(fileStream);
            if (saveOption)
            {
                picAvatar.Image.Save(pathAvatar);
            }
            fileStream.Close();
        }

        public void refreshDataGridView()
        {
            // Refresh 
            bdsQuaTrinhHocTap.DataSource = QuaTrinhHocTap.getQthtFromFile(pathDataQTHT, sinhVien.MaSinhVien);
            dgvQuaTrinhHocTap.DataSource = bdsQuaTrinhHocTap;
            dgvQuaTrinhHocTap.Refresh();
        }
        #endregion

        #region Event
        private void lnkChooseAvatar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Chon anh vao luu vao thu muc avatar
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn ảnh đại diện";
            openFileDialog.Filter = "File anh (*.png, *.jpg)|*.png;*.jpg";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var fileName = openFileDialog.FileName;
                
                //KIỂM TRA THƯ MỤC CÓ TỒN TẠI HAY KHÔNG 
                if (!Directory.Exists(pathAvatarFordel)) {
                    Directory.CreateDirectory(pathAvatarFordel);
                }

                showAndSaveImageAva(pathAvatar,true);
            }
            #endregion 
        }

        private void picAvatar_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void picAvatar_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                var lstFile = (string[])e.Data.GetData(DataFormats.FileDrop);
                showAndSaveImageAva(pathAvatar, true);
            }
            catch
            {
                MessageBox.Show("Vui lòng chọn ảnh!");
            }
        }

        private void ctmPicturerAvatar_Click(object sender, EventArgs e)
        {

        }

        private void mniXoaAnhDaiDien_Click(object sender, EventArgs e)
        {
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           if(MessageBox.Show(
               "Ban co that su muon xoa khong?", 
               "Thong bao", 
               MessageBoxButtons.OKCancel, 
               MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK)
           {
                // Code delete data
                var quaTrinhHocTap = (QuaTrinhHocTap)bdsQuaTrinhHocTap.Current; // doi tuong dang chon
                                                                                
                //Console.WriteLine(quaTrinhHocTap.maQuaTrinhHocTap);
                                                                                
                QuaTrinhHocTap.deleteQTHT(pathDataQTHT, quaTrinhHocTap.maQuaTrinhHocTap);

                // Refresh 
                bdsQuaTrinhHocTap.DataSource = QuaTrinhHocTap.getQthtFromFile(pathDataQTHT, sinhVien.MaSinhVien);
                dgvQuaTrinhHocTap.DataSource = bdsQuaTrinhHocTap;
                dgvQuaTrinhHocTap.Refresh();

                MessageBox.Show("Da xoa thanh cong du lieu co ma la : " + quaTrinhHocTap.maQuaTrinhHocTap,
                    "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
           }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var f = new frmQuaTrinhHocTap(this ,sinhVien.maSinhVien);
            f.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var quaTrinhHocTap = bdsQuaTrinhHocTap.Current as QuaTrinhHocTap;
            if (quaTrinhHocTap != null)
            {
                var f = new frmQuaTrinhHocTap(this ,sinhVien.maSinhVien, quaTrinhHocTap);
                f.ShowDialog();
            }
        }
        #endregion

    }
}
