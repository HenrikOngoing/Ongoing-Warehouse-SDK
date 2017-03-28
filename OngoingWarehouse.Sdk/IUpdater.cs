using System;

namespace OngoingWarehouse.Sdk
{
   public interface IUpdater<OngoingType>
   {
      void Update(OngoingType t);
   }
}
