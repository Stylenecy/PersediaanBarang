using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersediaanBarang
{
    public partial class FormNotaJual : Form
    {
        public FormNotaJual()
        {
            InitializeComponent();
            dgvDetailJual.DataSource = detailJual.getBS();
        }

        Tabel master = new Tabel("notaJual");
        Tabel detailJual = new Tabel("view_detailJual");

        void modeOutput()
        {
            txtTgl.Enabled = false;
            txtKodeBarang.Enabled = false;
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
            txtKodeBarang.Enabled = true;
            txtTgl.Enabled = true;
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
            txtKodeBarang.Focus();
        }

        void tampil()
        {
            detailJual.getBS().Filter = "noNotaJual = " + txtNoNotaJual.Text;
            //decimal totalJumlah = 0;
            int total = 0; //<-- akumulator

            foreach (DataGridViewRow row in dgvDetailJual.Rows)
            {
                // Pastikan baris tidak kosong (misalnya, pada baris terakhir untuk menambahkan data baru)
                //if (row.Cells["jumlah"].Value != null && row.Cells["jumlah"].Value != DBNull.Value)
                //{
                // Tambahkan nilai kolom "jumlah" ke total
                //    totalJumlah += Convert.ToDecimal(row.Cells["jumlah"].Value);
                //}
                total += int.Parse(row.Cells["jumlah"].Value.ToString()); //<-- tapi kalo yang jumlah itu diganti jadi angka
                                                                          //<-- dengan syarat harus pas itungannya angka cell nya  
                                                                          //<-- dari idItemNotaJual itu hitung dari 0
            }
            txtTotal.Text = total.ToString("N0");

            // Tampilkan total (misalnya, di label)
            //txtTotal.Text = totalJumlah.ToString("N0");
        }

        void ikat()
        {
            txtNoNotaJual.DataBindings.Add("Text", master.getBS(), "noNotaJual");
            txtTgl.DataBindings.Add("Text", master.getBS(), "noNotaJual");
        }

        private void FormNotaJual_Load(object sender, EventArgs e)
        {
            ikat();
            tampil();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            master.getBS().MoveNext();
            tampil();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            master.getBS().MovePrevious();
            tampil();
        }

        private void btnTop_Click(object sender, EventArgs e)
        {
            master.getBS().MovePrevious();
            tampil();
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            master.getBS().MoveLast();
            tampil();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            modeInput();
        }

        Tabel barang = new Tabel("barang");
        private void txtKodeBarang_TextChanged(object sender, EventArgs e)
        {

            if(txtKodeBarang.Text.Length == 5)
            {
                int noBrs = barang.getBS().Find("kodeBarang", txtKodeBarang.Text);
                if(noBrs >= 0)
                { //kodeBarang valid
                    string noNotaJual, kodeBarang, qty, harga;
                    noNotaJual = txtNoNotaJual.Text;
                    kodeBarang = txtKodeBarang.Text;
                    qty = "1";
                    barang.getBS().Position = noBrs; //<-- pindah dulu record pointernya
                    harga = ((DataRowView)barang.getBS().Current).Row["hargaJual"].ToString(); //<-- jadi Current-nya baca posisi data yang baru
                    string strSql = "INSERT INTO itemNotaJual(noNotaJual, kodeBarang, qty, harga) " +
                        $"VALUES ('{noNotaJual}', '{kodeBarang}', '{qty}', '{harga}')";
                    detailJual.eksekusiSQL(strSql);
                    txtKodeBarang.Clear();
                    txtKodeBarang.Focus();
                }
                else
                { //kodeBarang tidak valid
                    FormCariBarang fcb = new FormCariBarang();
                    fcb.ShowDialog();
                    txtKodeBarang.Text = fcb.kodeCari;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            modeOutput();
        }

        private void txtKodeBarang_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtKodeBarang.Text.Length > 0)
            {
                detailJual.getBS().MoveLast();
                string idNya = ((DataRowView)detailJual.getBS().Current).Row["idItemNotaJual"].ToString();
                if (txtKodeBarang.Text.Substring(0, 1) == "+")
                {
                    int tambah = int.Parse(txtKodeBarang.Text.Substring(1));
                    string strSql = $"UPDATE itemNotaJual SET qty = qty + {tambah} " +
                        $"WHERE idItemNotaJual='{idNya}'";
                    detailJual.eksekusiSQL(strSql);
                    txtKodeBarang.Clear();
                    txtKodeBarang.Focus();
                }
                else
                {
                    if (txtKodeBarang.Text.Substring(0, 1) == "-")
                    {
                        int kurang = int.Parse(txtKodeBarang.Text.Substring(1));
                        string strSql = $"UPDATE itemNotaJual SET qty = qty - {kurang} " +
                            $"WHERE idItemNotaJual='{idNya}'";
                        detailJual.eksekusiSQL(strSql);
                        txtKodeBarang.Clear();
                        txtKodeBarang.Focus();
                    }
                }
            }
        }

        private void dgvDetailJual_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && btnSave.Visible) 
            {
                DialogResult jwb = MessageBox.Show("Anda yakin akan menghapus item penjualan ini?",
                    "Konfirmasi",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (jwb == DialogResult.Yes)
                {
                    string idNya = dgvDetailJual.CurrentRow.Cells[0].Value.ToString();
                    string strSql = $"DELETE FROM itemNotaJual WHERE idItemNotaJual='{idNya}'";
                    detailJual.eksekusiSQL(strSql);
                    txtKodeBarang.Focus();
                }                
            }
        }
    }
}
