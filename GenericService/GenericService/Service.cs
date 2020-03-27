using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace GenericService
{
    partial class Service : ServiceBase
    {
        private Logger logger = LogManager.GetLogger("MyService");

        public Service()
        {
            InitializeComponent();
            watcher.Path = Properties.Settings.Default.Root;
            watcher.Changed += Watcher_Event;
            watcher.Created += Watcher_Event;
            watcher.Deleted += Watcher_Event;
            watcher.Renamed += Watcher_Event;
        }

        private void Watcher_Event(object sender, System.IO.FileSystemEventArgs e)
        {
            try
            {
                logger.Info($"{e.ChangeType};{e.FullPath}");
            }
            catch (Exception exception)
            {
                logger.Error(exception);
            }
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                watcher.EnableRaisingEvents = true;
                EventLog.WriteEntry("Сервис запущен", EventLogEntryType.Information, 1);
                logger.Info("Сервис запущен");
            }
            catch (Exception e)
            {
                logger.Fatal(e);
            }
        }

        protected override void OnStop()
        {
            try
            {
                watcher.EnableRaisingEvents = false;
                EventLog.WriteEntry("Сервис остановлен", EventLogEntryType.Information, 2);
                logger.Info("Сервис остановлен");
            }
            catch (Exception e)
            {
                logger.Error(e);
            }
        }

        protected override void OnPause()
        {
            try
            {
                watcher.EnableRaisingEvents = false;
                EventLog.WriteEntry("Сервис приостановлен", EventLogEntryType.Information, 3);
                logger.Info("Сервис приостановлен");
            }
            catch (Exception e)
            {
                logger.Error(e);
            }
        }

        protected override void OnContinue()
        {
            try
            {
                watcher.EnableRaisingEvents = true;
                EventLog.WriteEntry("Сервис возобновлен", EventLogEntryType.Information, 4);
                logger.Info("Сервис возобновлен");
            }
            catch (Exception e)
            {
                logger.Error(e);
            }
        }
    }
}
