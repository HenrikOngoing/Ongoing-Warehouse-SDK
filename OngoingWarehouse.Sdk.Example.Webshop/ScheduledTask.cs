using System;

namespace OngoingWarehouse.Sdk.Example.Webshop
{
   public abstract class ScheduledTask
   {
      public void RunAndRecordDateTime()
      {
         var startExecutionTime = DateTime.Now;
         var success = Run();
         if (success)
         {
            SetLastSuccessfulExecutionTime(startExecutionTime);
         }
      }

      protected abstract bool Run();

      protected DateTime SetLastSuccessfulExecutionTime(DateTime lastSuccessfulExecutionTime)
      {
         throw new NotImplementedException("Save the date of last successful execution.");
      }

      protected DateTime GetLastSuccessfulExecution()
      {
         throw new NotImplementedException("Insert code for getting date and time of last successful execution.");
      }
   }
}
