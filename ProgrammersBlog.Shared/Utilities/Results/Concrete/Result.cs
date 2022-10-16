using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Utilities.Results.Concrete
{
    public class Result : IResult
    {
        public Result(ResultStatus resultStatus)
        {
            this.ResultStatus = resultStatus;
        }

        public Result(ResultStatus resultStatus, string message)
        {
            this.ResultStatus = resultStatus;
            this.Message = message;
        }

        public Result(ResultStatus resultStatus, string message, Exception exception)
        {
            this.ResultStatus = resultStatus;
            this.Message = message;
            this.Exception = exception;
        }

        public ResultStatus ResultStatus { get; }

        public string Message { get; }

        public Exception Exception { get; }
    }
}
