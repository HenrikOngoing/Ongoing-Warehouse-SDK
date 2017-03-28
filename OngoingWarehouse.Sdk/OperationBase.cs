namespace OngoingWarehouse.Sdk
{
   public abstract class OperationBase
   {
      internal readonly SoapService _soapService;

      internal OperationBase(ConnectionCredentials connectionCredentials)
      {
         _soapService = new SoapService(connectionCredentials);
      }
   }
}
