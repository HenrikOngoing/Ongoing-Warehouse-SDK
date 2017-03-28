using System.Collections.Generic;

namespace OngoingWarehouse.Sdk.Example.WebshopEntities
{
   public class SalesOrder
   {
      public string OrderNumber { get; set; }
      public IEnumerable<SalesOrderLine> Lines { get; set; }
      public Customer Customer { get; set; }
   }
}
