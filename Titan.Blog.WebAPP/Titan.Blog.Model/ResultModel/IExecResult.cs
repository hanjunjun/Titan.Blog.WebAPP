namespace Titan.Blog.Model.ResultModel
{
    /// <summary>
    /// 执行结果
    /// </summary>
    /// <typeparam name="TResultType">执行结果类型</typeparam>
    /// <typeparam name="TData">执行结果数据</typeparam>
    public interface IExecResult<TResultType, TData>
    {
        /// <summary>
        /// 结果类型
        /// 0=操作没有引发任何变化，提交取消。
        /// 1=操作成功。
        /// 2=操作引发错误。
        /// 3=指定参数的数据不存在。
        /// 4=输入信息验证失败。
        /// 5=登录失效。
        /// 6=身份认证信息错误。
        /// 7=未登录。
        /// </summary>
        TResultType ResultType { get; set; }

        /// <summary>
        /// 返回消息
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        string Message { get; set; }

        /// <summary>
        /// 结果数据
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        TData Data { get; set; }
    }
}
