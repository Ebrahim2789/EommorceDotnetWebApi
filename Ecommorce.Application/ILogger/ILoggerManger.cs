using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommorce.Application.ILogger
{
    public interface ILoggerManger
    {

         void LogError(string message);
         void LogInfo(string message);

          void LogWarn(string message);
        void LogDebug(string message);

    }
}
 