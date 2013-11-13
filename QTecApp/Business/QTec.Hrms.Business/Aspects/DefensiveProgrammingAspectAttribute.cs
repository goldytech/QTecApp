using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTec.Hrms.Business.Aspects
{
    using PostSharp.Aspects;

    /// <summary>
    ///  Represents the Defensive programming aspect where you can check for Argument Null Exceptions
    /// </summary>
    [Serializable]
    public class DefensiveProgrammingAspectAttribute : OnMethodBoundaryAspect
    {
        /// <summary>
        /// Method executed <b>before</b> the body of methods to which this aspect is applied.
        /// </summary>
        /// <param name="args">Event arguments specifying which method
        /// is being executed, which are its arguments, and how should the execution continue
        /// after the execution of <see cref="M:PostSharp.Aspects.IOnMethodBoundaryAspect.OnEntry(PostSharp.Aspects.MethodExecutionArgs)" />.</param>
        public override void OnEntry(MethodExecutionArgs args)
        {
            var methodParams = args.Method.GetParameters();
            var arguments = args.Arguments;
            for (var i = 0; i < arguments.Count; i++)
            {
                if (arguments[i] == null)
                {
                    throw new ArgumentNullException(methodParams[i].Name);
                }

                if (arguments[i] is int && (int)arguments[i] < 0)
                {
                    throw new ArgumentException(
                        string.Format("{0} parameter cannot have value < 0", methodParams[i].Name));
                }
            }
            base.OnEntry(args);
        }
        
    }
}
