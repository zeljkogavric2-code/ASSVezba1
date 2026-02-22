
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;

namespace BadUserManager
{
    public partial class MainWindow : Window
    {
        private List<User> _users = new List<User>();

        public MainWindow()
        {
            InitializeComponent();
            LoadUsers();
            Refresh();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || 
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Name and email required");
                return;
            }

            if (_users.Any(u => u.Email == txtEmail.Text))
            {
                MessageBox.Show("User exists");
                return;
            }

            var user = new User
            {
                Name = txtName.Text,
                Email = txtEmail.Text
            };

            _users.Add(user);
            File.WriteAllText("users.json", JsonSerializer.Serialize(_users));
            Refresh();
        }

        private void Refresh()
        {
            lstUsers.ItemsSource = null;
            lstUsers.ItemsSource = _users.Select(u => u.Name + " - " + u.Email);
        }

        private void LoadUsers()
        {
            if (File.Exists("users.json"))
            {
                _users = JsonSerializer.Deserialize<List<User>>(
                    File.ReadAllText("users.json"));
            }
        }
    }
}
