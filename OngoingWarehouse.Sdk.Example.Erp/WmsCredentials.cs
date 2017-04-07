namespace OngoingWarehouse.Sdk.Example.Erp
{
   internal static class WmsCredentials
   {
      internal static ConnectionCredentials Credentials { get; } = new ConnectionCredentials
      {
         GoodsOwner = new GoodsOwner()
         {
            Id = 3210,
            Name = "The name of the goodsowner in Ongoing WMS. Sometimes denoted as GoodsOwnerCode."
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
