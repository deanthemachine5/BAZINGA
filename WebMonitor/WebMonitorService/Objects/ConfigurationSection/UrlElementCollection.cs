using System.Collections.Generic;
using System.Configuration;

namespace WebMonitorService.Objects
{
    public class UrlElementCollection : ConfigurationElementCollection, IEnumerable<UrlElement>
    {
        public new IEnumerator<UrlElement> GetEnumerator()
        {
            foreach (var key in this.BaseGetAllKeys())
            {
                yield return (UrlElement)BaseGet(key);
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new UrlElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((UrlElement)element).Url;
        }
    }
}
