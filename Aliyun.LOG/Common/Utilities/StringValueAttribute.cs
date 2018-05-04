/*
 * Copyright (C) Alibaba Cloud Computing
 * All rights reserved.
 * 
 * 版权所有 （C）阿里云计算有限公司
 */

namespace Aliyun.LOG.Common.Utilities
{
    /// <summary>
    /// The Attribute to mark a field that corresponds a string.
    /// </summary>
    internal sealed class StringValueAttribute : System.Attribute
    {
        public string Value { get; private set; }

        public StringValueAttribute(string value)
        {
            this.Value = value;
        }
    }
}
