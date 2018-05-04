using System;
using System.Collections.Generic;

namespace Aliyun.LOG.Request
{
    public abstract class LogStoreRequest : LogRequest
    {
        private String _logstore;

        /// <summary>
        /// The logstore name
        /// </summary>
        public String Logstore
        {
            get { return _logstore; }
            set { _logstore = value; }
        }
        public LogStoreRequest(String project, String logstore)
            : base(project)
        {
            Logstore = logstore;
        }
        abstract public void AddSpecParamsTo(IDictionary<String, String> dic);
        abstract public void AddSpecHeadersTo(IDictionary<String, String> dic);
    }
}
