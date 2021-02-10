using System;
using System.Collections.Generic;
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
using System.Data.Entity;

namespace CompanyMaster
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class SearchPg : Page
    {
        
        public SearchPg()
        {
            InitializeComponent();
            //CompanyDatabaseEntities1 db = new CompanyDatabaseEntities1();
            //var comp = from c in db.Companies
            //           select c;

            ////foreach (var item in comp)
            ////{
            ////    Console.WriteLine(item.FullName);
            ////}

            //this.companyDataGrid.ItemsSource = comp.ToList();
        }

        private void srchButton_Click(object sender, RoutedEventArgs e)
        {
            //CompanyDatabaseEntities1 db = new CompanyDatabaseEntities1();
            //var comp = from c in db.Companies
            //           where c.FullName.Contains(srchBox.Text)
            //           select c;

            //this.companyDataGrid.ItemsSource = comp.ToList();
            CompaniesDatabaseEntities db = new CompaniesDatabaseEntities();
            var comp = from c in db.Companies
                       where c.FullName.Contains(srchBox.Text)
                       select c;
            this.companyDataGrid.ItemsSource = comp.ToList();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            CompaniesDatabaseEntities db = new CompaniesDatabaseEntities();
            int CId = (companyDataGrid.SelectedItem as Companies).Id;
            string CName = (companyDataGrid.SelectedItem as Companies).FullName;
            

            Companies comp = (from r in db.Companies where r.Id == CId select r).SingleOrDefault();
            db.Companies.Remove(comp);
            db.SaveChanges();

            string xd = CId.ToString();
            MessageBox.Show("Removed "+xd+" "+CName);

            companyDataGrid.ItemsSource = db.Companies.ToList();

        }
    }
}
