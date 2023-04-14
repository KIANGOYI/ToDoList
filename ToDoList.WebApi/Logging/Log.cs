using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLog;

namespace ToDoList.WebApi.Logging
{
    public class Log
    {
        private static NLog.ILogger _logger = LogManager.GetCurrentClassLogger(); //Il permet d'utiliser les fonctionnalités de Nlog;
        public void Information(string msg){
            _logger.Info(msg);
        }
        public void Warning(string msg){
            _logger.Warn(msg);
        }
        public void Error(string msg){
            _logger.Error(msg);
        }
        public void Debug(string msg){
            _logger.Debug(msg);
        }
    }
}