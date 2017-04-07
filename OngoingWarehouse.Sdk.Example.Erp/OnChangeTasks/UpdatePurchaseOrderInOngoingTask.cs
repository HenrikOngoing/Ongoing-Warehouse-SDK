using OngoingWarehouse.Sdk.Example.Erp.ErpEntities;
using OngoingWarehouse.Sdk.Updaters;
using OngoingWarehouse.Sdk.OngoingWarehouseAPI;
using System.Linq;

namespace OngoingWarehouse.Sdk.Example.Erp.OnChangeTasks
{
   /**
    * Execute this task when a new purchase order is created in the ERP system.
    **/
   public class UpdatePurchaseOrderInOngoingTask
   {
      public void Run(PurchaseOrder purchaseOrder)
      {
         var updater = new InOrderUpdater(WmsCredentials.Credentials);
         var ongoingInOrder = MapToOngoingType(purchaseOrder);
         updater.Update(ongoingInOrder);
      }

      private InOrder MapToOngoingType(PurchaseOrder purchaseOrder)
      {
         var inOrder = new InOrder
         {
            InOrderInfo = new InOrderInfoClass
            {
               InOrderOperation = InOrderOperation.CreateOrUpdate,
               InOrderIdentification = InOrderIdentificationType.GoodsOwnerOrderNumber,
               GoodsOwnerOrderNumber = purchaseOrder.Id.ToString()
            },
            InOrderLines = purchaseOrder.Lines.Select(MapToOngoingType).ToArray()
         };
         return inOrder;
      }

      private InOrderLine MapToOngoingType(PurchaseOrderLine purchaseOrderLine)
      {
         var inOrderLine = new InOrderLine()
         {
            ArticleIdentification = ArticleIdentificationType.ArticleNumber,
            ArticleNumber = purchaseOrderLine.ArticleNumber.ToString(),
            OrderLineIdentification = OrderLineIdentificationType.ExternalOrderLineCode,
            ExternalOrderLineCode = purchaseOrderLine.LineNumber.ToString(),
            NumberOfItems = purchaseOrderLine.Quantity
         };
         return inOrderLine;
      }
   }
}
