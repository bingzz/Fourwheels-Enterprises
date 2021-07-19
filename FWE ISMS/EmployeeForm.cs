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
    public partial class EmployeeForm : Form
    {
        string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\Documents\Visual Studio 2019\Projects\FWE ISMS\InventorySystemDB v3.mdb";
        public EmployeeForm()
        {
            InitializeComponent();
            DisplayEmployees();
        }

        public void isAdministrator(bool admin, string idNum)
        {
            if (!admin)
            {
                EmployeesLstBx.Hide();
                AddEmployeeBttn.Hide();
                RemoveEmployeeBttn.Hide();
                EmployeeResetPassBttn.Hide();
                EmployeeClearBttn.Hide();
                EmployeesLbl.Hide();
                EmployeeIDNoTxtBx.Enabled = false;
                EmployeeAdministratorChkBx.Hide();
            }

            string query = "SELECT * FROM EMPLOYEEFILE WHERE EMPID = '" + idNum +"'";
            OleDbConnection connect = new OleDbConnection(connectionString);
            connect.Open();
            OleDbCommand command = new OleDbCommand(query, connect);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                EmployeeIDNoTxtBx.Text = reader["EMPID"].ToString();
                EmployeeFNameTxtBx.Text = reader["EMPFNAME"].ToString();
                EmployeeLNameTxtBx.Text = reader["EMPLNAME"].ToString();
                EmployeeCnctNoTxtBx.Text = reader["EMPCONTACT"].ToString();
                EmployeeEmailTxtBx.Text = reader["EMPEMAIL"].ToString();
                EmployeeUserNameTxtBx.Text = reader["EMPUSERNM"].ToString();
                EmployeePassTxtBx.Text = reader["EMPPASSWD"].ToString();
            }
            reader.Close();
            connect.Close();
        }

        private void DisplayEmployees()
        {
            string query = "SELECT EMPID FROM EMPLOYEEFILE ORDER BY EMPID ASC";
            OleDbConnection connect = new OleDbConnection(connectionString);
            connect.Open();

            DataSet dataSet = new DataSet();
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connect);
            dataAdapter.Fill(dataSet);
            EmployeesLstBx.DisplayMember = "EMPID";
            EmployeesLstBx.ValueMember = "EMPID";
            EmployeesLstBx.DataSource = dataSet.Tables[0];
            connect.Close();
        }

        private void ClearFields()
        {
            EmployeeIDNoTxtBx.Text = "";
            EmployeeFNameTxtBx.Text = "";
            EmployeeLNameTxtBx.Text = "";
            EmployeeCnctNoTxtBx.Text = "";
            EmployeeUserNameTxtBx.Text = "";
            EmployeePassTxtBx.Text = "";
            EmployeeEmailTxtBx.Text = "";
            EmployeeAdministratorChkBx.Checked = false;
        }

        private void EmployeesLstBx_MouseClick(object sender, MouseEventArgs e)
        {
            string query = "SELECT * FROM EMPLOYEEFILE";
            OleDbConnection connect = new OleDbConnection(connectionString);
            connect.Open();
            OleDbCommand command = new OleDbCommand(query, connect);
            OleDbDataReader reader = command.ExecuteReader();

            if (EmployeesLstBx.SelectedItem != null)
            {
                DataRowView rowView = (DataRowView)EmployeesLstBx.SelectedItem;
                string value = rowView["EMPID"].ToString();

                while (reader.Read())
                {
                    if (reader["EMPID"].ToString().Equals(value))
                    {
                        EmployeeIDNoTxtBx.Text = reader["EMPID"].ToString();
                        EmployeeFNameTxtBx.Text = reader["EMPFNAME"].ToString();
                        EmployeeLNameTxtBx.Text = reader["EMPLNAME"].ToString();
                        EmployeeCnctNoTxtBx.Text = reader["EMPCONTACT"].ToString();
                        EmployeeEmailTxtBx.Text = reader["EMPEMAIL"].ToString();
                        EmployeeUserNameTxtBx.Text = reader["EMPUSERNM"].ToString();
                        EmployeePassTxtBx.Text = reader["EMPPASSWD"].ToString();

                        if (reader["EMPADMINSTAT"].ToString().Equals("Y"))
                            EmployeeAdministratorChkBx.Checked = true;
                        else
                            EmployeeAdministratorChkBx.Checked = false;

                        break;
                    }
                }
                reader.Close();
            }
            connect.Close();
        }

        private void RemoveEmployeeBttn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(EmployeeIDNoTxtBx.Text))
                MessageBox.Show("Please enter an Employee ID", "Empty field", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                OleDbConnection connect = new OleDbConnection(connectionString);
                connect.Open();
                string query = "SELECT * FROM EMPLOYEEFILE WHERE EMPID = '" + EmployeeIDNoTxtBx.Text + "'", 
                    delete = "DELETE FROM EMPLOYEEFILE WHERE EMPID = '" + EmployeeIDNoTxtBx.Text + "'";
                OleDbCommand command = new OleDbCommand(query, connect);
                OleDbDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Close();
                    DialogResult YesNo = MessageBox.Show("Are you sure you want to delete this Employee?", "Delete Employee", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (YesNo == DialogResult.Yes)
                    {
                        command.CommandText = delete;
                        command.ExecuteNonQuery();

                        connect.Close();
                        ClearFields();
                        DisplayEmployees();
                        
                        MessageBox.Show("Employee Successfully deleted", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    MessageBox.Show("Employee cannot be found", "No employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                connect.Close();
            }
        }

        private void EmployeeClearBttn_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void AddEmployeeBttn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(EmployeeIDNoTxtBx.Text) || string.IsNullOrEmpty(EmployeeFNameTxtBx.Text) || string.IsNullOrEmpty(EmployeeCnctNoTxtBx.Text) || string.IsNullOrEmpty(EmployeeEmailTxtBx.Text) || string.IsNullOrEmpty(EmployeeUserNameTxtBx.Text) || string.IsNullOrEmpty(EmployeePassTxtBx.Text))
                MessageBox.Show("Please fill out the missing fields", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            { // ADD
                string query = "SELECT * FROM EMPLOYEEFILE";
                OleDbConnection connect = new OleDbConnection(connectionString);
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connect);
                OleDbCommandBuilder commandBuilder = new OleDbCommandBuilder(dataAdapter);
                DataSet dataSet = new DataSet();

                dataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                dataAdapter.Fill(dataSet, "EMPLOYEEFILE");

                DataRow newRow = dataSet.Tables["EMPLOYEEFILE"].NewRow();
                DataRow findRow = dataSet.Tables["EMPLOYEEFILE"].Rows.Find(EmployeeIDNoTxtBx.Text);

                if (findRow == null)
                {
                    DialogResult YesNo = MessageBox.Show("Do you want to add this new Employee?", "Create New Employee", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (YesNo == DialogResult.Yes)
                    {
                        string isAdmin = "";
                        if (EmployeeAdministratorChkBx.Checked)
                            isAdmin = "Y";
                        else
                            isAdmin = "N";

                        newRow["EMPID"] = EmployeeIDNoTxtBx.Text;
                        newRow["EMPUSERNM"] = EmployeeUserNameTxtBx.Text;
                        newRow["EMPPASSWD"] = EmployeePassTxtBx.Text;
                        newRow["EMPFNAME"] = EmployeeFNameTxtBx.Text;
                        newRow["EMPLNAME"] = EmployeeLNameTxtBx.Text;
                        newRow["EMPCONTACT"] = EmployeeCnctNoTxtBx.Text;
                        newRow["EMPEMAIL"] = EmployeeEmailTxtBx.Text;
                        newRow["EMPADMINSTAT"] = isAdmin;

                        dataSet.Tables["EMPLOYEEFILE"].Rows.Add(newRow);
                        dataAdapter.Update(dataSet, "EMPLOYEEFILE");

                        ClearFields();
                        MessageBox.Show("New Employee successfully added!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        connect.Close();
                        DisplayEmployees();
                    }
                }
                else
                {
                    MessageBox.Show("Duplicate Employee ID Number", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    EmployeeIDNoTxtBx.Text = "";
                }
            }
        }

        private void UpdateEmployeeBttn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(EmployeeIDNoTxtBx.Text) || string.IsNullOrEmpty(EmployeeFNameTxtBx.Text) || string.IsNullOrEmpty(EmployeeCnctNoTxtBx.Text) || string.IsNullOrEmpty(EmployeeEmailTxtBx.Text) || string.IsNullOrEmpty(EmployeeUserNameTxtBx.Text) || string.IsNullOrEmpty(EmployeePassTxtBx.Text))
                MessageBox.Show("Please fill out the missing fields", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                DialogResult YesNo = MessageBox.Show("Confirm changes?", "Update Employee", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (YesNo == DialogResult.Yes)
                {
                    string query = "SELECT * FROM EMPLOYEEFILE";
                    OleDbConnection connect = new OleDbConnection(connectionString);
                    connect.Open();
                    OleDbCommand command = new OleDbCommand(query, connect);
                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connect);

                    string isAdmin = "";
                    if (EmployeeAdministratorChkBx.Checked)
                        isAdmin = "Y";
                    else
                        isAdmin = "N";

                    string update = "UPDATE EMPLOYEEFILE SET EMPUSERNM = '" + EmployeeUserNameTxtBx.Text + "', EMPPASSWD = '" + EmployeePassTxtBx.Text + "', EMPFNAME = '" + EmployeeFNameTxtBx.Text + "', EMPLNAME = '" + EmployeeLNameTxtBx.Text + "', EMPCONTACT = '" + EmployeeCnctNoTxtBx.Text + "',  EMPEMAIL = '" + EmployeeEmailTxtBx.Text + "', EMPADMINSTAT = '" + isAdmin + "' WHERE EMPID = '" + EmployeeIDNoTxtBx.Text + "'";
                    command.CommandText = update;
                    command.ExecuteNonQuery();

                    
                    MessageBox.Show("Changes saved", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connect.Close();
                    DisplayEmployees();
                    
                }
            }
        }

        private void EmployeeResetPassBttn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(EmployeePassTxtBx.Text))
                MessageBox.Show("Please enter a password", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                string query = "UPDATE EMPLOYEEFILE SET EMPPASSWD = '123' WHERE EMPID = '" + EmployeeIDNoTxtBx.Text + "'";
                OleDbConnection connect = new OleDbConnection(connectionString);
                connect.Open();
                OleDbCommand command = new OleDbCommand(query, connect);
                OleDbDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Close();
                    DialogResult YesNo = MessageBox.Show("Are you sure you want to reset this password?", "Reset Password", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (YesNo == DialogResult.Yes)
                    {
                        command.ExecuteNonQuery();
                        connect.Close();
                        ClearFields();
                        MessageBox.Show("Employee password has successfully reset", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    MessageBox.Show("Employee cannot be found", "No employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void EmployeeIDNoTxtBx_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT * FROM EMPLOYEEFILE WHERE EMPID = '" + EmployeeIDNoTxtBx.Text +"'";
            OleDbConnection connect = new OleDbConnection(connectionString);
            connect.Open();
            OleDbCommand command = new OleDbCommand(query, connect);
            OleDbDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    EmployeeFNameTxtBx.Text = reader["EMPFNAME"].ToString();
                    EmployeeLNameTxtBx.Text = reader["EMPLNAME"].ToString();
                    EmployeeCnctNoTxtBx.Text = reader["EMPCONTACT"].ToString();
                    EmployeeEmailTxtBx.Text = reader["EMPEMAIL"].ToString();
                    EmployeeUserNameTxtBx.Text = reader["EMPUSERNM"].ToString();
                    EmployeePassTxtBx.Text = reader["EMPPASSWD"].ToString();

                    if (reader["EMPADMINSTAT"].ToString().Equals("Y"))
                        EmployeeAdministratorChkBx.Checked = true;
                    else
                        EmployeeAdministratorChkBx.Checked = false;

                    break;
                }
            }
            else
            {
                EmployeeFNameTxtBx.Text = "";
                EmployeeLNameTxtBx.Text = "";
                EmployeeCnctNoTxtBx.Text = "";
                EmployeeEmailTxtBx.Text = "";
                EmployeeUserNameTxtBx.Text = "";
                EmployeePassTxtBx.Text = "";
                EmployeeAdministratorChkBx.Checked = false;
            }
            reader.Close();
            connect.Close();
        }
    }
}
