using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace Titan.Blog.Infrastructure.Utility
{
    /// <summary>
    /// 通用静态方法帮助类
    /// </summary>
    public static class WeixinHelp
    {
        #region 加密
        /// <summary>
        /// 创建微信支付签名
        /// </summary>
        /// <param name="dic"></param>
        /// <param name="apiKey"></param>
        /// <param name="signType"></param>
        /// <returns></returns>
        public static string GenerateWxPaySignature(Dictionary<string, string> dic, string apiKey, WxPaySignType signType)
        {
            var arr = dic.OrderBy(z => z.Key).ToArray();
            string stringSign = string.Empty;

            foreach (var item in arr)
            {
                if (!string.IsNullOrEmpty(item.Value))
                {
                    stringSign += $"{item.Key}={item.Value}&";
                }
            }
            stringSign += $"key={apiKey}";

            string sign = string.Empty;
            switch (signType)
            {
                case WxPaySignType.MD5:
                    sign = WeixinHelp.MD5Encrypt(stringSign).ToUpper();
                    break;
                case WxPaySignType.SHA256:
                    sign = WeixinHelp.SHA256Encrypt(stringSign, apiKey).ToUpper();
                    break;
                default:
                    throw new Exception($"{signType.ToString()}不受支持");
            }

            return sign;
        }

        /// <summary>
        /// SHA1加密
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string SHA1Encrypt(string source)
        {
            SHA1 sha;
            ASCIIEncoding enc;
            string hash = "";
            sha = new SHA1CryptoServiceProvider();
            enc = new ASCIIEncoding();
            byte[] dataToHash = enc.GetBytes(source);
            byte[] dataHashed = sha.ComputeHash(dataToHash);
            hash = BitConverter.ToString(dataHashed).Replace("-", "");
            hash = hash.ToLower();
            return hash;
        }

        /// <summary>
        /// SHA256加密
        /// </summary>
        /// <param name="source"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string SHA256Encrypt(string source, string key)
        {
            using (HMACSHA256 sha256 = new HMACSHA256(Encoding.UTF8.GetBytes(key)))
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(source));
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    sb.Append(bytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }

        /// <summary>
        /// MD5加密（UTF-8编码）
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string MD5Encrypt(string source)
        {
            using (var md5 = MD5.Create())
            {
                var bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(source));

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    sb.Append(bytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
        #endregion

        /// <summary>
		/// XML转换为字典
		/// </summary>
		/// <param name="xml"></param>
		/// <returns></returns>
		public static Dictionary<string, string> Xml2Dictionary(string xml)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.LoadXml(xml);
            XmlElement root = xmlDoc.DocumentElement;
            foreach (XmlNode node in root.ChildNodes)
            {
                dictionary.Add(node.Name, node.InnerText);
            }

            return dictionary;
        }
    }

    /// <summary>
    /// 微信支付签名类型
    /// </summary>
    public enum WxPaySignType
    {
        /// <summary>
        /// MD5
        /// </summary>
        [Description("MD5")]
        MD5,

        /// <summary>
        /// SHA256
        /// </summary>
        [Description("HMAC-SHA256")]
        SHA256,
    }
}
