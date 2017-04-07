using System.Collections.Generic;

namespace OngoingWarehouse.Sdk.Example.Erp.ErpEntities
{
   public class PurchaseOrder
   {
      public int Id { get; set; }
      public IEnumerable<PurchaseOrderLine> Lines { get; set; }
   }
}
