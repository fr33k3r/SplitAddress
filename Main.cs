using SplitAddresses.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SplitAddresses
{
    public partial class Main : Form
    {
        string ConnectionStringLive = "Data Source=10.193.18.131;Initial Catalog = IDISSUERDB; User ID = gsis_admin; Password=pRZJdUNhUBAjUFvDFmGmEXtDY82p8V3v";
        string ConnectionStringDev = "Data Source=10.193.18.135;Initial Catalog = ASTTSStaging; User ID = authentix_staging; Password=staging@123";

        CultureInfo Culture = CultureInfo.CreateSpecificCulture("en-US");

        public Main()
        {
            InitializeComponent();
        }

        private void TestStagingDBButton_Click(object sender, EventArgs e)
        {
            string ConnectionString = null;
            SqlConnection cnn;
            ConnectionString = ConnectionStringDev;
            cnn = new SqlConnection(ConnectionString);
            using (cnn)
            {
                try
                {
                    cnn.Open();
                    MessageBox.Show(Properties.Resources.ConnectionOpen);
                    cnn.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(Properties.Resources.ConnectionError, ex.Message);
                }
            }
        }

        private void TestLiveDBButton_Click(object sender, EventArgs e)
        {
            string ConnectionString = null;
            SqlConnection cnn;
            ConnectionString = ConnectionStringLive;
            cnn = new SqlConnection(ConnectionString);
            using (cnn)
            {
                try
                {
                    cnn.Open();
                    MessageBox.Show(Properties.Resources.ConnectionOpen);
                    cnn.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(Properties.Resources.ConnectionError, ex.Message);
                }
            }
        }

        private void FetchDataButton_Click(object sender, EventArgs e)
        {
            string ConnectionString = ConnectionStringLive;            

            List<Address> lstAddress = new List<Address>();
            List<SplitAddress> lstSplitAddress = new List<SplitAddress>();

            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Address", con))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr != null)
                            {
                                while (dr.Read())
                                {
                                    Address address = new Address();
                                    address.ID = Convert.ToInt32(dr["Address_ID"],Culture);
                                    address.AddressLine1 = dr["Address_Line_1"].ToString();

                                    //Stop for testing
                                    //if (lstAddress.Count == 74)
                                    //{
                                    //    Console.WriteLine(lstAddress.Count);
                                    //}

                                    lstAddress.Add(address);

                                    string[] addressfields = address.AddressLine1.Split(' ');                                    

                                    // Create a pattern for a word that has 5 numbers                                    
                                    //string pattern = @"^[0-9]{5}$";
                                    // Create a Regex  
                                    //Regex rg = new Regex(pattern);

                                    
                                    // Get all matches  
                                    //MatchCollection matchedPostalCode = rg.Matches(address.AddressLine1);
                                    
                                    // Print all matched Postal Codes  
                                    //for (int count = 0; count < matchedPostalCode.Count; count++)
                                    //    Console.WriteLine(matchedPostalCode[count].Value);

                                    SplitAddress splitAddress = new SplitAddress();
                                    splitAddress.ID = address.ID;

                                    splitAddress.Street = "";
                                    splitAddress.City = "";
                                                                        
                                    int TotalNumberLocation = -1;
                                    int TotalNumberLength = -1;
                                    int TotalPostalLocation = -1;
                                    

                                    string[] numbers = Regex.Split(address.AddressLine1, @"\D+");

                                    foreach (string value in numbers)
                                    {
                                        int PostalLocation = -1;
                                        int NumberLocation = -1;

                                        if (!string.IsNullOrEmpty(value))
                                        {
                                            if (value.Length == 5)
                                            {
                                                splitAddress.PostalCode = value;
                                                PostalLocation = address.AddressLine1.IndexOf(value, StringComparison.InvariantCultureIgnoreCase);
                                                TotalPostalLocation = PostalLocation;
                                                
                                            }
                                            else                                                
                                            {
                                                splitAddress.Number = value;
                                                NumberLocation = address.AddressLine1.IndexOf(value, StringComparison.InvariantCultureIgnoreCase);
                                                TotalNumberLocation = NumberLocation;
                                                TotalNumberLength = value.Length;
                                            }
                                        }
                                        
                                        if (NumberLocation > 0)
                                        {
                                            splitAddress.Street = Regex.Replace(address.AddressLine1.Substring(0, NumberLocation-1).Trim(), @"[^\w\ .@-]", "", RegexOptions.None, TimeSpan.FromSeconds(1.5));
                                        }
                                        else
                                        {
                                            //splitAddress.Street = address.AddressLine1;
                                        }

                                        if (PostalLocation > 0)
                                        {
                                            splitAddress.City = Regex.Replace(address.AddressLine1.Substring(PostalLocation + 5).Trim(), @"[^\w\ .@-]", "", RegexOptions.None, TimeSpan.FromSeconds(1.5));

                                            if (splitAddress.City.Length == 0)
                                            {
                                                if (TotalNumberLocation + TotalNumberLength > 0)
                                                {
                                                    //splitAddress.City = Regex.Replace(address.AddressLine1.Substring(TotalNumberLocation + TotalNumberLength, address.AddressLine1.Length - PostalLocation), @"[^\w\.@-]", "", RegexOptions.None, TimeSpan.FromSeconds(1.5));
                                                    splitAddress.City = Regex.Replace(address.AddressLine1.Substring(TotalNumberLocation + TotalNumberLength, TotalPostalLocation - TotalNumberLocation - TotalNumberLength).Trim(), @"[^\w\ .@-]", "", RegexOptions.None, TimeSpan.FromSeconds(1.5));

                                                }
                                            }
                                        }
                                        else
                                        {
                                            //splitAddress.City = address.AddressLine1;
                                        }
                                    }
                                                                       
                                    lstSplitAddress.Add(splitAddress);
                                }
                            }
                        } // reader closed and disposed up here

                    } // command disposed here

                } //connection closed and disposed here

                var bindingAddressList = new BindingList<Address>(lstAddress);
                var source = new BindingSource(bindingAddressList, null);
                AddressDataGrid.DataSource = source;
                AddressDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                var bindingSplitList = new BindingList<SplitAddress>(lstSplitAddress);
                var splitSource = new BindingSource(bindingSplitList, null);
                SplitAddressDataGrid.DataSource = splitSource;
                SplitAddressDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show(Properties.Resources.InvalidIntCastError + ex.Message, Properties.Resources.InvalidCastError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
