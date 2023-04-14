using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.WebApi.Logging
{
    public interface Ilog
    {
        void Information(string msg);
        void Warning(string msg);
        void Error(string msg);
        void Debug(string msg);
    }
}