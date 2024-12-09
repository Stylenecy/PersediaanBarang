using MySql.Data.MySqlClient;
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
    public partial class FormTombolCari : Form
    {
        public FormTombolCari()
        {
            InitializeComponent();
            dgvBarang.DataSource = barang.getBS();
        }
        
        
        int nRow;
        DataTable dt = new DataTable();

        
        private void FormTombolCari_Load(object sender, EventArgs e)
        {
           
            nRow = dgvBarang.CurrentCell.RowIndex;
        }
        Tabel barang = new Tabel("barang");
        private void btnCari_Click(object sender, EventArgs e)
        {
            BindingSource bs = barang.getBS();
            string cari = txtNamaTukang.Text;

            int index = bs.Find("namaBarang", cari);

            if (index != -1)
            {
                bs.Position = index;
                dgvBarang.Rows[index].Selected = true;
            }
            else
            {
                MessageBox.Show("Item not found");
            }
        }

        private void txtNamaTukang_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
