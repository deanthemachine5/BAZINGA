using System.Collections.Generic;
using System.Configuration;

namespace WebMonitorService.Objects
{
    public class ErrorCodeElementCollection : ConfigurationElementCollection, IEnumerable<ErrorCodeElement>
    {
        public new IEnumerator<ErrorCodeElement> GetEnumerator()
        {
            foreach (var key in this.BaseGetAllKeys())
            {
                yield return (ErrorCodeElement)BaseGet(key);
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new ErrorCodeElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ErrorCodeElement)element).ErrorCode;
        }
    }
}
