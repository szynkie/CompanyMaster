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
            //var comp = from c in db.Companies
            //           where c.FullName.Contains(srchBox.Text)
            //           select c;
            //this.companyDataGrid.ItemsSource = comp.ToList();

            var query = from com in db.Companies

                        join cou in db.Countries on com.Country equals cou.Id
                        join bs in db.BusinessSegments on com.BusinessSegmentFK equals bs.Id
                        join tp in db.Types on com.TypeFK equals tp.Id

                        where com.FullName.Contains(srchBox.Text)

                        select new
                        {
                            Id = com.Id,
                            FullName = com.FullName,
                            Street = com.Street,
                            City = com.City,
                            Country = cou.Country,
                            BusinessSegmentFK = bs.BusinessSegment,
                            TypeFK = tp.Type
                        };
            this.companyDataGrid.ItemsSource = query.ToList();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (companyDataGrid.SelectedIndex != -1)
            {
                CompaniesDatabaseEntities db = new CompaniesDatabaseEntities();
                int CId = (companyDataGrid.SelectedItem as Companies).Id;
                string CName = (companyDataGrid.SelectedItem as Companies).FullName;


                Companies comp = (from r in db.Companies where r.Id == CId select r).SingleOrDefault();
                db.Companies.Remove(comp);
                db.SaveChanges();

                string xd = CId.ToString();
                MessageBox.Show("Removed " + xd + " " + CName);


                companyDataGrid.ItemsSource = db.Companies.ToList();
            }
            else
            {
                MessageBox.Show("Select record");
            }
        }
    }
}
