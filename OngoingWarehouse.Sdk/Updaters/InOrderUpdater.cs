using OngoingWarehouse.Sdk.OngoingWarehouseAPI;
using System;

namespace OngoingWarehouse.Sdk.Updaters
{
   public class InOrderUpdater : OperationBase, IUpdater<InOrder>
   {
      public InOrderUpdater(ConnectionCredentials connectionCredentials) : base(connectionCredentials)
      {
      }

      public void Update(InOrder inOrder)
      {
         _soapService.UpdateOrCreatePurchaseOrder(inOrder);
      }
   }
}
