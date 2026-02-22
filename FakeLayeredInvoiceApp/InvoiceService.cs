
using System;
using System.Collections.Generic;

namespace FakeLayeredInvoiceApp
{
    public class InvoiceService
    {
        private InvoiceRepository _repo = new InvoiceRepository();

        public void AddInvoice(Invoice invoice)
        {
            if (invoice.Amount <= 0)
                throw new Exception("Amount must be positive");

            invoice.CreatedAt = DateTime.Now;
            _repo.Save(invoice);
        }

        public List<Invoice> GetAll()
        {
            return _repo.GetAll();
        }
    }
}
