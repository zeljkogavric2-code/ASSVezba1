
namespace FakeLayeredInvoiceApp
{
    public class Invoice
    {
        public double Amount { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public override string ToString()
        {
            return $"Amount: {Amount} | Created: {CreatedAt:dd.MM.yyyy HH:mm}";
        }
    
    }
}
