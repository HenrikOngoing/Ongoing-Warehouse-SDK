using System.Collections.Generic;
using System;
using OngoingWarehouse.Sdk.OngoingWarehouseAPI;

namespace OngoingWarehouse.Sdk.Getters
{
   public class StockGetter<T> : OperationBase, IGetter<InventoryLine>
   {
      public StockGetter(ConnectionCredentials connectionCredentials) : base(connectionCredentials)
      {
      }

      public IEnumerable<InventoryLine> Get(DateTime lastExecutionTime)
      {
         var ongoingInventory = _soapService.GetStock(lastExecutionTime);
         return ongoingInventory;
      }
   }
}
