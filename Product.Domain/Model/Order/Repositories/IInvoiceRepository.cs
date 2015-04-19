namespace Shop.Domain.Model.Order.Repositories
{
    public interface IInvoiceRepository
    {
        void Insert(Invoice invoice);

        Invoice Find(int id);
    }
}
