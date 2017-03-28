using OngoingWarehouse.Sdk.OngoingWarehouseAPI;
using OngoingWarehouse.Sdk.Updaters;
using System;
using System.Collections.Generic;

namespace OngoingWarehouse.Sdk.Getters
{
   public class OrderGetter : OperationBase, IGetter<Order>
   {
      private readonly OrderGetterSettings _settings;

      public OrderGetter(ConnectionCredentials connectionCredentials, OrderGetterSettings settings) 
         : base(connectionCredentials)
      {
         _settings = settings;
      }

      public IEnumerable<Order> Get(DateTime lastExecutionTime)
      {
         var ongoingOrders = _soapService.GetOrders(lastExecutionTime, _settings.MinimumStatusToGet, _settings.MaximumStatusToGet);
         return ongoingOrders;
      }
   }
}
