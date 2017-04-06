using System;
using System.Collections.Generic;
using OngoingWarehouse.Sdk.OngoingWarehouseAPI;

namespace OngoingWarehouse.Sdk.Getters
{
   public class InOrderGetter : OperationBase, IGetter<ReceivedInOrder>
   {
      private readonly InOrderGetterSettings _inOrderGetterSettings;

      public InOrderGetter(ConnectionCredentials connectionCredentials, InOrderGetterSettings inOrderGetterSettings)
         : base(connectionCredentials)
      {
         _inOrderGetterSettings = inOrderGetterSettings;
      }

      public IEnumerable<ReceivedInOrder> Get(DateTime lastExecutionTime)
      {
         var ongoingInOrders = _soapService.GetInOrders(lastExecutionTime, _inOrderGetterSettings.MinimumInOrderStatusToGet, _inOrderGetterSettings.MaximumInOrderStatusToGet);
         return ongoingInOrders;
      }
   }
}
