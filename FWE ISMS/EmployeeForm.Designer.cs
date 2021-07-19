namespace FWE_ISMS
{
    partial class EmployeeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeForm));
            this.EmployeeListPanel = new System.Windows.Forms.Panel();
            this.EmployeesLbl = new System.Windows.Forms.Label();
            this.EmployeesLstBx = new System.Windows.Forms.ListBox();
            this.UpdateEmployeeBttn = new System.Windows.Forms.Button();
            this.AddEmployeeBttn = new System.Windows.Forms.Button();
            this.RemoveEmployeeBttn = new System.Windows.Forms.Button();
            this.EmployeeDetailPanel = new System.Windows.Forms.Panel();
            this.EmployeeResetPassBttn = new System.Windows.Forms.Button();
            this.EmployeeAdministratorChkBx = new System.Windows.Forms.CheckBox();
            this.EmployeePassTxtBx = new System.Windows.Forms.TextBox();
            this.EmployeeUserNameTxtBx = new System.Windows.Forms.TextBox();
            this.EmployeeClearBttn = new System.Windows.Forms.Button();
            this.EmployeeEmailTxtBx = new System.Windows.Forms.TextBox();
            this.EmployeeCnctNoTxtBx = new System.Windows.Forms.TextBox();
            this.EmployeeLNameTxtBx = new System.Windows.Forms.TextBox();
            this.EmployeeFNameTxtBx = new System.Windows.Forms.TextBox();
            this.EmployeeIDNoTxtBx = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.EmployeeListPanel.SuspendLayout();
            this.EmployeeDetailPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // EmployeeListPanel
            // 
            this.EmployeeListPanel.BackColor = System.Drawing.Color.Silver;
            this.EmployeeListPanel.Controls.Add(this.EmployeesLbl);
            this.EmployeeListPanel.Controls.Add(this.EmployeesLstBx);
            this.EmployeeListPanel.Controls.Add(this.UpdateEmployeeBttn);
            this.EmployeeListPanel.Controls.Add(this.AddEmployeeBttn);
            this.EmployeeListPanel.Controls.Add(this.RemoveEmployeeBttn);
            this.EmployeeListPanel.Location = new System.Drawing.Point(5, 5);
            this.EmployeeListPanel.Name = "EmployeeListPanel";
            this.EmployeeListPanel.Size = new System.Drawing.Size(257, 565);
            this.EmployeeListPanel.TabIndex = 0;
            // 
            // EmployeesLbl
            // 
            this.EmployeesLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EmployeesLbl.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmployeesLbl.ForeColor = System.Drawing.Color.Black;
            this.EmployeesLbl.Location = new System.Drawing.Point(0, 29);
            this.EmployeesLbl.Name = "EmployeesLbl";
            this.EmployeesLbl.Size = new System.Drawing.Size(257, 23);
            this.EmployeesLbl.TabIndex = 1;
            this.EmployeesLbl.Text = "Employees";
            this.EmployeesLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EmployeesLstBx
            // 
            this.EmployeesLstBx.FormattingEnabled = true;
            this.EmployeesLstBx.ItemHeight = 14;
            this.EmployeesLstBx.Location = new System.Drawing.Point(3, 128);
            this.EmployeesLstBx.Name = "EmployeesLstBx";
            this.EmployeesLstBx.Size = new System.Drawing.Size(251, 144);
            this.EmployeesLstBx.TabIndex = 0;
            this.EmployeesLstBx.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EmployeesLstBx_MouseClick);
            // 
            // UpdateEmployeeBttn
            // 
            this.UpdateEmployeeBttn.BackColor = System.Drawing.Color.LimeGreen;
            this.UpdateEmployeeBttn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.UpdateEmployeeBttn.ForeColor = System.Drawing.Color.White;
            this.UpdateEmployeeBttn.Location = new System.Drawing.Point(22, 333);
            this.UpdateEmployeeBttn.Name = "UpdateEmployeeBttn";
            this.UpdateEmployeeBttn.Size = new System.Drawing.Size(208, 32);
            this.UpdateEmployeeBttn.TabIndex = 1;
            this.UpdateEmployeeBttn.Text = "Update";
            this.UpdateEmployeeBttn.UseVisualStyleBackColor = false;
            this.UpdateEmployeeBttn.Click += new System.EventHandler(this.UpdateEmployeeBttn_Click);
            // 
            // AddEmployeeBttn
            // 
            this.AddEmployeeBttn.BackColor = System.Drawing.Color.LimeGreen;
            this.AddEmployeeBttn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AddEmployeeBttn.ForeColor = System.Drawing.Color.White;
            this.AddEmployeeBttn.Location = new System.Drawing.Point(22, 295);
            this.AddEmployeeBttn.Name = "AddEmployeeBttn";
            this.AddEmployeeBttn.Size = new System.Drawing.Size(208, 32);
            this.AddEmployeeBttn.TabIndex = 1;
            this.AddEmployeeBttn.Text = "Add Employee";
            this.AddEmployeeBttn.UseVisualStyleBackColor = false;
            this.AddEmployeeBttn.Click += new System.EventHandler(this.AddEmployeeBttn_Click);
            // 
            // RemoveEmployeeBttn
            // 
            this.RemoveEmployeeBttn.BackColor = System.Drawing.Color.IndianRed;
            this.RemoveEmployeeBttn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RemoveEmployeeBttn.ForeColor = System.Drawing.Color.White;
            this.RemoveEmployeeBttn.Location = new System.Drawing.Point(41, 371);
            this.RemoveEmployeeBttn.Name = "RemoveEmployeeBttn";
            this.RemoveEmployeeBttn.Size = new System.Drawing.Size(165, 32);
            this.RemoveEmployeeBttn.TabIndex = 2;
            this.RemoveEmployeeBttn.Text = "Remove Employee";
            this.RemoveEmployeeBttn.UseVisualStyleBackColor = false;
            this.RemoveEmployeeBttn.Click += new System.EventHandler(this.RemoveEmployeeBttn_Click);
            // 
            // EmployeeDetailPanel
            // 
            this.EmployeeDetailPanel.BackColor = System.Drawing.Color.Silver;
            this.EmployeeDetailPanel.Controls.Add(this.EmployeeResetPassBttn);
            this.EmployeeDetailPanel.Controls.Add(this.EmployeeAdministratorChkBx);
            this.EmployeeDetailPanel.Controls.Add(this.EmployeePassTxtBx);
            this.EmployeeDetailPanel.Controls.Add(this.EmployeeUserNameTxtBx);
            this.EmployeeDetailPanel.Controls.Add(this.EmployeeClearBttn);
            this.EmployeeDetailPanel.Controls.Add(this.EmployeeEmailTxtBx);
            this.EmployeeDetailPanel.Controls.Add(this.EmployeeCnctNoTxtBx);
            this.EmployeeDetailPanel.Controls.Add(this.EmployeeLNameTxtBx);
            this.EmployeeDetailPanel.Controls.Add(this.EmployeeFNameTxtBx);
            this.EmployeeDetailPanel.Controls.Add(this.EmployeeIDNoTxtBx);
            this.EmployeeDetailPanel.Controls.Add(this.label10);
            this.EmployeeDetailPanel.Controls.Add(this.label9);
            this.EmployeeDetailPanel.Controls.Add(this.label8);
            this.EmployeeDetailPanel.Controls.Add(this.label7);
            this.EmployeeDetailPanel.Controls.Add(this.label4);
            this.EmployeeDetailPanel.Controls.Add(this.label5);
            this.EmployeeDetailPanel.Controls.Add(this.label3);
            this.EmployeeDetailPanel.Controls.Add(this.label2);
            this.EmployeeDetailPanel.Location = new System.Drawing.Point(268, 5);
            this.EmployeeDetailPanel.Name = "EmployeeDetailPanel";
            this.EmployeeDetailPanel.Size = new System.Drawing.Size(470, 565);
            this.EmployeeDetailPanel.TabIndex = 0;
            // 
            // EmployeeResetPassBttn
            // 
            this.EmployeeResetPassBttn.Location = new System.Drawing.Point(356, 306);
            this.EmployeeResetPassBttn.Name = "EmployeeResetPassBttn";
            this.EmployeeResetPassBttn.Size = new System.Drawing.Size(75, 23);
            this.EmployeeResetPassBttn.TabIndex = 12;
            this.EmployeeResetPassBttn.Text = "Reset";
            this.EmployeeResetPassBttn.UseVisualStyleBackColor = true;
            this.EmployeeResetPassBttn.Click += new System.EventHandler(this.EmployeeResetPassBttn_Click);
            // 
            // EmployeeAdministratorChkBx
            // 
            this.EmployeeAdministratorChkBx.AutoSize = true;
            this.EmployeeAdministratorChkBx.Location = new System.Drawing.Point(175, 344);
            this.EmployeeAdministratorChkBx.Name = "EmployeeAdministratorChkBx";
            this.EmployeeAdministratorChkBx.Size = new System.Drawing.Size(156, 18);
            this.EmployeeAdministratorChkBx.TabIndex = 11;
            this.EmployeeAdministratorChkBx.Text = "Administrator Access";
            this.EmployeeAdministratorChkBx.UseVisualStyleBackColor = true;
            // 
            // EmployeePassTxtBx
            // 
            this.EmployeePassTxtBx.Location = new System.Drawing.Point(175, 306);
            this.EmployeePassTxtBx.Name = "EmployeePassTxtBx";
            this.EmployeePassTxtBx.PasswordChar = '•';
            this.EmployeePassTxtBx.Size = new System.Drawing.Size(175, 22);
            this.EmployeePassTxtBx.TabIndex = 10;
            // 
            // EmployeeUserNameTxtBx
            // 
            this.EmployeeUserNameTxtBx.Location = new System.Drawing.Point(175, 271);
            this.EmployeeUserNameTxtBx.Name = "EmployeeUserNameTxtBx";
            this.EmployeeUserNameTxtBx.Size = new System.Drawing.Size(175, 22);
            this.EmployeeUserNameTxtBx.TabIndex = 9;
            // 
            // EmployeeClearBttn
            // 
            this.EmployeeClearBttn.BackColor = System.Drawing.Color.Transparent;
            this.EmployeeClearBttn.ForeColor = System.Drawing.Color.Black;
            this.EmployeeClearBttn.Location = new System.Drawing.Point(193, 382);
            this.EmployeeClearBttn.Name = "EmployeeClearBttn";
            this.EmployeeClearBttn.Size = new System.Drawing.Size(73, 32);
            this.EmployeeClearBttn.TabIndex = 2;
            this.EmployeeClearBttn.Text = "Clear";
            this.EmployeeClearBttn.UseVisualStyleBackColor = false;
            this.EmployeeClearBttn.Click += new System.EventHandler(this.EmployeeClearBttn_Click);
            // 
            // EmployeeEmailTxtBx
            // 
            this.EmployeeEmailTxtBx.Location = new System.Drawing.Point(175, 236);
            this.EmployeeEmailTxtBx.Name = "EmployeeEmailTxtBx";
            this.EmployeeEmailTxtBx.Size = new System.Drawing.Size(187, 22);
            this.EmployeeEmailTxtBx.TabIndex = 8;
            // 
            // EmployeeCnctNoTxtBx
            // 
            this.EmployeeCnctNoTxtBx.Location = new System.Drawing.Point(175, 201);
            this.EmployeeCnctNoTxtBx.Name = "EmployeeCnctNoTxtBx";
            this.EmployeeCnctNoTxtBx.Size = new System.Drawing.Size(109, 22);
            this.EmployeeCnctNoTxtBx.TabIndex = 7;
            // 
            // EmployeeLNameTxtBx
            // 
            this.EmployeeLNameTxtBx.Location = new System.Drawing.Point(175, 163);
            this.EmployeeLNameTxtBx.Name = "EmployeeLNameTxtBx";
            this.EmployeeLNameTxtBx.Size = new System.Drawing.Size(241, 22);
            this.EmployeeLNameTxtBx.TabIndex = 5;
            // 
            // EmployeeFNameTxtBx
            // 
            this.EmployeeFNameTxtBx.Location = new System.Drawing.Point(175, 128);
            this.EmployeeFNameTxtBx.Name = "EmployeeFNameTxtBx";
            this.EmployeeFNameTxtBx.Size = new System.Drawing.Size(241, 22);
            this.EmployeeFNameTxtBx.TabIndex = 4;
            // 
            // EmployeeIDNoTxtBx
            // 
            this.EmployeeIDNoTxtBx.Location = new System.Drawing.Point(175, 93);
            this.EmployeeIDNoTxtBx.Name = "EmployeeIDNoTxtBx";
            this.EmployeeIDNoTxtBx.Size = new System.Drawing.Size(132, 22);
            this.EmployeeIDNoTxtBx.TabIndex = 3;
            this.EmployeeIDNoTxtBx.TextChanged += new System.EventHandler(this.EmployeeIDNoTxtBx_TextChanged);
            // 
            // label10
            // 
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(-2, 305);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(168, 22);
            this.label10.TabIndex = 2;
            this.label10.Text = "Password:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(1, 270);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(168, 22);
            this.label9.TabIndex = 2;
            this.label9.Text = "Username:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(1, 235);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(168, 22);
            this.label8.TabIndex = 2;
            this.label8.Text = "E-mail:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(1, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(168, 22);
            this.label7.TabIndex = 2;
            this.label7.Text = "Contact No:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(1, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 22);
            this.label4.TabIndex = 2;
            this.label4.Text = "Last Name:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(1, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 22);
            this.label5.TabIndex = 2;
            this.label5.Text = "First Name:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(4, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "Employee No:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(0, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(470, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Employee Information";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(744, 574);
            this.Controls.Add(this.EmployeeDetailPanel);
            this.Controls.Add(this.EmployeeListPanel);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EmployeeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee Management";
            this.EmployeeListPanel.ResumeLayout(false);
            this.EmployeeDetailPanel.ResumeLayout(false);
            this.EmployeeDetailPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel EmployeeListPanel;
        private System.Windows.Forms.Panel EmployeeDetailPanel;
        private System.Windows.Forms.Label EmployeesLbl;
        private System.Windows.Forms.ListBox EmployeesLstBx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button RemoveEmployeeBttn;
        private System.Windows.Forms.Button AddEmployeeBttn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox EmployeePassTxtBx;
        private System.Windows.Forms.TextBox EmployeeUserNameTxtBx;
        private System.Windows.Forms.TextBox EmployeeCnctNoTxtBx;
        private System.Windows.Forms.TextBox EmployeeLNameTxtBx;
        private System.Windows.Forms.TextBox EmployeeFNameTxtBx;
        private System.Windows.Forms.TextBox EmployeeIDNoTxtBx;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox EmployeeEmailTxtBx;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox EmployeeAdministratorChkBx;
        private System.Windows.Forms.Button EmployeeClearBttn;
        private System.Windows.Forms.Button UpdateEmployeeBttn;
        private System.Windows.Forms.Button EmployeeResetPassBttn;
    }
}