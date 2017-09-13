using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using WebMonitorService.Objects;

namespace WebMonitorService
{
    public partial class WebMonitorService : ServiceBase
    {
        private bool _isRunning = false;
        private System.Timers.Timer _timer;
        public WebMonitorService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                _timer = new System.Timers.Timer(Config.RunFrequencyInMilliseconds);
                _timer.Elapsed += Timer_Elapsed;               
                _timer.Start();
            }
            catch (Exception ex)
            {
                Common.SendErrorEmail(ex);
            }
        }   

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (!_isRunning)
            {
                _isRunning = true;
                WebMonitor.Execute();
                _isRunning = false;
            }                        
        }

        protected override void OnStop()
        {
        }
    }
}
