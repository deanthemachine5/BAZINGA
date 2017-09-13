using System.Configuration;

namespace WebMonitorService.Objects
{
    public class WebMonitorServiceConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("emailServer", IsRequired = true)]
        public string EmailServer
        {
            get
            {
                return this["emailServer"].ToString();
            }
        }

        [ConfigurationProperty("emailFromAddress", IsRequired = true)]
        public string EmailFromAddress
        {
            get
            {
                return this["emailFromAddress"].ToString();
            }
        }

        [ConfigurationProperty("summaryEmailSubject", IsRequired = true)]
        public string SummaryEmailSubject
        {
            get
            {
                return this["summaryEmailSubject"].ToString();
            }
        }

        [ConfigurationProperty("errorEmailSubject", IsRequired = true)]
        public string ErrorEmailSubject
        {
            get
            {
                return this["errorEmailSubject"].ToString();
            }
        }

        [ConfigurationProperty("timerElapseInMS", IsRequired = true)]
        public int TimerElapsedInMS
        {
            get
            {
                return (int)this["timerElapseInMS"];
            }
        }

        [ConfigurationProperty("maxResponseDurationThresholdInMS", IsRequired = true)]
        public int MaxResponseDurationThresholdInMS
        {
            get
            {
                return (int)this["maxResponseDurationThresholdInMS"];
            }
        }

        [ConfigurationProperty("urls", IsRequired = true)]
        public UrlElementCollection Urls
        {
            get
            {
                return (UrlElementCollection)this["urls"];
            }
        }

        [ConfigurationProperty("errorCodes", IsRequired = true)]
        public ErrorCodeElementCollection ErrorCodes
        {
            get
            {
                return (ErrorCodeElementCollection)this["errorCodes"];
            }
        }

        [ConfigurationProperty("emails", IsRequired = true)]
        public EmailElementCollection Emails
        {
            get
            {
                return (EmailElementCollection)this["emails"];
            }
        }

    }    
}
