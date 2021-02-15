using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CompanyMaster
{
    /// <summary>
    /// Strona umozliwiajaca wyszukiwanie rekordow w bazie po nazwie 
    /// </summary>
    public partial class SearchPg : Page
    {

        public SearchPg()
        {
            InitializeComponent();
        }

        private void srchButton_Click(object sender, RoutedEventArgs e)
        {
            ///Wybieranie wszystich rekordow w tabeli Companies i przypisanie wartosci FK z innych tabel
            CompaniesDatabaseEntities db = new CompaniesDatabaseEntities();

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
            //Usuwanie rekordu z bazy po Id
            if (companyDataGrid.SelectedIndex != -1)
            {
                CompaniesDatabaseEntities db = new CompaniesDatabaseEntities();

                object item = companyDataGrid.SelectedItem;
                string ID = (companyDataGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                int di = Int32.Parse(ID);

                Companies comp = (from r in db.Companies where r.Id == di select r).SingleOrDefault();
                db.Companies.Remove(comp);
                db.SaveChanges();

                string xd = di.ToString();
                MessageBox.Show("Removed " + di);

                //pokaz dane
                srchButton_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Select record");
            }
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            //Identyfikacja rekordu i przekazanie danych do editpage
            //Companies tempComp = (Companies)companyDataGrid.SelectedItem;
            object item = companyDataGrid.SelectedItem;
            string ID = (companyDataGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            int di = Int32.Parse(ID);
            
            xd.Navigate(new Page3(di)); // poprawic kiedys
        }
    }
}