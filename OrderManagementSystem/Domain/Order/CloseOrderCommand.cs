﻿namespace OrderManagementSystem.Domain.Order
{
    using System;
    using Castle.Windsor;
    using NHibernate;
    using Infrastructure.Command;

    /// <summary>
    /// Zamknięcie zamówienia
    /// </summary>
    public class CloseOrderCommand : Command<Order>, INeedSession, INeedAutocommitTransaction
    {
        private readonly Guid orderId;
        private IOrderStatusService orderStatusService;

        public CloseOrderCommand(Guid orderId)
        {
            this.orderId = orderId;
        }

        /// <summary>
        /// Wywołuje komendę i zwraca wskazany typ
        /// </summary>
        /// <returns>Rezultat</returns>
        public override Order Execute()
        {
            var order = Session.Load<Order>(orderId);
            orderStatusService.CloseOrder(order);
            Session.Update(order);

            return order;
        }

        /// <summary>
        /// Dodawanie własnych zależności do komendy.
        /// </summary>
        /// <param name="container">Kontener IoC</param>
        public override void SetupDependencies(IWindsorContainer container)
        {
            orderStatusService = container.Resolve<IOrderStatusService>();
        }

        /// <summary>
        /// Sesja NHibernate.
        /// </summary>
        public ISession Session { get; set; }
    }
}