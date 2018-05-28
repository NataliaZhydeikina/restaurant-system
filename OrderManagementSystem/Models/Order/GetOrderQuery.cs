namespace OrderManagementSystem.Models.Order
{
    using System.Linq;
    using NHibernate.Util;
    using System;
    using NHibernate;
    using Infrastructure.Exception;
    using Infrastructure.Query;

    /// <summary>
    /// Pobranie zamówienia po ID
    /// </summary>
    public class GetOrderQuery : Query<OrderForm>
    {
        private readonly Guid orderId;

        public GetOrderQuery(Guid orderId)
        {
            this.orderId = orderId;
        }

        /// <summary>
        /// Metoda do konstruowania i wywoływania zapytania za pomocą sesji NHibernate
        /// </summary>
        /// <param name="session">Sesja NHibernate</param>
        public override OrderForm Execute(ISession session)
        {
            var order = session.Get<Domain.Order.Order>(orderId);

            if (order == null)
                throw new TechnicalException($"The order with the given id can not be found: {orderId}");

            var productIds = order.OrderItems.Select(x => x.Product.Id).ToList();

            foreach (var productId in productIds)
            {
                var product = session.Get<Domain.Product.Product>(productId);
                order.OrderItems.Where(x => x.Product.Id == productId).ForEach(x => x.Product = product);
            }

            return OrderMapper.MapOrderToForm(order);
        }
    }
}