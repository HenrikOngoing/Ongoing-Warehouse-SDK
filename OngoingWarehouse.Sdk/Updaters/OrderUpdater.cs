using OngoingWarehouse.Sdk.OngoingWarehouseAPI;

namespace OngoingWarehouse.Sdk.Updaters
{
   public class OrderUpdater : OperationBase, IUpdater<CustomerOrder>
   {
      public OrderUpdater(ConnectionCredentials connectionCredentials) : base(connectionCredentials)
      {
      }

      public void Update(CustomerOrder customerOrder)
      {
         _soapService.UpdateOrCreateOrder(customerOrder);
      }
   }
}
