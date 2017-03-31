namespace OngoingWarehouse.Sdk.Example.Webshop
{
   public static class WebshopWmsCredentials
   {
      public static ConnectionCredentials Credentials { get; } = new ConnectionCredentials()
      {
         GoodsOwner = new GoodsOwner()
         {
            Id = 123,
            Name = "Name of the the webshop and the goodsowner in Ongoing WMS. Sometimes denoted as GoodsOwnerCode."
         },
         SystemName = "The name of your logistics provider.",
         User = new User()
         {
            Name = "Name of the account.",
            Password = "Password for the account."
         }
      };
   }
}
