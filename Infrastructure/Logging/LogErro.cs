using Infrastructure.DbConnection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Logging
{
    public class LogErro
    {

        public LogErro(string message, string stackTrace)
        {
            IdLog = Guid.NewGuid().ToString();
            Message = message;
            StackTrace = stackTrace;
            TimeStamp = ((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds();
        }

        public string IdLog { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public long TimeStamp { get; set; }
        
    }
}
