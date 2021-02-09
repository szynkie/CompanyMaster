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
            using (SqlConnection conn = new SqlConnection(@"data source=(localdb)\MSSQLLocalDB;initial catalog=CompaniesDatabase;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework"))
            {
                try
                {
                    string query = "select Country from Countries";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    conn.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Country");
                    //CountryBox.DisplayMember = "Country";
                    //CountryBox.ValueMember = "Country";
                    //CityBox.DataSource = ds.Tables["Country"];


                }
                catch (Exception ex)
                {
                    // write exception info to log or anything else
                    MessageBox.Show("Error occured!");
                }
            }
        }
        
    }
}
