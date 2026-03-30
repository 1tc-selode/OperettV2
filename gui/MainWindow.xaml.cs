using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using core;

namespace gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Operett> operettek; 
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                operettek = Services.GetAll();

                List<Operett> egyediMuCimek = operettek
                    .GroupBy(o => o.Muid)
                    .Select(g => g.First())
                    .OrderBy(o => o.Cim)
                    .ToList();

                cbOperett.ItemsSource = egyediMuCimek;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"hoba a betolteskor: {ex.Message}");
                throw;
            }
        }
        private void cbOperett_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbOperett.SelectedItem is Operett kivalasztott)
            {
                tbCim.Text = kivalasztott.Cim;
                tbEredeti.Text = $"Eredeti cím: {kivalasztott.Eredeti}";
                tbEvszinhaz.Text = $"Bemutató: {kivalasztott.Ev}, {kivalasztott.Szinhaz}";
                tbFelvonas.Text = $"Felvonások száma: {kivalasztott.Felvonas}";

                dgAlkotok.ItemsSource = operettek
                    .Where(o => o.Muid == kivalasztott.Muid)
                    .Select(o => new Alkoto { Nev = o.Nev, Tipus = o.Tipus})
                    .ToList();
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}