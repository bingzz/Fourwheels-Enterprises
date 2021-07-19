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
using System.Globalization;

namespace FWE_ISMS
{
    public partial class TransactionForm : Form
    {
        string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\Documents\Visual Studio 2019\Projects\FWE ISMS\InventorySystemDB v3.mdb";

        public TransactionForm()
        {
            InitializeComponent();
            EmptyPanel.Show();
            InventoryPurchasePanel.Hide();
            SalesPanel.Hide();
        }


        // ============================  INTERFACE ============================ //
        private void TransactionTypeCmbBx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TransactionTypeCmbBx.SelectedItem != null)
            {
                if (TransactionTypeCmbBx.SelectedItem.ToString() == "SALES")
                {
                    EmptyPanel.Hide();
                    InventoryPurchasePanel.Hide();
                    SalesPanel.Show();
                    LoadSales();
                    LoadPartSection();
                }
                else if (TransactionTypeCmbBx.SelectedItem.ToString() == "INVENTORY PURCHASE")
                {
                    EmptyPanel.Hide();
                    InventoryPurchasePanel.Show();
                    SalesPanel.Hide();
                    LoadInventoryItems();
                    ListSuppliers();
                }
            }
        } // selects the type of transactions and displays in the interface

        private int GenerateNumber()
        {
            Random r = new Random();
            return r.Next((9999 - 1000) + 1) + 1;
        } // random number generator for transaction number

        public void UserIsAdmin(bool admin)
        {
            if (!admin)
            {
                TransactionTypeCmbBx.Items.Clear();
                TransactionTypeCmbBx.Items.Add("SALES");
            }
        }


        // ============================  INVENTORY PURCHASE ============================ //

        private void InventorySearchItemTxtBx_TextChanged(object sender, EventArgs e)
        {
            if (InventorySearchItemTxtBx.Text == "")
                LoadInventoryItems();
            else
            {
                string query = "SELECT DISTINCT PARTDESC FROM PARTSDETAILFILE WHERE PARTDESC LIKE '%" + InventorySearchItemTxtBx.Text + "%'";
                OleDbConnection connect = new OleDbConnection(connectionString);
                connect.Open();
                DataSet dataSet = new DataSet();
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connect);
                dataAdapter.Fill(dataSet);
                InventoryItemLstBx.DisplayMember = "PARTDESC";
                InventoryItemLstBx.ValueMember = "PARTDESC";
                InventoryItemLstBx.DataSource = dataSet.Tables[0];
                connect.Close();
            }
        } // searches the available parts

        private void InventoryItemLstBx_MouseClick(object sender, MouseEventArgs e)
        {
            ClearInventoryPurchaseDetails();
            string query = "SELECT * FROM PARTSDETAILFILE";
            OleDbConnection connect = new OleDbConnection(connectionString);
            connect.Open();
            OleDbCommand command = new OleDbCommand(query, connect);
            OleDbDataReader reader = command.ExecuteReader();

            if (InventoryItemLstBx.SelectedItem != null)
            {
                DataRowView rowView = (DataRowView)InventoryItemLstBx.SelectedItem;
                string value = rowView["PARTDESC"].ToString();

                while (reader.Read())
                {
                    if (reader["PARTDESC"].ToString().Equals(value))
                    {
                        InventoryItemIDLbl.Text = reader["IDPART"].ToString();
                        break;
                    }
                }
                reader.Close();
            }
            connect.Close();
        } // displays the details of the part

        private void InventoryUnitPriceTxtBx_TextChanged(object sender, EventArgs e)
        {
            int parsedInt;
            if (InventoryQuantityTxtBx.Text != "" && InventoryUnitPriceTxtBx.Text != "")
            {
                if (int.TryParse(InventoryQuantityTxtBx.Text, out parsedInt))
                {
                    double total = 0;
                    total = ((Convert.ToDouble(InventoryQuantityTxtBx.Text)) * Convert.ToDouble(InventoryUnitPriceTxtBx.Text));
                    InventoryTotalItemCostLbl.Text = string.Format("{0:#,0.00}", total);
                }
            }
            else
                InventoryTotalItemCostLbl.Text = "0.00";
        } // displays the total unit price of the part

        private void InventoryQuantityTxtBx_TextChanged(object sender, EventArgs e)
        {
            int parsedInt;
            if (InventoryQuantityTxtBx.Text != "" && InventoryUnitPriceTxtBx.Text != "")
            {
                if (int.TryParse(InventoryQuantityTxtBx.Text, out parsedInt))
                {
                    double total = 0;
                    total = ((Convert.ToDouble(InventoryQuantityTxtBx.Text)) * Convert.ToDouble(InventoryUnitPriceTxtBx.Text));
                    InventoryTotalItemCostLbl.Text = string.Format("{0:#,0.00}", total);
                }
            }
            else
                InventoryTotalItemCostLbl.Text = "0.00";
        } // enters the quantity and displays the amount of the part

        private void LoadInventoryItems()
        {
            string query = "SELECT DISTINCT PARTDESC FROM PARTSDETAILFILE ORDER BY PARTDESC ASC";
            OleDbConnection connect = new OleDbConnection(connectionString);
            connect.Open();
            DataSet dataSet = new DataSet();
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connect);
            dataAdapter.Fill(dataSet);
            InventoryItemLstBx.DisplayMember = "PARTDESC";
            InventoryItemLstBx.ValueMember = "PARTDESC";
            InventoryItemLstBx.DataSource = dataSet.Tables[0];
            connect.Close();
        } // lists all the parts

        private void ClearInventoryPurchaseDetails()
        {
            InventoryItemIDLbl.Text = "";
            InventoryQuantityAvailableLbl.Text = "";
            InventoryUnitPriceTxtBx.Text = "";
            InventoryQuantityTxtBx.Text = "";
            InventoryTotalItemCostLbl.Text = "0.00";
            InventorySearchItemTxtBx.Text = "";
        } // clears the part details

        private void ListSuppliers()
        {
            InventorySupplierCmbBx.Items.Clear();
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
                    InventorySupplierCmbBx.Items.Add(reader["SUPPNAME"]);
                }
            }

            reader.Close();
            connect.Close();
        } // lists all the suppliers 

        int invPurchCounter = 0;

        private void InventoryAddToPurchasesBttn_Click(object sender, EventArgs e)
        {
            int parsedInt;
            double parsedDouble;

            if (InventoryQuantityTxtBx.Text == "")
                MessageBox.Show("Please Enter quantity", "Enter Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (!int.TryParse(InventoryQuantityTxtBx.Text, out parsedInt) || !double.TryParse(InventoryUnitPriceTxtBx.Text, out parsedDouble))
                MessageBox.Show("Must contain numbers", "Invalid value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (InventorySupplierCmbBx.SelectedItem == null)
                MessageBox.Show("Please enter a Supplier", "No Supplier", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                DataRowView rowView = (DataRowView)InventoryItemLstBx.SelectedItem;
                string value = rowView["PARTDESC"].ToString();

                string query = "SELECT * FROM PARTSDETAILFILE WHERE PARTDESC = '" + value + "'";
                OleDbConnection connect = new OleDbConnection(connectionString);
                connect.Open();
                OleDbCommand command = new OleDbCommand(query, connect);
                OleDbDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (reader["PARTDESC"].ToString().Equals(value))
                        {
                            if (InventoryUnique())
                            {
                                InventoryPurchaseDataGrid.Rows.Insert(invPurchCounter);
                                InventoryPurchaseDataGrid.Rows[invPurchCounter].Cells["InventoryItemIDColumn"].Value = reader["IDPART"].ToString();
                                InventoryPurchaseDataGrid.Rows[invPurchCounter].Cells["InventoryItemDescriptionColumn"].Value = reader["PARTDESC"].ToString();
                                InventoryPurchaseDataGrid.Rows[invPurchCounter].Cells["InventorySupplierColumn"].Value = InventorySupplierCmbBx.SelectedItem;
                                InventoryPurchaseDataGrid.Rows[invPurchCounter].Cells["InventoryItemQuantityPurchasedColumn"].Value = Convert.ToInt32(InventoryQuantityTxtBx.Text);
                                InventoryPurchaseDataGrid.Rows[invPurchCounter].Cells["InventoryUnitPriceColumn"].Value = Convert.ToInt32(InventoryUnitPriceTxtBx.Text);
                                InventoryPurchaseDataGrid.Rows[invPurchCounter].Cells["InventoryItemTotalColumn"].Value = InventoryTotalItemCostLbl.Text;
                                invPurchCounter++;
                                break;
                            }
                            else
                            {
                                foreach (DataGridViewRow row in InventoryPurchaseDataGrid.Rows)
                                {
                                    if (row.Cells["InventoryItemDescriptionColumn"].Value.ToString().Equals(value))
                                    {
                                        row.Cells["InventoryItemQuantityPurchasedColumn"].Value = Convert.ToInt32(InventoryQuantityTxtBx.Text);
                                        row.Cells["InventoryUnitPriceColumn"].Value = Convert.ToDecimal(InventoryUnitPriceTxtBx.Text);
                                        row.Cells["InventoryItemTotalColumn"].Value = InventoryTotalItemCostLbl.Text;
                                    }
                                }
                            }
                        }
                    }
                }
                InventoryPriceTotal();
            }
        } // adds the parts to the cart

        private void InventoryItemIDLbl_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT * FROM PARTSHEADERFILE WHERE IDPART = '" + InventoryItemIDLbl.Text + "'";
            OleDbConnection connect = new OleDbConnection(connectionString);
            connect.Open();
            OleDbCommand command = new OleDbCommand(query, connect);
            OleDbDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    InventoryQuantityAvailableLbl.Text = reader["TOTALQTY"].ToString();
                }
            }
            reader.Close();
            connect.Close();
        } // displays the part ID number

        private void InventoryPriceTotal()
        {
            decimal sum = 0;

            foreach (DataGridViewRow row in InventoryPurchaseDataGrid.Rows)
            {
                sum += decimal.Parse(row.Cells["InventoryItemTotalColumn"].Value.ToString(), NumberStyles.AllowCurrencySymbol | NumberStyles.Number);
            }
            InventoryPurchaseTotalAmountLbl.Text = string.Format("{0:#,0.00}", sum);
        } // displays the overall amount from the cart

        private bool InventoryUnique()
        {
            DataRowView rowView = (DataRowView)InventoryItemLstBx.SelectedItem;
            string value = rowView["PARTDESC"].ToString();

            if (InventoryPurchaseDataGrid.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in InventoryPurchaseDataGrid.Rows)
                {
                    if (row.Cells["InventoryItemDescriptionColumn"].Value.Equals(value))
                    {
                        return false;
                    }
                }
            }
            return true;
        } // checks if the part exists in the cart

        private void InventoryRemoveItemBttn_Click(object sender, EventArgs e)
        {
            if (InventoryPurchaseDataGrid.Rows.Count != 0)
            {
                DialogResult YesNo = MessageBox.Show("Do you want to delete this Item?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (YesNo == DialogResult.Yes)
                {
                    foreach (DataGridViewCell cell in InventoryPurchaseDataGrid.SelectedCells)
                    {
                        InventoryPurchaseDataGrid.Rows.RemoveAt(cell.RowIndex);
                        invPurchCounter--;
                        InventoryPriceTotal();
                        break;
                    }
                }
            }
            else
                MessageBox.Show("Please select an item to remove", "No item in cart", MessageBoxButtons.OK, MessageBoxIcon.Information);
        } // removes the part from the cart

        private void InventoryClearItemsBttn_Click(object sender, EventArgs e)
        {
            DialogResult YesNo = MessageBox.Show("Are you sure you want clear your purchases?", "Clear Purchases", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (YesNo == DialogResult.Yes)
            {
                invPurchCounter = 0;
                InventoryPurchaseDataGrid.Rows.Clear();
                InventoryRefDocNumTxtBx.Text = "";
                InventoryTransRefDocNumTxtBx.Text = "";
                InventorySupplierCmbBx.Enabled = true;
                InventorySupplierCmbBx.Text = "";
                InventoryPurchaseTotalAmountLbl.Text = "0.00";
            }
        } // removes all parts from the cart

        private void InventorySupplierCmbBx_SelectionChangeCommitted(object sender, EventArgs e)
        {
            InventorySupplierCmbBx.Enabled = false;
        } // selects the type of supplier

        private void InventoryAddTransactionBttn_Click(object sender, EventArgs e)
        {
            string query, insert;
            if (InventoryPurchaseDataGrid.Rows.Count != 0)
            {
                if (string.IsNullOrEmpty(InventoryTransRefDocNumTxtBx.Text) || string.IsNullOrEmpty(InventoryRefDocNumTxtBx.Text))
                    MessageBox.Show("Please enter a Reference Number", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (InventorySupplierCmbBx.SelectedItem == null)
                    MessageBox.Show("Please enter a Supplier", "No Supplier", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    DialogResult YesNo = MessageBox.Show("Do you want to complete the Transaction?", "Add Transaction", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (YesNo == DialogResult.Yes)
                    {
                        string transactNum;

                        OleDbConnection connect = new OleDbConnection(connectionString);
                        connect.Open();
                        OleDbDataReader reader;
                        OleDbCommand command;

                        do
                        {
                            transactNum = "TR" + GenerateNumber();
                            query = "SELECT * FROM TRANSACTIONHEADERFILE WHERE TRANSID = '" + transactNum + "'";
                            command = new OleDbCommand(query, connect);
                            reader = command.ExecuteReader();
                        } while (reader.HasRows);
                        reader.Close();

                        decimal newSellPrice = 0, unitPrice = 0, maxSellPrice = 0;
                        string maxSellPriceQuery, update;

                        for (int counter = 0; counter < invPurchCounter; counter++)
                        {
                            unitPrice = Convert.ToDecimal(InventoryPurchaseDataGrid.Rows[counter].Cells["InventoryUnitPriceColumn"].Value.ToString());
                            newSellPrice = (unitPrice * (decimal).3) + unitPrice;
                            maxSellPriceQuery = "SELECT MAX(SELLPRICE) FROM PARTSDETAILFILE WHERE IDPART = '" + InventoryPurchaseDataGrid.Rows[counter].Cells["InventoryItemIDColumn"].Value.ToString() + "'";

                            command = new OleDbCommand(maxSellPriceQuery, connect);
                            maxSellPrice = Convert.ToDecimal(command.ExecuteScalar());
                            
                            if (newSellPrice > maxSellPrice)
                            {
                                update = "UPDATE PARTSDETAILFILE SET SELLPRICE = " + newSellPrice + " WHERE IDPART = '" + InventoryPurchaseDataGrid.Rows[counter].Cells["InventoryItemIDColumn"].Value.ToString() + "'";
                                command = new OleDbCommand(update, connect);
                                command.ExecuteNonQuery();
                            }
                        }

                        foreach (DataGridViewRow eachRow in InventoryPurchaseDataGrid.Rows)
                        {
                            string PARTNUM = "", PARTSECTION = "", VEHMFG = "", VEHMODEL = "", VEHMODELYRSTART = "", VEHMODELYREND = "";
                            decimal partCost = 0;

                            // SUPPLIER PURCHASE DETAIL
                            insert = "INSERT INTO SUPPURCHASEDETAILFILE VALUES ('" + transactNum + "', '" + InventoryTransRefDocNumTxtBx.Text + "', '" + InventoryRefDocNumTxtBx.Text + "', '" + InventoryDatePicker.Value.Date + "', '" + eachRow.Cells["InventorySupplierColumn"].Value + "', '" + eachRow.Cells["InventoryItemIDColumn"].Value + "', " + eachRow.Cells["InventoryItemQuantityPurchasedColumn"].Value + ", '" + eachRow.Cells["InventoryItemTotalColumn"].Value + "')";
                            command = new OleDbCommand(insert, connect);
                            command.ExecuteNonQuery();

                            // PARTS DETAIL
                            query = "SELECT DISTINCT IDPART, PARTNUM, PARTSECTION, VEHMFG, VEHMODEL, VEHMODELYRSTART, VEHMODELYREND, PARTCOST FROM PARTSDETAILFILE WHERE IDPART = '" + eachRow.Cells["InventoryItemIDColumn"].Value + "'";
                            command = new OleDbCommand(query, connect);
                            reader = command.ExecuteReader();

                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    PARTNUM = reader["PARTNUM"].ToString();
                                    PARTSECTION = reader["PARTSECTION"].ToString();
                                    VEHMFG = reader["VEHMFG"].ToString();
                                    VEHMODELYRSTART = reader["VEHMODELYRSTART"].ToString();
                                    VEHMODELYREND = reader["VEHMODELYREND"].ToString();
                                    VEHMODEL = reader["VEHMODEL"].ToString();
                                    partCost = Convert.ToDecimal(reader["PARTCOST"].ToString());
                                }

                                if (Convert.ToDecimal(eachRow.Cells["InventoryUnitPriceColumn"].Value.ToString()) == partCost)
                                {
                                    update = "UPDATE PARTSDETAILFILE SET PARTQTY = PARTQTY + " + eachRow.Cells["InventoryItemQuantityPurchasedColumn"].Value + " WHERE IDPART = '" + eachRow.Cells["InventoryItemIDColumn"].Value + "' AND PARTCOST = " + partCost + "";
                                    command = new OleDbCommand(update, connect);
                                    command.ExecuteNonQuery();
                                }
                                else
                                {
                                    unitPrice = Convert.ToDecimal(eachRow.Cells["InventoryUnitPriceColumn"].Value.ToString());
                                    newSellPrice = (unitPrice * (decimal).3) + unitPrice;

                                    insert = "INSERT INTO PARTSDETAILFILE VALUES ('" + eachRow.Cells["InventoryItemIDColumn"].Value + "', " + eachRow.Cells["InventoryItemQuantityPurchasedColumn"].Value + ", '" + PARTNUM + "', '" + eachRow.Cells["InventoryItemDescriptionColumn"].Value + "', '" + PARTSECTION + "', '" + VEHMFG + "', '" + VEHMODEL + "', " + VEHMODELYRSTART + ", " + VEHMODELYREND + ", '" + eachRow.Cells["InventoryUnitPriceColumn"].Value.ToString() + "', '" + newSellPrice + "', '" + InventorySupplierCmbBx.SelectedItem.ToString() + "')";
                                    command = new OleDbCommand(insert, connect);
                                    command.ExecuteNonQuery();
                                }
                            }
                            reader.Close();

                            // PARTS HEADER
                            update = "UPDATE PARTSHEADERFILE SET TOTALQTY = TOTALQTY + " + eachRow.Cells["InventoryItemQuantityPurchasedColumn"].Value + " WHERE IDPART = '" + eachRow.Cells["InventoryItemIDColumn"].Value + "'";
                            command = new OleDbCommand(update, connect);
                            command.ExecuteNonQuery();
                        }

                        // SUPPLIER PURCHASE HEADER
                        insert = "INSERT INTO SUPPURCHASEHEADERFILE VALUES ('" + transactNum + "', '" + InventoryRefDocNumTxtBx.Text + "', '" + InventorySupplierCmbBx.SelectedItem.ToString() + "', '" + InventoryDatePicker.Value.Date + "', " + Convert.ToDecimal(InventoryPurchaseTotalAmountLbl.Text) + ")";
                        command = new OleDbCommand(insert, connect);
                        command.ExecuteNonQuery();

                        
                        // TRANSACTIONS HEADER
                        insert = "INSERT INTO TRANSACTIONHEADERFILE VALUES ('" + transactNum + "', '" + InventoryRefDocNumTxtBx.Text + "', '" + InventoryDatePicker.Value.Date + "', 'INVENTORY PURCHASE', '" + InventorySupplierCmbBx.Text + "', '" + InventoryPurchaseTotalAmountLbl.Text + "')";
                        command = new OleDbCommand(insert, connect);
                        command.ExecuteNonQuery();

                        connect.Close();
                        ClearInventoryPurchaseDetails();
                        InventoryTransRefDocNumTxtBx.Text = "";
                        InventoryRefDocNumTxtBx.Text = "";
                        InventoryPurchaseDataGrid.Rows.Clear();
                        
                        invPurchCounter = 0;
                        InventoryPurchaseTotalAmountLbl.Text = "0.00";
                        InventorySupplierCmbBx.Enabled = true;
                        InventorySupplierCmbBx.Text = "";
                        MessageBox.Show("Transaction Complete", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
                MessageBox.Show("There is no Items in your cart, please add items", "Missing Items", MessageBoxButtons.OK, MessageBoxIcon.Error);
        } // records the transaction to the database


        // ============================  SALES PURCHASE ============================ //

        
        private void LoadSales()
        {
            string query = "SELECT DISTINCT PARTDESC FROM PARTSDETAILFILE ORDER BY PARTDESC ASC";
            OleDbConnection connect = new OleDbConnection(connectionString);
            connect.Open();
            DataSet dataSet = new DataSet();
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connect);
            dataAdapter.Fill(dataSet);
            SalesLstBx.DisplayMember = "PARTDESC";
            SalesLstBx.ValueMember = "PARTDESC";
            SalesLstBx.DataSource = dataSet.Tables[0];
            connect.Close();
        } // lists all parts for sale

        private void LoadPartSection()
        {
            SalesPartSectionCmbBx.Items.Clear();
            string query = "SELECT DISTINCT PARTTYPE FROM PARTSHEADERFILE";
            OleDbConnection connect = new OleDbConnection(connectionString);
            connect.Open();
            OleDbCommand command = new OleDbCommand(query, connect);
            OleDbDataReader reader = command.ExecuteReader();

            SalesPartSectionCmbBx.Items.Add("");
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    SalesPartSectionCmbBx.Items.Add(reader["PARTTYPE"].ToString());
                }
            }
            reader.Close();
            connect.Close();
        } // lists the car parts in the box

        private void SalesPartSectionCmbBx_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (SalesPartSectionCmbBx.SelectedItem.Equals(""))
            {
                SalesVehicleManufacturerCmbBx.Enabled = false;
                SalesVehicleManufacturerCmbBx.Items.Clear();
                SalesVehicleModelCmbBx.Enabled = false;
                SalesVehicleModelCmbBx.Items.Clear();
                LoadSales();
            }
            else
            {
                SalesVehicleManufacturerCmbBx.Enabled = true;
                SalesVehicleManufacturerCmbBx.Items.Clear();
                ListPartSection();
            }
        } // once selected, the vehicle manufacturer loads

        private void ListPartSection()
        {
            string query = "SELECT DISTINCT VEHMFG FROM PARTSDETAILFILE WHERE PARTSECTION = '" + SalesPartSectionCmbBx.SelectedItem.ToString() + "'";
            OleDbConnection connect = new OleDbConnection(connectionString);
            connect.Open();
            OleDbCommand command = new OleDbCommand(query, connect);
            OleDbDataReader reader = command.ExecuteReader();

            SalesVehicleManufacturerCmbBx.Items.Clear();
            SalesVehicleManufacturerCmbBx.Items.Add("");
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    SalesVehicleManufacturerCmbBx.Items.Add(reader["VEHMFG"].ToString());
                }
            }

            query = "SELECT DISTINCT PARTDESC FROM PARTSDETAILFILE WHERE PARTSECTION = '" + SalesPartSectionCmbBx.SelectedItem.ToString() + "'";
            command = new OleDbCommand(query, connect);

            DataSet dataSet = new DataSet();
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connect);
            dataAdapter.Fill(dataSet);
            SalesLstBx.DisplayMember = "PARTDESC";
            SalesLstBx.ValueMember = "PARTDESC";
            SalesLstBx.DataSource = dataSet.Tables[0];

            connect.Close();
        } // lists the car manufacturer in the box

        private void SalesVehicleManufacturerCmbBx_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (SalesVehicleManufacturerCmbBx.SelectedItem.Equals(""))
            {
                SalesVehicleModelCmbBx.Enabled = false;
                SalesVehicleModelCmbBx.Items.Clear();
                ListPartSection();
            }
            else
            {
                SalesVehicleModelCmbBx.Enabled = true;
                SalesVehicleModelCmbBx.Items.Clear();
                ListPartSectionAndManufacturer();
            }
        } // once selected, the vehicle model loads 

        private void ListPartSectionAndManufacturer()
        {
            string query = "SELECT DISTINCT VEHMODEL FROM PARTSDETAILFILE WHERE PARTSECTION = '" + SalesPartSectionCmbBx.SelectedItem + "' AND VEHMFG = '" + SalesVehicleManufacturerCmbBx.SelectedItem + "'";
            OleDbConnection connect = new OleDbConnection(connectionString);
            connect.Open();
            OleDbCommand command = new OleDbCommand(query, connect);
            OleDbDataReader reader = command.ExecuteReader();

            SalesVehicleModelCmbBx.Items.Add("");
            while (reader.Read())
            {
                SalesVehicleModelCmbBx.Items.Add(reader["VEHMODEL"].ToString());
            }

            query = "SELECT DISTINCT PARTDESC FROM PARTSDETAILFILE WHERE PARTSECTION = '" + SalesPartSectionCmbBx.SelectedItem.ToString() + "' AND VEHMFG = '" + SalesVehicleManufacturerCmbBx.SelectedItem + "'";
            command = new OleDbCommand(query, connect);

            DataSet dataSet = new DataSet();
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connect);
            dataAdapter.Fill(dataSet);
            SalesLstBx.DisplayMember = "PARTDESC";
            SalesLstBx.ValueMember = "PARTDESC";
            SalesLstBx.DataSource = dataSet.Tables[0];

            connect.Close();
        } // lists the car model in the box

        private void SalesVehicleModelCmbBx_SelectedValueChanged(object sender, EventArgs e)
        {
            
            if (SalesVehicleModelCmbBx.SelectedItem.Equals(""))
            {
                SalesVehicleModelCmbBx.Items.Clear();
                ListPartSectionAndManufacturer();
            }
            else
            {
                ListPartSectionManufacturerModel();
            }
        } // once selected, the specific part displays

        private void ListPartSectionManufacturerModel()
        {
            string query = "SELECT DISTINCT PARTDESC FROM PARTSDETAILFILE WHERE PARTSECTION = '" + SalesPartSectionCmbBx.SelectedItem + "' AND VEHMFG = '" + SalesVehicleManufacturerCmbBx.SelectedItem + "' AND VEHMODEL = '" + SalesVehicleModelCmbBx.SelectedItem + "'";
            OleDbConnection connect = new OleDbConnection(connectionString);
            connect.Open();
            OleDbCommand command = new OleDbCommand(query, connect);

            DataSet dataSet = new DataSet();
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connect);
            dataAdapter.Fill(dataSet);
            SalesLstBx.DisplayMember = "PARTDESC";
            SalesLstBx.ValueMember = "PARTDESC";
            SalesLstBx.DataSource = dataSet.Tables[0];
        } // lists the specific part

        private void ClearSalesDetails()
        {
            SalesItemIdLbl.Text = "";
            SalesItemQtyLbl.Text = "";
            SalesUnitPriceTxtBx.Text = "";
            SalesItemQtyPurchasedCmbBx.SelectedItem = null;
            SalesTotalItemCostLbl.Text = "0.00";
        } // clears the part details

        private bool SalesUnique()
        {
            DataRowView rowView = (DataRowView)SalesLstBx.SelectedItem;
            string value = rowView["PARTDESC"].ToString();

            if (SalesDataGrid.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in SalesDataGrid.Rows)
                {
                    if (row.Cells["SalesItemDescriptionColumn"].Value.Equals(value))
                    {
                        return false;
                    }
                }
            }
            return true;
        } // checks if the part exists in the cart

        private void SalesPriceTotal()
        {
            decimal sum = 0;

            foreach (DataGridViewRow row in SalesDataGrid.Rows)
            {
                sum += decimal.Parse(row.Cells["SalesItemTotalColumn"].Value.ToString(), NumberStyles.AllowCurrencySymbol | NumberStyles.Number);
            }
            SalesTotalAmtLbl.Text = string.Format("{0:#,0.00}", sum);
            SalesChangeLbl.Text = string.Format("{0:#,0.00}", sum);
        } // displays the total price from the cart

        private void SalesLstBx_MouseClick(object sender, MouseEventArgs e)
        {
            ClearSalesDetails();
            string query = "SELECT * FROM PARTSDETAILFILE";
            OleDbConnection connect = new OleDbConnection(connectionString);
            connect.Open();
            OleDbCommand command = new OleDbCommand(query, connect);
            OleDbDataReader reader = command.ExecuteReader();

            if (SalesLstBx.SelectedItem != null)
            {
                DataRowView rowView = (DataRowView)SalesLstBx.SelectedItem;
                string value = rowView["PARTDESC"].ToString();

                while (reader.Read())
                {
                    if (reader["PARTDESC"].ToString().Equals(value))
                    {
                        SalesItemIdLbl.Text = reader["IDPART"].ToString();
                        SalesUnitPriceTxtBx.Text = reader["SELLPRICE"].ToString();
                        break;
                    }
                }
                reader.Close();
            }
            connect.Close();
        } // once clicked, it displays the part id

        private void SalesSearchTxtBx_TextChanged(object sender, EventArgs e)
        {
            if (SalesSearchTxtBx.Text == "")
                LoadSales();
            else
            {
                SalesVehicleManufacturerCmbBx.Items.Clear();
                SalesVehicleManufacturerCmbBx.Enabled = false;
                SalesVehicleModelCmbBx.Items.Clear();
                SalesVehicleModelCmbBx.Enabled = false;
                SalesPartSectionCmbBx.Text = "";
                string query = "SELECT DISTINCT PARTDESC FROM PARTSDETAILFILE WHERE PARTDESC LIKE '%" + SalesSearchTxtBx.Text + "%'";
                OleDbConnection connect = new OleDbConnection(connectionString);
                connect.Open();
                DataSet dataSet = new DataSet();
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connect);
                dataAdapter.Fill(dataSet);
                SalesLstBx.DisplayMember = "PARTDESC";
                SalesLstBx.ValueMember = "PARTDESC";
                SalesLstBx.DataSource = dataSet.Tables[0];
                connect.Close();
            }
        } // searches the specific part

        private void SalesItemIdLbl_TextChanged(object sender, EventArgs e)
        {
            SalesItemQtyPurchasedCmbBx.Items.Clear();
            string query = "SELECT * FROM PARTSHEADERFILE WHERE IDPART = '" + SalesItemIdLbl.Text + "'";
            OleDbConnection connect = new OleDbConnection(connectionString);
            connect.Open();
            OleDbCommand command = new OleDbCommand(query, connect);
            OleDbDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    SalesItemQtyLbl.Text = reader["TOTALQTY"].ToString();
                }
            }

            for (int itemQuantity = 1; itemQuantity <= Convert.ToInt32(SalesItemQtyLbl.Text); itemQuantity++)
                SalesItemQtyPurchasedCmbBx.Items.Add(itemQuantity);

            reader.Close();
            connect.Close();
        } // displays the part ID to retrieve the total quantity

        private void SalesRemoveToCartBttn_Click(object sender, EventArgs e)
        {
            if (SalesDataGrid.Rows.Count != 0)
            {
                DialogResult YesNo = MessageBox.Show("Do you want to delete this Item?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (YesNo == DialogResult.Yes)
                {
                    foreach (DataGridViewCell cell in SalesDataGrid.SelectedCells)
                    {
                        SalesDataGrid.Rows.RemoveAt(cell.RowIndex);
                        salesPurchCounter--;
                        SalesPriceTotal();
                        break;
                    }
                    SalesPriceTotal();

                    if (salesPurchCounter == 0)
                    {
                        SalesAmtTenderedTxtBx.Enabled = false;
                        SalesAmtTenderedTxtBx.Text = "";
                    }
                        
                }
            }
            else
                MessageBox.Show("Please select an item to remove", "No item in cart", MessageBoxButtons.OK, MessageBoxIcon.Information);
        } // removes the part from the cart

        private void SalesClearCartBttn_Click(object sender, EventArgs e)
        {
            DialogResult YesNo = MessageBox.Show("Are you sure you want clear your purchases?", "Clear Purchases", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (YesNo == DialogResult.Yes)
            {
                salesPurchCounter = 0;
                SalesDataGrid.Rows.Clear();
                SalesRefDocNumTxtBx.Text = "";
                SalesItemIdLbl.Text = "";
                SalesItemQtyLbl.Text = "";
                SalesUnitPriceTxtBx.Text = "";
                SalesItemQtyPurchasedCmbBx.Items.Clear();
                SalesTotalItemCostLbl.Text = "0.00";
                LoadSales();
                SalesPriceTotal();
                SalesAmtTenderedTxtBx.Text = "";
                SalesAmtTenderedTxtBx.Enabled = false;
            }
        } // removes all parts from the cart

        int salesPurchCounter = 0;

        private void AddToPurchaseBttn_Click(object sender, EventArgs e)
        {
            double parsedDouble;

            if (SalesItemQtyPurchasedCmbBx.SelectedItem == null)
                MessageBox.Show("Please Enter quantity", "Enter Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (!double.TryParse(SalesUnitPriceTxtBx.Text, out parsedDouble))
                MessageBox.Show("Price must contain numbers", "Invalid value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                DataRowView rowView = (DataRowView)SalesLstBx.SelectedItem;
                string value = rowView["PARTDESC"].ToString();

                string query = "SELECT * FROM PARTSDETAILFILE WHERE PARTDESC = '" + value + "'";
                OleDbConnection connect = new OleDbConnection(connectionString);
                connect.Open();
                OleDbCommand command = new OleDbCommand(query, connect);
                OleDbDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (reader["PARTDESC"].ToString().Equals(value))
                        {
                            if (SalesUnique())
                            {
                                SalesDataGrid.Rows.Insert(salesPurchCounter);
                                SalesDataGrid.Rows[salesPurchCounter].Cells["SalesItemIDColumn"].Value = reader["IDPART"].ToString();
                                SalesDataGrid.Rows[salesPurchCounter].Cells["SalesItemDescriptionColumn"].Value = reader["PARTDESC"].ToString();
                                SalesDataGrid.Rows[salesPurchCounter].Cells["SalesItemUnitPriceColumn"].Value = Convert.ToDecimal(SalesUnitPriceTxtBx.Text);
                                SalesDataGrid.Rows[salesPurchCounter].Cells["SalesItemQuantityPurchasedColumn"].Value = Convert.ToInt32(SalesItemQtyPurchasedCmbBx.SelectedItem);
                                SalesDataGrid.Rows[salesPurchCounter].Cells["SalesItemTotalColumn"].Value = Convert.ToDecimal(SalesTotalItemCostLbl.Text);
                                salesPurchCounter++;
                                break;
                            }
                            else
                            {
                                foreach (DataGridViewRow row in SalesDataGrid.Rows)
                                {
                                    if (row.Cells["SalesItemDescriptionColumn"].Value.ToString().Equals(value))
                                    {
                                        row.Cells["SalesItemQuantityPurchasedColumn"].Value = Convert.ToInt32(SalesItemQtyPurchasedCmbBx.SelectedItem);
                                        row.Cells["SalesItemUnitPriceColumn"].Value = Convert.ToDecimal(SalesUnitPriceTxtBx.Text);
                                        row.Cells["SalesItemTotalColumn"].Value = SalesTotalItemCostLbl.Text;
                                    }
                                }
                            }
                        }
                    }
                }
                SalesAmtTenderedTxtBx.Enabled = true;
                SalesAmtTenderedTxtBx.Text = "";
                SalesPriceTotal();
            }
        } // adds the part to the cart

        private void SalesAmtTenderedTxtBx_TextChanged(object sender, EventArgs e)
        {
            decimal parsedDecimal;

            if (decimal.TryParse(SalesAmtTenderedTxtBx.Text, out parsedDecimal))
                SalesChangeLbl.Text = string.Format("{0:#,0.00}", Convert.ToDecimal(SalesAmtTenderedTxtBx.Text) - Convert.ToDecimal(SalesTotalAmtLbl.Text));
            else
                SalesPriceTotal();
            
        } // displays the amount change

        private void SalesAddTransactionBttn_Click(object sender, EventArgs e)
        {
            decimal parsedDecimal;

            if (Convert.ToDecimal(SalesTotalAmtLbl.Text) == 0)
                MessageBox.Show("No Items has been entered", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (string.IsNullOrEmpty(SalesRefDocNumTxtBx.Text) || string.IsNullOrEmpty(SalesTransRefDocNumTxtBx.Text))
                MessageBox.Show("Please enter a Document Number", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (string.IsNullOrEmpty(SalesAmtTenderedTxtBx.Text))
                MessageBox.Show("No amount Entered", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (Convert.ToDecimal(SalesChangeLbl.Text) < 0)
                MessageBox.Show("Insufficient Funds", "Not enough balance", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (!decimal.TryParse(SalesChangeLbl.Text, out parsedDecimal))
                MessageBox.Show("Invalid value type", "Incorrect Input", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (!decimal.TryParse(SalesAmtTenderedTxtBx.Text, out parsedDecimal))
                MessageBox.Show("Invalid value type", "Incorrect Input", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (string.IsNullOrEmpty(SalesCustomerNameTxtBx.Text))
                MessageBox.Show("Please enter a Customer Name", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                DialogResult YesNo = MessageBox.Show("Do you want to complete the Transaction?", "Add Transaction", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (YesNo == DialogResult.Yes)
                {
                    string transactNum, query, delete, update, insert;

                    OleDbConnection connect = new OleDbConnection(connectionString);
                    connect.Open();
                    OleDbDataReader reader;
                    OleDbCommand command;

                    do
                    {
                        transactNum = "TR" + GenerateNumber();
                        query = "SELECT * FROM TRANSACTIONHEADERFILE WHERE TRANSID = '" + transactNum + "'";
                        command = new OleDbCommand(query, connect);
                        reader = command.ExecuteReader();
                    } while (reader.HasRows);
                    reader.Close();

                    foreach (DataGridViewRow eachRow in SalesDataGrid.Rows)
                    {
                        int qtyOrdered = Convert.ToInt32(eachRow.Cells["SalesItemQuantityPurchasedColumn"].Value);
                        decimal totalPartCost = 0, partcost = 0;

                        while (qtyOrdered > 0)
                        {
                            int partQty = 0;
                            query = "SELECT TOP 1 PARTQTY, PARTCOST FROM PARTSDETAILFILE WHERE IDPART = '" + eachRow.Cells["SalesItemIDColumn"].Value + "'";
                            command = new OleDbCommand(query, connect);
                            reader = command.ExecuteReader();

                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    partQty = Convert.ToInt32(reader["PARTQTY"]);
                                    partcost = Convert.ToDecimal(reader["PARTCOST"]);
                                    break;
                                }
                            }

                            reader.Close();

                            if (qtyOrdered >= partQty)
                            {
                                if (qtyOrdered > partQty)
                                {
                                    totalPartCost += partQty * partcost;
                                }
                                else if (qtyOrdered == partQty)
                                {
                                    totalPartCost += qtyOrdered * partcost;
                                }
                                delete = "DELETE FROM (" + query + ")";
                                command = new OleDbCommand(delete, connect);
                                command.ExecuteNonQuery();
                                qtyOrdered -= partQty;
                            }
                            else
                            {
                                if (qtyOrdered < partQty)
                                {
                                    totalPartCost += qtyOrdered * partcost;
                                }
                                partQty -= qtyOrdered;
                                update = "UPDATE PARTSDETAILFILE SET PARTQTY = " + partQty + " WHERE IDPART = '" + eachRow.Cells["SalesItemIDColumn"].Value + "'";
                                command = new OleDbCommand(update, connect);
                                command.ExecuteNonQuery();
                                qtyOrdered = 0;
                            }
                        }

                        int totalQty = 0;

                        query = "SELECT SUM(PARTQTY) FROM PARTSDETAILFILE WHERE IDPART = '" + eachRow.Cells["SalesItemIDColumn"].Value + "'";
                        command = new OleDbCommand(query, connect);
                        object quantity = command.ExecuteScalar();

                        if (quantity.GetType() != typeof(DBNull))
                            totalQty += Convert.ToInt32(quantity);

                        update = "UPDATE PARTSHEADERFILE SET TOTALQTY = " + totalQty + " WHERE IDPART = '" + eachRow.Cells["SalesItemIDColumn"].Value + "'";
                        command = new OleDbCommand(update, connect);
                        command.ExecuteNonQuery();

                        insert = "INSERT INTO SALESDETAILFILE VALUES ('" + transactNum + "', '" + SalesTransRefDocNumTxtBx.Text + "', '" + SalesRefDocNumTxtBx.Text + "', '" + SalesDatePicker.Value.Date + "', '" + SalesCustomerNameTxtBx.Text + "', '" + eachRow.Cells["SalesItemIDColumn"].Value + "', " + Convert.ToInt32(eachRow.Cells["SalesItemQuantityPurchasedColumn"].Value) + ", " + totalPartCost + ", " + Convert.ToDecimal(eachRow.Cells["SalesItemTotalColumn"].Value) + ")";
                        command = new OleDbCommand(insert, connect);
                        command.ExecuteNonQuery();
                    }

                    insert = "INSERT INTO SALESHEADERFILE VALUES ('" + transactNum + "', '" + SalesRefDocNumTxtBx.Text + "', '" + SalesDatePicker.Value.Date + "', '" + SalesCustomerNameTxtBx.Text + "', " + Convert.ToDecimal(SalesTotalAmtLbl.Text) + ")";
                    command = new OleDbCommand(insert, connect);
                    command.ExecuteNonQuery();

                    insert = "INSERT INTO TRANSACTIONHEADERFILE VALUES ('" + transactNum + "', '" + SalesRefDocNumTxtBx.Text + "', '" + SalesDatePicker.Value.Date + "', 'SALES', '" + SalesCustomerNameTxtBx.Text + "', " + Convert.ToDecimal(SalesTotalAmtLbl.Text) + ")";
                    command = new OleDbCommand(insert, connect);
                    command.ExecuteNonQuery();

                    delete = "DELETE FROM PARTSHEADERFILE PH WHERE NOT EXISTS (SELECT * FROM PARTSDETAILFILE PD WHERE PD.IDPART = PH.IDPART)";
                    command = new OleDbCommand(delete, connect);
                    command.ExecuteNonQuery();

                    connect.Close();
                    salesPurchCounter = 0;
                    SalesDataGrid.Rows.Clear();
                    SalesRefDocNumTxtBx.Text = "";
                    SalesItemIdLbl.Text = "";
                    SalesItemQtyLbl.Text = "";
                    SalesUnitPriceTxtBx.Text = "";
                    SalesItemQtyPurchasedCmbBx.Items.Clear();
                    SalesTotalItemCostLbl.Text = "0.00";
                    SalesVehicleManufacturerCmbBx.Items.Clear();
                    SalesVehicleManufacturerCmbBx.Enabled = false;
                    SalesVehicleModelCmbBx.Items.Clear();
                    SalesVehicleModelCmbBx.Enabled = false;
                    SalesCustomerNameTxtBx.Text = "";
                    SalesTransRefDocNumTxtBx.Text = "";
                    LoadPartSection();
                    LoadSales();
                    SalesPriceTotal();

                    MessageBox.Show("Transaction Complete", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        } // completes the transaction

        private void getItemTotal()
        {
            decimal parsedDecimal;
            if (decimal.TryParse(SalesUnitPriceTxtBx.Text, out parsedDecimal) && SalesItemQtyPurchasedCmbBx.SelectedItem != null)
            {
                SalesTotalItemCostLbl.Text = string.Format("{0:#,0.00}", Convert.ToDecimal(SalesUnitPriceTxtBx.Text) * Convert.ToDecimal(SalesItemQtyPurchasedCmbBx.SelectedItem));
            }
            else
            {
                SalesTotalItemCostLbl.Text = "0.00";
            }
        } // user lets to enter the selling price of the part

        private void SalesUnitPriceTxtBx_TextChanged(object sender, EventArgs e)
        {
            getItemTotal();
        }  // displays the selling price

        private void SalesItemQtyPurchasedCmbBx_SelectionChangeCommitted(object sender, EventArgs e)
        {
            getItemTotal();
        } // user lets to choose the quantity

    }

}
