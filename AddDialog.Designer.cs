namespace Steinhart_Hart
{
    partial class AddDialog 
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private TempView observer ;  // not implementingfull observer given it is one fixed instance only

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

        public AddDialog Subscribe(TempView observer)
        {
            this.observer = observer;
            return this;
        }


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnAdd = new Button();
            btnClose = new Button();
            label1 = new Label();
            label2 = new Label();
            txtTemp = new TextBox();
            txtRes = new TextBox();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(59, 268);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(112, 34);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(299, 268);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(112, 34);
            btnClose.TabIndex = 2;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(59, 94);
            label1.Name = "label1";
            label1.Size = new Size(81, 25);
            label1.TabIndex = 3;
            label1.Text = "Temp (C)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(59, 141);
            label2.Name = "label2";
            label2.Size = new Size(153, 25);
            label2.TabIndex = 4;
            label2.Text = "Resistance (ohms)";
            // 
            // txtTemp
            // 
            txtTemp.Location = new Point(224, 90);
            txtTemp.Name = "txtTemp";
            txtTemp.Size = new Size(150, 31);
            txtTemp.TabIndex = 5;
            // 
            // txtRes
            // 
            txtRes.Location = new Point(224, 141);
            txtRes.Name = "txtRes";
            txtRes.Size = new Size(150, 31);
            txtRes.TabIndex = 6;
            // 
            // AddDialog
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(463, 373);
            Controls.Add(txtRes);
            Controls.Add(txtTemp);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnClose);
            Controls.Add(btnAdd);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "AddDialog";
            Text = "Add Temp/Resistance";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAdd;
        private Button btnClose;
        private Label label1;
        private Label label2;
        private TextBox txtTemp;
        private TextBox txtRes;
    }
}