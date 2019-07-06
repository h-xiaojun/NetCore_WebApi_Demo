using PDM.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PDM.AppCore.Attributes
{
    /// <summary>
    /// 异常 过滤器
    /// 暂时用这个试试
    /// </summary>
    public class ExceptionFilterAttribute : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.ExceptionHandled == false)
            {
                //记录异常详细信息。这里入数据库？
                //......
                //返回500错误信息
                context.Result = new ObjectResult(Result.Fail(StatusCodes.Status500InternalServerError,context.Exception.Message));
            }
            context.ExceptionHandled = true;
        }

        public Task OnExceptionAsync(ExceptionContext context)
        {
            OnException(context);
            return Task.CompletedTask;
        }
    }
}
