namespace FWE_ISMS
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.UsernameTxtBx = new System.Windows.Forms.TextBox();
            this.UserNamePassTxtBx = new System.Windows.Forms.TextBox();
            this.LoginBttn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(138, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fourwheels Enterprises \r\nUser Login";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(81, 106);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Username:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(85, 144);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "Password:";
            // 
            // UsernameTxtBx
            // 
            this.UsernameTxtBx.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameTxtBx.Location = new System.Drawing.Point(183, 105);
            this.UsernameTxtBx.Margin = new System.Windows.Forms.Padding(2);
            this.UsernameTxtBx.Name = "UsernameTxtBx";
            this.UsernameTxtBx.Size = new System.Drawing.Size(147, 22);
            this.UsernameTxtBx.TabIndex = 1;
            this.UsernameTxtBx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UsernameTxtBx_KeyPress);
            // 
            // UserNamePassTxtBx
            // 
            this.UserNamePassTxtBx.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNamePassTxtBx.Location = new System.Drawing.Point(183, 143);
            this.UserNamePassTxtBx.Margin = new System.Windows.Forms.Padding(2);
            this.UserNamePassTxtBx.Name = "UserNamePassTxtBx";
            this.UserNamePassTxtBx.PasswordChar = '*';
            this.UserNamePassTxtBx.Size = new System.Drawing.Size(147, 22);
            this.UserNamePassTxtBx.TabIndex = 2;
            this.UserNamePassTxtBx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UserNamePassTxtBx_KeyPress);
            // 
            // LoginBttn
            // 
            this.LoginBttn.BackColor = System.Drawing.Color.LimeGreen;
            this.LoginBttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginBttn.ForeColor = System.Drawing.Color.White;
            this.LoginBttn.Location = new System.Drawing.Point(162, 179);
            this.LoginBttn.Margin = new System.Windows.Forms.Padding(2);
            this.LoginBttn.Name = "LoginBttn";
            this.LoginBttn.Size = new System.Drawing.Size(112, 36);
            this.LoginBttn.TabIndex = 3;
            this.LoginBttn.Text = "LOG IN";
            this.LoginBttn.UseVisualStyleBackColor = false;
            this.LoginBttn.Click += new System.EventHandler(this.LoginBttn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(31, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(73, 71);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(430, 232);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LoginBttn);
            this.Controls.Add(this.UserNamePassTxtBx);
            this.Controls.Add(this.UsernameTxtBx);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventory and Sales Management System";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox UsernameTxtBx;
        private System.Windows.Forms.TextBox UserNamePassTxtBx;
        private System.Windows.Forms.Button LoginBttn;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

