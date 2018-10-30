namespace plamen
{
    partial class FormSpisakMagacin
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvSpisakNaloga = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpisakNaloga)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvSpisakNaloga);
            this.groupBox1.Location = new System.Drawing.Point(2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(642, 467);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Spisak Realizovanih Zahteva";
            // 
            // dgvSpisakNaloga
            // 
            this.dgvSpisakNaloga.AllowUserToAddRows = false;
            this.dgvSpisakNaloga.AllowUserToDeleteRows = false;
            this.dgvSpisakNaloga.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSpisakNaloga.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvSpisakNaloga.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSpisakNaloga.Location = new System.Drawing.Point(6, 34);
            this.dgvSpisakNaloga.Name = "dgvSpisakNaloga";
            this.dgvSpisakNaloga.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSpisakNaloga.Size = new System.Drawing.Size(630, 306);
            this.dgvSpisakNaloga.TabIndex = 2;
            this.dgvSpisakNaloga.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSpisakNaloga_CellContentClick);
            this.dgvSpisakNaloga.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSpisakNaloga_CellDoubleClick);
            // 
            // FormSpisakMagacin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 471);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormSpisakMagacin";
            this.Text = "Spisak Magacin";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpisakNaloga)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvSpisakNaloga;
    }
}