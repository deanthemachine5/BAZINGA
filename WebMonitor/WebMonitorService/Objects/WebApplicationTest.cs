using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebMonitorService.Objects
{
    public class WebApplicationTest
    {
        public string Url { get; set; }
        public int ResponseCode { get; set; }
        public int ResponseDuration { get; set; }
        public WebHeaderCollection ResponseHeaders { get; set; }
    }
}
