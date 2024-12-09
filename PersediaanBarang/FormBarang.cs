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
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace PersediaanBarang
{
    public partial class FormBarang : Form
    {
        public FormBarang()
        {
            InitializeComponent();
            saveMode(); //<-- sudah memanggil ikatTextBox()
            sambungDatabase();
            isiDataTable(); //<-- DataTable diisi
            dgvBarang.DataSource = this.bs; //<-- ganti sumber datanya menjadi BindingSource
            //tampilTextBoxManual(5); //<-- tampilkan baris yang ke-5
            
        }
        private DataTable dt = new DataTable(); //<-- struktur data bentuk Tabel
        private BindingSource bs = new BindingSource(); //<-- objek BindingSource
        private string originalKode;
        private string originalNama;
        private string originalHargaBeli;
        private string originalHargaJual;
        private string originalStok;
        private string originalSatuan;

        private void ikatTextBox()
        {
            txtKode.DataBindings.Add("Text", this.bs, "kodeBarang");
            txtBarang.DataBindings.Add("Text", this.bs, "namaBarang");
            txtHargaBeli.DataBindings.Add("Text", this.bs, "hargaBeli");
            txtHargaJual.DataBindings.Add("Text", this.bs, "hargaJual");
            txtStok.DataBindings.Add("Text", this.bs, "stok");
            txtSatuan.DataBindings.Add("Text", this.bs, "satuan");
        }

        private void lepasTextBox()
        {
            txtKode.DataBindings.Clear();
            txtBarang.DataBindings.Clear();
            txtHargaBeli.DataBindings.Clear();
            txtHargaJual.DataBindings.Clear();
            txtStok.DataBindings.Clear();
            txtSatuan.DataBindings.Clear();
        }

            private void tampilTextBoxManual(int baris)
        {
            txtKode.Text = this.dt.Rows[baris]["kodeBarang"].ToString();
            txtBarang.Text = this.dt.Rows[baris]["namaBarang"].ToString();
            txtHargaBeli.Text = this.dt.Rows[baris]["hargaBeli"].ToString();
            txtHargaJual.Text = this.dt.Rows[baris]["hargaJual"].ToString();
            txtStok.Text = this.dt.Rows[baris]["stok"].ToString();
            txtSatuan.Text = this.dt.Rows[baris]["satuan"].ToString();
        }
        
        private void isiDataTable()
        {
            this.sambungan.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM barang", this.sambungan);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            this.dt.Clear(); //<-- kosoongkan dulu DataTable
            da.Fill(this.dt);
            this.bs.DataSource = this.dt; //<-- sambungkan BindingSource ke DataTable
            this.sambungan.Close();
        }
        private void sambungDatabase()
        {
            string parameterKoneksi = "server=localhost;user id=root;password='';database=inv";
            this.sambungan = new MySqlConnection(parameterKoneksi);
        }
        public Boolean baru = false;
        private String kodeLama = null;
        private MySqlConnection sambungan;

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveMode()
        {
            dgvBarang.Enabled = true;
            //textbox disabled
            txtKode.Enabled = false;
            txtBarang.Enabled = false;
            txtHargaBeli.Enabled = false;
            txtHargaJual.Enabled = false;
            txtSatuan.Enabled = false;

            //navigasi enabled
            btnTop.Enabled = true;
            btnBack.Enabled = true;
            btnEnd.Enabled = true;
            btnNext.Enabled = true;

            //controller
            btnFind.Enabled = true;
            btnPrint.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnNew.Enabled = true;

            //Save dan Undo disabled -> tidak ada save/undo ketika lihat-lihat
            btnSave.Visible = false;
            btnUndo.Visible = false;

            //mencegah user close ketika edit
            btnClose.Enabled = true;
            ikatTextBox();
        }

        private void editMode()
        {
            dgvBarang.Enabled = false;
            //lakukan !boolean
            //textbox enabled
            
            originalKode = txtKode.Text;
            originalNama = txtBarang.Text;
            originalHargaBeli = txtHargaBeli.Text;
            originalHargaJual = txtHargaJual.Text;
            originalStok = txtStok.Text;
            originalSatuan = txtSatuan.Text;
            //simpan data asli sebelum diedit

            txtKode.Enabled = true;
            txtBarang.Enabled = true;
            txtHargaBeli.Enabled = true;
            txtHargaJual.Enabled = true;
            txtSatuan.Enabled = true;
            //txtStok.Enabled = true;

            //navigasi disabled untuk mencegah index berubah
            btnTop.Enabled = false;
            btnBack.Enabled = false;
            btnEnd.Enabled = false;
            btnNext.Enabled = false;

            //controller tidak bisa digunakan
            btnFind.Enabled = false;
            btnPrint.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnNew.Enabled = false;

            //Save dan Undo enabled -> tidak ada save/undo ketika lihat-lihat
            btnSave.Visible = true;
            btnUndo.Visible = true;

            //mencegah user close ketika edit
            btnClose.Enabled = false;
            lepasTextBox();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            editMode();
            baru = false;
            kodeLama = txtKode.Text;
            txtKode.Focus();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            editMode();
            baru = true;
            txtKode.Clear();
            txtBarang.Clear();
            txtHargaBeli.Text = "0";
            txtHargaJual.Text = "0";
            txtSatuan.Text = "pcs";
            txtStok.Text = "0";

            //tambah focus agar kursor langsung ada di kode
            txtKode.Focus();
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            txtKode.Text = originalKode;
            txtBarang.Text = originalNama;
            txtHargaBeli.Text = originalHargaBeli;
            txtHargaJual.Text = originalHargaJual;
            txtStok.Text = originalStok;
            txtSatuan.Text = originalSatuan;
            //balikin data asli ke textbox

            saveMode();
            //balik ke mode view
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string kode, nama, hargaBeli, hargaJual, satuan, querySQL;
            kode = txtKode.Text.Trim();
            hargaBeli = txtHargaBeli.Text.Trim();
            hargaJual = txtHargaJual.Text.Trim();
            nama = txtBarang.Text;
            satuan = txtSatuan.Text.Trim();

            if (baru)
            {
                //insert query data baru
                //nama atribut disesuaikan degan database kalian
                querySQL = "INSERT INTO barang(kodeBarang, namaBarang, hargaBeli, hargaJual, satuan) " +
                    "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')";
                querySQL = string.Format(querySQL, kode, nama, hargaBeli, hargaJual, satuan);
            }
            else
            {
                //update data barang lama
                querySQL = "UPDATE  barang SET kodeBarang = '{0}', namaBarang = '{1}', hargaBeli = '{2}', hargaJual = '{3}', satuan = '{4}'" +
                    "WHERE kodeBarang = '{5}'";
                querySQL = string.Format(querySQL, kode, nama, hargaBeli, hargaJual, satuan, this.kodeLama);
            }
            MessageBox.Show("Query berikut akan dieksekusi" + querySQL);
            try
            {
                this.sambungan.Open();
                MySqlCommand cmd = new MySqlCommand(querySQL, this.sambungan);
                cmd.ExecuteNonQuery();
                if (baru)
                    MessageBox.Show("Penambahan Berhasil, silahkan periksa tabel di Barang");
                else
                    MessageBox.Show("Perubahan Data Berhasil, silahkan periksa tabel di Barang");
            }
            catch (Exception ex)
            {
                if (ex.Message.Substring(0, 15) == "Duplicate Entry")
                {
                    MessageBox.Show("Kode Barang : " + kode + " sudah digunakan\n" +
                        "Silahkan menggunakan kode yang lain");
                }
                else
                    MessageBox.Show(ex.Message);
                txtKode.Focus(); //<-- memindah kursor ke textBox kodeBarang
                return; //<-- keluar dari metode btnSave_Click
            }
            finally
            {
                this.sambungan.Close();
            }
            saveMode();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult respon = MessageBox.Show("Anda yakin akan menghapus?",
                "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respon == DialogResult.Yes)
            {
                string strSql = $"DELETE FROM barang WHERE kodeBarang='{txtKode.Text.Trim()}'";
                try
                {
                    this.sambungan.Open();
                    MySqlCommand cmd = new MySqlCommand(strSql, this.sambungan);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Penghapusan berhasil " + strSql + "\nSelesai...");
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("Cannot delete"))
                    {
                        MessageBox.Show("Kode Barang : " + txtKode.Text.Trim() + " sedang digunakan\n" +
                            "Anda tidak bisa menghapus data ini");
                    }
                    else
                        MessageBox.Show(ex.Message);
                    txtKode.Focus(); //<-- pesan bahasa Inggris (default)
                    return; //<-- keluar dari metode btnSave_Click
                }
                finally
                {
                    this.sambungan.Close();
                    this.isiDataTable();
                }
                //stringSQL = string.Format(stringSQL, txtKode.Text.Trim());
                MessageBox.Show("Dilakuan penghapusan:\n" + strSql);
            }
            else
            {
                MessageBox.Show("Tidak jadi dihapus...");
            }
        }

        private void btnTop_Click(object sender, EventArgs e)
        {
            this.bs.MoveFirst();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.bs.MovePrevious();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.bs.MoveNext();
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            this.bs.MoveLast();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            FormCariBarang frm = new FormCariBarang();
            frm.ShowDialog();
            //MessageBox.Show("Kodenya = " + frm.kodeCari);
            int baris = bs.Find("kodeBarang", frm.kodeCari);
            bs.Position = baris;
            frm.Close();
        }
    }
}
