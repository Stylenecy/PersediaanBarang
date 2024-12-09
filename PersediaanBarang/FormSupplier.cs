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
    public partial class FormSupplier : Form
    {
        public FormSupplier()
        {
            InitializeComponent();
            dgvSupplier.DataSource = supplier.getBS();
        }
        Tabel supplier = new Tabel("supplier");

        private bool baru;
        private string kodeLama;

        private void ikat()
        {
            txtKodeSupplier.DataBindings.Add("Text", supplier.getBS(), "kodeSupplier");
            txtNamaSupplier.DataBindings.Add("Text", supplier.getBS(), "namaSupplier");
            txtAlamat.DataBindings.Add("Text", supplier.getBS(), "alamat");
            txtTelpon.DataBindings.Add("Text", supplier.getBS(), "telpon");
            txtKota.DataBindings.Add("Text", supplier.getBS(), "kota");
        }
        private void lepasTextBox()
        {
            txtKodeSupplier.DataBindings.Clear();
            txtNamaSupplier.DataBindings.Clear();
            txtAlamat.DataBindings.Clear();
            txtTelpon.DataBindings.Clear();
            txtKota.DataBindings.Clear();
        }

        private void saveMode()
        {
            //textbox disabled
            txtKodeSupplier.Enabled = false;
            txtNamaSupplier.Enabled = false;
            txtAlamat.Enabled = false;
            txtTelpon.Enabled = false;
            txtKota.Enabled = false;

            //navigasi enabled untuk liat-liat
            btnTop.Enabled = true;
            btnBack.Enabled = true;
            btnEnd.Enabled = true;
            btnNext.Enabled = true;

            //controller
            btnFind.Enabled = true;
            btnPrint.Enabled = true;
            btnEdit.Enabled = true;
            btnDel.Enabled = true;
            btnNew.Enabled = true;

            //save dan undo disabled->tidak ada save/undo ketika lihat-lihat
            btnSave.Visible = false;
            btnUndo.Visible = false;

            //mencegah user close ketika edit
            btnClose.Enabled = true;
            ikat();
        }

        private void editMode()
        {
            //lakukan !boolean
            //textbox enabled untuk edit
            txtKodeSupplier.Enabled = true;
            txtNamaSupplier.Enabled = true;
            txtAlamat.Enabled = true;
            txtTelpon.Enabled = true;
            txtKota.Enabled = true;

            //navigasi disabled untuk mencegah index berubah
            btnTop.Enabled = false;
            btnBack.Enabled = false;
            btnEnd.Enabled = false;
            btnNext.Enabled = false;

            //controller tidak bisa digunakan
            btnFind.Enabled = false;
            btnPrint.Enabled = false;
            btnEdit.Enabled = false;
            btnDel.Enabled = false;
            btnNew.Enabled = false;

            //save dan undo enabled->menyimpan atau membatalkan operasi
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
            kodeLama = txtKodeSupplier.Text;
            txtKodeSupplier.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult jawab;
            jawab = MessageBox.Show("Yakin ingin menghapus data ini ?", "konfirmasi", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (jawab == System.Windows.Forms.DialogResult.Yes)
            {
                string stringSQL = "DELETE FROM supplier WHERE kodeSupplier='{0}'";
                stringSQL = string.Format(stringSQL, txtKodeSupplier.Text);
                MessageBox.Show("Cek Dulu : " + stringSQL);
                this.supplier.eksekusiSQL(stringSQL);
                MessageBox.Show("Penghapusan berhasil");
            }
            else
            {
                MessageBox.Show("Penghapusan Gagal");
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            editMode();
            baru = true;
            txtKodeSupplier.Clear();
            txtNamaSupplier.Clear();
            txtAlamat.Clear();
            txtTelpon.Clear();
            txtKota.Clear();

            txtKodeSupplier.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string stringSQL, kodeS, namaS, alamatS, telp, kota;
            kodeS = txtKodeSupplier.Text;
            namaS = txtNamaSupplier.Text;
            alamatS = txtAlamat.Text;
            telp = txtTelpon.Text;
            kota = txtKota.Text;
            if (baru)
            {
                stringSQL = "INSERT INTO supplier VALUES('{0}','{1}','{2}','{3}','{4}')";
                stringSQL = String.Format(stringSQL, kodeS, namaS, alamatS, telp, kota);
            }
            else
            {
                stringSQL = "UPDATE supplier SET kodeSupplier='{0}', namaSupplier='{1}', alamat='{2}', telpon='{3}', kota='{4}'";
                stringSQL += "WHERE kodeSupplier='{5}'";
                stringSQL = String.Format(stringSQL, kodeS, namaS, alamatS, telp, kota, this.kodeLama);
            }
            this.supplier.eksekusiSQL(stringSQL);
            saveMode();
        }

        private void btnTop_Click(object sender, EventArgs e)
        {
            this.supplier.getBS().MoveFirst();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.supplier.getBS().MovePrevious();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.supplier.getBS().MoveNext();
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            this.supplier.getBS().MoveLast();
        }
    }
}
