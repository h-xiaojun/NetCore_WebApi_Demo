namespace PDM.Models
{
    /// <summary>
    /// 消息实体类
    /// </summary>
    public class ResultModel
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; set; } = false;

        /// <summary>
        /// http状态码
        /// </summary>
        public int StatusCode { get; set; } = 200;

        /// <summary>
        /// 错误消息
        /// </summary>
        public string Msg { get; set; } = string.Empty;

        /// <summary>
        /// 数据
        /// </summary>
        public object Data { get; set; }
    }

    public class Result
    {
        public static ResultModel Fail(int status)
        {
            string msg = string.Empty;
            switch (status)
            {
                case 404:
                    msg = "地址错误";
                    break;
                case 500:
                    msg = "服务器内部错误";
                    break;
                case 401:
                    msg = "未授权";
                    break;
                case 403:
                    msg = "拒绝访问";
                    break;
                default:
                    msg = "未知错误";
                    break;
            }
            return Fail(status, msg);
        }
        public static ResultModel Fail(int status, string msg)
        {
            return new ResultModel()
            {
                StatusCode = status,
                Msg = msg
            };
        }
        public static ResultModel Successful(object value)
        {
            return new ResultModel() { Data = value, Success = true };
        }
    }
}
