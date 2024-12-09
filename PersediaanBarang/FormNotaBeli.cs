using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersediaanBarang
{
    public partial class FormNotaBeli : Form
    {
        public FormNotaBeli()
        {
            InitializeComponent();
            ikat();
            dgvDetailBeli.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetailBeli.DataSource = detailBeli.getBS();
        }
        Tabel masterBeli = new Tabel("viewMaster");
        Tabel detailBeli = new Tabel("view_detailBeli");

        void modeOutput()
        {
            txtTgl.Enabled = false;
            txtKodeSupplier.Enabled = false;
            dgvDetailBeli.Height = 203;
            dgvDetailBeli.Top = 158;
            btnTop.Enabled = true;
            btnBack.Enabled = true;
            btnEnd.Enabled = true;
            btnNext.Enabled = true;
            btnFind.Enabled = true;
            btnPrint.Enabled = true;
            btnEdit.Enabled = true;
            btnDel.Enabled = true;
            btnNew.Enabled = true;
            btnSave.Visible = false;
            btnUndo.Visible = false;
            btnClose.Enabled = true;
        }
        void modeInput()
        {
            txtTgl.Enabled = true;
            txtKodeSupplier.Enabled = true;
            dgvDetailBeli.Height = 145;
            dgvDetailBeli.Top = 216;
            btnTop.Enabled = false;
            btnBack.Enabled = false;
            btnEnd.Enabled = false;
            btnNext.Enabled = false;
            btnFind.Enabled = false;
            btnPrint.Enabled = false;
            btnEdit.Enabled = false;
            btnDel.Enabled = false;
            btnNew.Enabled = false;
            btnSave.Visible = true;
            btnUndo.Visible = true;
            btnClose.Enabled = false;
            txtKodeSupplier.Focus();
        }
        void ikat()
        {
            txtNoNotaBeli.DataBindings.Add("Text", masterBeli.getBS(), "noNotaBeli");
            txtTgl.DataBindings.Add("Text", masterBeli.getBS(), "tgl");
            txtKodeSupplier.DataBindings.Add("Text", masterBeli.getBS(), "kodeSupplier");
            txtNamaSupplier.DataBindings.Add("Text", masterBeli.getBS(), "namaSupplier");
            txtAlamat.DataBindings.Add("Text", masterBeli.getBS(), "alamat");
            txtTelpon.DataBindings.Add("Text", masterBeli.getBS(), "telpon");
            txtKota.DataBindings.Add("Text", masterBeli.getBS(), "kota");
        }
        void tampil()
        {
            detailBeli.getBS().Filter = "noNotaBeli = " + txtNoNotaBeli.Text;
            decimal totalJumlah = 0;

            foreach (DataGridViewRow row in dgvDetailBeli.Rows)
            {
                // Pastikan baris tidak kosong (misalnya, pada baris terakhir untuk menambahkan data baru)
                if (row.Cells["jumlah"].Value != null && row.Cells["jumlah"].Value != DBNull.Value)
                {
                    // Tambahkan nilai kolom "jumlah" ke total
                    totalJumlah += Convert.ToDecimal(row.Cells["jumlah"].Value);
                }
            }

            // Tampilkan total (misalnya, di label)
            txtTotal.Text = totalJumlah.ToString("N0");
        }
        private void btnTop_Click(object sender, EventArgs e)
        {
            masterBeli.getBS().MoveFirst();
            tampil();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            masterBeli.getBS().MovePrevious();
            tampil();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            masterBeli.getBS().MoveNext();
            tampil();
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            masterBeli.getBS().MoveLast();
            tampil();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            modeInput();
        }

        private void FormNotaBeli_Load(object sender, EventArgs e)
        {
            tampil();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            modeOutput();
        }
        Tabel barang = new Tabel("barang");
        private void txtKodeBarang_KeyUp(object sender, KeyEventArgs e)
        {

            if (txtKodeBarang.Text.Length == 5)
            {
                //MessageBox.Show("Mari kita periksa dulu, kode itu ada atau tidak?");
                int noBrs = barang.getBS().Find("kodeBarang", txtKodeBarang.Text);
                if (noBrs == -1)
                {
                    //MessageBox.Show("Kode Barang tersebut tidak ada");
                    FormCariBarang fcb = new FormCariBarang();
                    fcb.ShowDialog();
                    txtKodeBarang.Text = fcb.kodeCari;
                }
                else
                {
                    //MessageBox.Show("Kode barang aman, mari kita tampilkan Namanya!");
                    barang.getBS().Position = noBrs; //<-- menuju baris pada barang tersebut
                    txtNamaBarang.Text = ((DataRowView)barang.getBS().Current).Row["namaBarang"].ToString();
                    txtHarga.Text = ((DataRowView)barang.getBS().Current).Row["hargaBeli"].ToString();
                    txtQty.Focus();
                }
            }
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true; // Mencegah input selain angka
            }
        }

        private void txtQty_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtHarga.Focus();
            }
        }

        private void txtHarga_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true; // Mencegah input selain angka
            }
        }

        private void txtHarga_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string noNotaBeli, kodeBarang, qty, harga, strSql;
                noNotaBeli = txtNoNotaBeli.Text;
                kodeBarang = txtKodeBarang.Text;
                qty = txtQty.Text;
                harga = txtHarga.Text;

                strSql = "INSERT INTO itemNotaBeli(noNotaBeli, kodeBarang, qty, harga) " +
                    $"VALUES('{noNotaBeli}','{kodeBarang}','{qty}','{harga}')";
                detailBeli.eksekusiSQL(strSql);
                txtKodeBarang.Clear();
                txtNamaBarang.Clear();
                txtQty.Clear();
                txtHarga.Clear();
                txtKodeBarang.Focus();
            }
        }

        private void dgvDetailBeli_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back && btnSave.Visible)
            {
                txtKodeBarang.Text = dgvDetailBeli.CurrentRow.Cells["kodeBarang"].Value.ToString();
                txtNamaBarang.Text = dgvDetailBeli.CurrentRow.Cells["namaBarang"].Value.ToString();
                txtQty.Text = dgvDetailBeli.CurrentRow.Cells["qty"].Value.ToString();
                txtHarga.Text = dgvDetailBeli.CurrentRow.Cells["harga"].Value.ToString();
                txtQty.Focus();
            }
            if ((e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back) && btnSave.Visible)
            {
                DialogResult jwb = DialogResult.Yes; //<-- defaultnya Yes

                if (e.KeyCode == Keys.Delete) //<-- konfirmasi hanya jika tombol Delete
                {
                    jwb = MessageBox.Show("Anda Yakin akan menghapus detail pembelian ini?",
                        "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }

                if (jwb == DialogResult.Yes)
                {
                    string idHapus = dgvDetailBeli.CurrentRow.Cells[0].Value.ToString();
                    string strSql = $"DELETE FROM itemNotaBeli WHERE idItemNotaBeli='{idHapus}'";
                    //MessageBox.Show(strSql);
                    detailBeli.eksekusiSQL(strSql);
                }
                else
                {
                    MessageBox.Show("Penghapusan dibatalkan...");
                }
            }
        }
        Tabel supplier = new Tabel("supplier");
        private void txtKodeSupplier_KeyUp(object sender, KeyEventArgs e)
        {
            string noSkrg = txtNoNotaBeli.Text; //<-- disini dicatat dulu
            if (txtKodeSupplier.Text.Length == 3)
            {
                int noBrs = supplier.getBS().Find("kodeSupplier", txtKodeSupplier.Text);
                if (noBrs == -1)
                {
                    //MessageBox.Show("Kode : " + txtKodeSupplier.Text + " tidak ada!");
                    //txtKodeSupplier.Clear();
                    //txtKodeSupplier.Focus();
                    FormCariSupplier fcs = new FormCariSupplier();
                    fcs.ShowDialog();
                    txtKodeSupplier.Text = fcs.ks;
                }
                else
                {
                    string strSql = $"UPDATE notaBeli SET kodeSupplier='{txtKodeSupplier.Text}' " +
                        $"WHERE noNotaBeli='{txtNoNotaBeli.Text}'";
                    masterBeli.eksekusiSQL(strSql);
                    masterBeli.getBS().Position = masterBeli.getBS().Find("noNotaBeli", noSkrg); //<-- kembali ke posisi nota sekarang
                    txtKodeBarang.Focus();
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            string tglSekarang = DateTime.Now.ToString("yyyy-MM-dd");
            string strSql = $"INSERT INTO notaBeli(tgl) VALUES ('{tglSekarang}')";
            long noNotanya = masterBeli.eksekusiSQL_getId(strSql);
            masterBeli.getBS().Position = masterBeli.getBS().Find("noNotaBeli", noNotanya);
            tampil();
            modeInput();
            txtKodeSupplier.Focus();
            tampil(); //<--supaya DGV diFilter dengan noNotaBeli yang terbaru
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtTgl_Leave(object sender, EventArgs e)
        {
            string noNotaSekarang = txtNoNotaBeli.Text;
            DateTime tipeDataTime = DateTime.ParseExact(txtTgl.Text, "dd/MM/yyyy00:00:00", CultureInfo.InvariantCulture);
            string tanggal = tipeDataTime.ToString("yyyy-MM-dd");
            string strSql = $"UPDATE noNotaBeli SET tgl='{tanggal}' WHERE noNotaBeli='{noNotaSekarang}')";
            masterBeli.eksekusiSQL(strSql);
            masterBeli.getBS().Position = masterBeli.getBS().Find("noNotaBeli", noNotaSekarang);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DialogResult jwb = MessageBox.Show("Anda yakin akan menghapus nota ini?",
                "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (jwb == DialogResult.Yes)
            {
                string strSql = $"DELETE FROM notaBeli WHERE noNotaBeli='{txtNoNotaBeli.Text}'";
                masterBeli.eksekusiSQL(strSql);
                MessageBox.Show("Penghapusan selesai...");
            }
            else
            {
                MessageBox.Show("Penghapusan dibatalkan...");
            }
        }
    }
}
