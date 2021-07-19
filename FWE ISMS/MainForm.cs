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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            EmptyFunctionPanel.Show();
            EmptyDetailPanel.Show();
            EmptyMainPanel.Show();
            UsernamePositionLbl.Hide();
            InventoryManagementPanel.Hide();
            InventoryDetailPanel.Hide();
            InventoryFunctionPanel.Hide();
            SalesManagementPanel.Hide();
            SalesFunctionPanel.Hide();
            SalesDetailPanel.Hide();
            TransactionDetailPanel.Hide();
            TransactionFunctionPanel.Hide();
            TransactionsMainPanel.Hide();
            GenerateReportsPanel.Hide();
            SupplierMainPanel.Hide();
            SupplierDetailPanel.Hide();
            SupplierFunctionsPanel.Hide();

        }
        string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\Documents\Visual Studio 2019\Projects\FWE ISMS\InventorySystemDB v3.mdb";


        // ============================  INTERFACE ============================ //
        private void InventoryMgtBttn_Click(object sender, EventArgs e)
        {
            InventoryMgtBttn.Enabled = false;
            InventoryMgtBttn.BackColor = System.Drawing.Color.DarkGreen;
            SalesManagementBttn.Enabled = TransactionsBttn.Enabled = GenerateReportBttn.Enabled = SuppliersBttn.Enabled = true;
            GenerateReportBttn.BackColor = TransactionsBttn.BackColor = SalesManagementBttn.BackColor = SuppliersBttn.BackColor = System.Drawing.Color.LimeGreen;
            InventoryManagementPanel.Show();
            InventoryDetailPanel.Show();
            InventoryFunctionPanel.Show();
            EmptyFunctionPanel.Hide();
            EmptyDetailPanel.Hide();
            EmptyMainPanel.Hide();
            SalesManagementPanel.Hide();
            SalesFunctionPanel.Hide();
            SalesDetailPanel.Hide();
            SupplierFunctionsPanel.Hide();
            SupplierMainPanel.Hide();
            SupplierDetailPanel.Hide();
            TransactionDetailPanel.Hide();
            TransactionFunctionPanel.Hide();
            TransactionsMainPanel.Hide();
            GenerateReportsPanel.Hide();
            DisplayInventoryItems();
            ListSuppliers();
        }

        private void SalesManagementBttn_Click(object sender, EventArgs e)
        {
            SalesManagementBttn.Enabled = false;
            SalesManagementBttn.BackColor = System.Drawing.Color.DarkGreen;
            InventoryMgtBttn.Enabled = TransactionsBttn.Enabled = GenerateReportBttn.Enabled = SuppliersBttn.Enabled = true;
            GenerateReportBttn.BackColor = TransactionsBttn.BackColor = InventoryMgtBttn.BackColor = SuppliersBttn.BackColor = System.Drawing.Color.LimeGreen;
            SalesManagementPanel.Show();
            SalesDetailPanel.Show();
            SalesFunctionPanel.Show();
            EmptyFunctionPanel.Hide();
            EmptyDetailPanel.Hide();
            EmptyMainPanel.Hide();
            InventoryManagementPanel.Hide();
            InventoryDetailPanel.Hide();
            InventoryFunctionPanel.Hide();
            SupplierFunctionsPanel.Hide();
            SupplierMainPanel.Hide();
            SupplierDetailPanel.Hide();
            TransactionDetailPanel.Hide();
            TransactionFunctionPanel.Hide();
            TransactionsMainPanel.Hide();
            GenerateReportsPanel.Hide();

            DisplaySales();
        }

        private void TransactionsBttn_Click(object sender, EventArgs e)
        {
            TransactionsBttn.Enabled = false;
            TransactionsBttn.BackColor = System.Drawing.Color.DarkGreen;
            InventoryMgtBttn.Enabled = SalesManagementBttn.Enabled = GenerateReportBttn.Enabled = SuppliersBttn.Enabled = true;
            GenerateReportBttn.BackColor = SalesManagementBttn.BackColor = InventoryMgtBttn.BackColor = SuppliersBttn.BackColor = System.Drawing.Color.LimeGreen;
            TransactionDetailPanel.Show();
            TransactionFunctionPanel.Show();
            TransactionsMainPanel.Show();
            EmptyFunctionPanel.Hide();
            EmptyDetailPanel.Hide();
            EmptyMainPanel.Hide();
            InventoryManagementPanel.Hide();
            InventoryDetailPanel.Hide();
            InventoryFunctionPanel.Hide();
            SalesManagementPanel.Hide();
            SalesFunctionPanel.Hide();
            SalesDetailPanel.Hide();
            SupplierFunctionsPanel.Hide();
            SupplierMainPanel.Hide();
            SupplierDetailPanel.Hide();
            GenerateReportsPanel.Hide();
            DisplayTransactions();
        }

        private void GenerateReportBttn_Click(object sender, EventArgs e)
        {
            GenerateReportBttn.Enabled = false;
            GenerateReportBttn.BackColor = System.Drawing.Color.DarkGreen;
            InventoryMgtBttn.Enabled = SalesManagementBttn.Enabled = TransactionsBttn.Enabled = true;
            TransactionsBttn.BackColor = SalesManagementBttn.BackColor = InventoryMgtBttn.BackColor = SuppliersBttn.BackColor = System.Drawing.Color.LimeGreen;
            GenerateReportsPanel.Show();
            EmptyFunctionPanel.Hide();
            EmptyDetailPanel.Hide();
            EmptyMainPanel.Hide();
            InventoryManagementPanel.Hide();
            InventoryDetailPanel.Hide();
            InventoryFunctionPanel.Hide();
            SalesManagementPanel.Hide();
            SalesFunctionPanel.Hide();
            SalesDetailPanel.Hide();
            SupplierFunctionsPanel.Hide();
            SupplierMainPanel.Hide();
            SupplierDetailPanel.Hide();
            TransactionDetailPanel.Hide();
            TransactionFunctionPanel.Hide();
            TransactionsMainPanel.Hide();
            ReportAllTransactionRadioBttn.Checked = true;
            DisplayReport();
        }

        private void SuppliersBttn_Click(object sender, EventArgs e)
        {
            SuppliersBttn.Enabled = false;
            SuppliersBttn.BackColor = System.Drawing.Color.DarkGreen;
            InventoryMgtBttn.Enabled = SalesManagementBttn.Enabled = GenerateReportBttn.Enabled = TransactionsBttn.Enabled = true;
            GenerateReportBttn.BackColor = SalesManagementBttn.BackColor = InventoryMgtBttn.BackColor = TransactionsBttn.BackColor = System.Drawing.Color.LimeGreen;
            SupplierMainPanel.Show();
            SupplierDetailPanel.Show();
            SupplierFunctionsPanel.Show();
            EmptyFunctionPanel.Hide();
            EmptyDetailPanel.Hide();
            EmptyMainPanel.Hide();
            InventoryManagementPanel.Hide();
            InventoryDetailPanel.Hide();
            InventoryFunctionPanel.Hide();
            SalesManagementPanel.Hide();
            SalesFunctionPanel.Hide();
            SalesDetailPanel.Hide();
            GenerateReportsPanel.Hide();
            TransactionDetailPanel.Hide();
            TransactionFunctionPanel.Hide();
            TransactionsMainPanel.Hide();
            DisplaySuppliers();
        }

        public void User(string firstname, string lastname, string position, string idNum)
        {
            FirstNameLbl.Text = firstname.ToString();
            UsernamePositionLbl.Text = position.ToString();
            LastNameLbl.Text = lastname.ToString();
            EmpIDLbl.Text = idNum;

            if (UsernamePositionLbl.Text.ToUpper() == "ADMINISTRATOR")
            {
                UsernamePositionLbl.Show();
            }
            else
            {
                AddItemBttn.Hide();
                ClearItemDetailsBttn.Hide();
                UpdateItemBttn.Hide();
                RemoveItemBttn.Hide();
                SupplierAddUpdateBttn.Hide();
                SupplierClearBttn.Hide();
                SupplierIDTxtBx.Enabled = false;
                SupplierNameTxtBx.Enabled = false;
                SupplierAddressTxtBx.Enabled = false;
                SupplierCnctNoTxtBx.Enabled = false;
                ItemQuantityTxtBx.Enabled = false;
                ItemDescriptionTxtBx.Enabled = false;
                ItemBodyPartTypeTxtBx.Enabled = false;
                ItemVehicleManufacturerTxtBx.Enabled = false;
                ItemVehicleModelTxtBx.Enabled = false;
                ItemVehicleYearModelEndTxtBx.Enabled = false;
                ItemVehicleYearModelStartTxtBx.Enabled = false;
                ItemCostTxtBx.Enabled = false;
                ItemSellPriceTxtBx.Enabled = false;
                ItemSupplierCmbBx.Enabled = false;
                GenerateReportBttn.Hide();
                SupplierDeleteBttn.Hide();
            }
        }

        private void UsernamePositionLbl_Click(object sender, EventArgs e)
        {
            if (UsernamePositionLbl.Text.ToUpper() == "ADMINISTRATOR")
            {
                EmployeeForm emp = new EmployeeForm();
                emp.isAdministrator(true, EmpIDLbl.Text);
                emp.ShowDialog();
            }
            else
            {
                EmployeeForm emp = new EmployeeForm();
                emp.isAdministrator(false, EmpIDLbl.Text);
                emp.ShowDialog();
            }
        }

        private void LastNameLbl_Click(object sender, EventArgs e)
        {
            UsernamePositionLbl_Click(sender, e);
        }

        private void FirstNameLbl_Click(object sender, EventArgs e)
        {
            UsernamePositionLbl_Click(sender, e);
        }

        private void LogoutBttn_Click(object sender, EventArgs e)
        {
            DialogResult yesNo = MessageBox.Show("Are you sure you want to Log out?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (yesNo == DialogResult.Yes)
            {
                LoginForm login = new LoginForm();
                this.Hide();
                this.Close();
                login.ShowDialog();
            }
        }


        // ============================  INVENTORY MANAGEMENT ============================ //
        
        private void clearLists()
        {
            ItemIdTxtBx.Text = "";
            ItemQuantityTxtBx.Text = "";
            ItemDescriptionTxtBx.Text = "";
            ItemBodyPartTypeTxtBx.Text = "";
            ItemVehicleManufacturerTxtBx.Text = "";
            ItemVehicleModelTxtBx.Text = "";
            ItemVehicleYearModelEndTxtBx.Text = "";
            ItemVehicleYearModelStartTxtBx.Text = "";
            ItemCostTxtBx.Text = "";
            ItemSellPriceTxtBx.Text = "";
            ItemSupplierCmbBx.SelectedItem = null;
            AddItemBttn.Enabled = true;
        } // clears item details

        public void DisplayItemDetails()
        {
            string query = "SELECT PARTQTY AS Quantity, PARTDESC AS Description, PARTSECTION AS Type, VEHMFG AS Manufacturer, VEHMODEL AS Model, VEHMODELYRSTART AS YrStart, VEHMODELYREND AS YrEnd, PARTCOST AS Cost, SELLPRICE AS Price, SUPPNAME AS Supplier FROM PARTSDETAILFILE WHERE IDPART = '" + ItemIdTxtBx.Text + "'";
            OleDbConnection connect = new OleDbConnection(connectionString);
            connect.Open();
            OleDbCommand command = new OleDbCommand(query, connect);
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            ItemDetailsDataGrid.DataSource = table;
            connect.Close();
        } // displays item details data grid

        public void DisplayInventoryItems()
        {
            string query = "SELECT * FROM PARTSHEADERFILE";
            OleDbConnection connect = new OleDbConnection(connectionString);
            connect.Open();
            OleDbCommand command = new OleDbCommand(query, connect);
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            ItemsDataGrid.DataSource = table;
            connect.Close();

        } // displays the item header

        public void ListSuppliers()
        {
            ItemSupplierCmbBx.Items.Clear();
            OleDbConnection connect = new OleDbConnection(connectionString);
            connect.Open();
            string query = "SELECT SUPPNAME FROM SUPPLIERFILE";
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connect);
            OleDbCommand command = new OleDbCommand(query, connect);
            OleDbDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ItemSupplierCmbBx.Items.Add(reader["SUPPNAME"]);
                }
            }

            reader.Close();
            connect.Close();
        } // lists all the suppliers

        private void ClearItemDetailsBttn_Click(object sender, EventArgs e)
        {
            clearLists();
            ItemDetailsDataGrid.DataSource = null;
            RemoveItemBttn.Enabled = false;
        } // clears the item details texts

        decimal partCost;
        private void UpdateItemBttn_Click(object sender, EventArgs e)
        {
            int parsedQuantity, parsedYearStart, parsedYearEnd;
            double parsedCost, parsedSellPrice;

            if (string.IsNullOrEmpty(ItemIdTxtBx.Text) || string.IsNullOrEmpty(ItemQuantityTxtBx.Text) || string.IsNullOrEmpty(ItemDescriptionTxtBx.Text) || string.IsNullOrEmpty(ItemBodyPartTypeTxtBx.Text) || string.IsNullOrEmpty(ItemVehicleManufacturerTxtBx.Text) ||
                string.IsNullOrEmpty(ItemVehicleModelTxtBx.Text) || string.IsNullOrEmpty(ItemVehicleYearModelStartTxtBx.Text) || string.IsNullOrEmpty(ItemVehicleYearModelEndTxtBx.Text) || string.IsNullOrEmpty(ItemCostTxtBx.Text) || string.IsNullOrEmpty(ItemSellPriceTxtBx.Text) ||
                string.IsNullOrEmpty(ItemSupplierCmbBx.Text))
                MessageBox.Show("There are Empty fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (!int.TryParse(ItemQuantityTxtBx.Text, out parsedQuantity) || !int.TryParse(ItemVehicleYearModelStartTxtBx.Text, out parsedYearStart) || !int.TryParse(ItemVehicleYearModelEndTxtBx.Text, out parsedYearEnd))
                MessageBox.Show("Quantity and Years must only contain numbers", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (!double.TryParse(ItemCostTxtBx.Text, out parsedCost) || !double.TryParse(ItemSellPriceTxtBx.Text, out parsedSellPrice))
                MessageBox.Show("Cost and Sell Price must only contain numbers", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (Convert.ToInt32(ItemQuantityTxtBx.Text) <= 0)
                MessageBox.Show("Quantity must not be below 0", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                if (!string.IsNullOrEmpty(ItemIdTxtBx.Text))
                {
                    string query, update;
                    int totalQuantity = 0;
                    OleDbConnection connect = new OleDbConnection(connectionString);
                    connect.Open();

                    query = "SELECT * FROM PARTSDETAILFILE WHERE IDPART = '" + ItemIdTxtBx.Text + "'";
                    OleDbCommand command = new OleDbCommand(query, connect);
                    OleDbDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Close();
                        DialogResult YesNo = MessageBox.Show("Are you sure you want to confirm the changes?", "Changes has been made", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (YesNo == DialogResult.Yes)
                        {
                            try
                            {
                                // PARTS DETAIL
                                update = "UPDATE PARTSDETAILFILE SET PARTQTY = " + Convert.ToInt32(ItemQuantityTxtBx.Text) + ", PARTCOST = " + Convert.ToDouble(ItemCostTxtBx.Text) + ", SELLPRICE = " + Convert.ToDouble(ItemSellPriceTxtBx.Text) + ", SUPPNAME = '" + ItemSupplierCmbBx.Text + "' WHERE IDPART = '" + ItemIdTxtBx.Text + "' AND PARTCOST = " + partCost + "";
                                command.CommandText = update;
                                command.ExecuteNonQuery();

                                update = "UPDATE PARTSDETAILFILE SET PARTDESC = '" + ItemDescriptionTxtBx.Text + "', PARTSECTION = '" + ItemBodyPartTypeTxtBx.Text + "', VEHMFG = '" + ItemVehicleManufacturerTxtBx.Text + "', VEHMODEL = '" + ItemVehicleModelTxtBx.Text + "', VEHMODELYRSTART = " + Convert.ToInt32(ItemVehicleYearModelStartTxtBx.Text) + ", VEHMODELYREND = " + Convert.ToInt32(ItemVehicleYearModelEndTxtBx.Text) + " WHERE IDPART = '" + ItemIdTxtBx.Text + "'";
                                command.CommandText = update;
                                command.ExecuteNonQuery();

                                // PARTS HEADER
                                update = "UPDATE PARTSHEADERFILE SET PARTDESC = '" + ItemDescriptionTxtBx.Text + "', PARTTYPE = '" + ItemBodyPartTypeTxtBx.Text + "' WHERE IDPART = '" + ItemIdTxtBx.Text + "'";
                                command.CommandText = update;
                                command.ExecuteNonQuery();

                                foreach (DataGridViewRow eachRow in ItemsDataGrid.Rows)
                                {
                                    query = "SELECT SUM(PARTQTY) FROM PARTSDETAILFILE WHERE IDPART = '" + eachRow.Cells["InventoryItemIDColumn"].Value.ToString() + "'";
                                    command.CommandText = query;

                                    if (totalQuantity.GetType() != typeof(DBNull))
                                        totalQuantity = Convert.ToInt32(command.ExecuteScalar());

                                    update = "UPDATE PARTSHEADERFILE SET TOTALQTY = " + totalQuantity + " WHERE IDPART = '" + eachRow.Cells["InventoryItemIDColumn"].Value.ToString() + "'";
                                    command.CommandText = update;
                                    command.ExecuteNonQuery();
                                }

                                connect.Close();
                                ClearItemDetailsBttn_Click(sender, e);
                                DisplayInventoryItems();
                                MessageBox.Show("Item Successfully updated", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            
                            catch (Exception f)
                            {
                                MessageBox.Show("Unhandled exception has occured. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                        MessageBox.Show("Item Part is not found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("The Item number does not exist, please select existing items to update", "No Item Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        } // updates existing item

        private void AddItemBttn_Click(object sender, EventArgs e)
        {
            int parsedQuantity, parsedYearStart, parsedYearEnd;
            double parsedCost, parsedSellPrice;

            if (string.IsNullOrEmpty(ItemIdTxtBx.Text) || string.IsNullOrEmpty(ItemQuantityTxtBx.Text) || string.IsNullOrEmpty(ItemDescriptionTxtBx.Text) || string.IsNullOrEmpty(ItemBodyPartTypeTxtBx.Text) || string.IsNullOrEmpty(ItemVehicleManufacturerTxtBx.Text) ||
                string.IsNullOrEmpty(ItemVehicleModelTxtBx.Text) || string.IsNullOrEmpty(ItemVehicleYearModelStartTxtBx.Text) || string.IsNullOrEmpty(ItemVehicleYearModelEndTxtBx.Text) || string.IsNullOrEmpty(ItemCostTxtBx.Text) || string.IsNullOrEmpty(ItemSellPriceTxtBx.Text) ||
                string.IsNullOrEmpty(ItemSupplierCmbBx.Text))
                MessageBox.Show("There are Empty fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (!int.TryParse(ItemQuantityTxtBx.Text, out parsedQuantity) || !int.TryParse(ItemVehicleYearModelStartTxtBx.Text, out parsedYearStart) || !int.TryParse(ItemVehicleYearModelEndTxtBx.Text, out parsedYearEnd))
                MessageBox.Show("Quantity and Years must only contain numbers", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (!double.TryParse(ItemCostTxtBx.Text, out parsedCost) || !double.TryParse(ItemSellPriceTxtBx.Text, out parsedSellPrice))
                MessageBox.Show("Cost and Sell Price must only contain numbers", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                string queryHeader = "SELECT * FROM PARTSHEADERFILE";
                string queryDetail = "SELECT * FROM PARTSDETAILFILE";
                OleDbConnection connect = new OleDbConnection(connectionString);
                connect.Open();

                // DETAIL
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(queryDetail, connect);
                OleDbCommandBuilder commandBuild = new OleDbCommandBuilder(dataAdapter);
                DataSet dataSet = new DataSet();

                dataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                dataAdapter.Fill(dataSet, "PARTSDETAILFILE");

                Object[] key = new object[2];
                key[0] = ItemIdTxtBx.Text;
                key[1] = Convert.ToDouble(ItemCostTxtBx.Text);

                DataRow newRow = dataSet.Tables["PARTSDETAILFILE"].NewRow();
                DataRow findRow = dataSet.Tables["PARTSDETAILFILE"].Rows.Find(key);

                if (findRow == null)
                {
                    DialogResult YesNo = MessageBox.Show("New Item part will be added, confirm?", "New Part Item", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (YesNo == DialogResult.Yes)
                    {
                        newRow["IDPART"] = ItemIdTxtBx.Text;
                        newRow["PARTSECTION"] = ItemBodyPartTypeTxtBx.Text;
                        newRow["PARTQTY"] = Convert.ToInt32(ItemQuantityTxtBx.Text);
                        //newRow["PARTNUM"] = ;
                        newRow["PARTDESC"] = ItemDescriptionTxtBx.Text;
                        newRow["VEHMFG"] = ItemVehicleManufacturerTxtBx.Text;
                        newRow["VEHMODEL"] = ItemVehicleModelTxtBx.Text;
                        newRow["VEHMODELYRSTART"] = Convert.ToInt32(ItemVehicleYearModelStartTxtBx.Text);
                        newRow["VEHMODELYREND"] = Convert.ToInt32(ItemVehicleYearModelEndTxtBx.Text);
                        newRow["PARTCOST"] = Convert.ToDouble(ItemCostTxtBx.Text);
                        newRow["SELLPRICE"] = Convert.ToDouble(ItemSellPriceTxtBx.Text);
                        newRow["SUPPNAME"] = ItemSupplierCmbBx.SelectedItem.ToString();

                        dataSet.Tables["PARTSDETAILFILE"].Rows.Add(newRow);
                        dataAdapter.Update(dataSet, "PARTSDETAILFILE");

                        // HEADER
                        dataAdapter = new OleDbDataAdapter(queryHeader, connect);
                        commandBuild = new OleDbCommandBuilder(dataAdapter);
                        dataSet = new DataSet();

                        dataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                        dataAdapter.Fill(dataSet, "PARTSHEADERFILE");

                        newRow = dataSet.Tables["PARTSHEADERFILE"].NewRow();
                        findRow = dataSet.Tables["PARTSHEADERFILE"].Rows.Find(key[0]);

                        if (findRow == null)
                        {
                            newRow["IDPART"] = ItemIdTxtBx.Text;
                            newRow["TOTALQTY"] = Convert.ToInt32(ItemQuantityTxtBx.Text);
                            newRow["PARTTYPE"] = ItemBodyPartTypeTxtBx.Text;
                            newRow["PARTDESC"] = ItemDescriptionTxtBx.Text;

                            dataSet.Tables["PARTSHEADERFILE"].Rows.Add(newRow);
                            dataAdapter.Update(dataSet, "PARTSHEADERFILE");
                        }
                        else
                        {
                            string update = "UPDATE PARTSHEADERFILE SET TOTALQTY = TOTALQTY + " + Convert.ToInt32(ItemQuantityTxtBx.Text)  + " WHERE IDPART = '" + ItemIdTxtBx.Text + "'";
                            OleDbCommand command = new OleDbCommand(queryHeader, connect);
                            command.CommandText = update;
                            command.ExecuteNonQuery();
                        }

                        connect.Close();
                        clearLists();
                        DisplayInventoryItems();
                        MessageBox.Show("New Item has been added", "New Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    MessageBox.Show("Part Item already Exist, try updating the existing Item", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        } // adds item to the header and detail

        private void RemoveItemBttn_Click(object sender, EventArgs e)
        {
            bool toDelete = false;
            if (!string.IsNullOrEmpty(ItemIdTxtBx.Text) && !string.IsNullOrEmpty(ItemCostTxtBx.Text) && ItemDetailsDataGrid.Rows.Count != 0)
                toDelete = true;

            if (toDelete)
            {
                DialogResult YesNo = MessageBox.Show("Are you sure you want to delete this item?", "Delete Item", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (YesNo == DialogResult.Yes)
                {
                    string delete, update, query;
                    int totalQuantity = 0;

                    OleDbConnection connect = new OleDbConnection(connectionString);
                    connect.Open();
                    OleDbCommand command;

                    // PARTSDETAILFILE
                    delete = "DELETE FROM PARTSDETAILFILE WHERE IDPART = '" + ItemIdTxtBx.Text + "' AND PARTCOST = " + Convert.ToDouble(ItemCostTxtBx.Text) + "";
                    command = new OleDbCommand(delete, connect);
                    command.ExecuteNonQuery();

                    // PARTSHEADER
                    delete = "DELETE FROM PARTSHEADERFILE PH WHERE NOT EXISTS (SELECT * FROM PARTSDETAILFILE PD WHERE ph.IDPART = pd.IDPART)";
                    command = new OleDbCommand(delete, connect);
                    command.ExecuteNonQuery();

                    foreach (DataGridViewRow eachRow in ItemsDataGrid.Rows)
                    {
                        query = "SELECT SUM(PARTQTY) FROM PARTSDETAILFILE WHERE IDPART = '" + eachRow.Cells["InventoryItemIDColumn"].Value.ToString() + "'";
                        command = new OleDbCommand(query, connect);
                        object quantity = command.ExecuteScalar();

                        if (quantity.GetType() != typeof(DBNull))
                            totalQuantity = Convert.ToInt32(quantity);

                        update = "UPDATE PARTSHEADERFILE SET TOTALQTY = " + totalQuantity + " WHERE IDPART = '" + eachRow.Cells["InventoryItemIDColumn"].Value.ToString() + "'";
                        command = new OleDbCommand(update, connect);
                        command.ExecuteNonQuery();
                    }

                    connect.Close();
                    ClearItemDetailsBttn_Click(sender, e);
                    DisplayInventoryItems();

                    MessageBox.Show("Item Successfully deleted", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
            }
            else
                MessageBox.Show("Please select an item to Delete", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
        } // removes existing item

        private void SearchItemTxtBx_TextChanged(object sender, EventArgs e)
        {
            if (SearchItemTxtBx.Text == "")
                DisplayInventoryItems();
            else
            {
                string query = "SELECT DISTINCT PH.IDPART, PH.PARTTYPE, PH.PARTDESC, PH.TOTALQTY FROM PARTSDETAILFILE PD INNER JOIN PARTSHEADERFILE PH ON PD.IDPART = PH.IDPART WHERE PD.VEHMFG LIKE '%" + SearchItemTxtBx.Text + "%' OR PD.VEHMODEL LIKE '%" + SearchItemTxtBx.Text + "%' OR PD.VEHMODELYRSTART LIKE '%" + SearchItemTxtBx.Text + "%' OR PD.VEHMODELYREND LIKE '%" + SearchItemTxtBx.Text + "%' OR PH.PARTTYPE LIKE '%" + SearchItemTxtBx.Text + "%' OR PH.IDPART LIKE '%" + SearchItemTxtBx.Text + "%' OR PH.PARTDESC LIKE '%" + SearchItemTxtBx.Text + "%'";

                OleDbConnection connect = new OleDbConnection(connectionString);
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connectionString);

                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                ItemsDataGrid.DataSource = dataTable;
            }
        } // searches the item header

        private void ItemDetailsDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RemoveItemBttn.Enabled = true;
            if (ItemDetailsDataGrid.Rows.Count > 0)
            {
                foreach (DataGridViewCell cell in ItemDetailsDataGrid.SelectedCells)
                {
                    DataGridViewRow row = cell.OwningRow;
                    ItemQuantityTxtBx.Text = row.Cells[0].Value.ToString();
                    ItemDescriptionTxtBx.Text = row.Cells[1].Value.ToString();
                    ItemBodyPartTypeTxtBx.Text = row.Cells[2].Value.ToString();
                    ItemVehicleManufacturerTxtBx.Text = row.Cells[3].Value.ToString();
                    ItemVehicleModelTxtBx.Text = row.Cells[4].Value.ToString();
                    ItemVehicleYearModelStartTxtBx.Text = row.Cells[5].Value.ToString();
                    ItemVehicleYearModelEndTxtBx.Text = row.Cells[6].Value.ToString();
                    ItemCostTxtBx.Text = row.Cells[7].Value.ToString();
                    ItemSellPriceTxtBx.Text = row.Cells[8].Value.ToString();
                    ItemSupplierCmbBx.Text = row.Cells[9].Value.ToString();
                    partCost = Convert.ToDecimal(row.Cells[7].Value);
                    break;
                }
            }
        } // displays the item details

        private void ItemsDataGrid_CellClick(object sender, DataGridViewCellEventArgs e) // set the item id to the textbox to display each items
        {
            clearLists();
            if (ItemsDataGrid.Rows.Count > 0)
            {
                foreach (DataGridViewCell cell in ItemsDataGrid.SelectedCells)
                {
                    DataGridViewRow row = cell.OwningRow;
                    ItemIdTxtBx.Text = row.Cells["InventoryItemIDColumn"].Value.ToString();
                    break;
                }

                DisplayItemDetails();

            }
            else
                ClearItemDetailsBttn_Click(sender, e);
        }


        // ============================  SALES MANAGEMENT ============================ //
        private void SearchSalesTxtBx_TextChanged(object sender, EventArgs e)
        {
            if (SearchSalesTxtBx.Text == "")
                DisplaySales();
            else
            {
                string query = "SELECT * FROM SALESHEADERFILE " +
                    "WHERE TRANSID LIKE '%" + SearchSalesTxtBx.Text +"%'" +
                    "OR REFDOCNUM LIKE '%" + SearchSalesTxtBx.Text + "%'" +
                    "OR SALECUSTNAME LIKE '%" + SearchSalesTxtBx.Text + "%'";
                OleDbConnection connect = new OleDbConnection(connectionString);
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connectionString);

                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                SalesDataGrid.DataSource = dataTable;
            }
        } // searches the sales

        public void DisplaySales()
        {
            string query = "SELECT * FROM SALESHEADERFILE";
            OleDbConnection connect = new OleDbConnection(connectionString);
            connect.Open();
            OleDbCommand command = new OleDbCommand(query, connect);
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            SalesDataGrid.DataSource = table;
            connect.Close();
        } // displays all the sales

        private void ViewItemsPurchased()
        {
            string query = "SELECT IDPART AS Description, SALEQTY AS Quantity, SALEITEMTOTAL AS Total FROM SALESDETAILFILE WHERE TRANSID = '" + SalesTransactionIDTxtBx.Text + "'";
            OleDbConnection connect = new OleDbConnection(connectionString);
            connect.Open();
            OleDbCommand command = new OleDbCommand(query, connect);
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            ItemsPurchasedGridView.DataSource = table;
            connect.Close();
        } // displays the items purchased from a specific transaction

        private void SalesDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            double totalAmount = 0;
            if (SalesDataGrid.Rows.Count > 0)
            {
                OleDbConnection connect = new OleDbConnection(connectionString);
                connect.Open();

                foreach (DataGridViewCell cell in SalesDataGrid.SelectedCells)
                {
                    DataGridViewRow row = cell.OwningRow;
                    SalesTransactionIDTxtBx.Text = row.Cells["SalesTransactionIDColumn"].Value.ToString();
                    break;
                }

                if (SalesDataGrid.SelectedCells != null)
                {
                    string query = "SELECT * FROM SALESDETAILFILE WHERE TRANSID = '" + SalesTransactionIDTxtBx.Text + "'";
                    OleDbCommand command = new OleDbCommand(query, connect);
                    OleDbDataReader reader = command.ExecuteReader();
                    ViewItemsPurchased();

                    while (reader.Read())
                    {
                        SalesTransactionReferenceTxtBx.Text = reader["TRANSREFDOC"].ToString();
                        SalesTransactionReferenceTxtBx.Text = reader["TRANSREFDOC"].ToString();
                        SalesReferenceNoTxtBx.Text = reader["REFDOCNUM"].ToString();
                        SalesPurchasedDatePicker.Text = reader["SALEDATE"].ToString();
                        SalesCustomerNameTxtBx.Text = reader["SALECUSTNAME"].ToString();
                        totalAmount += Convert.ToDouble(reader["SALEITEMTOTAL"]);
                        SalesTotalLbl.Text = string.Format("P {0:#,0.00}" , totalAmount);
                    }
                    reader.Close();
                }
                connect.Close();
            }
        } // displays the details of the transaction

        private void SalesClearDetailsBttn_Click(object sender, EventArgs e)
        {
            SalesTransactionIDTxtBx.Text = "";
            SalesTransactionReferenceTxtBx.Text = "";
            SalesReferenceNoTxtBx.Text = "";
            SalesCustomerNameTxtBx.Text = "";
            ItemsPurchasedGridView.DataSource = null;
            SalesTotalLbl.Text = "P 0.00";
        } // clears the item detail texts


        // ============================  SUPPLIERS ============================ //
        private void SearchSupplierTxtBx_TextChanged(object sender, EventArgs e)
        {
            if (SearchSupplierTxtBx.Text == "")
                DisplaySuppliers();
            else
            {
                string query = "SELECT * FROM SUPPLIERFILE WHERE SUPPNAME LIKE '%" + SearchSupplierTxtBx.Text +"%'" +
                    "OR SUPPNAME LIKE '%" + SearchSupplierTxtBx.Text + "%'" +
                    "OR SUPPADDRESS LIKE '%" + SearchSupplierTxtBx.Text + "%'" +
                    "OR SUPPCONTACT LIKE '%" + SearchSupplierTxtBx.Text + "%'";

                OleDbConnection connect = new OleDbConnection(connectionString);
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connect);

                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                SupplierDataGrid.DataSource = dataTable;
            }
        } // searches the suppliers

        public void DisplaySuppliers()
        {
            string query = "SELECT * FROM SUPPLIERFILE";
            OleDbConnection connect = new OleDbConnection(connectionString);
            connect.Open();
            OleDbCommand command = new OleDbCommand(query, connect);
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            SupplierDataGrid.DataSource = table;
            connect.Close();
        } // displays the suppliers in the data grid

        private void SupplierClearBttn_Click(object sender, EventArgs e)
        {
            SupplierIDTxtBx.Text = "";
            SupplierNameTxtBx.Text = "";
            SupplierAddressTxtBx.Text = "";
            SupplierCnctNoTxtBx.Text = "";
            SupplierIDTxtBx.Enabled = true;
        } // clears the supplier information

        private void SupplierAddUpdateBttn_Click(object sender, EventArgs e)
        {
            long contactNum;
            string query = "SELECT * FROM SUPPLIERFILE WHERE SUPPID = '" + SupplierIDTxtBx.Text + "'";
            OleDbConnection connect = new OleDbConnection(connectionString);
            connect.Open();
            OleDbCommand command = new OleDbCommand(query, connect);
            OleDbDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Close();
                if (string.IsNullOrEmpty(SupplierIDTxtBx.Text) || string.IsNullOrEmpty(SupplierNameTxtBx.Text) || string.IsNullOrEmpty(SupplierAddressTxtBx.Text) || string.IsNullOrEmpty(SupplierCnctNoTxtBx.Text))
                    MessageBox.Show("Please fill out the missing fields", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                { // UPDATE EXISTING
                    if (!long.TryParse(SupplierCnctNoTxtBx.Text, out contactNum))
                        MessageBox.Show("Contact Number must be in numbers", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        DialogResult YesNo = MessageBox.Show("Do you want to update this current Supplier?", "Update Supplier", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (YesNo == DialogResult.Yes)
                        {
                            string update = "UPDATE SUPPLIERFILE SET SUPPNAME = '" + SupplierNameTxtBx.Text + "', SUPPADDRESS = '" + SupplierAddressTxtBx.Text + "', SUPPCONTACT = '" + SupplierCnctNoTxtBx.Text + "' WHERE SUPPID = '" + SupplierIDTxtBx.Text + "'";
                            command.CommandText = update;
                            command.ExecuteNonQuery();

                            SupplierClearBttn_Click(sender, e);
                            connect.Close();
                            DisplaySuppliers();
                            MessageBox.Show("Employee has been updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            else
            { // NEW
                if (string.IsNullOrEmpty(SupplierIDTxtBx.Text) || string.IsNullOrEmpty(SupplierNameTxtBx.Text) || string.IsNullOrEmpty(SupplierAddressTxtBx.Text) || string.IsNullOrEmpty(SupplierCnctNoTxtBx.Text))
                    MessageBox.Show("Please fill out the missing fields", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (!long.TryParse(SupplierCnctNoTxtBx.Text, out contactNum))
                    MessageBox.Show("Contact Number must be in numbers", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                {
                    query = "SELECT * FROM SUPPLIERFILE";
                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connect);
                    OleDbCommandBuilder commandBuilder = new OleDbCommandBuilder(dataAdapter);
                    DataSet dataSet = new DataSet();

                    dataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                    dataAdapter.Fill(dataSet, "SUPPLIERFILE");

                    DataRow newRow = dataSet.Tables["SUPPLIERFILE"].NewRow();
                    DataRow findRow = dataSet.Tables["SUPPLIERFILE"].Rows.Find(SupplierIDTxtBx.Text);

                    if (findRow == null)
                    {
                        DialogResult YesNo = MessageBox.Show("Do you want to add this new Supplier?", "New Supplier", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (YesNo == DialogResult.Yes)
                        {
                            newRow["SUPPID"] = SupplierIDTxtBx.Text;
                            newRow["SUPPNAME"] = SupplierNameTxtBx.Text;
                            newRow["SUPPADDRESS"] = SupplierAddressTxtBx.Text;
                            newRow["SUPPCONTACT"] = SupplierCnctNoTxtBx.Text;

                            dataSet.Tables["SUPPLIERFILE"].Rows.Add(newRow);
                            dataAdapter.Update(dataSet, "SUPPLIERFILE");

                            SupplierClearBttn_Click(sender, e);
                            connect.Close();
                            DisplaySuppliers();
                            MessageBox.Show("New Employee successfully added!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                connect.Close();
                
            }
        } // adds a new supplier or updates an existing supplier

        private void SupplierDeleteBttn_Click(object sender, EventArgs e)
        {
            if (SupplierIDTxtBx.Text == "")
                MessageBox.Show("Supplier ID is not found", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                DialogResult YesNo = MessageBox.Show("Are you sure you want to delete this Supplier?", "Delete Supplier", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (YesNo == DialogResult.Yes)
                {
                    string query = "SELECT * FROM SUPPLIERFILE";
                    string delete = "DELETE FROM SUPPLIERFILE WHERE SUPPID = '" + SupplierIDTxtBx.Text + "'";

                    OleDbConnection connect = new OleDbConnection(connectionString);
                    connect.Open();

                    OleDbCommand command = new OleDbCommand(query, connect);
                    command.CommandText = delete;
                    command.ExecuteNonQuery();

                    connect.Close();
                    SupplierClearBttn_Click(sender, e);
                    DisplaySuppliers();
                    MessageBox.Show("Supplier Successfully deleted", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        } // delets the supplier

        private void SupplierDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SupplierIDTxtBx.Enabled = false;
            OleDbConnection connect = new OleDbConnection(connectionString);
            connect.Open();

            if (SupplierDataGrid.Rows.Count > 0)
            {
                foreach (DataGridViewCell cell in SupplierDataGrid.SelectedCells)
                {
                    DataGridViewRow row = cell.OwningRow;
                    SupplierIDTxtBx.Text = row.Cells["SupplierIDColumn"].Value.ToString();
                    break;
                }

                if (SupplierDataGrid.SelectedCells != null)
                {
                    string query = "SELECT * FROM SUPPLIERFILE WHERE SUPPID = '" + SupplierIDTxtBx.Text + "'";
                    
                    OleDbCommand command = new OleDbCommand(query, connect);
                    OleDbDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        SupplierNameTxtBx.Text = reader["SUPPNAME"].ToString();
                        SupplierAddressTxtBx.Text = reader["SUPPADDRESS"].ToString();
                        SupplierCnctNoTxtBx.Text = reader["SUPPCONTACT"].ToString();
                    }
                    reader.Close();
                }
            }
            connect.Close();
        } // displays the supplier details


        // ============================  TRANSACTION MANAGEMENT ============================ //
        private void RecordTransactionBttn_Click(object sender, EventArgs e)
        {
            TransactionForm transactions = new TransactionForm();
            if (UsernamePositionLbl.Text.Equals("Administrator"))
                transactions.UserIsAdmin(true);
            else
                transactions.UserIsAdmin(false);

            transactions.ShowDialog();
        } // opens a window to add a transaction

        private void TransactionRefreshBttn_Click(object sender, EventArgs e)
        {
            DisplayTransactions();
        } // reloads the datagrid to the recent transaction

        public void DisplayTransactions()
        {
            string query = "SELECT * FROM TRANSACTIONHEADERFILE";
            OleDbConnection connect = new OleDbConnection(connectionString);
            connect.Open();
            OleDbCommand command = new OleDbCommand(query, connect);
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            TransactionsDataGrid.DataSource = table;
            connect.Close();
        } // displays all transactions

        private void DisplayTransactionItems()
        {
            string query = "";

            if (TransactionTypeTxtBx.Text == "SALES")
                query = "SELECT IDPART AS Description, SALEQTY AS Quantity, SALEITEMTOTAL AS Total FROM SALESDETAILFILE WHERE TRANSID = '" + TransactionIDTxtBx.Text + "'";
            else
                query = "SELECT BUYITEM AS Description, BUYQTY AS Quantity, BUYITEMTOTAL AS Total FROM SUPPURCHASEDETAILFILE WHERE TRANSID = '" + TransactionIDTxtBx.Text + "'";

            OleDbConnection connect = new OleDbConnection(connectionString);
            connect.Open();
            OleDbCommand command = new OleDbCommand(query, connect);
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            TransactionItemsDataGrid.DataSource = table;
            connect.Close();
        } // displays the items from the transaction

        private void SearchTransactionsTxtBx_TextChanged(object sender, EventArgs e)
        {
            if (SearchTransactionsTxtBx.Text == "")
                DisplayTransactions();
            else
            {
                string query = "SELECT * FROM TRANSACTIONHEADERFILE WHERE TRANSID LIKE '%" + SearchTransactionsTxtBx.Text + "%'" +
                    "OR REFDOCNUM LIKE '%" + SearchTransactionsTxtBx.Text + "%'" +
                    "OR TRANSTYPE LIKE '%" + SearchTransactionsTxtBx.Text + "%'" +
                    "OR SUPPCUSTNAME LIKE '%" + SearchTransactionsTxtBx.Text + "%'";

                OleDbConnection connect = new OleDbConnection(connectionString);
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connect);

                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                TransactionsDataGrid.DataSource = dataTable;
            }
        } // searches the transactions

        private void TransactionsDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            OleDbConnection connect = new OleDbConnection(connectionString);
            connect.Open();

            if (TransactionsDataGrid.Rows.Count > 0)
            {
                foreach (DataGridViewCell cell in TransactionsDataGrid.SelectedCells)
                {
                    DataGridViewRow row = cell.OwningRow;
                    TransactionIDTxtBx.Text = row.Cells["TransactionIDColumn"].Value.ToString();
                    TransactionTypeTxtBx.Text = row.Cells["TransactionTypeColumn"].Value.ToString();
                    break;
                }

                DisplayTransactionItems();

                if (TransactionsDataGrid.SelectedCells != null)
                {
                    string query = "SELECT * FROM TRANSACTIONHEADERFILE WHERE TRANSID = '" + TransactionIDTxtBx.Text + "'";

                    OleDbCommand command = new OleDbCommand(query, connect);
                    OleDbDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        TransactionRefNoTxtBx.Text = reader["REFDOCNUM"].ToString();
                        TransactionDate.Text = reader["TRANSDATE"].ToString();
                        TransactionTotalPriceLbl.Text = string.Format("P {0:#,0.00}", reader["TRANSTOTAL"]) ;
                    }
                    reader.Close();
                }
                DisplayTransactionItems();
            }
            connect.Close();
        } // displays the details of the specified transaction

        private void ClearTransactionDetailsBttn_Click(object sender, EventArgs e)
        {
            TransactionIDTxtBx.Text = "";
            TransactionTypeTxtBx.Text = "";
            TransactionRefNoTxtBx.Text = "";
            TransactionTotalPriceLbl.Text = "P 0.00";
            TransactionItemsDataGrid.DataSource = null;
        } // clears the transaction detail texts


        // ============================  GENERATE REPORTS ============================ //

        private void DisplayReport()
        {
            string query = GetQuery();
            OleDbConnection connect = new OleDbConnection(connectionString);
            connect.Open();
            OleDbCommand command;
            OleDbDataAdapter dataAdapter;
            DataTable table;

            command = new OleDbCommand(query, connect);
            dataAdapter = new OleDbDataAdapter(command);
            table = new DataTable();
            dataAdapter.Fill(table);
            GenerateReportsDataGrid.DataSource = table;
            connect.Close();
            FinancialOverview();
        } // displays the transaction report

        private void ReportListSuppCust()
        {
            ReportFindSuppCustCmbBx.Items.Clear();
            string query = "SELECT DISTINCT SUPPCUSTNAME FROM TRANSACTIONHEADERFILE";
            OleDbConnection connect = new OleDbConnection(connectionString);
            connect.Open();
            OleDbCommand command = new OleDbCommand(query, connect);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReportFindSuppCustCmbBx.Items.Add(reader["SUPPCUSTNAME"].ToString());
            }

            reader.Close();
            connect.Close();
        } // lists down the supplier and customer from the sales

        private string GetQuery()
        {
            string query = "";

            if (ReportAllTransactionRadioBttn.Checked)
                query = "SELECT * FROM TRANSACTIONHEADERFILE";

            else if (ReportAllSalesTransactionRadioBttn.Checked)
                query = "SELECT * FROM TRANSACTIONHEADERFILE WHERE TRANSTYPE = 'SALES'";

            else if (ReportAllInventoryPurchaseRadioBttn.Checked)
                query = "SELECT * FROM TRANSACTIONHEADERFILE WHERE TRANSTYPE = 'INVENTORY PURCHASE'";

            if (ReportDateChkBx.Checked)
            {
                if (ReportAllTransactionRadioBttn.Checked) // ALL TRANSACTION
                    query += " WHERE TRANSDATE BETWEEN #" + ReportStartDate.Value.Date + "# AND #" + ReportEndDate.Value.Date + "#";
                else // SALES OR INV PURCHASE
                    query += " AND TRANSDATE BETWEEN #" + ReportStartDate.Value.Date + "# AND #" + ReportEndDate.Value.Date + "#";
            }

            if (ReportFindCustomerSupplierChkBx.Checked)
            {
                if (ReportDateChkBx.Checked)
                    query += " AND SUPPCUSTNAME = '" + ReportFindSuppCustCmbBx.Text + "'";
                else
                {
                    if (ReportAllTransactionRadioBttn.Checked)
                        query += " WHERE SUPPCUSTNAME = '" + ReportFindSuppCustCmbBx.Text + "'";
                    else
                        query += " AND SUPPCUSTNAME = '" + ReportFindSuppCustCmbBx.Text + "'";
                }
            }
            return query;
        } // the overall query text from the search

        private void FinancialOverview()
        {
            decimal totalCostGoods = 0, totalRevenue = 0;
            string query;
            OleDbConnection connect = new OleDbConnection(connectionString);
            connect.Open();
            OleDbCommand command;

            if (ReportAllTransactionRadioBttn.Checked)
            {
                foreach (DataGridViewRow eachRow in GenerateReportsDataGrid.Rows)
                {
                    if (eachRow.Cells["ReportTransTypeColumn"].Value.ToString().Equals("SALES"))
                    {
                        totalRevenue += Convert.ToDecimal(eachRow.Cells["ReportAmountColumn"].Value);
                        query = "SELECT SUM(PARTCOSTTOTAL) FROM SALESDETAILFILE WHERE TRANSID = '" + eachRow.Cells["ReportTransactionIDColumn"].Value + "'";
                        command = new OleDbCommand(query, connect);
                        totalCostGoods += Convert.ToDecimal(command.ExecuteScalar());
                    }
                    else
                    {
                        totalCostGoods += Convert.ToDecimal(eachRow.Cells["ReportAmountColumn"].Value);
                    }
                }

                ReportTotalRevenueLbl.Text = string.Format("{0:#,0.00}", totalRevenue);
                ReportTotalCostLbl.Text = string.Format("{0:#,0.00}", totalCostGoods);
                ReportGrossProfitLbl.Text = string.Format("{0:#,0.00}", totalRevenue - totalCostGoods);
            }
            else if (ReportAllSalesTransactionRadioBttn.Checked)
            {
                foreach (DataGridViewRow eachRow in GenerateReportsDataGrid.Rows)
                {
                    totalRevenue += Convert.ToDecimal(eachRow.Cells["ReportAmountColumn"].Value);
                }

                ReportTotalRevenueLbl.Text = string.Format("{0:#,0.00}", totalRevenue);
                ReportTotalCostLbl.Text = "N/A";
                ReportGrossProfitLbl.Text = "N/A";
            }
            else if (ReportAllInventoryPurchaseRadioBttn.Checked)
            {
                foreach (DataGridViewRow eachRow in GenerateReportsDataGrid.Rows)
                {
                    totalCostGoods += Convert.ToDecimal(eachRow.Cells["ReportAmountColumn"].Value);
                }

                ReportTotalRevenueLbl.Text = "N/A";
                ReportTotalCostLbl.Text = string.Format("{0:#,0.00}", totalCostGoods);
                ReportGrossProfitLbl.Text = "N/A";
            }
            

            
        } // displays the revenues and profits

        private void ReportFilterBttn_Click(object sender, EventArgs e)
        {
            DisplayReport();
        } // filters the search

        private void ReportDateChkBx_CheckedChanged(object sender, EventArgs e)
        {
            if (ReportDateChkBx.Checked)
            {
                ReportStartDate.Enabled = true;
                ReportEndDate.Enabled = true;
            }
            else
            {
                ReportStartDate.Enabled = false;
                ReportEndDate.Enabled = false;
            }
        } // enables or disables the date checkbox for filtering

        private void ReportFindCustomerSupplierChkBx_CheckedChanged(object sender, EventArgs e)
        {
            if (ReportFindCustomerSupplierChkBx.Checked)
            {
                ReportFindSuppCustCmbBx.Enabled = true;
                ReportListSuppCust();
            }
            else
            {
                ReportFindSuppCustCmbBx.Enabled = false;
                ReportFindSuppCustCmbBx.Items.Clear();
            }
        } // enables or disables the customer/supplier combobox for filtering

        private void ReportClearFilterBttn_Click(object sender, EventArgs e)
        {
            ReportAllTransactionRadioBttn.Checked = true;
            ReportAllSalesTransactionRadioBttn.Checked = false;
            ReportAllInventoryPurchaseRadioBttn.Checked = false;
            ReportDateChkBx.Checked = false;
            ReportFindCustomerSupplierChkBx.Checked = false;
            ReportFindSuppCustCmbBx.Items.Clear();
            DisplayReport();
        } // clears the search field
    }
}
