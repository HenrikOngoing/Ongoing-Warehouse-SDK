using System;
using System.Collections.Generic;

namespace OngoingWarehouse.Sdk
{
   public interface IGetter<OngoingType>
   {
      IEnumerable<OngoingType> Get(DateTime lastExecutionTime);
   }
}
