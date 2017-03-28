using OngoingWarehouse.Sdk.Example.WebshopEntities;
using OngoingWarehouse.Sdk.Getters;
using OngoingWarehouse.Sdk.OngoingWarehouseAPI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OngoingWarehouse.Sdk.Example.ScheduledTasks
{
   /**
    * Execute this task periodicaly. For example every 15 minutes the get the stock from the warehouse.
    * When task is done: save the the start time of the task in a database and use it as the query parameter next time.
    */
   public class GetStockFromOngoingTask : ScheduledTask
   {
      protected override bool Run()
      {
         var stockGetter = new StockGetter<Stock>(WebshopWmsCredentials.Credentials);
         var lastSuccesfulExecution = GetLastSuccessfulExecution();
         var inventoryLines = stockGetter.Get(lastSuccesfulExecution);
         var webshopType = inventoryLines.Select(MapToWebshopType);
         var success = UpdateStockInWebshop(webshopType);
         return success;
      }

      private Stock MapToWebshopType(InventoryLine inventoryLine)
      {
         var stockItem = new Stock()
         {
            ArticleNumber = inventoryLine.Article.ArticleNumber,
            SellableStock = inventoryLine.NumberOfItems - inventoryLine.NumberOfBookedItems
         };
         return stockItem;
      }

      private bool UpdateStockInWebshop(IEnumerable<Stock> stockItem)
      {
         throw new NotImplementedException("Insert code for updating stock into the webshop here.");
      }
   }
}
