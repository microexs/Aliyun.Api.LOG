﻿/*
 * Copyright (C) Alibaba Cloud Computing
 * All rights reserved.
 * 
 * 版权所有 （C）阿里云计算有限公司
 */

using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace Aliyun.LOG.Common.Authentication
{
    internal class HmacSHA1Signature : ServiceSignature
    {
        private Encoding _encoding = Encoding.UTF8;

        public override string SignatureMethod
        {
            get { return "HmacSHA1"; }
        }

        public override string SignatureVersion
        {
            get { return "1"; }
        }

        public HmacSHA1Signature()
        {
        }

        protected override string ComputeSignatureCore(string key, string data)
        {
            Debug.Assert(!string.IsNullOrEmpty(data));
            using (KeyedHashAlgorithm algorithm = new HMACSHA1())
            {
                algorithm.Key = _encoding.GetBytes(key);
                //var hash = algorithm.ComputeHash(_encoding.GetBytes(data));
                //var returnStr = new StringBuilder("");
                //for (int i = 0; i < hash.Length; i++)
                //{
                //    returnStr.Append(hash[i].ToString("X2").ToUpper());
                //}
                //return returnStr.ToString();
                return Convert.ToBase64String(algorithm.ComputeHash(_encoding.GetBytes(data)));
            }
            

            using (KeyedHashAlgorithm algorithm = KeyedHashAlgorithm.Create(
                this.SignatureMethod.ToString().ToUpperInvariant()))
            {
                algorithm.Key = _encoding.GetBytes(key.ToCharArray());
                return Convert.ToBase64String(
                    algorithm.ComputeHash(_encoding.GetBytes(data.ToCharArray())));
            }
        }

    }
}
