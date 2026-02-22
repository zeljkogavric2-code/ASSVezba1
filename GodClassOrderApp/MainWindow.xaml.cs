
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;

namespace GodClassOrderApp
{
    public partial class MainWindow : Window
    {
        private List<Order> _orders = new List<Order>();
        private string _filePath = "orders.json";

        public MainWindow()
        {
            InitializeComponent();
            LoadOrders();
            Refresh();
        }

        private void AddOrder_Click(object sender, RoutedEventArgs e)
        {
            // VALIDATION LOGIC
            if (string.IsNullOrWhiteSpace(txtProduct.Text))
            {
                MessageBox.Show("Product is required.");
                return;
            }

            if (!double.TryParse(txtPrice.Text, out double price) || price <= 0)
            {
                MessageBox.Show("Invalid price.");
                return;
            }

            // BUSINESS LOGIC
            var order = new Order
            {
                Id = Guid.NewGuid(),
                Product = txtProduct.Text,
                Price = price,
                CreatedAt = DateTime.Now
            };

            _orders.Add(order);

            // CALCULATION LOGIC
            double total = _orders.Sum(o => o.Price);
            this.Title = $"God Class Order App - Total: {total}";

            // PERSISTENCE LOGIC
            File.WriteAllText(_filePath, JsonSerializer.Serialize(_orders));

            Refresh();
        }

        private void LoadOrders()
        {
            if (File.Exists(_filePath))
            {
                _orders = JsonSerializer.Deserialize<List<Order>>(
                    File.ReadAllText(_filePath));
            }
        }

        private void Refresh()
        {
            lstOrders.ItemsSource = null;
            lstOrders.ItemsSource = _orders
                .Select(o => $"{o.Product} - {o.Price} ({o.CreatedAt})");
        }
    }

    public class Order
    {
        public Guid Id { get; set; }
        public string Product { get; set; }
        public double Price { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
