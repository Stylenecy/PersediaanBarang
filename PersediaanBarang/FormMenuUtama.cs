using Org.BouncyCastle.Crypto.Parameters;
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
    public partial class FormMenuUtama : Form
    {
        public FormMenuUtama(string username)
        {
            InitializeComponent();
            Tabel karyawan = new Tabel("karyawan");
            karyawan.getBS().Position = karyawan.getBS().Find("user_name", username);
            bool hak_sb, hak_ss, hak_beli, hak_jual;
            hak_sb = bool.Parse(((DataRowView)karyawan.getBS().Current).Row["barang"].ToString());
            hak_ss = bool.Parse(((DataRowView)karyawan.getBS().Current).Row["supplier"].ToString());
            hak_beli = bool.Parse(((DataRowView)karyawan.getBS().Current).Row["beli"].ToString());
            hak_jual = bool.Parse(((DataRowView)karyawan.getBS().Current).Row["jual"].ToString());

            setupDataBarang.Enabled = hak_sb;
            setupDataSupplier.Enabled = hak_ss;
            pembelian.Enabled = hak_beli;
            penjualan.Enabled = hak_jual;
        }

        private void keluarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void setupDataBarangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBarang fb = new FormBarang();  
            fb.ShowDialog();
            fb.Dispose();
        }

        private void setupDataSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSupplier fs = new FormSupplier();
            fs.ShowDialog();
            fs.Dispose();
        }

        private void pembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNotaBeli fnb = new FormNotaBeli();
            fnb.ShowDialog();
            fnb.Dispose();
        }

        private void penjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNotaJual fnj = new FormNotaJual();
            fnj.ShowDialog();
            fnj.Dispose();
            //MessageBox.Show("Maaf belum dibuat");
        }
    }
}
