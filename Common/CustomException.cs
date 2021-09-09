using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class CustomException:Exception
    {
        public CustomException() : this(ExceptionType.UnknownError)
        {
        }
        public CustomException(ExceptionType type) : this(type, "something went Wrong")
        {
        }
        public CustomException(ExceptionType type,string message):this(type,message,null)
        {
        }
        public CustomException(ExceptionType type, string message,Exception ex) : base($"{type}-{message}",ex)
        {
        }
        
        

    }
}
