using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PDM.Models;

namespace PDM.AppCore.Attributes
{
    /// <summary>
    /// 接口返回协议
    /// </summary>
    public class WebApiResultAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            //根据实际需求进行具体实现
            if (context.Result is ObjectResult)
            {
                var objectResult = context.Result as ObjectResult;
                if (objectResult.Value == null)
                    context.Result = new ObjectResult(Result.Fail(404));
                else
                    context.Result = new ObjectResult(Result.Successful(objectResult.Value));
            }
            else if (context.Result is EmptyResult)
                context.Result = new ObjectResult(Result.Fail(404));
            else if (context.Result is ContentResult)
                context.Result = new ObjectResult(Result.Successful((context.Result as ContentResult).Content));
            else if (context.Result is StatusCodeResult)
                context.Result = new ObjectResult(Result.Fail((context.Result as StatusCodeResult).StatusCode));
        }
    }
}
