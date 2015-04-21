using NHibernate.Type;

namespace Shop.Domain.Model.Order
{
    public enum OrderStatus
    {
        Created,
        ToPay,
        Paid,
        Shipment,
        Finished,
        Cancelled
    }

    public class OrderStatusType : EnumStringType<OrderStatus>
    {
        public static string GetDescription(OrderStatus status)
        {
            switch (status)
            {
                case OrderStatus.Created: return "Created";
                case OrderStatus.ToPay: return "ToPay";
                case OrderStatus.Paid: return "Paid";
                case OrderStatus.Shipment: return "Shipment";
                case OrderStatus.Finished: return "Finished";
                case OrderStatus.Cancelled: return "Cancelled";
                default: return string.Empty;
            }
        }
    }
}
