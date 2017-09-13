using System.Collections.Generic;
using System.Configuration;

namespace WebMonitorService.Objects
{
    public class EmailElementCollection : ConfigurationElementCollection, IEnumerable<EmailElement>
    {
        public new IEnumerator<EmailElement> GetEnumerator()
        {
            foreach (var key in this.BaseGetAllKeys())
            {
                yield return (EmailElement)BaseGet(key);
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new EmailElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((EmailElement)element).Address;
        }
    }
}
