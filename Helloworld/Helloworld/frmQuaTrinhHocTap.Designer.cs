namespace Helloworld
{
    partial class frmQuaTrinhHocTap
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nmFromYear = new System.Windows.Forms.NumericUpDown();
            this.nmToYear = new System.Windows.Forms.NumericUpDown();
            this.txtHocTai = new System.Windows.Forms.TextBox();
            this.btnDongY = new System.Windows.Forms.Button();
            this.btnBoQua = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nmFromYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmToYear)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ năm : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Đến năm : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Học tại :  ";
            // 
            // nmFromYear
            // 
            this.nmFromYear.Location = new System.Drawing.Point(99, 21);
            this.nmFromYear.Maximum = new decimal(new int[] {
            2050,
            0,
            0,
            0});
            this.nmFromYear.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nmFromYear.Name = "nmFromYear";
            this.nmFromYear.Size = new System.Drawing.Size(102, 20);
            this.nmFromYear.TabIndex = 3;
            this.nmFromYear.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // nmToYear
            // 
            this.nmToYear.Location = new System.Drawing.Point(99, 58);
            this.nmToYear.Maximum = new decimal(new int[] {
            2050,
            0,
            0,
            0});
            this.nmToYear.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nmToYear.Name = "nmToYear";
            this.nmToYear.Size = new System.Drawing.Size(102, 20);
            this.nmToYear.TabIndex = 4;
            this.nmToYear.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // txtHocTai
            // 
            this.txtHocTai.Location = new System.Drawing.Point(99, 99);
            this.txtHocTai.Multiline = true;
            this.txtHocTai.Name = "txtHocTai";
            this.txtHocTai.Size = new System.Drawing.Size(302, 45);
            this.txtHocTai.TabIndex = 5;
            // 
            // btnDongY
            // 
            this.btnDongY.Location = new System.Drawing.Point(245, 172);
            this.btnDongY.Name = "btnDongY";
            this.btnDongY.Size = new System.Drawing.Size(75, 23);
            this.btnDongY.TabIndex = 6;
            this.btnDongY.Text = "Đồng ý";
            this.btnDongY.UseVisualStyleBackColor = true;
            this.btnDongY.Click += new System.EventHandler(this.btnDongY_Click);
            // 
            // btnBoQua
            // 
            this.btnBoQua.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBoQua.Location = new System.Drawing.Point(326, 172);
            this.btnBoQua.Name = "btnBoQua";
            this.btnBoQua.Size = new System.Drawing.Size(75, 23);
            this.btnBoQua.TabIndex = 7;
            this.btnBoQua.Text = "Bỏ qua";
            this.btnBoQua.UseVisualStyleBackColor = true;
            // 
            // frmQuaTrinhHocTap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnBoQua;
            this.ClientSize = new System.Drawing.Size(438, 216);
            this.ControlBox = false;
            this.Controls.Add(this.btnBoQua);
            this.Controls.Add(this.btnDongY);
            this.Controls.Add(this.txtHocTai);
            this.Controls.Add(this.nmToYear);
            this.Controls.Add(this.nmFromYear);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmQuaTrinhHocTap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm/ Sửa Quá trình học tập ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmQuaTrinhHocTap_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.nmFromYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmToYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nmFromYear;
        private System.Windows.Forms.NumericUpDown nmToYear;
        private System.Windows.Forms.TextBox txtHocTai;
        private System.Windows.Forms.Button btnDongY;
        private System.Windows.Forms.Button btnBoQua;
    }
}