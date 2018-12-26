using System;
using System.Text;

namespace Titan.Blog.Infrastructure.Utility
{
    /// <summary>
    /// 公共方法
    /// </summary>
    public static class UtilityHelp
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appid"></param>
        /// <param name="appSecret"></param>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        public static string AccessToken(string appid, string appSecret, string timestamp)
        {
            var accessToken =
                Md5Helper.Md5Hex($"{appid}{appSecret}{timestamp}");
            return accessToken;
        }

        /// <summary>
        /// Guid转Long
        /// </summary>
        /// <param name="strGuid"></param>
        /// <returns></returns>
        public static long GuidToLong(string strGuid)
        {
            var buffer = new Guid(strGuid).ToByteArray();
            return BitConverter.ToInt64(buffer, 0);
        }

        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        public static long GetTimeStamp()
        {
            //return (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
            DateTime startUtc = new DateTime(1970, 1, 1);
            DateTime nowUtc = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Utc);
            return (long)(nowUtc - startUtc).TotalSeconds;
        }

        /// <summary>
        /// 将时间戳转换为日期类型
        /// </summary>
        /// <param name="longDateTime"></param>
        /// <returns></returns>
        public static DateTime LongDateTimeToDateTime(long longDateTime)
        {
            //用来格式化long类型时间的,声明的变量
            var start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var date = start.AddMilliseconds(longDateTime).ToLocalTime();
            return date;

        }

        #region 距离
        private static double EARTH_RADIUS = 6371.0;//km 地球半径 平均值，千米

        private static double HaverSin(double theta)
        {
            var v = Math.Sin(theta / 2);
            return v * v;
        }

        /// <summary>
        /// 将角度换算为弧度。
        /// </summary>
        /// <param name="degrees">角度</param>
        /// <returns>弧度</returns>
        private static double ConvertDegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }

        private static double ConvertRadiansToDegrees(double radian)
        {
            return radian * 180.0 / Math.PI;
        }

        /// <summary>
        /// 给定的经度1，纬度1；经度2，纬度2. 计算2个经纬度之间的距离。
        /// </summary>
        /// <param name="lat1">经度1</param>
        /// <param name="lon1">纬度1</param>
        /// <param name="lat2">经度2</param>
        /// <param name="lon2">纬度2</param>
        /// <returns>距离（公里、千米）</returns>
        public static double Distance(double lon1, double lat1, double lon2, double lat2)
        {
            //用haversine公式计算球面两点间的距离。
            //经纬度转换成弧度
            lat1 = ConvertDegreesToRadians(lat1);
            lon1 = ConvertDegreesToRadians(lon1);
            lat2 = ConvertDegreesToRadians(lat2);
            lon2 = ConvertDegreesToRadians(lon2);

            //差值
            var vLon = Math.Abs(lon1 - lon2);
            var vLat = Math.Abs(lat1 - lat2);

            //h is the great circle distance in radians, great circle就是一个球体上的切面，它的圆心即是球心的一个周长最大的圆。
            var h = HaverSin(vLat) + Math.Cos(lat1) * Math.Cos(lat2) * HaverSin(vLon);

            var distance = 2 * EARTH_RADIUS * Math.Asin(Math.Sqrt(h));

            return distance;
        }
        #endregion

        #region 订单
        /// <summary>
        /// GUID转短（16位）字符串
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static string Guid2ShortString(Guid guid)
        {
            long i = 1;
            foreach (byte b in guid.ToByteArray())
            {
                i *= ((int)b + 1);
            }
            return string.Format("{0:x}", i - DateTime.Now.Ticks);
        }

        private static char[] numbers = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private static Random random = new Random();
        /// <summary>
        /// 生成随机串
        /// </summary>
        /// <param name="length">长度</param>
        /// <returns></returns>
        public static string GenerateNonceStr(int length = 14)
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < length; i++)
            {
                var index = random.Next(0, 10);
                sb.Append(numbers[index]);
            }

            return sb.ToString();
        }

        /// <summary>
        /// 生成订单号
        /// </summary>
        /// <param name="billCreateTime">订单创建时间</param>
        /// <param name="platform">订单平台（0：平台，1：APP，2：微信）</param>
        /// <param name="tradeSource">交易来源（0：预约缴费，1：入院缴费，2：月度缴费，3：欠费缴费，4：预交费，5：退住缴费，6：初始费用充值）</param>
        /// <param name="tradeType">订单交易类型（0：微信，1：支付宝）</param>
        /// <param name="testMode">测试模式（1：测试模式，0：正式模式）</param>
        /// <returns>订单号规则：(yyyyMMddHHmmss:14)(平台:1)(来源:1)(类型:1)(模式:1)(随机串:14)</returns>
        public static string GenerateBillNo(DateTime billCreateTime, int platform, int tradeSource, int tradeType, bool testMode)
        {
            var nonceStr = GenerateNonceStr();
            return $"{billCreateTime.ToString("yyyyMMddHHmmss")}{platform}{tradeSource}{tradeType}{(testMode ? 1 : 0)}{nonceStr}";
        }
        #endregion

    }
}