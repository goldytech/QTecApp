namespace QTec.Hrms.Business.Utils
{
    using System.Collections.Generic;
    using System.Text;

    public static class ValidationResultsToStringExtension
    {
      public static string ToErrorMessage(this IList<string> errorsList)
      {
          var sb = new StringBuilder();
          foreach (var error in errorsList)
          {
              // TODO use <ul> for better display
              sb.Append("<br/>");
              sb.Append(error);
          }

          return sb.ToString();
      }
    }
}
