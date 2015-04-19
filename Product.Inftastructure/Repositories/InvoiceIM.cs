using System.Collections.Generic;
using System.Linq;
using Shop.Domain.Model.Order;
using Shop.Domain.Model.Order.Repositories;

namespace Shop.Inftastructure.Repositories
{
    public class InvoiceIM : IInvoiceRepository
    {
        private List<Invoice> invoices = new List<Invoice>();

        public InvoiceIM()
        {
            invoices = new List<Invoice>
            {
                new Invoice{Id = 1, InvoiceNumber = "ABC"},
                new Invoice{Id = 2, InvoiceNumber = "123"},
                new Invoice{Id = 3, InvoiceNumber = "DEF"}
            };
        }

        public void Insert(Invoice invoice)
        {
            invoices.Add(invoice);
        }

        public Invoice Find(int id)
        {
            return invoices.Single(i => i.Id == id);
        }
    }
}
