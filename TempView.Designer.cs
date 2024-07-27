namespace Steinhart_Hart
{
    partial class TempView
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

 



        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtC1 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            txtC2 = new TextBox();
            txtC3 = new TextBox();
            lstTempReadings = new ListBox();
            btnLoad = new Button();
            btnAdd = new Button();
            btnDel = new Button();
            btnClear = new Button();
            label4 = new Label();
            txtThermistor = new TextBox();
            fileDlg = new OpenFileDialog();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(28, 730);
            label1.Name = "label1";
            label1.Size = new Size(33, 25);
            label1.TabIndex = 0;
            label1.Text = "C1";
            // 
            // txtC1
            // 
            txtC1.Enabled = false;
            txtC1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txtC1.Location = new Point(80, 725);
            txtC1.Name = "txtC1";
            txtC1.Size = new Size(140, 31);
            txtC1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(278, 728);
            label2.Name = "label2";
            label2.Size = new Size(33, 25);
            label2.TabIndex = 2;
            label2.Text = "C2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(553, 730);
            label3.Name = "label3";
            label3.Size = new Size(33, 25);
            label3.TabIndex = 3;
            label3.Text = "C3";
            // 
            // txtC2
            // 
            txtC2.Enabled = false;
            txtC2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txtC2.Location = new Point(317, 725);
            txtC2.Name = "txtC2";
            txtC2.Size = new Size(150, 31);
            txtC2.TabIndex = 4;
            // 
            // txtC3
            // 
            txtC3.Enabled = false;
            txtC3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txtC3.Location = new Point(592, 727);
            txtC3.Name = "txtC3";
            txtC3.Size = new Size(150, 31);
            txtC3.TabIndex = 5;
            // 
            // lstTempReadings
            // 
            lstTempReadings.AllowDrop = true;
            lstTempReadings.FormatString = "N2";
            lstTempReadings.FormattingEnabled = true;
            lstTempReadings.ItemHeight = 25;
            lstTempReadings.Location = new Point(31, 85);
            lstTempReadings.Name = "lstTempReadings";
            lstTempReadings.Size = new Size(557, 579);
            lstTempReadings.TabIndex = 7;
            lstTempReadings.DragDrop += listBox1_DragDrop;
            lstTempReadings.DragOver += listBox1_DragOver;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(601, 85);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(121, 34);
            btnLoad.TabIndex = 8;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(610, 223);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(112, 34);
            btnAdd.TabIndex = 9;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDel
            // 
            btnDel.Location = new Point(610, 276);
            btnDel.Name = "btnDel";
            btnDel.Size = new Size(112, 34);
            btnDel.TabIndex = 10;
            btnDel.Text = "Delete";
            btnDel.UseVisualStyleBackColor = true;
            btnDel.Click += this.btnDel_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(610, 330);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(112, 34);
            btnClear.TabIndex = 11;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click_1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(35, 29);
            label4.Name = "label4";
            label4.Size = new Size(97, 25);
            label4.TabIndex = 12;
            label4.Text = "Thermistor";
            // 
            // txtThermistor
            // 
            txtThermistor.Location = new Point(164, 24);
            txtThermistor.Name = "txtThermistor";
            txtThermistor.Size = new Size(557, 31);
            txtThermistor.TabIndex = 13;
            // 
            // fileDlg
            // 
            fileDlg.Filter = "CSV|*.csv|Text |*.txt";
            // 
            // TempView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 791);
            Controls.Add(txtThermistor);
            Controls.Add(label4);
            Controls.Add(btnClear);
            Controls.Add(btnDel);
            Controls.Add(btnAdd);
            Controls.Add(btnLoad);
            Controls.Add(lstTempReadings);
            Controls.Add(txtC3);
            Controls.Add(txtC2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtC1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "TempView";
            Text = "Steinhart-Hart";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtC1;
        private Label label2;
        private Label label3;
        private TextBox txtC2;
        private TextBox txtC3;
        private ListBox lstTempReadings;
        private Button btnLoad;
        private Button btnAdd;
        private Button btnDel;
        private Button btnClear;
        private Label label4;
        private TextBox txtThermistor;
        private OpenFileDialog fileDlg;
    }
}
