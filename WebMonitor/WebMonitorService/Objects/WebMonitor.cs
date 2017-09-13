using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace WebMonitorService.Objects
{
    public static class WebMonitor
    {
        public static void Execute()
        {
            List<WebApplicationTest> appList = Config.WebApplications;
            List<WebApplicationTest> errorList = new List<WebApplicationTest>();
            List<WebApplicationTest> warningList = new List<WebApplicationTest>();
            List<int> errorCodes = Config.ErrorCodes;
            DateTime requestStart = DateTime.Now;
            DateTime requestEnd;

            foreach (WebApplicationTest app in appList)
            {
                try
                {
                    requestStart = DateTime.Now;
                    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(app.Url);
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        requestEnd = DateTime.Now;
                        app.ResponseCode = (int)response.StatusCode;
                    }

                    // check the response time to make sure its acceptable. Add to warnings list if above config threshold
                    app.ResponseDuration = requestEnd.Subtract(requestStart).Milliseconds;
                    if (app.ResponseDuration > Config.MaxResponseDurationThresholdInMS)
                    {
                        warningList.Add(app);
                    }
                }

                catch (WebException ex)
                {
                    // anything other than a 200 will end up here

                    requestEnd = DateTime.Now;
                    if (ex.Response != null)
                    {
                        app.ResponseCode = (int)((HttpWebResponse)ex.Response).StatusCode;
                        app.ResponseHeaders = ex.Response.Headers;
                        // check if response code is one we care about. Add it to the list
                        if (errorCodes.Any(x => x == app.ResponseCode))
                        {
                            errorList.Add(app);
                        }

                        continue;
                    }
                    else
                    {
                        // did not get a response, add to error list and go ahead and send the exception details as well
                        Common.SendErrorEmail(ex, app.Url);
                        errorList.Add(app);
                    }
                }

                catch (Exception ex) 
                {
                    // unknown exception
                    Common.SendErrorEmail(ex);
                    requestEnd = DateTime.Now;
                    // eat the exception and move on
                }                
            }

            // send out error report (if any)
            if (errorList.Count > 0)
            {
                Common.SendErrorSummaryReport(errorList);
            }
 
            if (warningList.Count > 0)
            {
                Common.SendWarningSummaryReport(warningList);
            }
        }       
    }
}
