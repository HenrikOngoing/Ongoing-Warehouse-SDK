namespace OngoingWarehouse.Sdk
{
   public class ConnectionCredentials
   {
      public string SystemName { get; set; }
      public GoodsOwner GoodsOwner { get; set; }
      public User User { get; set; }
   }

   public class User
   {
      public string Name { get; set; }
      public string Password { get; set; }
   }

   public class GoodsOwner
   {
      public string Name { get; set; }
      public int Id { get; set; }
   }
}
