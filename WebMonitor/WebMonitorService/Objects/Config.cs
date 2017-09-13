using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace WebMonitorService.Objects
{
    public static class Config
    {
        private static int _minutesFromConfig;

        public static int RunFrequencyInMilliseconds
        {
            get
            {

                return ((WebMonitorServiceConfigurationSection)System.Configuration.ConfigurationManager.GetSection("webMonitorConfig")).TimerElapsedInMS;

            }
        }

        public static int MaxResponseDurationThresholdInMS
        {
            get
            {

                return ((WebMonitorServiceConfigurationSection)System.Configuration.ConfigurationManager.GetSection("webMonitorConfig")).MaxResponseDurationThresholdInMS;

            }
        }

        public static string EmailServer
        {
            get
            {

                return ((WebMonitorServiceConfigurationSection)System.Configuration.ConfigurationManager.GetSection("webMonitorConfig")).EmailServer;

            }
        }

        public static string EmailFromAddress
        {
            get
            {

                return ((WebMonitorServiceConfigurationSection)System.Configuration.ConfigurationManager.GetSection("webMonitorConfig")).EmailFromAddress;

            }
        }

        public static string SummaryEmailSubject
        {
            get
            {

                return ((WebMonitorServiceConfigurationSection)System.Configuration.ConfigurationManager.GetSection("webMonitorConfig")).SummaryEmailSubject;

            }
        }

        public static string ErrorEmailSubject
        {
            get
            {

                return ((WebMonitorServiceConfigurationSection)System.Configuration.ConfigurationManager.GetSection("webMonitorConfig")).ErrorEmailSubject;

            }
        }

        public static List<WebApplicationTest> WebApplications
        {
            get
            {
                UrlElementCollection list = ((WebMonitorServiceConfigurationSection)System.Configuration.ConfigurationManager.GetSection("webMonitorConfig")).Urls;
                 var newlist = list.Select(x => new WebApplicationTest { Url = x.Url }).ToList();
                 return (List<WebApplicationTest>)newlist;
                
            }
        }

        public static List<string> EmailAddresses
        {
            get
            {
                EmailElementCollection list = ((WebMonitorServiceConfigurationSection)System.Configuration.ConfigurationManager.GetSection("webMonitorConfig")).Emails;
                List<string> newlist = list.Select(x => x.Address).ToList();
                return newlist;

            }
        }

        public static List<int> ErrorCodes
        {
            get
            {
                ErrorCodeElementCollection list = ((WebMonitorServiceConfigurationSection)System.Configuration.ConfigurationManager.GetSection("webMonitorConfig")).ErrorCodes;
                List<int> newlist = list.Select(x => x.ErrorCode).ToList();
                return newlist;
            }
        }
    }
}
