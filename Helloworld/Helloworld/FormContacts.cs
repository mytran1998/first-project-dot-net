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
    public partial class FormContacts : Form
    {
        string pathDataContact = @"E:\Net Framework\Learn\Helloworld\Helloworld\DATA\datacontacts.txt";
        public FormContacts()
        {
            InitializeComponent();
            //pathDataContact = Application.StartupPath + @"\Data\datacontacts.txt";
            List<Contacts> lstContacts = getListContact(pathDataContact);
            dgvContacts.AutoGenerateColumns = false;
            dgvContacts.DataSource = lstContacts;
        }

        public List<Contacts> getListContact(string path)
        {
            return Contacts.getListContacts(path);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgvContacts.DataSource = Contacts.getListABC(pathDataContact, 'A');
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dgvContacts.DataSource = Contacts.getListABC(pathDataContact, 'D');
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dgvContacts.DataSource = Contacts.getListABC(pathDataContact, 'G');
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dgvContacts.DataSource = Contacts.getListABC(pathDataContact, 'J');
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dgvContacts.DataSource = Contacts.getListABC(pathDataContact, 'M');
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dgvContacts.DataSource = Contacts.getListABC(pathDataContact, 'P');
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dgvContacts.DataSource = Contacts.getListABC(pathDataContact, 'V');
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dgvContacts.DataSource = Contacts.getListABC(pathDataContact, 'Z');
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
               "Ban co that su muon xoa khong?",
               "Thong bao",
               MessageBoxButtons.OKCancel,
               MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK)
            {
                // Code delete data
                // doi tuong dang chon
                string name = (string)dgvContacts.CurrentRow.Cells[1].Value;
                string phone = (string)dgvContacts.CurrentRow.Cells[2].Value;
                string email = (string)dgvContacts.CurrentRow.Cells[3].Value;
                //Console.WriteLine(quaTrinhHocTap.maQuaTrinhHocTap);

                Contacts.deleteContact(pathDataContact, name, phone, email);

                // Refresh 
                dgvContacts.DataSource = Contacts.getListContacts(pathDataContact);
                dgvContacts.Refresh();

                MessageBox.Show("Da xoa thanh cong du lieu co ma la : " + name,
                    "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
