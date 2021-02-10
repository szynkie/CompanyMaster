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
        //CompaniesDatabaseEntities dc = new CompaniesDatabaseEntities();
        public AddPg()
        {
            InitializeComponent();
            fillComboBox();
            fillComboBoxBS();
            fillComboBoxTp();
            //bindCountry();
            //bindBS();
            //bindTps();
            //using (SqlConnection conn = new SqlConnection(@"data source=(localdb)\MSSQLLocalDB;initial catalog=CompaniesDatabase;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework"))
            //{
            //    try
            //    {
            //        string query = "select Country from Countries";
            //        SqlDataAdapter da = new SqlDataAdapter(query, conn);
            //        conn.Open();
            //        DataSet ds = new DataSet();
            //        da.Fill(ds, "Country");
            //        //CountryBox.DisplayMember = "Country";
            //        //CountryBox.ValueMember = "Country";
            //        //CityBox.DataSource = ds.Tables["Country"];


            //    }
            //    catch (Exception ex)
            //    {
            //        // write exception info to log or anything else
            //        MessageBox.Show("Error occured!");
            //    }
            //}
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
                    CountryBox.Items.Add(Country);
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
                    SegmentBox.Items.Add(BusinessSegment);
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
                    TypeBox.Items.Add(Type);
                }
                conn2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //public List<Countries> Coun { get; set; }
        //public List<BusinessSegments> BS { get; set; }
        ////public List<Type> Tps { get; set; }

        ////private void bindTps()
        ////{
        ////    //throw new NotImplementedException();
        ////    //CompaniesDatabaseEntities dc = new CompaniesDatabaseEntities();
        ////    //var item = dc.Types.ToList();
        ////    //Tps = item;
        ////    //DataContext = Tps;

        ////}

        //private void bindBS()
        //{
        //    //CompaniesDatabaseEntities dc = new CompaniesDatabaseEntities();
        //    var item = dc.BusinessSegments.ToList();
        //    BS = item;
        //    DataContext = BS;
        //}



        //private void bindCountry()
        //{
        //    //throw new NotImplementedException();
        //    //CompaniesDatabaseEntities dc = new CompaniesDatabaseEntities();
        //    var item = dc.Countries.ToList();
        //    Coun = item;
        //    DataContext = Coun;
        //}


    }
}
