using OngoingWarehouse.Sdk.Example.Webshop;
using OngoingWarehouse.Sdk.Example.Webshop.WebshopEntities;
using OngoingWarehouse.Sdk.Getters;
using OngoingWarehouse.Sdk.OngoingWarehouseAPI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OngoingWarehouse.Sdk.Example.ScheduledTasks.Webshop
{
   public class GetOrdersFromOngoingTask : ScheduledTask
   {
      protected override bool Run()
      {
         const int pickedOrderStatus = 400;
         const int pickedUpOrderStatus = 500;
         var settings = new Updaters.OrderGetterSettings()
         {
            //These settings are configurable in the Ongoing Warehouse WMS and could therefore vary. 
            MinimumStatusToGet = pickedOrderStatus,
            MaximumStatusToGet = pickedUpOrderStatus
         };
         var orderGetter = new OrderGetter(WebshopWmsCredentials.Credentials, settings);
         var lastSuccessfulExecution = GetLastSuccessfulExecution();
         var ongoingOrders = orderGetter.Get(lastSuccessfulExecution);
         var salesOrders = ongoingOrders.Select(MapToWebshopType);
         var success = UpdateSalesOrderInWebshop(salesOrders);
         return success;
      }

      private SalesOrder MapToWebshopType(Order order)
      {
         var salesOrder = new SalesOrder()
         {
            OrderNumber = order.OrderInfo.GoodsOwnerOrderNumber,
            Lines = order.PickedOrderLines.Select(pickedOrderLine => 
               new SalesOrderLine()
               {
                  ArticleNumber = pickedOrderLine.Article.ArticleNumber,
                  //Since this is an example for a simple webshop it is assumed that no partial items exists.
                  DeliveredQuantity = (int) pickedOrderLine.PickedNumberOfItems
               })
         };
         return salesOrder;
      }

      private bool UpdateSalesOrderInWebshop(IEnumerable<SalesOrder> salesOrders)
      {
         throw new NotImplementedException("Insert code for updating sales order into the webshop here.");
      }
   }
}
