using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FWE_ISMS
{
    public partial class LoginForm : Form
    {
        string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\Documents\Visual Studio 2019\Projects\FWE ISMS\InventorySystemDB v3.mdb";
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginBttn_Click(object sender, EventArgs e)
        {
            bool found = false;
            string query = "SELECT * FROM EMPLOYEEFILE WHERE EMPUSERNM = '" + UsernameTxtBx.Text + "'";
            OleDbConnection connect = new OleDbConnection(connectionString);
            connect.Open();

            OleDbCommand command = new OleDbCommand(query, connect);

            OleDbDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (reader["EMPUSERNM"].ToString().Equals(UsernameTxtBx.Text))
                    {
                        if (reader["EMPPASSWD"].ToString().Equals(UserNamePassTxtBx.Text))
                        {
                            found = true;
                            string admin = "";

                            if (reader["EMPADMINSTAT"].ToString().Equals("Y"))
                                admin = "Administrator";

                            MainForm main = new MainForm();
                            main.User(reader["EMPFNAME"].ToString(), reader["EMPLNAME"].ToString(), admin, reader["EMPID"].ToString());
                            main.ShowDialog();
                            this.Hide();
                            this.Close();
                            break;
                        }
                    }
                }
                reader.Close();
            }
            connect.Close();

            if (!found)
                MessageBox.Show("Incorrect Username. Please try a valid ID", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void UserNamePassTxtBx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                LoginBttn_Click(sender, e);
        }

        private void UsernameTxtBx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                LoginBttn_Click(sender, e);
        }
    }
}
