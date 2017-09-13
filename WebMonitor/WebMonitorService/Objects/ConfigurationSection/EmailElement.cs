using System.Configuration;

namespace WebMonitorService.Objects
{
    public class EmailElement : ConfigurationElement
    {
        [ConfigurationProperty("address", IsKey = true, IsRequired = true)]
        public string Address
        {
            get
            {
                return (string)this["address"];
            }
        }
    }
}
