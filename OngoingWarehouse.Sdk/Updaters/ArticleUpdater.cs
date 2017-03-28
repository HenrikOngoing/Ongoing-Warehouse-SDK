using OngoingWarehouse.Sdk.OngoingWarehouseAPI;

namespace OngoingWarehouse.Sdk.Updaters
{
   public class ArticleUpdater : OperationBase, IUpdater<ArticleDefinition>
   {
      public ArticleUpdater(ConnectionCredentials connectionCredentials) : base(connectionCredentials)
      {
      }

      public void Update(ArticleDefinition article)
      {
         _soapService.UpdateOrCreateArticle(article);
      }
   }
}
