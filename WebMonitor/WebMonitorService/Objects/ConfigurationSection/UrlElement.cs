using System.Configuration;

namespace WebMonitorService.Objects
{
    public class UrlElement : ConfigurationElement
    {
        [ConfigurationProperty("url", IsKey = true, IsRequired = true)]
        public string Url
        {
            get
            {
                return (string)this["url"];
            }
        }
    }
}
