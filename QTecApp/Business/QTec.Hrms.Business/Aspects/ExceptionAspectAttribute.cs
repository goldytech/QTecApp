namespace QTec.Hrms.Business.Aspects
{
    using System;

    using NLog;

    using PostSharp.Aspects;

    /// <summary>
    ///  Represents Exception Aspect
    /// </summary>
    [Serializable]
    public class ExceptionAspectAttribute : OnExceptionAspect
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Method executed <b>after</b> the body of methods to which this aspect is applied,
        /// in case that the method resulted with an exception (i.e., in a <c>catch</c> block).
        /// </summary>
        /// <param name="args">Advice arguments.</param>
        public override void OnException(MethodExecutionArgs args)
        {
           var logMessage = string.Format("Error was thrown in method {0} . The error message is {1} Stack Trace is {2}", args.Method.Name, args.Exception.Message,args.Exception.StackTrace);
            logger.Error(logMessage);
            //args.ReturnValue = null;
            //args.FlowBehavior=FlowBehavior.
            base.OnException(args);
        }
    }
}
