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
        /// </summary>
        /// <value>
        /// The type of the result.
        /// </value>
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
