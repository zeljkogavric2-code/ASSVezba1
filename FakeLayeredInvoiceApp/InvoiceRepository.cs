
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace FakeLayeredInvoiceApp
{
    public class InvoiceRepository
    {
        private string _path = "invoices.json";

        public void Save(Invoice invoice)
        {
            var list = GetAll();
            list.Add(invoice);
            File.WriteAllText(_path, JsonSerializer.Serialize(list));
        }

        public List<Invoice> GetAll()
        {
            if (!File.Exists(_path))
                return new List<Invoice>();

            return JsonSerializer.Deserialize<List<Invoice>>(
                File.ReadAllText(_path));
        }
    }
}
