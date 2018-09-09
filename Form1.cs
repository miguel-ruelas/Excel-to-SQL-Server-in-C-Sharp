using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;

namespace Import
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void GetFileName(out string selectedFile) //Move to button1_Click if not autorun on open.
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "Z:\\";  //Drive letter of initial directory
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) //Select the file to import
            {
                selectedFile = openFileDialog1.FileName;
                return;
            }
            else
            {
                MessageBox.Show("Please enter a valid Filename");
            }
            selectedFile = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }


        public void ImportDataFromExcel(string excelFilePath)
        {
            //declare variables - edit these based on your particular situation 
            string ssqltable = "sampleTable"; //Change the table name to your needs
            // make sure your sheet name is correct, here sheet name is sheet1, so you can change your sheet name if have    different 
            string myexceldataquery = "select ASIN, DESCRIPTION, QTY, PRICE, [AZ SELLING PRICE], [SALES RANK], RATING from [Products$]"; //Excel query
            try
            {
                //create our connection strings 

                string sexcelconnectionstring = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelFilePath + ";Extended Properties=Excel 12.0;";  //Excel connection string
        
                //Server, Database, User login string
				string ssqlconnectionstring = "Data Source = SQLSRV\\SQLEXPRESS; Initial Catalog = DBNAME; Persist Security Info = True; User ID = USERID; Password =PASSWORD";
                //execute a query to erase any previous data from our destination table 
                string sclearsql = "delete from " + ssqltable;   //Create the command string
                SqlConnection sqlconn = new SqlConnection(ssqlconnectionstring); //Create the connection object
                SqlCommand sqlcmd = new SqlCommand(sclearsql, sqlconn);          //Create the query command objects SqlCommand(command, connection)
                
				try //Try to connect
                {
                    sqlconn.Open();
                    if (sqlconn.State == ConnectionState.Open)
                    {
                        //MessageBox.Show("Sqlconn open");
                    }
                    else
                    {
                        MessageBox.Show("Connection failed.");
                    }
				}
				catch (SqlException ex)  //Something whent wrong, display error
                {
                    MessageBox.Show(ex.Message);
                }

				//Delete all records in table
                sqlcmd.ExecuteNonQuery(); //Executes a Transact-SQL statement against the connection and returns the number of rows affected.
                sqlconn.Close(); //Close the connection

                //series of commands to bulk copy data from the excel file into our sql table 
                OleDbConnection oledbconn = new OleDbConnection(sexcelconnectionstring); //Create excel connection object
                OleDbCommand oledbcmd = new OleDbCommand(myexceldataquery, oledbconn);   //Excel query object
                try //attempt to open the excel
                 {
                     oledbconn.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + " oledb");
                }
                
                OleDbDataReader dr = oledbcmd.ExecuteReader();   //Object that reads from Excel
                SqlBulkCopy bulkcopy = new SqlBulkCopy(ssqlconnectionstring);  //Create Bulk Copy object
                bulkcopy.DestinationTableName = ssqltable;  
                while (dr.Read())   //Read from excel and copy to SQL
                {
                    bulkcopy.WriteToServer(dr);
                }
                dr.Close(); //Close excel reader object
                oledbconn.Close(); //Close SQL connection
                outputLabel.Text = "File imported into sql server."; //Display Message
            }
            catch (Exception ex)
            {
              MessageBox.Show(ex.Message + "Exception Thrown");
           }
            fillDataGridView();   //Display imported rows 
        }
        private void fillDataGridView()
        {
			//Alter to show your own individual data in DataGridView
			
			//Optional Run Queries after import 
			//Change Server, DB, USER and pass
            string connectionString = "Data Source = SQLSRV\\SQLEXPRESS; Initial Catalog = DBNAME; Persist Security Info = True; User ID = USERID; Password =PASS";   
			string sql = "DELETE FROM tableName WHERE COLUMN IS NULL SELECT * FROM tableName GO exec sp_sample "; //Sample SQL Query to run after import.

            
            SqlConnection connection = new SqlConnection(connectionString); //Connection object
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection); //Execute query
            
			//Get info from SQL to fill DataGridView
			DataSet ds = new DataSet();
            connection.Open();
            dataadapter.Fill(ds, "test");
            connection.Close();
           
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "test";
			
            SqlCommand command = new SqlCommand("Select Count(COLUMN) from TABLE");
            command.Connection = connection;
            connection.Open();
            int newItemCount = (int)command.ExecuteScalar();
            connection.Close();

            command = new SqlCommand("Select Count(COLUMN) from TABLE");
            command.Connection = connection;
            connection.Open();
            int importItemCount = (int)command.ExecuteScalar();
            connection.Close();
            countNewItemLabel.Text = newItemCount.ToString();
            countImportLabel.Text = importItemCount.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
			//Uncomment for static path, use double \\ for folders
            //string path = "Z:\\Folder\\subfolder\\excel.xls";
            GetFileName(out path);
            //MessageBox.Show(path);
            ImportDataFromExcel(path);
            //this.Close();
        }

    
    }
}
