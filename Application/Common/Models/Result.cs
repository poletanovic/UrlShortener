using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class Result
    {
        public bool Succeeded { get; set; }
        public string[] Errors { get; set; }

        public Tuple<string, object> RetVal { get; set; }

        public Result(bool succeeded, IEnumerable<string> errors, Tuple<string, object> retVal)
        {
            Succeeded = succeeded;
            Errors = errors.ToArray();
            RetVal = retVal;
        }

        public static Result Success(Tuple<string, object> retVal = null)
        {
            return new Result(true, new string[] { }, retVal);
        }

        public static Result Failure(IEnumerable<string> errors)
        {
            return new Result(false, errors, null);
        }
    }
}
