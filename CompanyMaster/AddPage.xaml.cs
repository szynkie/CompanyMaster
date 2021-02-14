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
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class AddPg : Page
    {
        public AddPg()
        {
            InitializeComponent();
            fillComboBox();
            fillComboBoxBS();
            fillComboBoxTp();
        }
        void fillComboBox()
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString);
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
                    CountryBox.Items.Add(Id+" "+Country);
                }
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void fillComboBoxBS()
        {
            SqlConnection conn1 = new SqlConnection(Properties.Settings.Default.connString);
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
                    SegmentBox.Items.Add(Id+" "+BusinessSegment);
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
            SqlConnection conn2 = new SqlConnection(Properties.Settings.Default.connString);
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
                    TypeBox.Items.Add(Id+" "+Type);
                }
                conn2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (FullNameBox.Text == "" || StreetBox.Text == "" || CityBox.Text == "" || CountryBox.Text == "" || SegmentBox.Text == "" || TypeBox.Text == "")
            {
                MessageBox.Show("One or more fields empty!");
            }
            else
            {
                SqlConnection conn3 = new SqlConnection(Properties.Settings.Default.connString);
                try
                {
                    conn3.Open();
                    string query3 = "insert into Companies (FullName,Street,City,Country,BusinessSegmentFK,TypeFK) values ('" + this.FullNameBox.Text + "','" + this.StreetBox.Text + "','" + this.CityBox.Text + "','" + Int32.Parse(this.CountryBox.Text.Substring(0, 1)) + "','" + Int32.Parse(this.SegmentBox.Text.Substring(0, 1)) + "','" + Int32.Parse(this.TypeBox.Text.Substring(0, 1)) + "')";
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
