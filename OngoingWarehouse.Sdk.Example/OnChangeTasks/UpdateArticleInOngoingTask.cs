using OngoingWarehouse.Sdk.Example.WebshopEntities;
using OngoingWarehouse.Sdk.OngoingWarehouseAPI;
using OngoingWarehouse.Sdk.Updaters;

namespace OngoingWarehouse.Sdk.Example
{
   /**
    * Execute the run method when a change of an article in the webshops article registry has been performed.
    */
   public class UpdateArticleInOngoingTask
   {
      public void Run(InventoryArticle inventoryArticle)
      {
         var updater = new ArticleUpdater(WebshopWmsCredentials.Credentials);
         var ongoingArticle = MapToOngoingType(inventoryArticle);
         updater.Update(ongoingArticle);
      }

      private ArticleDefinition MapToOngoingType(InventoryArticle inventoryArticle)
      {
         var articleDefinition = new ArticleDefinition()
         {
            ArticleOperation = ArticleOperation.CreateOrUpdate,
            ArticleNumber = inventoryArticle.Number,
            ProductCode = inventoryArticle.Id.ToString(),
            //Use the following if article numbers are unique in the webshop.
            ArticleIdentification = ArticleIdentificationType.ArticleNumber,
            //if articles numbers are not unique in the webshop use:
            //ArticleIdentification = ArticleIdentificationType.ProductCode,
            ArticleName = inventoryArticle.Name
         };
         return articleDefinition;
      }
   }
}
