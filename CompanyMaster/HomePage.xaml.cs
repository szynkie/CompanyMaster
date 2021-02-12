using System;
using System.Collections.Generic;
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
        
        public Page3()
        {
            InitializeComponent();

            

            



            




        }


        public Page3(int tempComp)
        {
            InitializeComponent();
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


                    FullNameBox.Text = FullName;

                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void updateButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
