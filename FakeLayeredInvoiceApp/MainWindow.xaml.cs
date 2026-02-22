
using System.Windows;

namespace FakeLayeredInvoiceApp
{
    public partial class MainWindow : Window
    {
        private InvoiceService _service = new InvoiceService();

        public MainWindow()
        {
            InitializeComponent();
            Refresh();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtAmount.Text, out double amount))
            {
                _service.AddInvoice(new Invoice { Amount = amount });
                Refresh();
            }
        }

        private void Refresh()
        {
            lstInvoices.ItemsSource = null;
            lstInvoices.ItemsSource = _service.GetAll();
        }
    }
}
