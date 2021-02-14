using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CompanyMaster
{
    /// <summary>
    /// Interaction logic for Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        public int xd;
        public Page3()
        {
            InitializeComponent();

        }


        public Page3(int tempComp)
        {
            InitializeComponent();
            fillComboBox();
            fillComboBoxBS();
            fillComboBoxTp();

            int fg = tempComp;
            
            SqlConnection conn = new SqlConnection(@"data source=(localdb)\MSSQLLocalDB;initial catalog=CompaniesDatabase;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
            try
            {
                conn.Open();
                string query = $"select * from Companies where Id = {fg}";
                
                SqlCommand createCommand = new SqlCommand(query, conn);
                
                SqlDataReader dr = createCommand.ExecuteReader();
                


                while (dr.Read())
                {
                    string FullName = dr.GetString(1);
                    string Street = dr.GetString(2);
                    string City = dr.GetString(3);
                    int CountryId = dr.GetInt32(4);
                    int BSId = dr.GetInt32(5);
                    int TpId = dr.GetInt32(6);


                    FullNameBox.Text = FullName;
                    StreetBox.Text = Street;
                    CityBox.Text = City;
                    CountryBox.SelectedIndex = (CountryId-1);
                    SegmentBox.SelectedIndex = (BSId - 1);
                    TypeBox.SelectedIndex = (TpId-1);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            xd = fg;
        }

        void fillComboBox()
        {
            SqlConnection conn = new SqlConnection(@"data source=(localdb)\MSSQLLocalDB;initial catalog=CompaniesDatabase;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
            try
            {
                conn.Open();
                string query = "select * from Countries";
                SqlCommand createCommand = new SqlCommand(query, conn);
                SqlDataReader dr = createCommand.ExecuteReader();
                while (dr.Read())
                {
                    string Country = dr.GetString(1);
                    int Id = dr.GetInt32(0);
                    CountryBox.Items.Add(Id + " " + Country);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void fillComboBoxBS()
        {
            SqlConnection conn1 = new SqlConnection(@"data source=(localdb)\MSSQLLocalDB;initial catalog=CompaniesDatabase;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
            try
            {
                conn1.Open();
                string query1 = "select * from BusinessSegments";
                SqlCommand createCommand1 = new SqlCommand(query1, conn1);
                SqlDataReader dr1 = createCommand1.ExecuteReader();
                while (dr1.Read())
                {
                    string BusinessSegment = dr1.GetString(1);
                    int Id = dr1.GetInt32(0);
                    SegmentBox.Items.Add(Id + " " + BusinessSegment);
                }
                conn1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void fillComboBoxTp()
        {
            SqlConnection conn2 = new SqlConnection(@"data source=(localdb)\MSSQLLocalDB;initial catalog=CompaniesDatabase;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
            try
            {
                conn2.Open();
                string query2 = "select * from Types";
                SqlCommand createCommand2 = new SqlCommand(query2, conn2);
                SqlDataReader dr2 = createCommand2.ExecuteReader();
                while (dr2.Read())
                {
                    string Type = dr2.GetString(1);
                    int Id = dr2.GetInt32(0);
                    TypeBox.Items.Add(Id + " " + Type);
                }
                conn2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            int re = xd;  
            if (FullNameBox.Text == "" || StreetBox.Text == "" || CityBox.Text == "" || CountryBox.Text == "" || SegmentBox.Text == "" || TypeBox.Text == "")
            {
                MessageBox.Show("One or more fields empty!");
            }
            else
            {
                SqlConnection conn3 = new SqlConnection(@"data source=(localdb)\MSSQLLocalDB;initial catalog=CompaniesDatabase;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
                try
                {
                    conn3.Open();
                    string query3 = $"update Companies set FullName = '" + this.FullNameBox.Text + "',Street = '" + this.StreetBox.Text + "',City = '" + this.CityBox.Text + "',Country = '" + Int32.Parse(this.CountryBox.Text.Substring(0, 1)) + "',BusinessSegmentFK = '" + Int32.Parse(this.SegmentBox.Text.Substring(0, 1)) + "',TypeFK = '" + Int32.Parse(this.TypeBox.Text.Substring(0, 1)) + "' where Id =" + re+"";
                    SqlCommand createCommand3 = new SqlCommand(query3, conn3);
                    createCommand3.ExecuteNonQuery();
                    MessageBox.Show("Saved");
                    conn3.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
