using OngoingWarehouse.Sdk.Getters;
using System;
using System.Linq;
using OngoingWarehouse.Sdk.OngoingWarehouseAPI;
using OngoingWarehouse.Sdk.Example.Erp.ErpEntities;
using System.Collections.Generic;

namespace OngoingWarehouse.Sdk.Example.Erp.ScheduledTasks
{
   /**
    * Execute this task periodicaly. For example every 15 minutes to get the received purchase orders from the warehouse.
    * When task is done: save the the start time of the task in a database and use it as the query parameter next time.
    */
   public class GetPurchaseOrdersInOngoingTask : ScheduledTask
   {
      protected override bool Run()
      {
         const int deflectionOrderStatus = 400;
         const int receivedOrderStatus = 500;
         var inOrderGetterSettings = new InOrderGetterSettings
         {
            MinimumInOrderStatusToGet = deflectionOrderStatus,
            MaximumInOrderStatusToGet = receivedOrderStatus
         };
         var inOrderGetter = new InOrderGetter(WmsCredentials.Credentials, inOrderGetterSettings);
         var lastSuccessfulExecution = GetLastSuccessfulExecution();
         var ongoingInOrders = inOrderGetter.Get(lastSuccessfulExecution);
         var purchaseOrder = ongoingInOrders.Select(MapToErpType);
         var success = UpdatePurchaseOrdersInErp(purchaseOrder);
         return success;
      }

      private PurchaseOrder MapToErpType(ReceivedInOrder arg)
      {
         int erpId;
         if (!int.TryParse(arg.InOrderInfo.GoodsOwnerOrderNumber, out erpId))
         {
            throw new Exception($"{nameof(arg.InOrderInfo.GoodsOwnerOrderNumber)} is not an integer. Value: {arg.InOrderInfo.GoodsOwnerOrderNumber}");
         }
         var purchaseOrder = new PurchaseOrder
         {
            Id = erpId,
            Lines = arg.ReceivedInOrderLines.Select(MapToErpType)
         };
         return purchaseOrder;
      }

      private PurchaseOrderLine MapToErpType(ReceivedInOrderLine receivedInOrderLine)
      {
         int lineNumber;
         if (!int.TryParse(receivedInOrderLine.ExternalOrderLineCode, out lineNumber))
         {
            throw new Exception($"{nameof(receivedInOrderLine.ExternalOrderLineCode)} is not an integer. Value: {receivedInOrderLine.ExternalOrderLineCode}");
         }
         var purchaseOrderLine = new PurchaseOrderLine()
         {
            ArticleNumber = receivedInOrderLine.Article.ArticleNumber,
            LineNumber = lineNumber,
            Quantity = (int)receivedInOrderLine.ReceivedNumberOfItems
         };
         return purchaseOrderLine;
      }

      private bool UpdatePurchaseOrdersInErp(IEnumerable<PurchaseOrder> purchaseOrder)
      {
         throw new NotImplementedException("Insert code for sending the updates to the ERP here.");
      }
   }
}
