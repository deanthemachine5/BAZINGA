using System.Configuration;

namespace WebMonitorService.Objects
{
    public class ErrorCodeElement : ConfigurationElement
    {
        [ConfigurationProperty("code", IsKey = true, IsRequired = true)]
        public int ErrorCode
        {
            get
            {
                return (int)this["code"];
            }
        }
    }
}
