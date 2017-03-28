using System;

namespace OngoingWarehouse.Sdk
{
   public class SdkException : Exception
   {
      internal SdkException(string message) : base(message)
      {
      }
   }
}
