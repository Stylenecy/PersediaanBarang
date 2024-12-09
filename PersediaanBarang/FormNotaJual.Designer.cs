namespace PersediaanBarang
{
    partial class FormNotaJual
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtTgl = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnEnd = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnTop = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNoNotaJual = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvDetailJual = new System.Windows.Forms.DataGridView();
            this.idItemNotaJual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noNotaJual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kodeBarang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.namaBarang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.harga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jumlah = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.txtKodeBarang = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailJual)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTgl
            // 
            this.txtTgl.Enabled = false;
            this.txtTgl.Location = new System.Drawing.Point(701, 27);
            this.txtTgl.Name = "txtTgl";
            this.txtTgl.Size = new System.Drawing.Size(164, 22);
            this.txtTgl.TabIndex = 74;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(637, 30);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 16);
            this.label13.TabIndex = 72;
            this.label13.Text = "Tanggal";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(346, 525);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(33, 16);
            this.label18.TabIndex = 59;
            this.label18.Text = "Find";
            // 
            // btnClose
            // 
            this.btnClose.Image = global::PersediaanBarang.Properties.Resources._12_Close;
            this.btnClose.Location = new System.Drawing.Point(810, 544);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(55, 50);
            this.btnClose.TabIndex = 44;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnUndo
            // 
            this.btnUndo.Image = global::PersediaanBarang.Properties.Resources._11_Undo;
            this.btnUndo.Location = new System.Drawing.Point(702, 544);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(55, 50);
            this.btnUndo.TabIndex = 45;
            this.btnUndo.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            this.btnNew.Image = global::PersediaanBarang.Properties.Resources._07_New;
            this.btnNew.Location = new System.Drawing.Point(579, 544);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(55, 50);
            this.btnNew.TabIndex = 46;
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Image = global::PersediaanBarang.Properties.Resources._10_Save;
            this.btnSave.Location = new System.Drawing.Point(641, 544);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(55, 50);
            this.btnSave.TabIndex = 47;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDel
            // 
            this.btnDel.Image = global::PersediaanBarang.Properties.Resources._09_Delete;
            this.btnDel.Location = new System.Drawing.Point(518, 544);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(55, 50);
            this.btnDel.TabIndex = 48;
            this.btnDel.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::PersediaanBarang.Properties.Resources._08_Edit;
            this.btnEdit.Location = new System.Drawing.Point(457, 544);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(55, 50);
            this.btnEdit.TabIndex = 49;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.Image = global::PersediaanBarang.Properties.Resources._04_DataContainer_MoveLastHS;
            this.btnEnd.Location = new System.Drawing.Point(220, 544);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(55, 50);
            this.btnEnd.TabIndex = 50;
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::PersediaanBarang.Properties.Resources._06_Print;
            this.btnPrint.Location = new System.Drawing.Point(396, 544);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(55, 50);
            this.btnPrint.TabIndex = 51;
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Image = global::PersediaanBarang.Properties.Resources._03_DataContainer_MoveNextHS;
            this.btnNext.Location = new System.Drawing.Point(159, 544);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(55, 50);
            this.btnNext.TabIndex = 52;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnFind
            // 
            this.btnFind.Image = global::PersediaanBarang.Properties.Resources._05_Find;
            this.btnFind.Location = new System.Drawing.Point(335, 544);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(55, 50);
            this.btnFind.TabIndex = 53;
            this.btnFind.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            this.btnBack.Image = global::PersediaanBarang.Properties.Resources._02_DataContainer_MovePreviousHS;
            this.btnBack.Location = new System.Drawing.Point(98, 544);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(55, 50);
            this.btnBack.TabIndex = 54;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnTop
            // 
            this.btnTop.Image = global::PersediaanBarang.Properties.Resources._01_DataContainer_MoveFirstHS;
            this.btnTop.Location = new System.Drawing.Point(37, 544);
            this.btnTop.Name = "btnTop";
            this.btnTop.Size = new System.Drawing.Size(55, 50);
            this.btnTop.TabIndex = 55;
            this.btnTop.UseVisualStyleBackColor = true;
            this.btnTop.Click += new System.EventHandler(this.btnTop_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(708, 525);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 16);
            this.label9.TabIndex = 61;
            this.label9.Text = "Undo";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(470, 525);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 16);
            this.label8.TabIndex = 60;
            this.label8.Text = "Edit";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(526, 525);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 16);
            this.label7.TabIndex = 58;
            this.label7.Text = "Delete";
            // 
            // txtNoNotaJual
            // 
            this.txtNoNotaJual.Enabled = false;
            this.txtNoNotaJual.Location = new System.Drawing.Point(134, 27);
            this.txtNoNotaJual.Name = "txtNoNotaJual";
            this.txtNoNotaJual.Size = new System.Drawing.Size(100, 22);
            this.txtNoNotaJual.TabIndex = 66;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 62;
            this.label1.Text = "No. Nota Jual";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(590, 525);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 16);
            this.label6.TabIndex = 57;
            this.label6.Text = "New";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(648, 525);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 16);
            this.label5.TabIndex = 56;
            this.label5.Text = "Save";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(637, 488);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 69;
            this.label2.Text = "Total Rp";
            // 
            // dgvDetailJual
            // 
            this.dgvDetailJual.AllowUserToAddRows = false;
            this.dgvDetailJual.AllowUserToDeleteRows = false;
            this.dgvDetailJual.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetailJual.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idItemNotaJual,
            this.noNotaJual,
            this.kodeBarang,
            this.namaBarang,
            this.qty,
            this.harga,
            this.jumlah});
            this.dgvDetailJual.Location = new System.Drawing.Point(40, 195);
            this.dgvDetailJual.Name = "dgvDetailJual";
            this.dgvDetailJual.ReadOnly = true;
            this.dgvDetailJual.RowHeadersWidth = 51;
            this.dgvDetailJual.RowTemplate.Height = 24;
            this.dgvDetailJual.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetailJual.Size = new System.Drawing.Size(825, 284);
            this.dgvDetailJual.TabIndex = 77;
            this.dgvDetailJual.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvDetailJual_KeyUp);
            // 
            // idItemNotaJual
            // 
            this.idItemNotaJual.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.idItemNotaJual.DataPropertyName = "idItemNotaJual";
            this.idItemNotaJual.HeaderText = "idItemNotaJual";
            this.idItemNotaJual.MinimumWidth = 6;
            this.idItemNotaJual.Name = "idItemNotaJual";
            this.idItemNotaJual.ReadOnly = true;
            this.idItemNotaJual.Visible = false;
            this.idItemNotaJual.Width = 125;
            // 
            // noNotaJual
            // 
            this.noNotaJual.DataPropertyName = "noNotaJual";
            this.noNotaJual.HeaderText = "noNotaJual";
            this.noNotaJual.MinimumWidth = 6;
            this.noNotaJual.Name = "noNotaJual";
            this.noNotaJual.ReadOnly = true;
            this.noNotaJual.Visible = false;
            this.noNotaJual.Width = 125;
            // 
            // kodeBarang
            // 
            this.kodeBarang.DataPropertyName = "kodeBarang";
            this.kodeBarang.HeaderText = "Kode Barang";
            this.kodeBarang.MinimumWidth = 6;
            this.kodeBarang.Name = "kodeBarang";
            this.kodeBarang.ReadOnly = true;
            this.kodeBarang.Width = 55;
            // 
            // namaBarang
            // 
            this.namaBarang.DataPropertyName = "namaBarang";
            this.namaBarang.HeaderText = "Nama Barang";
            this.namaBarang.MinimumWidth = 6;
            this.namaBarang.Name = "namaBarang";
            this.namaBarang.ReadOnly = true;
            this.namaBarang.Width = 215;
            // 
            // qty
            // 
            this.qty.DataPropertyName = "qty";
            this.qty.HeaderText = "Qty";
            this.qty.MinimumWidth = 6;
            this.qty.Name = "qty";
            this.qty.ReadOnly = true;
            this.qty.Width = 40;
            // 
            // harga
            // 
            this.harga.DataPropertyName = "harga";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.harga.DefaultCellStyle = dataGridViewCellStyle1;
            this.harga.HeaderText = "Harga";
            this.harga.MinimumWidth = 6;
            this.harga.Name = "harga";
            this.harga.ReadOnly = true;
            this.harga.Width = 115;
            // 
            // jumlah
            // 
            this.jumlah.DataPropertyName = "jumlah";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.jumlah.DefaultCellStyle = dataGridViewCellStyle2;
            this.jumlah.HeaderText = "Jumlah";
            this.jumlah.MinimumWidth = 6;
            this.jumlah.Name = "jumlah";
            this.jumlah.ReadOnly = true;
            this.jumlah.Width = 120;
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(701, 485);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(164, 22);
            this.txtTotal.TabIndex = 75;
            // 
            // txtKodeBarang
            // 
            this.txtKodeBarang.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKodeBarang.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKodeBarang.Location = new System.Drawing.Point(40, 71);
            this.txtKodeBarang.Name = "txtKodeBarang";
            this.txtKodeBarang.Size = new System.Drawing.Size(825, 98);
            this.txtKodeBarang.TabIndex = 65;
            this.txtKodeBarang.TextChanged += new System.EventHandler(this.txtKodeBarang_TextChanged);
            this.txtKodeBarang.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtKodeBarang_KeyUp);
            // 
            // FormNotaJual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 624);
            this.Controls.Add(this.txtTgl);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtKodeBarang);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnTop);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtNoNotaJual);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvDetailJual);
            this.Controls.Add(this.txtTotal);
            this.Name = "FormNotaJual";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form Nota Penjualan";
            this.Load += new System.EventHandler(this.FormNotaJual_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailJual)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtTgl;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnTop;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNoNotaJual;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvDetailJual;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.TextBox txtKodeBarang;
        private System.Windows.Forms.DataGridViewTextBoxColumn idItemNotaJual;
        private System.Windows.Forms.DataGridViewTextBoxColumn noNotaJual;
        private System.Windows.Forms.DataGridViewTextBoxColumn kodeBarang;
        private System.Windows.Forms.DataGridViewTextBoxColumn namaBarang;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn harga;
        private System.Windows.Forms.DataGridViewTextBoxColumn jumlah;
    }
}