namespace Titan.Blog.Model.ResultModel
{
    /// <summary>
    /// 执行结果
    /// </summary>
    /// <typeparam name="TResultType">执行结果类型的类型</typeparam>
    public abstract class ExecResult<TResultType> : ExecResult<TResultType, object>
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        protected ExecResult()
            : this(default(TResultType))
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_type"></param>
        protected ExecResult(TResultType _type)
            : this(_type, null, null)
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_type"></param>
        /// <param name="_msg"></param>
        protected ExecResult(TResultType _type, string _msg)
            : this(_type, _msg, null)
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_type"></param>
        /// <param name="_msg"></param>
        /// <param name="_data"></param>
        protected ExecResult(TResultType _type, string _msg, object _data)
        {
            ResultType = _type;
            Message = _msg;
            Data = _data;
        }
    }

    /// <summary>
    /// 执行结果
    /// </summary>
    /// <typeparam name="TResultType">执行结果类型的类型</typeparam>
    /// <typeparam name="TData">执行结果数据的类型</typeparam>
    public abstract class ExecResult<TResultType, TData> : IExecResult<TResultType, TData>
    {
        /// <summary>
        /// 结果类型
        /// </summary>
        public virtual TResultType ResultType { get; set; }

        /// <summary>
        /// 结果附带数据
        /// </summary>
        public virtual TData Data { get; set; }

        /// <summary>
        /// 结果信息
        /// </summary>
        public virtual string Message { get; set; }

        /// <summary>
        /// 无参构造函数
        /// </summary>
        protected ExecResult()
            : this(default(TResultType))
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_type"></param>
        protected ExecResult(TResultType _type)
            : this(_type, null, default(TData))
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_type"></param>
        /// <param name="_msg"></param>
        protected ExecResult(TResultType _type, string _msg)
            : this(_type, _msg, default(TData))
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_type"></param>
        /// <param name="_msg"></param>
        /// <param name="_data"></param>
        protected ExecResult(TResultType _type, string _msg, TData _data)
        {
            ResultType = _type;
            Message = _msg;
            Data = _data;
        }
    }
}