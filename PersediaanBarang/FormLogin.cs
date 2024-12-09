using Org.BouncyCastle.Math.EC.Multiplier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersediaanBarang
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Tabel karyawan = new Tabel("karyawan");
            string username, password;
            username = txtUsername.Text;
            password = txtPassword.Text;
            if(karyawan.login(username,password))
            {
                MessageBox.Show("Silahkan masuk ke Sistem Informasi Persediaan Barang");
                FormMenuUtama fmu = new FormMenuUtama(username);
                fmu.ShowDialog();
                txtUsername.Clear();
                txtPassword.Clear();
            }
            else
            {
                MessageBox.Show("Maaf, izin ditolak!");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
