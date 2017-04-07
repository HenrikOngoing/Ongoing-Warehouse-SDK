using OngoingWarehouse.Sdk.Example.Webshop;
using OngoingWarehouse.Sdk.Example.Webshop.WebshopEntities;
using OngoingWarehouse.Sdk.OngoingWarehouseAPI;
using OngoingWarehouse.Sdk.Updaters;
using System.Linq;

namespace OngoingWarehouse.Sdk.Example.OnChangeTasks.Webshop
{
   /**
    * Execute this task when a new order has been received in the webshop or when an existing order is updated.
    **/
   public class UpdateOrderInOngoingTask
   {
      public void Run(SalesOrder salesOrder)
      {
         var updater = new OrderUpdater(WebshopWmsCredentials.Credentials);
         var ongoingOrder = MapToOngoingType(salesOrder);
         updater.Update(ongoingOrder);
      }

      private CustomerOrder MapToOngoingType(SalesOrder salesOrder)
      {
         var customerOrder = new CustomerOrder()
         {
            OrderInfo = new OrderInfoClass()
            {
               OrderOperation = OrderOperation.CreateOrUpdate,
               OrderIdentification = OrderIdentificationType.GoodsOwnerOrderNumber,
               GoodsOwnerOrderNumber = salesOrder.OrderNumber
            },
            CustomerOrderLines = salesOrder.Lines.Select(l =>
               new CustomerOrderLine
               {
                  OrderLineIdentification = OrderLineIdentificationType.ExternalOrderLineCode,
                  ExternalOrderLineCode = l.LineNumber.ToString(),
                  ArticleIdentification = ArticleIdentificationType.ArticleNumber,
                  ArticleNumber = l.ArticleNumber,
                  NumberOfItems = l.OrderedQuantity
               }
            ).ToArray(),
            Customer = MapCustomer(salesOrder.Customer)
         };
         return customerOrder;
      }

      private static OngoingWarehouseAPI.Customer MapCustomer(Example.Webshop.WebshopEntities.Customer customer)
      {
         var ongoingCustomer = new OngoingWarehouseAPI.Customer
         {
            CustomerIdentification = CustomerIdentificationType.FullNameAndAddress,
            CustomerOperation = CustomerOperation.CreateOrUpdate,
            Name = customer.Name,
            Address = customer.StreetAdress,
            City = customer.PostalAdress,
            PostCode = customer.PostalCode,
            CountryCode = customer.CountryISO3166Code
         };
         return ongoingCustomer;
      }
   }
}
