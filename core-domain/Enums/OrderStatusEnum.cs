namespace core_domain.Enums;

public enum OrderStatusEnum
{
    New,
    Pending,
    Completed,
    Cancelled,
    AwaitingPayment,
    AwaitingShipment,
    Shipping,
    Refunded,
}
